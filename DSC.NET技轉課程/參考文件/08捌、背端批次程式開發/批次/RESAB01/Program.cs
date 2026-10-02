#region 修改歷程
//^_^ 20150316 edit by 01477 weiti 批次檔範本，個案站台的 web.config appSettings 必需要加入 <add key="EFCompany" value="公司別資料庫名稱" />
//^_^ 20150330 edit by 01477 weiti 批次加入調用EFNETService的元件OEM_EFWS.dll
//^_^ 20171006 edit by 07277 yujie 發送mail
//^_^ 20171115 edit by 01477 weiti 加入此程式同時間只能被開啟一次的控管
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using tw.com.dsc.Encryption;
using System.Data;
using PublicUTIL;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Configuration;
using System.Reflection;
using System.Diagnostics;
using EF2KData;
using System.Collections;
using com.digiwin.net.ef.classlibrary;
using tw.com.dsc.dscDotNet.db;
using tw.com.dsc.dscDotNet.dscData;
using EF2KEFormUTL;
using System.Threading;

namespace OEM
{
    #region Progaram Class (進入點 Class)

    /// <summary>
    /// Progaram Class (進入點 Class)
    /// </summary>
    static class Program
    {
        #region 全域變數

        #region 是否只能開啟一次

        public static bool gOnlyone = true;

        #endregion

        #region 站台名稱

        public static string _gSiteName = string.Empty;

        /// <summary>
        /// 站台名稱
        /// </summary>
        public static string gSiteName
        {
            get
            {
                if (string.IsNullOrEmpty(_gSiteName))
                {
                    _gSiteName = "EFNET";
                }

                return _gSiteName;
            }
            set
            {
                _gSiteName = value;
            }
        }

        #endregion

        #region 公司別

        public static string _gCompany = string.Empty;

        /// <summary>
        /// 公司別
        /// </summary>
        public static string gCompany
        {
            get
            {
                if (string.IsNullOrEmpty(_gCompany))
                {
                    _gCompany = "EFNETDB";
                }

                return _gCompany;
            }
            set
            {
                _gCompany = value;
            }
        }

        #endregion        

        #endregion

        #region 應用程式的主要進入點

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)//string[] args
        {

            #region //^_^ 20171115 edit by 01477 weiti 此程式同時間只能被開啟一次的控管
            if (gOnlyone)//啟用同時間只能開啟一次
            {
                try
                {
                    //取得此process的名稱
                    String name = Process.GetCurrentProcess().ProcessName;
                    //取得所有與目前process名稱相同的process
                    Process[] ps = Process.GetProcessesByName(name);
                    //ps.Length > 1 表示此proces以重複執行
                    if (ps.Length > 1)
                    {
                        System.Environment.Exit(2);
                    }
                }
                catch (Exception ex) { }
            }
            #endregion


            RESAB01 objAuto = null;

            #region 檢查傳入參數

            //正式用↓
            if (args.Length == 2)
            {
                gSiteName = args[0];
                gCompany = args[1];
            }
            else
            {
                //throw new Exception("傳入參數個數錯誤!");
                gSiteName = "EFNET";
                gCompany = "EFNETDB";
            }
            //正式用↑

            ////測試用↓
            //gSiteName = "EFNET";
            //gCompany = "EFNETDB";
            ////測試用↑
            #endregion

            //New RESAB01 Class
            objAuto = new RESAB01(gSiteName, gCompany);

            //寫入設定檔
            objAuto.writeAppConfig();

            //若設定檔第一次執行不存在 Copy 到執行目錄後重啟應用程式
            if (!objAuto.gFileIsExists)
            {
                //重啟程式
                Application.Restart();
            }
            else
            {
                //執行程式
                objAuto.Run();
            }
        }

        #endregion
    }

    #endregion

    #region RESAB01 Class (程式邏輯 Class)

    /// <summary>
    /// OEMISOAutoSendForm Class (程式邏輯 Class)
    /// </summary>
    public class RESAB01
    {
        #region 全域變數

        #region  紀錄Log資訊
        StringBuilder tLog = new StringBuilder();
        #endregion

        #region 判斷是否交易成功
        private bool bRes = false;
        #endregion

        #region 站台名稱

        /// <summary>
        /// 站台名稱
        /// </summary>
        private string gSiteName = string.Empty;

        #endregion

        #region 公司別

        private string gCompany = string.Empty;

        #endregion

        #region 主 Table 名稱

        /// <summary>
        /// 主 Table 名稱
        /// </summary>
        private string gWriteToTable = string.Empty;

        #endregion

        #region 資料庫連線字串

        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        private string gStrConn = string.Empty;

        #endregion

        #region IISManager

        /// <summary>
        /// IISManager
        /// </summary>
        com.digiwin.net.ef.IISManager.IISManager iisMag = null;

        #endregion

        #region Mapping List

        /// <summary>
        /// Mapping List
        /// </summary>
        List<KeyValuePair<string, string>> gMapping = new List<KeyValuePair<string, string>>();

        #endregion

        #region DataSet (resta)

        DataSet gDsResta = null;

        #endregion

        #region Condition List

        /// <summary>
        /// Condition List
        /// </summary>
        List<KeyValuePair<string, string>> gCond = new List<KeyValuePair<string, string>>();

        #endregion

        #region 存放找出來要執行的那一筆排程

        /// <summary>
        /// 用來存放找出來要執行的那一筆排程
        /// </summary>
        DataSet tDsRes = null;

        #endregion

        #region 讀取 sysba 參數設定用物件
        /// <summary>
        /// 讀取 sysba 參數設定用物件
        /// </summary>
        private  EF_CompanyParameterData _objEFPara;

        /// <summary>
        /// 讀取 sysba 參數設定用物件
        /// </summary>
        public  EF_CompanyParameterData objEFPara
        {
            get
            {
                if (_objEFPara == null)
                {
                    _objEFPara = new EF_CompanyParameterData(gCompany, true);
                }
                return _objEFPara;
            }
            set
            {
                _objEFPara = value;
            }
        }
        #endregion

        #region mail發送元件 //^_^ 20171006 edit by 07277 yujie↓ UTL_PublicProcess
        public UTL_PublicProcess _UTL;
        public UTL_PublicProcess tUTL
        {
            get
            {
                if (_UTL == null)
                {
                    _UTL = new UTL_PublicProcess(m_processor);
                }
                return _UTL;
            }
            set
            {
                _UTL = value;
            }
        }

        #endregion

        #endregion

        #region 屬性 (Property) 用來 Instance 一些必要元件

        #region get ProcessID

        private string _strProcID = string.Empty;

        /// <summary>
        /// get ProcessID
        /// </summary>
        protected string m_strProcID
        {
            get
            {
                if (_strProcID == null || _strProcID == "")
                {
                    _strProcID = m_objWeb.Init("Administrator", "EFNET0080", 0);
                }
                return _strProcID;
            }
        }

        #endregion

        #region get/set EF2KWeb 物件實例

        private EF2KWeb.Class1 _objWeb = null;

        /// <summary>
        /// get/set EF2KWeb 物件實例
        /// </summary>
        protected EF2KWeb.Class1 m_objWeb
        {
            get
            {
                if (_objWeb == null)
                {
                    _objWeb = new EF2KWeb.Class1();
                }
                return _objWeb;
            }
            set
            {
                if (_objWeb == value)
                    return;
                _objWeb = value;
            }
        }

        #endregion

        #region get/set EF2KPublic 物件實例

        private EF2KPublic.DataBase _objDB = null;

        /// <summary>
        /// get/set EF2KPublic 物件實例
        /// </summary>
        public EF2KPublic.DataBase m_objDB
        {
            get
            {
                if (_objDB == null)
                {
                    _objDB = new EF2KPublic.DataBase(m_strProcID, m_processor);
                }
                return _objDB;
            }
            set
            {
                if (_objDB == value)
                {
                    return;
                }
                _objDB = value;
            }
        }

        #endregion

        #region get/set EF2KEngine 物件實例

        private EF2KEngine.Class1 _objRE = null;

        /// <summary>
        /// get/set EF2KEngine 物件實例
        /// </summary>
        protected EF2KEngine.Class1 m_objRE
        {
            get
            {
                if (_objRE == null)
                {
                    _objRE = new EF2KEngine.Class1(m_strProcID, m_processor);
                }
                return _objRE;
            }
            set
            {
                if (_objRE == value)
                {
                    return;
                }
                _objRE = value;
            }
        }

        #endregion

        #region get/set PublicUTIL 物件實例 (DB Transaction)

        private PublicUTIL.DBProcessor _Processor = null;

        /// <summary>
        /// get/set PublicUTIL 物件實例 (DB Transaction)
        /// </summary>
        protected PublicUTIL.DBProcessor m_processor
        {
            get
            {
                if (_Processor == null)
                {
                    if (string.IsNullOrEmpty(gStrConn))
                    {
                        gStrConn = GetConnenction();
                        _Processor = new PublicUTIL.DBProcessor(gStrConn);
                    }
                }
                return _Processor;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                _Processor = value;
            }
        }

        #endregion

        #region get/set EF2KRS 物件實例

        private EF2KRS.Server1 _objRS = null;

        /// <summary>
        /// get/set EF2KRS 物件實例
        /// </summary>
        protected EF2KRS.Server1 m_objRS
        {
            get
            {
                if (_objRS == null)
                {
                    _objRS = new EF2KRS.Server1(m_strProcID, m_processor);
                }
                return _objRS;
            }
            set
            {
                if (_objRS == value)
                {
                    return;
                }
                _objRS = value;
            }
        }

        #endregion

        #region get/set EF2KEFormUTL 物件實例

        private EF2KEFormUTL.SendForm _objSendForm = null;

        /// <summary>
        /// get/set EF2KEFormUTL 物件實例
        /// </summary>
        protected EF2KEFormUTL.SendForm m_objSendForm
        {
            get
            {
                if (_objSendForm == null)
                {
                    _objSendForm = new EF2KEFormUTL.SendForm(m_processor);
                }
                return _objSendForm;
            }
            set
            {
                if (_objSendForm == value)
                {
                    return;
                }
                _objSendForm = value;
            }
        }

        #endregion

        #region get/set XmlDocument (web.config 讀成 XmlDocument 物件實例)

        private XmlDocument _objEFXML = null;

        /// <summary>
        /// get/set XmlDocument (web.config 讀成 XmlDocument 物件實例)
        /// </summary>
        protected XmlDocument m_objEFXML
        {
            get
            {
                if (_objEFXML == null)
                {
                    _objEFXML = getWebConfigXML();
                }
                return _objEFXML;
            }
            set
            {
                if (_objEFXML == value)
                {
                    return;
                }
                _objEFXML = value;
            }
        }

        #endregion

        #region 設定檔是否存在

        bool _FileIsExists = true;

        /// <summary>
        /// 設定檔是否存在 (true = 存在; false = 不存在. 預設 true)
        /// </summary>
        public bool gFileIsExists
        {
            get
            {
                return _FileIsExists;
            }
            set
            {
                _FileIsExists = value;
            }
        }

        #endregion

        #region logFileName LOG檔的檔名
        private string _logFileName;
        public string glogFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_logFileName))
                {

                    //取得元件所在路徑
                    string logPath = iisMag.GetDllPath();
                    _logFileName = logPath + "\\Logs\\";

                    if (Directory.Exists(_logFileName) == false)
                    {
                        Directory.CreateDirectory(_logFileName);
                    }

                    //log檔名
                    _logFileName = _logFileName + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                }
                return _logFileName;
            }
        }

        #endregion

        #region 調用EFNETService的物件 //^_^ 20150330 edit by 01477 weiti
        private OEM_EFWS.Class1 _OEM_EFWS;
        public OEM_EFWS.Class1 gOEM_EFWS
        {
            get
            {
                if (_OEM_EFWS == null)
                {
                    _OEM_EFWS = new OEM_EFWS.Class1(gCompany);
                }
                return _OEM_EFWS;
            }
        }

        #endregion

        #endregion

        #region 建構子

        /// <summary>
        /// 建構子
        /// </summary> 
        /// <param name="pSiteName">站台名稱</param>
        /// <param name="pCompany">公司別</param>
        public RESAB01(string pSiteName, string pCompany)
        {
            gSiteName = pSiteName;
            gCompany = pCompany;

            //產生 IISManager 物件實例,並取得目前 IIS 內所有虛擬目錄第一層的內容
            iisMag = new com.digiwin.net.ef.IISManager.IISManager("IIS://localhost/W3SVC/1/ROOT");

            //把指定虛擬目錄下的 web.config 寫到執行目錄下成為 OEMISOAutoSendForm.exe.config 檔案
            writeAppConfig();
        }

        #endregion

        #region private 方法 勿動

        #region 取得 EFNET AP 上 web.config 中加密後的連線字串

        /// <summary>
        /// 取得 EFNET AP 上 web.config 中加密後的連線字串
        /// </summary>
        /// <returns>回傳解密後的連線字串</returns>
        private string GetConnenction()
        {
            string xRetVal = string.Empty;
            string encryptedConnectionString = string.Empty;
            string initVector = string.Empty;
            string strKey = string.Empty;

            try
            {
                //取出 web.config 解密用資訊(加密後連線字串, vector 和 key)
                encryptedConnectionString = GetValue("SysDBConnString", m_objEFXML);
                initVector = GetValue("DSNInitVector", m_objEFXML);
                strKey = GetValue("DSNKey", m_objEFXML);

                //建構解密員, 指定triple DES, 並且把vector給它
                Decryptor dec = new Decryptor(EncryptionAlgorithm.TripleDes);
                dec.IV = Convert.FromBase64String(initVector);

                //解密
                byte[] plainText = dec.Decrypt(Convert.FromBase64String(encryptedConnectionString), Convert.FromBase64String(strKey));
                xRetVal = System.Text.Encoding.UTF8.GetString(plainText);

            }
            catch (Exception ex)
            {
                iisMag.WriteLog(glogFileName, "[GetConnenction] " + ex.Message);
            }

            return xRetVal;
        }

        #endregion

        #region 取得指定虛擬目錄的實體路徑

        /// <summary>
        /// 取得指定虛擬目錄的實體路徑
        /// </summary>
        /// <returns></returns>
        private string getIISPath()
        {
            string tRet = string.Empty;

            tRet = iisMag.GetVirtualDirectoryInfos(gSiteName.Trim()).Path;

            return tRet;
        }

        #endregion

        #region 取得 EFNET 站台所用的 web.config XmlDocument 物件

        /// <summary>
        /// 取得 EFNET 站台所用的 web.config XmlDocument 物件
        /// </summary>
        /// <returns>XmlDocument 物件</returns>
        private XmlDocument getWebConfigXML()
        {
            XmlDocument objXML = null;
            string tEFPath = string.Empty;

            try
            {
                objXML = new XmlDocument();

                //讀取 WebService 中 EasyFlow.NET 設定的路徑
                tEFPath = getIISPath();

                if (string.IsNullOrEmpty(tEFPath))
                {
                    //寫 Log
                    throw new Exception(string.Format("在指定虛擬目錄 [{0}] 中找不到 web.config 檔案!", gSiteName));
                }
                else
                {
                    tEFPath += "\\web.config";
                }

                //讀取 EFNET 站台下的 web.config (XmlDocument)
                objXML.Load(tEFPath);
            }
            catch (Exception ex)
            {
                iisMag.WriteLog(glogFileName,"[getWebConfigXML] " + ex.Message);
            }

            return objXML;
        }

        #endregion

        #region 讀取 XML 值

        /// <summary>
        /// 讀取 EFNET 的 web.config (appSettings 區段)
        /// </summary>
        /// <param name="key">讀取得 key</param>
        /// <param name="cfgDoc">web.config 的 XmlDocument 物件實例</param>
        /// <returns>回傳該 key 的設定值</returns>
        private string GetValue(string key, XmlDocument cfgDoc)
        {
            string xRetVal = string.Empty;

            try
            {
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(cfgDoc.NameTable);
                nsmgr.AddNamespace("RegisterName", cfgDoc.DocumentElement.NamespaceURI);
                string xpath = "//RegisterName:appSettings/RegisterName:add[@key = \"" + key + "\"]/@value";
                XmlNode node = cfgDoc.SelectSingleNode(xpath, nsmgr);
                xRetVal = ((node == null) ? "" : node.InnerText);
            }
            catch (Exception ex)
            {
                iisMag.WriteLog(glogFileName,"[GetValue] " + ex.Message);
            }

            return xRetVal;
        }

        /// <summary>
        /// 讀取 EFNET 的 web.config (system.web 區段)
        /// </summary>
        /// <param name="key">讀取得 key</param>
        /// <param name="cfgDoc">web.config 的 XmlDocument 物件實例</param>
        /// <returns>回傳該 key 的設定值</returns>
        private string GetValueBySysWeb(string key, XmlDocument cfgDoc)
        {
            string xRetVal = string.Empty;

            try
            {
                XmlNode node = cfgDoc.DocumentElement.SelectSingleNode("system.web").SelectSingleNode(key);
                xRetVal = ((node == null) ? "" : node.Attributes["maxRequestLength"].Value.Trim());
            }
            catch (Exception ex)
            {
                iisMag.WriteLog(glogFileName,"[GetValueBySysWeb] " + ex.Message);
            }

            return xRetVal;
        }

        #endregion

        #region 寫入 RESAB01.exe.config

        /// <summary>
        /// 寫入 RESAB01.exe.config
        /// </summary>
        /// <returns>
        /// true = 設定檔存在
        /// false = 設定檔不存在
        /// </returns>
        public void writeAppConfig()
        {
            string tFullPath = string.Empty;
            string tSourcePath = string.Empty;
            StringBuilder tXML = new StringBuilder();
            XmlNodeList tNodes = null;
            XmlDocument tWrXml = new XmlDocument();

            try
            {
                #region 讀取指定虛擬目錄下的 web.config

                //目前執行路徑內
                tSourcePath = iisMag.GetDllPath();

                //把 web.config 內的所有 add 抓出來
                tNodes = m_objEFXML.GetElementsByTagName("add");

                #region RESAB01.exe.config 所需的 XML 格式

                tXML.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                tXML.Append("<configuration>");
                tXML.Append("<appSettings>");
                foreach (XmlNode item in tNodes)
                {
                    if (item.Attributes[0].Name.ToLower() == "key")
                    {
                        tXML.AppendFormat("<add key=\"{0}\" value=\"{1}\" />", item.Attributes[0].Value, item.Attributes[1].Value);
                    }
                }
                tXML.Append("</appSettings>");
                tXML.Append("</configuration>");

                #endregion

                #endregion

                #region 寫出 RESAB01.exe.config 檔案

                //完整路徑
                tFullPath = string.Format("{0}\\{1}.exe.config", Application.StartupPath, ((Assembly.GetEntryAssembly()).GetName()).Name);

                //檔案不存在則建立
                if (!File.Exists(tFullPath))
                {
                    //設定檔不存在
                    gFileIsExists = false;

                    using (StreamWriter tSr = File.CreateText(tFullPath))
                    {
                        tSr.Close();
                    }
                }

                tWrXml.LoadXml(tXML.ToString());

                File.SetAttributes(tFullPath, FileAttributes.Normal);

                using (XmlTextWriter w = new XmlTextWriter(tFullPath, Encoding.UTF8))
                {
                    w.Formatting = Formatting.Indented;
                    tWrXml.WriteTo(w);
                    w.Flush();
                    w.Close();
                }

                //寫完後再 Copy 一份檔名為 web.config
                File.Copy(tFullPath, string.Format("{0}\\web.config", Application.StartupPath), true);

                #endregion
            }
            catch (Exception ex)
            {
                iisMag.WriteLog(glogFileName,"[writeAppConfig] " + ex.Message);
            }
        }

        #endregion                    

        #endregion
        
        #region 執行程序 PR 修改部分

        /// <summary>
        /// 執行程序
        /// </summary>
        public void Run()
        {
            StringBuilder sbLog = new StringBuilder();
            string AdminMailbox = objEFPara.EF_getCompanyParameterData("AdminMailbox");//取得單一寄件者

            try
            {
                //sbLog.AppendLine(DateTime.Now.ToString("yyyyMMdd HHmmss"));
            }
            catch (Exception ex)
            {
                sbLog.AppendLine("Error:" + ex.Message);
                //SendMail("批次執行失敗", ex.Message.ToString(), AdminMailbox, "");
            }
            finally
            {
                //寫 Log範例
                if (sbLog.Length > 0)
                {
                    iisMag.WriteLog(glogFileName, sbLog.ToString());
                }
            }

        }

        #endregion

        #region //^_^ 20171006 edit by 07277 yujie↓ 發mail(tSubject:主旨,tContent:內文,sender:送件者,sMailTo:收件者
        private void SendMail(string tSubject, string tContent, string sender, string sMailTo)
        {
            tUTL.m_SendEMail(sender, sMailTo, tSubject, tContent, m_strProcID);
            Thread.Sleep(1000);//Delay1秒，防止mailServer判定為駭客攻擊
        }
        #endregion

    }

    #endregion
}