using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace com.digiwin.net.ef.IISManager
{
    /// <summary>
    /// IISManager Class
    /// </summary>
    public class IISManager
    {
        public System.DirectoryServices.DirectoryEntry _root;
        public VirtualDirectories vDir;

        //建構子
        public IISManager(string strPath)
        {
            try
            {
                //若 strPath = "" ,則自動以 "IIS://localhost/W3SVC/1/ROOT" 帶入
                if (strPath == "")
                {
                    strPath = "IIS://localhost/W3SVC/1/ROOT";
                }

                this._root = new System.DirectoryServices.DirectoryEntry(strPath);
                this.vDir = GetVirDirs(this._root.Children);
            }
            catch (Exception ex)
            {
                //把錯誤寫入 log
                WriteLog(ex.Message.ToString());
            }
        }

        //取得 IIS 內所有虛擬目錄的設定值
        private VirtualDirectories GetVirDirs(System.DirectoryServices.DirectoryEntries des)
        {
            VirtualDirectories tmpdirs = new VirtualDirectories();
            foreach (System.DirectoryServices.DirectoryEntry de in des)
            {
                if (de.SchemaClassName == "IIsWebVirtualDir")
                {
                    //利用下列方法可以取出 IIS 虛擬目錄屬性
                    //foreach (System.DirectoryServices.PropertyValueCollection dp in de.Properties)
                    //{
                    //    //取出 IIS 虛擬目錄所有的屬性名稱
                    //    //dp.PropertyName;
                    //}

                    VirtualDirectory vd = new VirtualDirectory();
                    vd.Name = de.Name;
                    vd.AccessRead = (bool)de.Properties["AccessRead"][0];
                    vd.AccessExecute = (bool)de.Properties["AccessExecute"][0];
                    vd.AccessWrite = (bool)de.Properties["AccessWrite"][0];
                    vd.AnonymousUserName = (string)de.Properties["AnonymousUserName"][0];
                    vd.AnonymousUserPass = (string)de.Properties["AnonymousUserName"][0];
                    vd.AuthBasic = (bool)de.Properties["AuthBasic"][0];
                    vd.AuthNTLM = (bool)de.Properties["AuthNTLM"][0];
                    vd.ContentIndexed = (bool)de.Properties["ContentIndexed"][0];
                    vd.EnableDefaultDoc = (bool)de.Properties["EnableDefaultDoc"][0];
                    vd.EnableDirBrowsing = (bool)de.Properties["EnableDirBrowsing"][0];
                    vd.AccessSSL = (bool)de.Properties["AccessSSL"][0];
                    vd.AccessScript = (bool)de.Properties["AccessScript"][0];
                    vd.Path = (string)de.Properties["Path"][0];
                    vd.DefaultDoc = (string)de.Properties["DefaultDoc"][0];
                    tmpdirs.Add(vd.Name.ToUpper(), vd);                               //存入 HashTable 的 Key 都轉成大寫,避免區分大小寫而找不到
                }
            }
            return tmpdirs;
        }

        //取得某一個虛擬目錄的資料設定
        public VirtualDirectory GetVirtualDirectoryInfos(string strVirDir)
        {
            VirtualDirectory objReturn = null;
            //判斷所要取得的虛擬目錄是否存在
            if (vDir.Contains(strVirDir.ToUpper()))
            {
                objReturn = vDir.Find(strVirDir.ToUpper());
            }

            return objReturn;
        }

        /// <summary>
        /// 取得組件(Assembly)所在目錄
        /// </summary>
        /// <returns>路徑</returns>
        public string GetDllPath()
        {
            string strTmp;
            int i;
            int j;
            string logPath;

            logPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;	//取得組件路徑+組件名稱
            logPath = logPath.Substring(0, logPath.LastIndexOf("/"));                       //組件路徑

            //取出路徑,因為用 System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
            //取出的路會如 "file:///c:/inetpub/wwwroot/EFCRMService/bin"
            if (logPath.Substring(0, 4) == "file")
            {
                strTmp = logPath;
                i = logPath.LastIndexOf(":");
                j = logPath.Length;
                logPath = strTmp.Substring(i - 1, j - i + 1);
            }

            return logPath;
        }

        /// <summary>
        /// 寫 log
        /// </summary>
        /// <param name="strLog">訊息</param>
        public void WriteLog(string strLogFilePath ,string strLog)
        {          
            try
            {                               
                //寫入檔案
                using (System.IO.StreamWriter sw = new StreamWriter(strLogFilePath, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(strLog);
                    sw.WriteLine();                       //多寫一行空白
                    sw.Close();
                }
            }
            catch (System.UnauthorizedAccessException e)	//沒有寫入權限
            {
                Console.WriteLine(e.Message);
            }
            catch (System.Exception e)						//其它錯誤
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 寫 log
        /// </summary>
        /// <param name="strLog">訊息</param>
        private void WriteLog(string strLog)
        {
            string logPath, filePath;
            string logFileName = "";

            try
            {
                //取得元件所在路徑
                logPath = GetDllPath();

                filePath = logPath + "\\Logs";

                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(filePath);
                }

                //log檔名
                logFileName = filePath + "\\IISManager_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                //寫入檔案
                using (System.IO.StreamWriter sw = new StreamWriter(logFileName, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff"), strLog));
                    sw.WriteLine();                             //多寫一行空白
                    sw.Close();
                }

            }
            catch (System.UnauthorizedAccessException e)	//沒有寫入權限
            {
                Console.WriteLine(e.Message);
            }
            catch (System.Exception e)						//其它錯誤
            {
                Console.WriteLine(e.Message);
            }
        }

    }

    /// <summary>
    /// VirtualDirectory Class, 收集一些 IIS 設定資訊
    /// </summary>
    public class VirtualDirectory
    {
        private bool _read, _execute, _script, _ssl, _write, _authbasic, _authntlm, _indexed, _endirbrow, _endefaultdoc;
        private string _ausername, _auserpass, _name, _path;

        private string _defaultdoc;

        //建構子
        public VirtualDirectory()
        {
            SetValue();
        }

        //起始值
        private void SetValue()
        {
            _read = true;                                                                       //讀取
            _execute = false;                                                                   //執行
            _script = true;                                                                     //執行權限(script)
            _ssl = false;                                                                       //SSL
            _write = false;                                                                     //寫入
            _authbasic = false;                                                                 //基本驗證(使用純文字傳送密碼)
            _authntlm = true;                                                                   //NT驗證
            _indexed = true;                                                                    //編製這個資源的索引值
            _endirbrow = false;                                                                 //瀏覽目錄
            _endefaultdoc = true;                                                               //使用預設起始頁
            _defaultdoc = "default.htm,default.aspx,default.asp,index.htm";                     //預設起始頁
            _path = "C:\\";                                                                     //實體路徑
            _ausername = "IUSR_DEVE-SERVER";                                                    //匿名存取名稱
            _auserpass = "IUSR_DEVE-SERVER";                                                    //匿名存取密碼
            _name = "";                                                                         //虛擬目錄名稱
        }

        #region 定義屬性
        //IISVirtualDir太多屬性了，若有需要請自行增加。  
        public bool AccessRead
        {
            get { return _read; }
            set { _read = value; }
        }
        public bool AccessWrite
        {
            get { return _write; }
            set { _write = value; }
        }
        public bool AccessExecute
        {
            get { return _execute; }
            set { _execute = value; }
        }
        public bool AccessSSL
        {
            get { return _ssl; }
            set { _ssl = value; }
        }
        public bool AccessScript
        {
            get { return _script; }
            set { _script = value; }
        }
        public bool AuthBasic
        {
            get { return _authbasic; }
            set { _authbasic = value; }
        }
        public bool AuthNTLM
        {
            get { return _authntlm; }
            set { _authntlm = value; }
        }
        public bool ContentIndexed
        {
            get { return _indexed; }
            set { _indexed = value; }
        }
        public bool EnableDirBrowsing
        {
            get { return _endirbrow; }
            set { _endirbrow = value; }
        }
        public bool EnableDefaultDoc
        {
            get { return _endefaultdoc; }
            set { _endefaultdoc = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public string DefaultDoc
        {
            get { return _defaultdoc; }
            set { _defaultdoc = value; }
        }
        public string AnonymousUserName
        {
            get { return _ausername; }
            set { _ausername = value; }
        }
        public string AnonymousUserPass
        {
            get { return _auserpass; }
            set { _auserpass = value; }
        }

        #endregion

    }

    /// <summary>
    /// VirtualDirectories Class, 利用 Hashtable 來回傳一個虛擬目錄的一些基本 IIS 設定值
    /// </summary>
    public class VirtualDirectories : System.Collections.Hashtable
    {
        //建構子
        public VirtualDirectories()
        {
        }

        //找尋某一個虛擬目錄是否存在
        public VirtualDirectory Find(string strName)
        {
            return (VirtualDirectory)this[strName];
        }
    }


}
