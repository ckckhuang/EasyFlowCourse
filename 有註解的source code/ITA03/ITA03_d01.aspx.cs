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
//2013/02/04:3.5.1.48:hiro:S00-20120626008:雙檔表單簽核鈕(發單、准、同意、會辦)增加單身驗證功能↓
using System.Collections.Generic;
using System.Text.RegularExpressions;
//2013/02/04:3.5.1.48:hiro:S00-20120626008:雙檔表單簽核鈕(發單、准、同意、會辦)增加單身驗證功能↑

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
//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↓
using tw.com.dsc.easyflowDotNet.kernelBasePage.easyflowfunction;
//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↑
@UsingClass

namespace tw.com.dsc.easyflowDotNet.forms
{
	/// <summary>
	/// @BOID 的摘要描述。
	/// </summary>
	public partial class @BOID : @InheritClass
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

		#region EasyFlow Engine 物件宣告
		//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↓
		private EF2KEFormUTL.UTL_ShareFunction _objUTL_ShareFunc;
		protected EF2KEFormUTL.UTL_ShareFunction objUTL_ShareFunc
		{
			get
			{
				if (_objUTL_ShareFunc == null)
				{
					_objUTL_ShareFunc = new EF2KEFormUTL.UTL_ShareFunction(processor);
				}
				return _objUTL_ShareFunc;
			}
		}
		//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↑
		#endregion EasyFlow Engine 物件宣告

		#region Page_Load
		/// <summary>
		/// Page_Load
		/// </summary>
		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			AjaxPro.Utility.RegisterTypeForAjax(typeof(@BOID));
			UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
			string tLanguageType = tClass.Language;

			//多國語系
			this.Title= MultiLanguage.GetComment("FD","@BOID","lblTitle",this.UserInfo.Language);
@MutiLanguage

			#region 自訂排序
			@tTABOrder
			#endregion 自訂排序

			#region 限制修改欄位
@tFieldEnabled
			#endregion 限制修改欄位

			#region 增加初始設定
			@InitPageLoadScript
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

		#region Page_Prender做的事
		/// <summary>
		/// Page_Prender
		/// </summary>
		protected override void Page_Prender(object sender, EventArgs e)
		{
			string tReturnValue = "";
			string tSQL = "";
			#region 與管理程式共用Before Prender區段
			//ToolTip參數：Y:顯示ToolTip；N:不顯示
			string strToolTipParameter = objEFPara.EF_getCompanyParameterData("ToolTip").ToString();
			

			#endregion 與管理程式共用Before Prender區段

			base.Page_Prender(sender, e);

			#region 與管理程式共用After Prender區段
			
@ListboxOpenQueryChangeBackColor
			#endregion 與管理程式共用After Prender區段

			@UserJavascript

			#region 自訂下拉選項
			@tDDLSql
			#endregion 自訂下拉選項

			#region 增加初始設定(可判斷表單狀態)
@InitPagePrenderScript
			#endregion 增加初始設定(可判斷表單狀態)

			if (base.FormStatus.ToString() == "APPROVE" || base.FormStatus.ToString() == "DISPLAY")
			{
				#region 派送表單功能強化控制項
				@DispatchFormCSCode
				#endregion 派送表單功能強化控制項

				#region CmpCode公司組織控件，依公司組織過濾加簽、轉寄名單
				@CmpCodeCSCode
				#endregion CmpCode公司組織控件，依公司組織過濾加簽、轉寄名單
			}

			#region 自訂Page_Prender區塊
			@SetCustomCode_Page_Prender
			#endregion 自訂Page_Prender區塊
		}
		#endregion Page_Prender做的事

		#region setBasicInfo , 設定表單的基本屬性
		/// <summary>
		/// 設定表單的基本屬性 (setBasicInfo)
		/// </summary>
		protected override void setBasicInfo()
		{
			// 作業代號
			this.TaskId = "@BOID";
			// 表單代號
			this.formID = "@BOID";
			// 有幾個單身 ex.0-->單檔, 1-->雙檔(一個單身), 2-->雙檔(二個單身)
			this.detailDepth = @DetailNum;
		}
		#endregion setBasicInfo , 設定表單的基本屬性

		#region 屬性 (Property) 用來 Instance EasyFlow 流程引擎所需的元件
		//屬性 (Property), 基本上應該只會用到 get {} 方法, set {} 方法寫來備用的!
		private string _strProcID = null;
		private string _strConn = "";

		//EasyFlow 流程引擎元件宣告
		private PublicUTIL.DBProcessor _Processor = null;	   //DB Transaction
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
		#endregion 屬性 (Property) 用來 Instance EasyFlow 流程引擎所需的元件

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
		#endregion GetEmployeeId

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
		#endregion GetLoginName

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
		#endregion GetAgentID

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
		#endregion GetAgentName

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
		#endregion GetDepartmentId

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
		#endregion GetDepartmentName

		//2013/09/03:3.3.3.75:hiro:S00-20120320002:初始值設定增加填表人職等、填表人直屬主管、填表人主要部門職務、填表人主要部門職稱↓
		#region GetLevel
		/// <summary>
		/// 取得填表人職等
		/// </summary>
		/// <returns>回傳填表人職等代號</returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetLevelID()
		{
			string tReturnLevel = "";
			UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
			string tCompanyDB = tClass.Company;
			string tEmployeeID = tClass.EmployeeId.ToString().Trim();

			DBCommand dbCommand = DscDBData.GetDataDBCommand();
			DataTable dtRESAK = new DataTable();
			string strSQL = "SELECT resak006 from $EFNETDB$..resak where resak001='$EmplID$'";
			strSQL = strSQL.Replace("$EFNETDB$", tCompanyDB).Replace("$EmplID$", tEmployeeID);
			dtRESAK = dbCommand.Query(strSQL);
			if (dtRESAK.Rows.Count > 0)
			{
				tReturnLevel = dtRESAK.Rows[0]["resak006"].ToString().Trim();
			}
			return tReturnLevel;
		}
		#endregion GetLevel

		#region GetSupervisor
		/// <summary>
		/// 取得填表人直屬主管
		/// </summary>
		/// <returns>回傳填表人直屬主管ID</returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetSupervisorID()
		{
			string tReturnSupervisor = "";
			UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
			string tCompanyDB = tClass.Company;
			string tEmployeeID = tClass.EmployeeId.ToString().Trim();

			DBCommand dbCommand = DscDBData.GetDataDBCommand();
			DataTable dtRESAK = new DataTable();
			string strSQL = "SELECT resak013 from $EFNETDB$..resak where resak001='$EmplID$'";
			strSQL = strSQL.Replace("$EFNETDB$", tCompanyDB).Replace("$EmplID$", tEmployeeID);
			dtRESAK = dbCommand.Query(strSQL);
			if (dtRESAK.Rows.Count > 0)
			{
				tReturnSupervisor = dtRESAK.Rows[0]["resak013"].ToString().Trim();
			}
			return tReturnSupervisor;
		}
		#endregion GetSupervisor

		#region GetPosition
		/// <summary>
		/// 取得填表人主要部門職務
		/// </summary>
		/// <returns>回傳填表人主要部門職務代號</returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetPositionID()
		{
			string tReturnPosition = "";
			UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
			string tCompanyDB = tClass.Company;
			string tEmployeeID = tClass.EmployeeId.ToString().Trim();
			//主要部門代號
			string tDeptID = ajaxGetDepartmentId();

			DBCommand dbCommand = DscDBData.GetDataDBCommand();
			DataTable dtRESAN = new DataTable();
			string strSQL = "SELECT resan004 from $EFNETDB$..resan where resan003='$EmplID$' and resan001='$DeptID$' and resan070='Y'";
			strSQL = strSQL.Replace("$EFNETDB$", tCompanyDB).Replace("$EmplID$", tEmployeeID).Replace("$DeptID$", tDeptID);
			dtRESAN = dbCommand.Query(strSQL);
			if (dtRESAN.Rows.Count > 0)
			{
				tReturnPosition = dtRESAN.Rows[0]["resan004"].ToString().Trim();
			}
			return tReturnPosition;
		}
		#endregion GetPosition

		#region GetTitle
		/// <summary>
		/// 取得填表人主要部門職稱
		/// </summary>
		/// <returns>回傳填表人主要部門職稱代號</returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetTitleID()
		{
			string tReturnTitle = "";
			UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
			string tCompanyDB = tClass.Company;
			string tEmployeeID = tClass.EmployeeId.ToString().Trim();
			//主要部門代號
			string tDeptID = ajaxGetDepartmentId();

			DBCommand dbCommand = DscDBData.GetDataDBCommand();
			DataTable dtRESAN = new DataTable();
			string strSQL = "SELECT resan005 from $EFNETDB$..resan where resan003='$EmplID$' and resan001='$DeptID$' and resan070='Y'";
			strSQL = strSQL.Replace("$EFNETDB$", tCompanyDB).Replace("$EmplID$", tEmployeeID).Replace("$DeptID$", tDeptID);
			dtRESAN = dbCommand.Query(strSQL);
			if (dtRESAN.Rows.Count > 0)
			{
				tReturnTitle = dtRESAN.Rows[0]["resan005"].ToString().Trim();
			}
			return tReturnTitle;
		}
		#endregion GetTitle
		//2013/09/03:3.3.3.75:hiro:S00-20120320002:初始值設定增加填表人職等、填表人直屬主管、填表人主要部門職務、填表人主要部門職稱↑

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
				tResult = tDt.Rows[0]["\""+pFieldName+"\""].ToString().Trim();
			}
			return tResult;
		}
		#endregion GetEFDBFieldValue

		#region GetOtherDBFieldValue
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetOtherDBFieldValue(string pDBType,string pSql,string pConn,string pFieldName)
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
				OracleConnection tDbConnection = new OracleConnection (pConn);
				tDbConnection.Open();
				OracleDataAdapter tAdpt = new OracleDataAdapter (pSql, pConn);
				tAdpt.Fill(tDs, "Result");
			}
			else if (pDBType == "OleDb")
			{
				OleDbConnection tDbConnection = new OleDbConnection (pConn);
				tDbConnection.Open();
				OleDbDataAdapter tAdpt = new OleDbDataAdapter (pSql, pConn);
				tAdpt.Fill(tDs, "Result");
			}
			else if (pDBType == "Odbc")
			{
				OdbcConnection tDbConnection = new OdbcConnection (pConn);
				tDbConnection.Open();
				OdbcDataAdapter tAdpt = new OdbcDataAdapter (pSql, pConn);
				tAdpt.Fill(tDs, "Result");
			}

			DataTable tDt = tDs.Tables["Result"];
			if (tDt != null)
			{
				if (tDt.Rows.Count > 0)
				{
					tResult = tDt.Rows[0]["\""+pFieldName+"\""].ToString().Trim();
				}
			}
			return tResult;
		}
		#endregion GetOtherDBFieldValue

		#region 取得日期時間相差天數、小時
		//2012/11/28:3.5.1.34:hiro:S00-20120321002:1.增加日期、日期時間計算功能。↓
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetDiffDateTimeValue(string pStartDateTime,string pEndDateTime,string pCompareType)
		{
			string tReturn="0";
			try{
				if(pCompareType=="yyyyMMdd"){
					DateTime StartDateTime = DateTime.ParseExact(pStartDateTime, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
					DateTime EndDateTime = DateTime.ParseExact(pEndDateTime, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
					TimeSpan DifferenceTime = EndDateTime.Subtract(StartDateTime); //日期相減
					//2013/04/16:3.5.1.60:hiro:S00-20130329001:修改日期計算，天數相減計算結果加1↓
					//tReturn = DifferenceTime.TotalDays.ToString();
					tReturn = (DifferenceTime.TotalDays+1).ToString();
					//2013/04/16:3.5.1.60:hiro:S00-20130329001:修改日期計算，天數相減計算結果加1↑
				}
				else if(pCompareType=="HHmm"){
					DateTime StartDateTime = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd")+pStartDateTime+"00", "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
					DateTime EndDateTime = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd")+pEndDateTime+"00", "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
					TimeSpan DifferenceTime = EndDateTime.Subtract(StartDateTime); //日期相減
					tReturn = DifferenceTime.TotalHours.ToString();
				}
			}
			catch{
				tReturn="0";
			}
			return tReturn;
		}
		//2012/11/28:3.5.1.34:hiro:S00-20120321002:1.增加日期、日期時間計算功能。↑
		#endregion 取得日期時間相差天數、小時

		#region 簽核按鈕檢查單身驗證欄位
		//2013/02/04:3.5.1.48:hiro:S00-20120626008:雙檔表單簽核鈕(發單、准、同意、會辦)增加單身驗證功能↓
		/// <summary>
		/// 簽核按鈕檢查單身驗證欄位
		/// </summary>
		/// <param name="pFormId">表單代號</param>
		/// <param name="pUniversalId">UniversalId</param>
		/// <returns>
		/// 空字串 = 驗證成功
		/// 若非空字串 = 驗證失敗, 而該資訊為回應訊息
		/// </returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxCheckAllDetailDataVerify(string pFormId, string pUniversalId)
		{
			string tRetMsg = string.Empty;
			UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
			string tLanguageType = tClass.Language;

			//欄位不允許空白
			string tFieldNotFilledMsg = MultiLanguage.GetComment("PSMSG", "Validation", "RequriedFieldNotFilled", tLanguageType);
			//輸入的資料不是數值
			string tNotNumberSTRErrMsg = MultiLanguage.GetComment("PSMSG", "Validation", "NotNumberSTRErrMsg", tLanguageType);
			//輸入的資料不符合 int 數值格式
			string tIntErrMsg = MultiLanguage.GetComment("PSMSG", "Validation", "IntErrMsg", tLanguageType);
			//輸入的資料不符合 float 數值格式
			string tFloatErrMsg = MultiLanguage.GetComment("PSMSG", "Validation", "FloatErrMsg", tLanguageType);
			//輸入的資料不符合 decimal 數值格式
			string tDecimalErrMsg = MultiLanguage.GetComment("PSMSG", "Validation", "DecimalErrMsg", tLanguageType);

			#region 找出每個單身的資料
			List<DscRow> listRow_Body01 = new List<DscRow>();
			List<DscRow> listRow_Body02 = new List<DscRow>();
			List<DscRow> listRow_Body03 = new List<DscRow>();
			List<DscRow> listRow_Body04 = new List<DscRow>();
			List<DscRow> listRow_Body05 = new List<DscRow>();
			int intBodyCount = @BodyCount;
			for(int i = 0; i < intBodyCount; i++)
			{
				DscDataObj tBodyGridObj = null;

				//檢查該單身所有 Row 的集合 (NewRow)
				tBodyGridObj = ((DscDataObj)Session[string.Format("{0}_dataObj_{1}", pFormId, pUniversalId)]).DetailObjs[i];

				//NewRows
				foreach (DscRow dscRow in tBodyGridObj.NewRows)
				{
					if (!dscRow.IsDeleted)
					{
						if(i==0)//單身1
							listRow_Body01.Add(dscRow);
						else if(i==1)//單身2
							listRow_Body02.Add(dscRow);
						else if(i==2)//單身3
							listRow_Body03.Add(dscRow);
						else if(i==3)//單身4
							listRow_Body04.Add(dscRow);
						else if(i==4)//單身5
							listRow_Body05.Add(dscRow);
					}
				}
			}
			
			int intBody01RowCount = listRow_Body01.Count;
			int intBody02RowCount = listRow_Body02.Count;
			int intBody03RowCount = listRow_Body03.Count;
			int intBody04RowCount = listRow_Body04.Count;
			int intBody05RowCount = listRow_Body05.Count;
			#endregion 找出每個單身的資料

			#region 範例
			////不允許空白驗證
			//for(int i=0;i<intBody02RowCount;i++){
			//	string ttext1 = listRow_Body02[i]["text1"].Value.ToString();
			//	if (ttext1.Length==0){
			//		//欄位不允許空白 !
			//		tRetMsg += "「" + MultiLanguage.GetComment("FD", "T0201001MT_d02", "text1", tLanguageType) +"」  " + tFieldNotFilledMsg + "\r\n";
			//		break;
			//	}
			//}
			////Int格式驗証
			//for(int i=0;i<intBody02RowCount;i++){
			//	string ttext2 = listRow_Body02[i]["text2"].Value.ToString();
			//	if (ttext2.Length>0){
			//		int inttext2 = 0;
			//		Int32.TryParse(ttext2, out inttext2);
			//		if (!Regex.IsMatch(ttext2, @"^-?\d+$")){
			//			//輸入的資料不符合int數值格式 !
			//			tRetMsg += "「" + MultiLanguage.GetComment("FD", "T0201001MT_d02", "text2", tLanguageType) +"」  " + tIntErrMsg + "\r\n";
			//			break;
			//		}
			//	}
			//}
			////float格式驗証
			//for(int i=0;i<intBody02RowCount;i++){
			//	string ttext3 = listRow_Body02[i]["text3"].Value.ToString();
			//	if (ttext3.Length>0){
			//		double doubletext3 = 0;
			//		double.TryParse(ttext3, out doubletext3);
			//		if (!Regex.IsMatch(ttext3, @"^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$")){
			//			//輸入的資料不符合float數值格式 !
			//			tRetMsg += "「" + MultiLanguage.GetComment("FD", "T0201001MT_d02", "text3", tLanguageType) +"」  " + tFloatErrMsg + "\r\n";
			//			break;
			//		}
			//	}
			//}
			////文字驗證
			//for(int i=0;i<intBody01RowCount;i++){
			//	string ttext1Value = listRow_Body01[i]["text1"].Value.ToString();
			//	if (ttext1Value.Length < 3 || ttext1Value.Length > 5)
			//	{
			//		tRetMsg += "「" + MultiLanguage.GetComment("FD", "T0201001MT_d01", "text1", tLanguageType) +"」  " + MultiLanguage.GetComment("FD", "T0201001MT_d01", "text1_Err", tLanguageType) + "\r\n";
			//		break;
			//	}
			//}
			////數值驗証
			//for(int i=0;i<intBody02RowCount;i++){
			//	string ttext2 = listRow_Body02[i]["text2"].Value.ToString();
			//	double doubletext2 = 0;
			//	if(!(double.TryParse(ttext2, out doubletext2))){
			//		//輸入的資料不是數值
			//		tRetMsg += "「" + MultiLanguage.GetComment("FD", "T0201001MT_d02", "text2", tLanguageType) +"」  " + tNotNumberSTRErrMsg + "\r\n";
			//		break;
			//	}
			//	else{
			//		if (doubletext2 < 1 || doubletext2 > 3)
			//		{
			//			tRetMsg += "「" + MultiLanguage.GetComment("FD", "T0201001MT_d02", "text2", tLanguageType) +"」  " + MultiLanguage.GetComment("FD", "T0201001MT_d02", "text2_Err", tLanguageType) + "\r\n";
			//			break;
			//		}
			//	}
			//}
			//
			#endregion 範例
@SetDetailVerifyInApprove

			return tRetMsg;
		}
		//2013/02/04:3.5.1.48:hiro:S00-20120626008:雙檔表單簽核鈕(發單、准、同意、會辦)增加單身驗證功能↑
		#endregion 簽核按鈕檢查單身驗證欄位

		//2013/06/07:3.6.1.4:hiro:S00-20130401009:增加數值自動轉換大寫金額格式↓
		#region 從CS取得定位後的數值(JS超出16進位會失真)
		/// <summary>
		/// 從CS取得定位後的數值
		/// </summary>
		/// <param name="pNumber">要轉換的數值</param>
		/// <param name="pDecimalPlaces">小數位</param>
		/// <returns>
		/// 回傳定位後的數值
		/// </returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetFixedNum(string pNumber, int pDecimalPlaces)
		{
			decimal decimalNumber=0;
			decimal.TryParse(pNumber, out decimalNumber);
			if(pDecimalPlaces>2)
				pDecimalPlaces=2;//只處理到角分
			decimalNumber = Math.Round(decimalNumber, pDecimalPlaces, MidpointRounding.AwayFromZero);
			return decimalNumber.ToString();
		}
		#endregion 從CS取得定位後的數值(JS超出16進位會失真)

		#region 數值轉大寫金額格式
		/// <summary>
		/// 數值轉大寫金額格式
		/// </summary>
		/// <param name="pNumber">要轉換的數值</param>
		/// <returns>
		/// 回傳轉換完成的大寫金額格式
		/// </returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public string ajaxGetMoneyWord(string pNumber)
		{
			string strReturn="";
			UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
			string tLanguageType = tClass.Language;

			string[] aryNumMatchSTRING = new string[10];
			string[] aryInterPosition = new string[16];
			string[] aryDecimalPosition = new string[5];
			decimal decimalNumber=0;
			decimal.TryParse(pNumber, out decimalNumber);
			if(tLanguageType=="Lang03"){
				//簡體中文
				aryNumMatchSTRING=new string[]{"零","壹","贰","叁","肆","伍","陆","柒","捌","玖"};
				aryInterPosition=new string[]{"整","元","拾","佰","仟","万","拾","佰","仟","亿","拾","佰","仟","兆","拾","佰","仟"};
				aryDecimalPosition=new string[]{"角","分","厘","毫","微"};

				if (pNumber.IndexOf("-") > -1)
				{
					strReturn="负";
					decimalNumber=decimalNumber*(-1);//去除負號後面再來做轉換
				}
			}
			else if(tLanguageType=="Lang02"){
				//英文(格式待確認，先不做處理)
				return pNumber;
			}
			else{
				//繁體中文
				aryNumMatchSTRING=new string[]{"零","壹","貳","參","肆","伍","陸","柒","捌","玖"};
				aryInterPosition=new string[]{"整","元","拾","佰","仟","萬","拾","佰","仟","億","拾","佰","仟","兆","拾","佰","仟"};
				aryDecimalPosition=new string[]{"角","分","厘","毫","微"};

				if(pNumber.IndexOf("-")>-1){
					strReturn="負";
					decimalNumber=decimalNumber*(-1);//去除負號後面再來做轉換
				}
			}

			string strIntegerSTR="";
			string strDecimalSTR="";
			string[] aryNumber = decimalNumber.ToString().Split('.');
			if(aryNumber.Length>1){
				//含小數位
				strIntegerSTR = aryNumber[0];
				strDecimalSTR = aryNumber[1];
			}
			else{
				strIntegerSTR = decimalNumber.ToString();
			}

			int intIntegerLenth = strIntegerSTR.Length;
			int intDecimalLenth = strDecimalSTR.Length;
			string strCharacters="";
			int intCharacters=0;
			string strNumMatchWord="";
			string strPositionWord="";
			string strSetZeroCTR="";
			int intZeroTime=0;
			for(int i=0;i<intIntegerLenth;i++){
				strCharacters=strIntegerSTR.Substring(i, 1);//取出需轉換的某一位的值
				intCharacters = Convert.ToInt32(strCharacters);

				strNumMatchWord=aryNumMatchSTRING[intCharacters];//大寫數字
				strPositionWord=aryInterPosition[intIntegerLenth-i];//位數字串

				if(intCharacters==0){
					++intZeroTime;
					strSetZeroCTR=aryNumMatchSTRING[0];
					if((intIntegerLenth-i) % 4 ==1){
						if(intZeroTime<4){
							//關鍵字不用加零，但是要寫出關鍵字，4位數都為0例外
							strReturn+=strPositionWord;
						}
						else if(i==intIntegerLenth-1){
							strReturn+=aryInterPosition[1];//一定要加元
						}
						strSetZeroCTR="";
						intZeroTime=0;
					}
				}
				else{
					intZeroTime=0;
					strReturn+=strSetZeroCTR;
					strReturn+=aryNumMatchSTRING[intCharacters];
					strReturn+=aryInterPosition[intIntegerLenth-i];
					strSetZeroCTR="";
				}
			}

			if(strDecimalSTR=="" || strDecimalSTR=="0" || strDecimalSTR=="00"){
				strReturn+=aryInterPosition[0];//沒有小數，最後加上“整”
			}
			else{
				//2015/09/18;3.7.3.21;hiro;C01-20150918001;修正數值轉大寫，0.xx小數被轉成「元x分x角」前面多一個“元”↓
				if(strIntegerSTR=="0")
					strReturn="";//避免0.xx小數被轉成「元x分x角」前面多一個“元”
				//2015/09/18;3.7.3.21;hiro;C01-20150918001;修正數值轉大寫，0.xx小數被轉成「元x分x角」前面多一個“元”↑

				for(int i=0;i<intDecimalLenth;i++){
					strCharacters=strDecimalSTR.Substring(i, 1);//取出需轉換的某一位的值
					intCharacters = Convert.ToInt32(strCharacters);
					if(intCharacters!=0){
						strReturn+=aryNumMatchSTRING[intCharacters];
						strReturn+=aryDecimalPosition[i];
					}
				}

			}

			if(decimalNumber==0){
				//零元整
				strReturn=aryNumMatchSTRING[0]+aryInterPosition[1]+aryInterPosition[0];
			}

			return strReturn;
		}
		#endregion 數值轉大寫金額格式
		//2013/06/07:3.6.1.4:hiro:S00-20130401009:增加數值自動轉換大寫金額格式↑

		#region 執行派送表單
		//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↓
		/// <summary>
		/// 執行派送表單
		/// </summary>
		/// <param name="pFormID">派送前置表單單別</param>
		/// <param name="pSheetNo">派送前置表單單號</param>
		/// <param name="pDispatchFormID">派送後置表單單別</param>
		/// <returns>回傳執行派送表單是否成功</returns>
		[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
		public bool ajaxDoDispatchForm(string pFormID, string pSheetNo, string pDispatchFormID)
		{
			UserInfoClass tUserInfo = (UserInfoClass)Session["UserInfo"];
			string tCreateUserId = tUserInfo.LoginId; //開單人員預設為點選按鈕的人
			string tCompanyDBName = tUserInfo.Company;

			EFUserInfoClass tEFUserInfo = (EFUserInfoClass)Session["EFUserInfoClass"];
			string tSiteName = tEFUserInfo.SiteName; //站台名稱

			string tBackFormId = string.Empty;						//後置表單代號
			string tBackSheetNo = string.Empty;						//後置表單單號
			string tBackOwnerId = string.Empty;						//後置表單表單關係人
			string tBackCond = string.Empty;						//後置表單送單條件式
			bool tDispatchResult = false;							//派送表單執行結果(預設 false)
			try
			{
				DBCommand dbCommand = DscDBData.GetDataDBCommand();
				string tSQL = @"select resfc004 from $EFDB$..resfc
where resfc001=@resfc001 and resfc002=@resfc002 and resfc003=@resfc003 and ISNULL(resfc004,'')<>''";
				tSQL = tSQL.Replace("$EFDB$", tCompanyDBName);
				dbCommand.AddParameter("resfc001", pFormID);
				dbCommand.AddParameter("resfc002", pSheetNo);
				dbCommand.AddParameter("resfc003", pDispatchFormID);
				DataTable dtRESFC = dbCommand.Query(tSQL);
				if (dtRESFC != null && dtRESFC.Rows.Count>0){
					return false;
				}

				//呼叫派送表單方法，然後依據不同的執行結果，將之紀錄下來
				tDispatchResult = objUTL_ShareFunc.doFlowDispatchCreate(pFormID, pSheetNo, pDispatchFormID, tCreateUserId, tSiteName, m_strProcID,
														ref tBackSheetNo, ref tBackOwnerId, ref tBackCond);

				if (tDispatchResult)
				{
					//執行成功 Insert 資料到記錄 Table (resfc)
					objUTL_ShareFunc.successDispatch(pFormID, pSheetNo, pDispatchFormID, tBackSheetNo, tCreateUserId, tBackOwnerId, tBackCond, m_strProcID);
				}
			}
			catch(Exception ex){
				tDispatchResult=false;
			}

			return tDispatchResult;
		}
		//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↑
		#endregion 執行派送表單

		#region 自訂Ajax
		@NewAjax
		#endregion 自訂Ajax
		#endregion AjaxMethod()

		#region settingClientFunction , 註冊onclick、onblur、onchange事件
		/// <summary>
		/// 註冊onclick、onblur、onchange事件
		/// </summary>
		protected override void settingClientFunction()
		{
			//參數1.為原本的開窗方式  參數2.為樹狀的開窗
			string tWindowOpenStyle = objEFPara.EF_getCompanyParameterData("WindowOpenStyle").ToString();
@ClickEvent
@TriggerFieldonclick
		}//settingClientFunction結尾

		/// <summary>
		/// %%必填%%
		/// </summary>
		/// <param name="pMiMjManager"></param>
		protected override void buildMiMjManager(Hashtable pMiMjManager)
		{
@MiMjManagers
		}//buildMiMjManager結尾
		#endregion settingClientFunction , 註冊onclick、onblur、onchange事件

		///<summary>
		///圖片控制項
		///</summary>
		///<param name="pListImage"></param>
		protected override void settingImgAssistantInfo(System.Collections.Generic.List<DigiWinImgAssistant> pListImage)
		{
			base.settingImgAssistantInfo(pListImage);
@ImageManagers
		}//settingImgAssistantInfo結尾

		#region SetDefaultValue , 設定表單欄位的初始值
		@SetDefaultValue
		#endregion SetDefaultValue , 設定表單欄位的初始值

		#region DB 相關 Method
		#region 取得EasyFlow資料庫欄位(1欄位)
		/// <summary>
		/// 取得EasyFlow資料庫欄位(1欄位)
		/// </summary>
		/// <param name="pSQLString">SQL Command</param>
		/// <param name="pValue">欄位 ID</param>
		/// <returns>欄位值</returns>
		public string getEasyFlowDataFieldValue(string pSQLString,string pValue)
		{
			string tResult = "";
			try
			{
				UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
				DBCommand dbCommand = DscDBData.GetDataDBCommand();
				//bool bHaveTwinSpace = true;
				//while(bHaveTwinSpace){
				//	if(pSQLString.IndexOf("  ")!=-1 || pSQLString.IndexOf("\r\n")!=-1){
				//		pSQLString=pSQLString.Replace("\r\n"," ").Replace("  "," ");
				//	}
				//	else{
				//		bHaveTwinSpace=false;
				//	}
				//}
				while(pSQLString.IndexOf("\r\n")!=-1){
					pSQLString=pSQLString.Replace("\r\n"," ");
				}

				int intFromPosition = pSQLString.ToLower().IndexOf("from");
				pSQLString = pSQLString.Substring(0, intFromPosition) + "from " + tClass.Company.ToString().Trim() + ".." +pSQLString.Substring(intFromPosition+5);
				DataTable tDt = dbCommand.Query(pSQLString);
				if (tDt != null)
				{
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "§";
						else
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim();
					}
				}
			}
			catch (Exception e)
			{
			}
			return tResult;
		}
		#endregion 取得EasyFlow資料庫欄位(1欄位)

		#region 取得EasyFlow資料庫欄位(2欄位)
		/// <summary>
		/// 取得EasyFlow資料庫欄位(2欄位)
		/// </summary>
		/// <param name="pEFDBType">EF資料庫類別(0:公司別;1:系統別)</param>
		/// <param name="pSQLString">SQL Command</param>
		/// <param name="pValue">欄位 ID</param>
		/// <param name="pText">欄位 ID</param>
		/// <returns>欄位值(以 § 分隔)</returns>
		public string createEasyFlowDataTable(string pEFDBType, string pSQLString, string pValue, string pText)
		{
			//bool bHaveTwinSpace = true;
			//while(bHaveTwinSpace){
			//	if(pSQLString.IndexOf("  ")!=-1 || pSQLString.IndexOf("\r\n")!=-1){
			//		pSQLString=pSQLString.Replace("\r\n"," ").Replace("  "," ");
			//	}
			//	else{
			//		bHaveTwinSpace=false;
			//	}
			//}
			while(pSQLString.IndexOf("\r\n")!=-1){
				pSQLString=pSQLString.Replace("\r\n"," ");
			}

			string tResult = "";
			try
			{
				UserInfoClass tClass = (UserInfoClass)Session["UserInfo"];
				DBCommand dbCommand = DscDBData.GetDataDBCommand();

				DataTable tDt = new DataTable();
				if(pEFDBType=="0"){
					string strCompanyDB = tClass.Company;
					string strSYSDBConn = LoadConfig.SysDBConnString;
					//Ex:server=localhost; database=EFNETSYS; uid=sa; pwd=dsc;
					string[] aryDBConn = strSYSDBConn.Split(';');
					int intDBConnLen = aryDBConn.Length;
					for(int i=0;i<intDBConnLen;i++){
						if(aryDBConn[i].IndexOf("database=")>-1){
							aryDBConn[i]="database="+strCompanyDB;
							break;
						}
					}
					string strCompanyDBConn = string.Empty;
					for(int i=0;i<intDBConnLen;i++){
						strCompanyDBConn+=aryDBConn[i]+";";
					}

					DBCommand dbCommand_company = new DBCommand(strCompanyDBConn);
					tDt = dbCommand_company.Query(pSQLString);
				}
				else
					tDt = dbCommand.Query(pSQLString);

				if (tDt != null)
				{
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
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
		#endregion 取得EasyFlow資料庫欄位(2欄位)

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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "§";
						else
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim();
					}
				}
			}
			catch (Exception e)
			{
			}
			return tResult;
		}
		#endregion 取得EasyFlow資料庫欄位自訂連線字串(1欄位)

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
			StringBuilder tResult = new StringBuilder();
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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
							tResult.AppendFormat(tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim() + "§");
						else
							tResult.AppendFormat(tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "Φ" + tDt.Rows[i]["" + pText + ""].ToString().Trim());
					}
				}
			}
			catch (Exception e)
			{
			}
			return tResult.ToString();
		}
		#endregion 取得EasyFlow資料庫欄位自訂連線字串(2欄位)

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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "§";
						else
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim();
					}
				}
			}
			catch (Exception e)
			{
			}
			return tResult;
		}
		#endregion 取得Oracle資料庫(1欄位)

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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
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
		#endregion 取得Oracle資料庫(2欄位)

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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "§";
						else
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim();
					}
				}
			}
			catch (Exception e)
			{
			}
			return tResult;
		}
		#endregion 取得Access資料庫欄位(1欄位)

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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
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
		#endregion 取得Access資料庫欄位(2欄位)

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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim() + "§";
						else
							tResult += tDt.Rows[i]["" + pValue + ""].ToString().Trim();
					}
				}
			}
			catch (Exception e)
			{
			}
			return tResult;
		}
		#endregion 取得ODBC資料庫欄位(1欄位)

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
					int intDTRowsCount = tDt.Rows.Count;
					for (int i = 0; i < intDTRowsCount; i++)
					{
						if (i != intDTRowsCount - 1)
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
		#endregion 取得ODBC資料庫欄位(2欄位)
		#endregion DB 相關 Method

		#region createSelectItemFromDB 產生下拉式選項的值
		/// <summary>
		/// 產生下拉式選項的值
		/// </summary>
		/// <param name="pReturnValue">從資料庫來源取得的選項字串</param>
		/// <param name="pDDL">DropDownList 控制項 ID</param>
		/// <returns>true=成功; false=失敗</returns>
		public bool createSelectItemFromDB(string pReturnValue, DscDropDownList pDDL)
		{
			bool bReturn = false;
			string[] aryDDLItems = pReturnValue.Split('§');
			string[] aryKeyAndShow;
			string tSaveValue = "";
			string tShowText = "";
			ListItem tList = null;
			try
			{
				int iDDLItemsCount = aryDDLItems.Length;
				for (int i = 0; i < iDDLItemsCount; i++)
				{
					aryKeyAndShow = aryDDLItems[i].Split('Φ');
					tSaveValue = aryKeyAndShow[0].Trim();	//Value (內存)
					tShowText = aryKeyAndShow[1].Trim();	//Text  (外顯)
					if (!string.IsNullOrEmpty(tSaveValue))
					{
						tList = new ListItem(tShowText, tSaveValue);
						pDDL.Items.Add(tList);
					}
				}
				bReturn = true;
			}
			catch (Exception e)
			{
				bReturn = false;
			}
			return bReturn;
		}
		#endregion createSelectItemFromDB 產生下拉式選項的值

		#region createDDLSaveValueAndShowTextFromDB 產生下拉
		//2017/12/18;6.1.6.5;hiro;S00-20171218001;下拉控件資料來源，內存外顯請改為動態取得↓
		/// <summary>
		/// 產生下拉控件於settingHeaderShown所需內存外顯對應字串
		/// </summary>
		/// <param name="pReturnValue">從資料庫來源取得的選項字串</param>
		/// <param name="tSaveValueAndShowText">要放到settingHeaderShown對應該下拉控件的字串</param>
		/// <returns>true=成功; false=失敗</returns>
		public bool createDDLSaveValueAndShowTextFromDB(string pReturnValue,ref string tSaveValueAndShowText)
		{
			string[] aryDDLItems = pReturnValue.Split('§');
			string[] aryKeyAndShow;
			string tSaveValue = "";
			string tShowText = "";
			int iCount = aryDDLItems.Length;
			try
			{
				tSaveValueAndShowText="";
				foreach(string tEachDDLItem in aryDDLItems){
					aryKeyAndShow =tEachDDLItem.Split('Φ');
					if (aryKeyAndShow[0].Trim()!="")
					{
						tSaveValue = aryKeyAndShow[0].Trim();	//內存
						tShowText = aryKeyAndShow[1].Trim();	//外顯
						if(tSaveValueAndShowText!="")
							tSaveValueAndShowText+="§";
						tSaveValueAndShowText+=tSaveValue+"="+tShowText;
					}
				}
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
		//2017/12/18;6.1.6.5;hiro;S00-20171218001;下拉控件資料來源，內存外顯請改為動態取得↑
		#endregion createDDLSaveValueAndShowTextFromDB 產生下拉式選項的值

		#region 派送表單功能強化
		//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↓
/*
表單串連紀錄檔(resfc)
欄位代號		欄位名稱
*resfc001		前置表單代號
*resfc002		前置表單單號
*resfc003		後置表單代號
*resfc004		後置表單單號
resfc005		送單時間
resfc006		後置表單填表人
resfc007		後置表單表單關係人
resfc008		後置表單條件式
resfc009		前置表單狀態碼
resfc010		後置表單狀態碼					(1=送簽中; 2=同意[結案]; 3=不同意[結案]; 4=抽單[結案])
resfc011		可否重送後置表單狀態碼			(1=不可重 送; 2=可以重送)
resfc012		記錄後置表單重送單別單號欄位	記錄格式: FormID_SheetNo;FormID_SheetNo... 以 "_" 串接單別和單號, 以 ";" 來串接第一次和第二次重送資訊
*/
		#region 取得派送後置表單簽核資訊
		/// <summary>
		/// 取得最後一次派送後置表單的簽核資訊
		/// </summary>
		/// <param name="pDispatchFormID">派送表單代號</param>
		/// <param name="pDSClbl">顯示派送後置表單簽核資訊的Label控件</param>
		/// <param name="pApproveType">顯示類型：簽核狀態(ApproveStatus)、簽核結果(ApproveResult)</param>
		protected void GetDispatchFormLabelText(string pDispatchFormID, DscLabel pDSClbl, string pApproveType){
			try
			{
				UserInfoClass tUserInfo = (UserInfoClass)Session["UserInfo"];
				string tLanguageType = tUserInfo.Language;
				string tCompanyDBName = tUserInfo.Company;
				DBCommand dbCommand = DscDBData.GetDataDBCommand();
				//執行派送多筆時，顯示最後一次的派迗表單流程資訊
				string tSQL = @"select LangRESDA020.$Lang$ as resda020,LangRESDA021.$Lang$ as resda021
from $EFDB$..resfc
left join $EFDB$..resda on resda001=resfc003 and resda002=resfc004
left join EFNETSYS..SYSComment LangRESDA020 on LangRESDA020.F0003=resda020 and LangRESDA020.F0002='EFWizard_resda020' and LangRESDA020.F0001='Combo'
left join EFNETSYS..SYSComment LangRESDA021 on LangRESDA021.F0003=resda021 and LangRESDA021.F0002='EFWizard_resda021' and LangRESDA021.F0001='Combo'
where resfc001=@resfc001 and resfc002=@resfc002 and resfc003=@resfc003 and ISNULL(resfc004,'')<>'' order by resfc004 desc";
				tSQL = tSQL.Replace("$Lang$", tLanguageType).Replace("$EFDB$", tCompanyDBName);
				dbCommand.AddParameter("resfc001", this.formID);
				dbCommand.AddParameter("resfc002", this.SheetNo);
				dbCommand.AddParameter("resfc003", pDispatchFormID);
				DataTable dtRESFC = dbCommand.Query(tSQL);
				if (dtRESFC != null && dtRESFC.Rows.Count>0)
				{
					string tresda020Value = dtRESFC.Rows[0]["resda020"]==DBNull.Value?"":dtRESFC.Rows[0]["resda020"].ToString().Trim();
					string tresda021Value = dtRESFC.Rows[0]["resda021"]==DBNull.Value?"":dtRESFC.Rows[0]["resda021"].ToString().Trim();
					if(pApproveType=="ApproveStatus")
						pDSClbl.Text=tresda020Value;
					else if(pApproveType=="ApproveResult")
						pDSClbl.Text=tresda021Value;
				}
				else{
					pDSClbl.Text=MultiLanguage.GetComment("FD", "DSCLabel", "DispatchFormNotSent", tLanguageType);//未執行派送表單
				}
			}
			catch (Exception ex)
			{
				//執行失敗則清空Label
				pDSClbl.Text="";
			}
		}
		#endregion 取得派送後置表單簽核資訊

		#region 設定派送表單相關按鈕是否啟用
		/// <summary>
		/// 設定派送表單相關按鈕是否啟用
		/// </summary>
		/// <param name="pDispatchFormID">派送表單代號</param>
		/// <param name="pDSCbtn">派送表單相關的Button控件</param>
		/// <param name="pRunOrShow">按鈕功能：執行派送表單(DoDispatchForm)、顯示後置派送表單(ShowDispatchForm)</param>
		protected void SetDispatchFormButtonIsEnabled(string pDispatchFormID, DscButton pDSCbtn, string pRunOrShow){
			try
			{
				string tSQL="";
				UserInfoClass tUserInfo = (UserInfoClass)Session["UserInfo"];
				string tLanguageType = tUserInfo.Language;
				string tCompanyDBName = tUserInfo.Company;
				DBCommand dbCommand = DscDBData.GetDataDBCommand();

				if(pRunOrShow=="DoDispatchForm"){
					//已經執行過派送表單，則設定執行派送表單的按鈕為不啟用(如果要讓它可以執行多次，就不用判斷了，直接啟用即可)
					//pDSCbtn.Enabled = true;
					tSQL = @"select resfc004 from $EFDB$..resfc
where resfc001=@resfc001 and resfc002=@resfc002 and resfc003=@resfc003 and ISNULL(resfc004,'')<>''";
					tSQL = tSQL.Replace("$EFDB$", tCompanyDBName);
					dbCommand.AddParameter("resfc001", this.formID);
					dbCommand.AddParameter("resfc002", this.SheetNo);
					dbCommand.AddParameter("resfc003", pDispatchFormID);
					DataTable dtRESFC = dbCommand.Query(tSQL);
					if (dtRESFC != null && dtRESFC.Rows.Count>0){
						pDSCbtn.Enabled = false;
						string tConfirmSTR=MultiLanguage.GetComment("Message", "EFWizardForm", "ConfirmDispatchFormOverTimes", tLanguageType);//派送表單已存在，是否執行第$Times$次派送表單？
						tConfirmSTR=tConfirmSTR.Replace("$Times$", (dtRESFC.Rows.Count+1).ToString());
						pDSCbtn.Attributes.Add("onclick", string.Format("if(confirm('{0}')){{jsDoDispatch('{1}','{2}','{3}');}} event.returnValue = false;return false;",
																				tConfirmSTR,
																				this.formID,
																				this.SheetNo,
																				pDispatchFormID));
					}
					else{
						pDSCbtn.Enabled = true;
						pDSCbtn.Attributes.Add("onclick", string.Format("jsDoDispatch('{0}','{1}','{2}');event.returnValue = false;return false;",
																		this.formID,
																		this.SheetNo,
																		pDispatchFormID));
					}
				}
				else if(pRunOrShow=="ShowDispatchForm"){
					//2016/01/25;3.7.3.40;hiro;S00-20160121003;3.避免點選顯示前/後置表單造成無限迴圈開啟表單↓
					if(Request["IsShowDispatchForm"] != null && Request["IsShowDispatchForm"]=="Y"){
						pDSCbtn.Enabled = false;
						return;
					}
					//2016/01/25;3.7.3.40;hiro;S00-20160121003;3.避免點選顯示前/後置表單造成無限迴圈開啟表單↑

					tSQL = @"select top 1 *,resda031 from $EFDB$..resdd
left join $EFDB$..resda on resda001=@DispatchFormID and resda001=resdd001 and resda002=resdd002
where resdd001=@DispatchFormID and resdd002=(select top 1 resfc004 from $EFDB$..resfc where resfc001=@FormID and resfc002=@SheetNo and resfc003=@DispatchFormID and ISNULL(resfc004,'')<>'' order by resfc005 desc)
order by resdd003 desc";
					tSQL = tSQL.Replace("$EFDB$", tCompanyDBName);
					dbCommand.ClearParameters();
					dbCommand.AddParameter("FormID", this.formID);
					dbCommand.AddParameter("SheetNo", this.SheetNo);
					dbCommand.AddParameter("DispatchFormID", pDispatchFormID);
					DataTable dtRESDD = dbCommand.Query(tSQL);
					if (dtRESDD != null && dtRESDD.Rows.Count>0){
						string tUrl="";
						string tMenuName="";
						tSQL = @"select Url,MenuName from Menu where MenuID=@MenuID";
						dbCommand.ClearParameters();
						dbCommand.AddParameter("MenuID", pDispatchFormID);
						DataTable dtMenu = dbCommand.Query(tSQL);
						if (dtMenu != null && dtMenu.Rows.Count>0){
							tUrl=dtMenu.Rows[0]["Url"]==DBNull.Value?"":dtMenu.Rows[0]["Url"].ToString().Trim();
							tMenuName=dtMenu.Rows[0]["MenuName"]==DBNull.Value?"":dtMenu.Rows[0]["MenuName"].ToString().Trim();
						}
						
						if(tUrl!=""){
							//已經執行過派送表單，且在resdd找得到流程資料，則設定顯示派送表單的按鈕為啟用
							pDSCbtn.Enabled = true;
							string tSheetNo=dtRESDD.Rows[0]["resdd002"]==DBNull.Value?"":dtRESDD.Rows[0]["resdd002"].ToString().Trim();
							string tFlowNo=dtRESDD.Rows[0]["resdd003"]==DBNull.Value?"":dtRESDD.Rows[0]["resdd003"].ToString().Trim();
							string tBranchNo=dtRESDD.Rows[0]["resdd004"]==DBNull.Value?"":dtRESDD.Rows[0]["resdd004"].ToString().Trim();
							string tSerialNo=dtRESDD.Rows[0]["resdd005"]==DBNull.Value?"":dtRESDD.Rows[0]["resdd005"].ToString().Trim();
							string tApproveNo=dtRESDD.Rows[0]["resdd006"]==DBNull.Value?"":dtRESDD.Rows[0]["resdd006"].ToString().Trim();
							string tSubject=dtRESDD.Rows[0]["resda031"]==DBNull.Value?"":dtRESDD.Rows[0]["resda031"].ToString().Trim();
							//pDSCbtn.Attributes.Add("onclick", string.Format("alert('"+tUrl+"');event.returnValue = false;return false;"));

							bool bIsReSendForm=false;//檢查頁面是否不是從「顯示前置表單」按鈕開啟，才可以執行顯示的功能
							//if (Request["IsReSendForm"] != null){
							//	if (Request["IsReSendForm"].ToString().Trim() == "Y"){
							//		bIsReSendForm=true;
							//	}
							//}
							if ((Request["IsReSendForm"] != null && Request["IsReSendForm"] == "Y") || (Request["Action"]!=null && Request["Action"] == "ShowOriginal"))
							{
								bIsReSendForm=true;
							}
							if(!bIsReSendForm){
								//pDSCbtn.Attributes.Add("onclick", string.Format("if(checkTabExist()){{createTab('{0}?FormType=In&formStatus=Approve&sheetNo={1}&flowNo={2}&branchNo={3}&SerialNo={4}&ApproveNo={5}&Subject={6}&gCursor=3','{7}','{8}','100');}}event.returnValue = false;return false;",
								//不允許使用點選顯示派送表單時執行簽核動作(避免目前使用者沒有執行派送表單的權限，或並非簽核者的身份進行簽核)
								//pDSCbtn.Attributes.Add("onclick", string.Format("createTab('{0}?FormType=Reply&formStatus=Display&sheetNo={1}&flowNo={2}&branchNo={3}&SerialNo={4}&ApproveNo={5}&Subject={6}&gCursor=3','{7}','{8}','100');event.returnValue = false;return false;",
								//允許使用者點選顯示派送表單後，就可以執行簽核動作(若目前使用者沒有執行派送表單的權限，或並非簽核者卻顯示出簽核鈕，避免使用者直接執行簽核而造成流程錯誤)
								//pDSCbtn.Attributes.Add("onclick", string.Format("createTab('{0}?FormType=In&formStatus=Approve&sheetNo={1}&flowNo={2}&branchNo={3}&SerialNo={4}&ApproveNo={5}&Subject={6}&gCursor=3','{7}','{8}','100');event.returnValue = false;return false;",
								//				tUrl,
								//				tSheetNo,
								//				tFlowNo,
								//				tBranchNo,
								//				tSerialNo,
								//				tApproveNo,
								//				tSubject,
								//				pDispatchFormID,
								//				tMenuName));
								//2016/07/22;3.7.3.67;hiro;S00-20160627004;表單的填表人或表單關係人，參數控管權限查看派送前置或後置的表單↓
								////2016/01/25;3.7.3.40;hiro;S00-20160121003;2.Button控件顯示派送表單功能，改為參考「顯示前置派送表單」按鈕，僅顯示表單內容不允許簽核表單↓
								//pDSCbtn.Attributes.Add("onclick", string.Format("showFrontFormInfo('{0}','{1}');event.returnValue = false;return false;", pDispatchFormID,  tSheetNo));
								////2016/01/25;3.7.3.40;hiro;S00-20160121003;2.Button控件顯示派送表單功能，改為參考「顯示前置派送表單」按鈕，僅顯示表單內容不允許簽核表單↑
								pDSCbtn.Attributes.Add("onclick", string.Format("showFrontFormInfo('{0}','{1}','{2}','{3}');event.returnValue = false;return false;", pDispatchFormID, tSheetNo, this.formID, this.SheetNo));
								//2016/07/22;3.7.3.67;hiro;S00-20160627004;表單的填表人或表單關係人，參數控管權限查看派送前置或後置的表單↑

							}
							else{
								//pDSCbtn.Attributes.Add("onclick", "alert('此畫面不支援顯示前置表單功能!');event.returnValue = false;return false;");
								pDSCbtn.Enabled = false;
							}
						}
						else{
							//派送表單的Menu路徑設定錯誤
							pDSCbtn.Enabled = false;
						}
					}
					else{
						//派送表單未執行，則設定顯示派送表單的按鈕為不啟用
						pDSCbtn.Enabled = false;
					}
				}
			}
			catch (Exception ex)
			{
				//pDSCbtn.Visible = false;
				pDSCbtn.Enabled = false;
				throw ex;
			}
		}
		#endregion 設定派送表單相關按鈕是否啟用
		//2014/12/30;3.7.3.3;hiro;S00-20141225002;派送表單功能強化↑
		#endregion 派送表單功能強化



		@DscReGetCondValue
		@DscReGetAgentIDParserRoleID
		@DscGridHashTable
		@DscGridShowColumn
		@BeforePrint
		@SetDetailComputeInfo
		@SetDetailDefaultValue
		@SetCustomCode_Other
	}
}
