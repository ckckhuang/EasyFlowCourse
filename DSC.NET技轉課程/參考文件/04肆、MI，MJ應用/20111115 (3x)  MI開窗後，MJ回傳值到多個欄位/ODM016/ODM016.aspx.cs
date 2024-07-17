using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;

using tw.com.dsc.dscDotNet.kernelBasePage;
using tw.com.dsc.dscDotNet.common;
using tw.com.dsc.dscDotNet.db;
using tw.com.dsc.dscDotNet.dscData;
using tw.com.dsc.dscDotNet.dscWeb;
using tw.com.dsc.dscDotNet.dscWebControls;
using tw.com.dsc.dscDotNet.grid;
using tw.com.dsc.dscDotNet.tool;
using tw.com.dsc.dscDotNet.util;
//edit by teppy 2011/02/08 Start
using EasyFlowEngine.PlatformInterface;
using com.digiwin.net.ef.classlibrary;
//edit by teppy 2011/02/08 End

namespace tw.com.dsc.easyflowDotNet.forms
{
    /// <summary>
    /// ODM016 的摘要描述。
    /// </summary>
    public partial class ODM016 : tw.com.dsc.easyflowDotNet.kernelBasePage.EFBasePage
    {
        //edit by teppy 2011/02/08 Start
        #region 讀取 sysba 參數設定用物件
        /// <summary>
        /// 讀取 sysba 參數設定用物件
        /// </summary>
        private EF_CompanyParameterData _objEFPara;

        /// <summary>
        /// 讀取 sysba 參數設定用物件
        /// </summary>
        public EF_CompanyParameterData objEFPara
        {
            get
            {
                if (_objEFPara == null)
                {
                    _objEFPara = new EF_CompanyParameterData(PLATFORMIF.Company, true);
                }
                return _objEFPara;
            }
            set
            {
                _objEFPara = value;
            }
        }
        #endregion
        //edit by teppy 2011/02/08 End

        #region Page_Load
        /// <summary>
        /// Page_Load
        /// </summary>
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ODM016));
            UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
            string tLanguageType = tClass.Language;

            //多國語系
            this.TabStrip1.Items[0].Text = MultiLanguage.GetComment("FD", "ODM016", "TabStrip1", tLanguageType);
            this.odm016003.Title = MultiLanguage.GetComment("FD", "ODM016", "odm016003", tLanguageType);
            this.odm016004.Title = MultiLanguage.GetComment("FD", "ODM016", "odm016004", tLanguageType);
            this.odm016005.Title = MultiLanguage.GetComment("FD", "ODM016", "odm016005", tLanguageType);
            this.odm016006.Title = MultiLanguage.GetComment("FD", "ODM016", "odm016006", tLanguageType);
            this.odm016007.Title = MultiLanguage.GetComment("FD", "ODM016", "odm016007", tLanguageType);

            this.Title = MultiLanguage.GetComment("FD", "ODM016", "lblTitle", this.UserInfo.Language);

            #region 註冊使用者自訂檢查 Javascript

            if (base.FormStatus.ToString() == "CREATE")
            {
                string tParentScript = base.BtnCreateToolSendForm.Attributes["onclick"].ToString();
                tParentScript = "if (!CustomerSaveCheck('" + base.FormStatus.ToString() + "')) {return false; }" + tParentScript + "";
                base.BtnCreateToolSendForm.Attributes.Add("onclick", tParentScript);

                base.BtnCreateToolSendForm.Attributes["onclick"] = "SetCustomSubject();" + base.BtnCreateToolSendForm.Attributes["onclick"];
            }
            else if (base.FormStatus.ToString() == "APPROVE")
            {
                string tParentScript = base.BtnApproveToolDecide.Attributes["onclick"].ToString();
                tParentScript = "if (!CustomerSaveCheck('" + base.FormStatus.ToString() + "')) {return false; }" + tParentScript + "";
                base.BtnApproveToolDecide.Attributes.Add("onclick", tParentScript);

                tParentScript = base.BtnApproveToolAgree.Attributes["onclick"].ToString();
                tParentScript = "if (!CustomerSaveCheck('" + base.FormStatus.ToString() + "')) {return false; }" + tParentScript + "";
                base.BtnApproveToolAgree.Attributes.Add("onclick", tParentScript);

                tParentScript = base.BtnApproveToolDone.Attributes["onclick"].ToString();
                tParentScript = "if (!CustomerSaveCheck('" + base.FormStatus.ToString() + "')) {return false; }" + tParentScript + "";
                base.BtnApproveToolDone.Attributes.Add("onclick", tParentScript);
            }

            #endregion


            #region 自訂排序

            #endregion 自訂排序

            #region 限制修改欄位

            #endregion 限制修改欄位

            #region 增加初始設定

            #endregion 增加初始設定
        }
        #endregion

        #region Web Form 設計工具產生的程式碼
        /// <summary>
        /// OnInit
        /// </summary>
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 此為 ASP.NET Web Form 設計工具所需的呼叫。
            //
            base.registChildObj(Page);
            base.OnInit(e);
        }
        #endregion

        #region PreRender做的事
        /// <summary>
        /// Page_Prender
        /// </summary>
        protected override void Page_Prender(object sender, EventArgs e)
        {
            string tReturnValue = "";
            string tSQL = "";
            //ToolTip參數：Y:顯示ToolTip；N:不顯示
            string strToolTipParameter = objEFPara.EF_getCompanyParameterData("ToolTip").ToString();





            base.Page_Prender(sender, e);

            #region 自訂下拉選項

            #endregion
        }
        #endregion

        #region setBasicInfo , 設定表單的基本屬性
        /// <summary>
        /// 設定表單的基本屬性 (setBasicInfo)
        /// </summary>
        protected override void setBasicInfo()
        {
            // 作業代號
            this.TaskId = "ODM016";
            // 表單代號
            this.formID = "ODM016";
            // 有幾個單身 ex.0-->單檔, 1-->雙檔(一個單身), 2-->雙檔(二個單身)
            this.detailDepth = 0;
        }
        #endregion

        #region 屬性 (Property) 用來 Instance EasyFlow 流程引擎所需的元件
        //屬性 (Property), 基本上應該只會用到 get {} 方法, set {} 方法寫來備用的!
        private string _strProcID = null;
        private string _strConn = "";

        //EasyFlow 流程引擎元件宣告
        private PublicUTIL.DBProcessor _Processor = null;       //DB Transaction
        private EF2KWeb.Class1 _objWeb = null;
        private EF2KPublic.DataBase _objDB = null;
        private EF2KEngine.Class1 _objRE = null;

        /// <summary>
        /// get ProcessID
        /// </summary>
        protected string m_strProcID
        {
            get
            {
                if (_strProcID == null)
                {
                    _strProcID = m_objWeb.Init("Administrator", "EF.NET", 0);
                }
                return _strProcID;
            }
        }

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

        /// <summary>
        /// get/set EF2KPublic 物件實例
        /// </summary>
        protected EF2KPublic.DataBase m_objDB
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

        /// <summary>
        /// get/set PublicUTIL 物件實例 (DB Transaction)
        /// </summary>
        protected PublicUTIL.DBProcessor m_processor
        {
            get
            {
                if (_Processor == null)
                {
                    _Processor = new PublicUTIL.DBProcessor(m_strConn);
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

        /// <summary>
        /// Connenction String
        /// </summary>
        protected string m_strConn
        {
            get
            {
                if (string.IsNullOrEmpty(_strConn))
                {
                    DBCommand dbCommand = DscDBData.GetDataDBCommand();
                    _strConn = dbCommand.DBAccess.ConnString.ToString().Trim();
                    dbCommand = null;
                }
                return _strConn;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                _strConn = value;
            }
        }
        #endregion

        #region AjaxMethod()
        #region GetEmployeeId
        /// <summary>
        /// 取得員工 ID
        /// </summary>
        /// <returns>回傳員工 ID(string)</returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetEmployeeId()
        {
            return this.UserInfo.EmployeeId.ToString().Trim();
        }
        #endregion

        #region GetLoginName
        /// <summary>
        /// 取得登入者員工姓名
        /// </summary>
        /// <returns>回傳員工姓名(string)</returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetLoginName()
        {
            return this.UserInfo.LoginName.ToString().Trim();
        }
        #endregion

        #region GetAgentID
        /// <summary>
        /// 取得代理人員工 ID
        /// </summary>
        /// <returns>回傳代理人員工 ID(string)</returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetAgentID()
        {
            return base.StrAgentID.ToString().Trim();
        }
        #endregion

        #region GetAgentName
        /// <summary>
        /// 取得代理人姓名
        /// </summary>
        /// <returns>回傳代理人姓名(string)</returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetAgentName()
        {
            string tAgentName = "";
            UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
            string mCompany = tClass.Company;
            DBCommand dbCommand = DscDBData.GetDataDBCommand();
            DataTable tDt = new DataTable();
            StringBuilder tSql = new StringBuilder();
            tSql.AppendFormat("SELECT resak002 FROM {0}..resak AS resak ", mCompany);
            tSql.AppendFormat("WHERE resak001 = '{0}' ", base.StrAgentID.ToString().Trim());
            tDt = dbCommand.Query(tSql.ToString());
            if (tDt.Rows.Count > 0)
            {
                tAgentName = tDt.Rows[0]["resak002"].ToString().Trim();
            }
            return tAgentName;
        }
        #endregion

        #region GetDepartmentId
        /// <summary>
        /// 取得部門 ID
        /// </summary>
        /// <returns>回傳部門 ID(string)</returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetDepartmentId()
        {
            string tDeptID = "";
            UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
            tDeptID = m_objRE.FindEmplDeptID(tClass.EmployeeId.ToString().Trim(), m_strProcID);
            return tDeptID;
        }
        #endregion

        #region GetDepartmentName
        /// <summary>
        /// 取得部門名稱
        /// </summary>
        /// <returns>回傳部門名稱(string)</returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetDepartmentName()
        {
            string tDeptName = "";
            string tDeptID = "";
            UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
            tDeptID = m_objRE.FindEmplDeptID(tClass.EmployeeId.ToString().Trim(), m_strProcID);
            tDeptName = m_objRE.FindDeptName(tDeptID, m_strProcID);
            return tDeptName;
        }
        #endregion

        #region GetEFDBFieldValue
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetEFDBFieldValue(string pSql, string pFieldName)
        {
            string tResult = "";
            UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
            string mCompany = tClass.Company;
            DBCommand dbCommand = DscDBData.GetDataDBCommand();
            DataTable tDt = new DataTable();
            string tSql = pSql;
            tDt = dbCommand.Query(tSql);
            if (tDt.Rows.Count > 0)
            {
                tResult = tDt.Rows[0]["\"" + pFieldName + "\""].ToString().Trim();
            }
            return tResult;
        }
        #endregion

        #region GetOtherDBFieldValue
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string ajaxGetOtherDBFieldValue(string pDBType, string pSql, string pConn, string pFieldName)
        {
            string tResult = "";
            DataSet tDs = new DataSet();
            if (pDBType == "SqlServer")
            {
                SqlConnection tDbConnection = new SqlConnection(pConn);
                tDbConnection.Open();
                SqlDataAdapter tAdpt = new SqlDataAdapter(pSql, pConn);
                tAdpt.Fill(tDs, "Result");
            }
            else if (pDBType == "Oracle")
            {
                OracleConnection tDbConnection = new OracleConnection(pConn);
                tDbConnection.Open();
                OracleDataAdapter tAdpt = new OracleDataAdapter(pSql, pConn);
                tAdpt.Fill(tDs, "Result");
            }
            else if (pDBType == "OleDb")
            {
                OleDbConnection tDbConnection = new OleDbConnection(pConn);
                tDbConnection.Open();
                OleDbDataAdapter tAdpt = new OleDbDataAdapter(pSql, pConn);
                tAdpt.Fill(tDs, "Result");
            }
            else if (pDBType == "Odbc")
            {
                OdbcConnection tDbConnection = new OdbcConnection(pConn);
                tDbConnection.Open();
                OdbcDataAdapter tAdpt = new OdbcDataAdapter(pSql, pConn);
                tAdpt.Fill(tDs, "Result");
            }

            DataTable tDt = tDs.Tables["Result"];
            if (tDt != null)
            {
                if (tDt.Rows.Count > 0)
                {
                    tResult = tDt.Rows[0]["\"" + pFieldName + "\""].ToString().Trim();
                }
            }
            return tResult;
        }
        #endregion

        #region 自訂Ajax

        #endregion 自訂Ajax
        #endregion

        #region settingClientFunction , 註冊onclick、onblur、onchange事件
        /// <summary>
        /// 註冊onclick、onblur、onchange事件
        /// </summary>
        protected override void settingClientFunction()
        {
            //參數1.為原本的開窗方式  參數2.為樹狀的開窗
            string tWindowOpenStyle = objEFPara.EF_getCompanyParameterData("WindowOpenStyle").ToString();

            switch (tWindowOpenStyle)
            {
                case "2":
                    string tPara = "RESAK§10§" + this.UserInfo.DepartmentId + "§§§";
                    string tUrl = "../../_Common/EFDefOpen/F2MutipleFrame.aspx?open=single&value=";
                    odm016003.HtmImg.Attributes.Add("onclick", "if(!SingleSelectEmpl('" + tUrl + System.Web.HttpUtility.UrlEncode(tPara) + "','" + odm016003.TxtInput.ClientID + "','員工代號_odm016003')){return false;}");
                    break;
                default:
                    odm016003.HtmImg.Attributes.Add("onclick", MIMJUtil.getClickParams("MasterPage_MasterPageContent_odm016003_btn", "MasterPage_MasterPageContent_odm016003_txt", "S"));
                    break;
            }
            odm016003.TxtInput.Attributes.Add("onblur", MIMJUtil.getBlurParams("MasterPage_MasterPageContent_odm016003_txt", "員工代號_odm016003", "MasterPage_MasterPageContent_odm016003_txt"));
            odm016003.TxtInput.Attributes.Add("onchange", "AddtoHash('MasterPage_MasterPageContent_odm016003_txt')");

            switch (tWindowOpenStyle)
            {
                case "2":
                    string tPara = "RESAK§10§" + this.UserInfo.DepartmentId + "§§§";
                    string tUrl = "../../_Common/EFDefOpen/F2MutipleFrame.aspx?open=single&value=";
                    odm016004.HtmImg.Attributes.Add("onclick", "if(!SingleSelectEmpl('" + tUrl + System.Web.HttpUtility.UrlEncode(tPara) + "','" + odm016004.TxtInput.ClientID + "','員工代號_odm016004')){return false;}");
                    break;
                default:
                    odm016004.HtmImg.Attributes.Add("onclick", MIMJUtil.getClickParams("MasterPage_MasterPageContent_odm016004_btn", "MasterPage_MasterPageContent_odm016004_txt", "S"));
                    break;
            }
            odm016004.TxtInput.Attributes.Add("onblur", MIMJUtil.getBlurParams("MasterPage_MasterPageContent_odm016004_txt", "員工代號_odm016004", "MasterPage_MasterPageContent_odm016004_txt"));
            odm016004.TxtInput.Attributes.Add("onchange", "AddtoHash('MasterPage_MasterPageContent_odm016004_txt')");

            odm016005.HtmImg.Attributes.Add("onclick", MIMJUtil.getClickParams("MasterPage_MasterPageContent_odm016005_btn", "MasterPage_MasterPageContent_odm016005_txt", "S"));
            odm016005.TxtInput.Attributes.Add("onblur", MIMJUtil.getBlurParams("MasterPage_MasterPageContent_odm016005_txt", "部門代號_odm016005", "MasterPage_MasterPageContent_odm016005_txt"));
            odm016005.TxtInput.Attributes.Add("onchange", "AddtoHash('MasterPage_MasterPageContent_odm016005_txt')");


        }//settingClientFunction結尾

        /// <summary>
        /// %%必填%%
        /// </summary>
        /// <param name="pMiMjManager"></param>
        protected override void buildMiMjManager(Hashtable pMiMjManager)
        {
            //IsStoredMIMJ
            if (FormStatus == EFFormStatus.CREATE)
            {
                pMiMjManager.Add("odm016003_0", odm016003);
                pMiMjManager.Add("odm016004_0", odm016004);
                pMiMjManager.Add("odm016005_0", odm016005);

            }
        }
        #endregion

        #region SetDefaultValue , 設定表單欄位的初始值
        protected override void SetDefaultValue(Hashtable defalutHash)
        {

            defalutHash.Add("odm016001", this.formID);
            defalutHash.Add("odm016002", this.SheetNo);
        }

        //草稿儲存後要將主旨清除
        protected override void AfterCreateToolSaveForm()
        {
            base.TxtCreateToolSubject.Text = String.Empty;
        }

        #endregion

        #region DB 相關 Method
        #region 取得EasyFlow資料庫欄位(1欄位)
        /// <summary>
        /// 取得EasyFlow資料庫欄位(1欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pValue">欄位 ID</param>
        /// <returns>欄位值</returns>
        public string getEasyFlowDataFieldValue(string pSQLString, string pValue)
        {
            string tResult = "";
            try
            {
                UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
                DBCommand dbCommand = DscDBData.GetDataDBCommand();
                //2010/12/27:3.2.1.15:hiro:Q00-20101227002:修正下拉選單預設值中包含「+」、「-」字元，無法新增表單↓
                //pSQLString = pSQLString.ToLower().Replace("from", "from " + tClass.Company.ToString().Trim() + "..");
                bool bHaveTwinSpace = true;
                while (bHaveTwinSpace)
                {
                    if (pSQLString.IndexOf("  ") != -1 || pSQLString.IndexOf("\r\n") != -1)
                    {
                        pSQLString = pSQLString.Replace("\r\n", " ").Replace("  ", " ");
                    }
                    else
                    {
                        bHaveTwinSpace = false;
                    }
                }
                int intFromPosition = pSQLString.ToLower().IndexOf("from");
                pSQLString = pSQLString.Substring(0, intFromPosition) + "from " + tClass.Company.ToString().Trim() + ".." + pSQLString.Substring(intFromPosition + 5);
                //2010/12/27:3.2.1.15:hiro:Q00-20101227002:修正下拉選單預設值中包含「+」、「-」字元，無法新增表單↑
                DataTable tDt = dbCommand.Query(pSQLString);
                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        tResult = tDt.Rows[0]["" + pValue + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得EasyFlow資料庫欄位(2欄位)
        /// <summary>
        /// 取得EasyFlow資料庫欄位(2欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pValue">欄位 ID</param>
        /// <param name="pText">欄位 ID</param>
        /// <returns>欄位值(以 § 分隔)</returns>
        public string createEasyFlowDataTable(string pSQLString, string pValue, string pText)
        {
            string tResult = "";
            try
            {
                UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
                DBCommand dbCommand = DscDBData.GetDataDBCommand();
                //2010/12/27:3.2.1.15:hiro:Q00-20101227002:修正下拉選單預設值中包含「+」、「-」字元，無法新增表單↓
                //pSQLString = pSQLString.ToLower().Replace("from ", "from " + tClass.Company.ToString().Trim() + "..");
                bool bHaveTwinSpace = true;
                while (bHaveTwinSpace)
                {
                    if (pSQLString.IndexOf("  ") != -1 || pSQLString.IndexOf("\r\n") != -1)
                    {
                        pSQLString = pSQLString.Replace("\r\n", " ").Replace("  ", " ");
                    }
                    else
                    {
                        bHaveTwinSpace = false;
                    }
                }
                int intFromPosition = pSQLString.ToLower().IndexOf("from");
                pSQLString = pSQLString.Substring(0, intFromPosition) + "from " + tClass.Company.ToString().Trim() + ".." + pSQLString.Substring(intFromPosition + 5);
                //2010/12/27:3.2.1.15:hiro:Q00-20101227002:修正下拉選單預設值中包含「+」、「-」字元，無法新增表單↑

                DataTable tDt = dbCommand.Query(pSQLString);
                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        if (i != tDt.Rows.Count - 1)
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim() + "§";
                        else
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得EasyFlow資料庫欄位自訂連線字串(1欄位)
        /// <summary>
        /// 取得EasyFlow資料庫欄位自訂連線字串(1欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <returns>欄位值</returns>
        public string getSQLSERVERDataField(string pSQLString, string pConn, string pValue)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                SqlConnection tDbConnection = new SqlConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                SqlDataAdapter tAdpt = new SqlDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出
                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        tResult = tDt.Rows[0]["" + pValue + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得EasyFlow資料庫欄位自訂連線字串(2欄位)
        /// <summary>
        /// 取得EasyFlow資料庫欄位自訂連線字串(2欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <param name="pText">欄位 ID</param>
        /// <returns>欄位值(以 § 分隔)</returns>
        public string createSQLSERVERDataTable(string pSQLString, string pConn, string pValue, string pText)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                SqlConnection tDbConnection = new SqlConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                SqlDataAdapter tAdpt = new SqlDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出

                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        if (i != tDt.Rows.Count - 1)
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim() + "§";
                        else
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得Oracle資料庫(1欄位)
        /// <summary>
        /// 取得Oracle資料庫欄位(1欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <returns>欄位值</returns>
        public string getOracleDataField(string pSQLString, string pConn, string pValue)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                OracleConnection tDbConnection = new OracleConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                OracleDataAdapter tAdpt = new OracleDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出

                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        tResult = tDt.Rows[0]["" + pValue + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得Oracle資料庫(2欄位)
        /// <summary>
        /// 取得Oracle資料庫欄位(2欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <param name="pText">欄位 ID</param>
        /// <returns>欄位值(以 § 分隔)</returns>
        public string createOracleDataTable(string pSQLString, string pConn, string pValue, string pText)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                OracleConnection tDbConnection = new OracleConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                OracleDataAdapter tAdpt = new OracleDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出

                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        if (i != tDt.Rows.Count - 1)
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim() + "§";
                        else
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得Access資料庫欄位(1欄位)
        /// <summary>
        /// 取得Access資料庫欄位(1欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <returns>欄位值</returns>
        public string getAccessDataField(string pSQLString, string pConn, string pValue)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                OleDbConnection tDbConnection = new OleDbConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                OleDbDataAdapter tAdpt = new OleDbDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出
                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        tResult = tDt.Rows[0]["" + pValue + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得Access資料庫欄位(2欄位)
        /// <summary>
        /// 取得Access資料庫欄位(2欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <param name="pText">欄位 ID</param>
        /// <returns>欄位值(以 § 分隔)</returns>
        public string createAccessDataTable(string pSQLString, string pConn, string pValue, string pText)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                OleDbConnection tDbConnection = new OleDbConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                OleDbDataAdapter tAdpt = new OleDbDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出

                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        if (i != tDt.Rows.Count - 1)
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim() + "§";
                        else
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得ODBC資料庫欄位(1欄位)
        /// <summary>
        /// 取得ODBC資料庫欄位(1欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <returns>欄位值</returns>
        public string getODBCDataField(string pSQLString, string pConn, string pValue)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                OdbcConnection tDbConnection = new OdbcConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                OdbcDataAdapter tAdpt = new OdbcDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出

                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        tResult = tDt.Rows[0]["" + pValue + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion

        #region 取得ODBC資料庫欄位(2欄位)
        /// <summary>
        /// 取得ODBC資料庫欄位(2欄位)
        /// </summary>
        /// <param name="pSQLString">SQL Command</param>
        /// <param name="pConn">連線字串</param>
        /// <param name="pValue">欄位 ID</param>
        /// <param name="pText">欄位 ID</param>
        /// <returns>欄位值(以 § 分隔)</returns>
        public string createODBCDataTable(string pSQLString, string pConn, string pValue, string pText)
        {
            string tResult = "";
            try
            {
                DataSet tDs = new DataSet();
                OdbcConnection tDbConnection = new OdbcConnection(pConn);//來源資料庫連線資訊
                tDbConnection.Open();
                OdbcDataAdapter tAdpt = new OdbcDataAdapter(pSQLString, pConn);//來源資料表配接器
                tAdpt.Fill(tDs, "Result");
                DataTable tDt = tDs.Tables["Result"];//離線來源資料"表"生出

                if (tDt != null)
                {
                    for (int i = 0; i < tDt.Rows.Count; i++)
                    {
                        if (i != tDt.Rows.Count - 1)
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim() + "§";
                        else
                            tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return tResult;
        }
        #endregion
        #endregion

        #region createSelectItemFromDB 產生下拉式選項的值
        /// <summary>
        /// 產生下拉式選項的值
        /// </summary>
        /// <param name="pReturnValue">要產生的選項字串</param>
        /// <param name="pDDL">DropDownList 控制項 ID</param>
        /// <returns>true=成功; false=失敗</returns>
        public bool createSelectItemFromDB(string pReturnValue, DscDropDownList pDDL)
        {
            bool tRet = false;
            string[] temptArray = pReturnValue.Split('§');
            string[] tArray;
            string tValue = "";
            string tText = "";
            int iCount = temptArray.Length;
            ListItem tList = null;
            try
            {
                for (int i = 0; i < temptArray.Length; i++)
                {
                    tArray = temptArray[i].Split('Φ');
                    tValue = tArray[0].Trim();  //Value (內存)
                    tText = tArray[1].Trim();   //Text  (外顯)
                    if (!string.IsNullOrEmpty(tValue))
                    {
                        tList = new ListItem(tText, tValue);
                        pDDL.Items.Add(tList);
                    }
                }
                tRet = true;
            }
            catch (Exception e)
            {
                tRet = false;
            }
            return tRet;
        }
        #endregion

        #region ReGetCondValue , 設定條件欄位陣列

        protected override void ReGetCondValue(object[,] pAryCondValue)
        {
            string tValue = string.Empty;
            string tTemp = string.Empty;
            double tDbl = 0;

            base.ReGetCondValue(pAryCondValue);
        }

        #endregion

        #region 重設表單代理人, 表單關係人

        //重設表單代理人
        protected override string ReGetAgentID()
        {
            return base.AryFormProperty.Filler.ToString().Trim(); ;
        }

        //重設表單關係人
        protected override string ReGetParserRoleID()
        {
            return base.AryFormProperty.Filler.ToString().Trim(); ;
        }

        #endregion




        protected override void BeforePrint(ref string pReport, ref string pReportID, ref string pWhere, ref string pOrder, ref string pReportDirectory)
        {
            pReport = "ODM016";
            pReportID = "ODM016_02";//憑證式
            pWhere = "AND (odm016001='" + this.formID + "') AND (odm016002='" + this.SheetNo + "')";
            pReportDirectory = "ODM016";
            base.BeforePrint(ref pReportID, ref pWhere, ref pOrder, ref pOrder, ref pReportDirectory);
        }


    }
}
