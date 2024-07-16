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

namespace tw.com.dsc.easyflowDotNet.forms
{
		/// <summary>
		/// TEST82_MIMJ 的摘要描述。		/// </summary>
		public partial class TEST82_MIMJ : tw.com.dsc.easyflowDotNet.kernelBasePage.EFMIMJBasepage
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
								
								case "MasterPage_MasterPageContent_dept1_btn":			//部門代號
									base.doMI("RESAL","01");
									break;
								case "MasterPage_MasterPageContent_empl1_btn":			//員工代號
									base.doMI("RESAK","03");
									break;
			
			
								default:
								    break;
						}
				}
				#endregion

				#region MJFunction
				protected override void MJFunction()
				{
						//2010/12/29:3.2.1.18:hiro:S00-20101005002:新增連動式開窗選項控制項↓
						bool bSelfResult = false;
						//2010/12/29:3.2.1.18:hiro:S00-20101005002:新增連動式開窗選項控制項↑
						switch(tMJ)//欄位ID命名要規則化
						{
								
								case "部門代號_dept1":	
									base.doMJ("RESAL","01","MasterPage_MasterPageContent_dept1_txt2=resal002");
									break;
								case "員工代號_empl1":	
									base.doMJ("RESAK","03","MasterPage_MasterPageContent_empl1_txt2=resak002");
									break;
			
			
								default:
								    break;
						}
				}
				#endregion

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
