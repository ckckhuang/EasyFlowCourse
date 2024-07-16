using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.IO;
using System.Reflection;
//2010/12/29:3.2.1.18:hiro:S00-20101005002:新增連動式開窗選項控制項↓
using tw.com.dsc.dscDotNet.common;
//2010/12/29:3.2.1.18:hiro:S00-20101005002:新增連動式開窗選項控制項↑
//2015/06/10;3.7.3.6;hiro;S00-20150610002;增加CmpCode公司組織控件，依公司組織過濾加簽、轉寄名單↓
using tw.com.dsc.dscDotNet.tool;
using tw.com.dsc.dscDotNet.db;
using tw.com.dsc.dscDotNet.dscData;
using System.Collections.Generic;
//2015/06/10;3.7.3.6;hiro;S00-20150610002;增加CmpCode公司組織控件，依公司組織過濾加簽、轉寄名單↑

namespace tw.com.dsc.easyflowDotNet.forms
{
	/// <summary>
	/// ITA04_MIMJ 的摘要描述。
	/// </summary>
	public partial class ITA04_MIMJ : tw.com.dsc.easyflowDotNet.kernelBasePage.EFMIMJBasepage
	{
		protected new void Page_Load(object sender, System.EventArgs e)
		{
			base.myPage_Load(sender, e);
		}

		#region MIFunction
		protected override void MIFunction()
		{
			switch(tBtnID)
			{
				case "MasterPage_MasterPageContent_ita04a003_btn":			//員工代號
				{
					base.doMI("RESAK","03");
					break;
				}
				case "MasterPage_MasterPageContent_ita04a005_btn":			//部門代號
				{
					base.doMI("RESAL","01");
					break;
				}
				case "MasterPage_MasterPageContent_ita04a006_btn":			//員工代號
				{
					string txtita04a005 = base.tAllInputValues["MasterPage_MasterPageContent_ita04a005_txt"].ToString().Trim();
					if(txtita04a005.Length>0)
						base.doMI("RESAK","14");
					else
						base.doMI("RESAK","03");
					break;
				}
				case "MasterPage_MasterPageContent_ita04b004_btn":			//其它類型開窗
				{
					base.doMI("OpenMIMJ01","03");
					break;
				}

				default:
					break;
			}
		}
		#endregion MIFunction

		#region MJFunction
		protected override void MJFunction()
		{
			//2010/12/29:3.2.1.18:hiro:S00-20101005002:新增連動式開窗選項控制項↓
			bool bSelfResult = false;
			//2010/12/29:3.2.1.18:hiro:S00-20101005002:新增連動式開窗選項控制項↑
			switch(tMJ)//欄位ID命名要規則化
			{
				case "員工代號_ita04a003":	
				{
					base.doMJ("RESAK","03","MasterPage_MasterPageContent_ita04a003_txt2=resak002");
					break;
				}
				case "部門代號_ita04a005":	
				{
					base.doMJ("RESAL","01","MasterPage_MasterPageContent_ita04a005_txt2=resal002");
					break;
				}
				case "員工代號_ita04a006":	
				{
					string txtita04a005 = string.Empty;
					if (tAllInputValues["MasterPage_MasterPageContent_ita04a005_txt"] != null)
						txtita04a005=tAllInputValues["MasterPage_MasterPageContent_ita04a005_txt"].ToString();

					string txtita04a006 = string.Empty;
					if (tAllInputValues["MasterPage_MasterPageContent_ita04a006_txt"] != null)
						txtita04a006=tAllInputValues["MasterPage_MasterPageContent_ita04a006_txt"].ToString();

					string[] aryParamger=null;
					if(txtita04a005.Length > 0){
						aryParamger = new string[2];
						aryParamger[0]=txtita04a006;
						aryParamger[1]=txtita04a005;
						bSelfResult = getMJResult("RESAK","14",aryParamger,FinalList,"MasterPage_MasterPageContent_ita04a006_txt2=resak002");
					}
					else{
						aryParamger = new string[1];
						aryParamger[0]=txtita04a006;
						bSelfResult = getMJResult("RESAK","03",aryParamger,FinalList,"MasterPage_MasterPageContent_ita04a006_txt2=resak002");
					}
					FinishMJ(bSelfResult, FinalList);
					break;
				}
				case "OpenMIMJ01_03_ita04b004_d01":	
				{
					base.doMJ("OpenMIMJ01","03","MasterPage_MasterPageContent_ita04b004_txt2=item_name","MasterPage_MasterPageContent_ita04b006_txt=price");
					break;
				}

				default:
					break;
			}
		}
		#endregion MJFunction

		//2015/06/10;3.7.3.6;hiro;S00-20150610002;增加CmpCode公司組織控件，依公司組織過濾加簽、轉寄名單↓
		/// <summary>
		/// 取得該員工所屬公司組織所需的SQL條件字串
		/// </summary>
		private string GetEmplAttachmentBaseDeptSQLString(){
			string strReturn = "";
			UserInfoClass tUserInfo = (UserInfoClass)Session["UserInfo"];

			string strSQL =  string.Format("select resal001 from {0}..resal WHERE resal001 in (select resan001 from {0}..resan where resan003='{1}') and resal005>1", tUserInfo.Company, tUserInfo.EmployeeId);
			DBCommand dbCommand = DscDBData.GetDataDBCommand();
			DataTable dtEmplAttachmentDept = dbCommand.Query(strSQL);
			//List<string> listBaseDeptNo = new List<string>();
			if (dtEmplAttachmentDept.Rows.Count > 0)
			{
				strReturn = " and (";
				int iCount = 0;
				//resal001(部門代號)、resal002(部門簡稱),resal004(上層部門代號),resal005(階層)
				strSQL =  string.Format("select resal001,resal002,resal004,resal005 from {0}..resal", tUserInfo.Company);
				DataTable dtAllDept = dbCommand.Query(strSQL);
				foreach(DataRow dr in dtEmplAttachmentDept.Rows)
				{
					//listBaseDeptNo.Add(GetBaseDeptNo(dr["real001"].ToString(), ref dtAllDept));
					if (iCount>0)
						strReturn += " or ";
					strReturn += "resal001='" + GetBaseDeptNo(dr["resal001"].ToString(), ref dtAllDept) + "'";
					++iCount;
				}
				strReturn += ")";
			}
			return strReturn;
		}

		private string GetBaseDeptNo(string pSonDeptNo, ref DataTable dtAllDept){
			string tParentDeptNo = "";
			dtAllDept.DefaultView.RowFilter = "resal001='"+pSonDeptNo+"'";
			if (dtAllDept.DefaultView.Count > 0) {
				string tDeptLevel=dtAllDept.DefaultView[0]["resal005"].ToString().Trim();
				if(tDeptLevel=="2"){
					return pSonDeptNo;
				}
				else{
					tParentDeptNo=dtAllDept.DefaultView[0]["resal004"].ToString().Trim();
					return GetBaseDeptNo(tParentDeptNo, ref dtAllDept);
				}
			}
			else
				return pSonDeptNo;
		}
		//2015/06/10;3.7.3.6;hiro;S00-20150610002;增加CmpCode公司組織控件，依公司組織過濾加簽、轉寄名單↑

		#region Web Form 設計工具產生的程式碼
		override protected void OnInit(EventArgs e)
		{
			// CODEGEN: 此為 ASP.NET Web Form 設計工具所需的呼叫。
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// 此為設計工具支援所必須的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
