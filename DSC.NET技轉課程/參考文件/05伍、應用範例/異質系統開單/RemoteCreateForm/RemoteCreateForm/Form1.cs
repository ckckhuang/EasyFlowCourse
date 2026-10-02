using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RemoteCreateForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateForm_Click(object sender, EventArgs e)
        {
            int iNums = 1;
            int.TryParse(txtNums.Text, out iNums);

            try
            {
                EFWS.EFNETService tefws = new RemoteCreateForm.EFWS.EFNETService();
                tefws.Url = txtWebServiceURL.Text;
                StringBuilder sbRequest = new StringBuilder();                
                string[] aryReturn = null;
                string sSubject = "";//表單主旨
                string sFormID = "PROJECT_PM";//表單代號
                int iDetailDepth = 0;//幾個單身
                string SiteName = "EFNET";//EF的站台名稱
                for (int i = 0; i < iNums; i++)
                {
                    sbRequest.Length = 0;
                    sSubject = "異質性統開單" + DateTime.Now.ToString("MMdd") + "_" + i.ToString();

                    sbRequest.AppendLine("<Request>");
                    sbRequest.AppendLine("<RequestIP>127.0.0.1</RequestIP>");
                    sbRequest.AppendLine("<ResponseIP>192.168.1.232</ResponseIP>");
                    sbRequest.AppendLine("<FormCreatorID>T2215098</FormCreatorID>");//填表人
                    sbRequest.AppendLine("<FormOwnerID>T2215098</FormOwnerID>");//表單關係人
                    sbRequest.AppendLine("<FormID>PROJECT_PM</FormID>");//表單代號
                    sbRequest.AppendLine("<DetailDepth>" + iDetailDepth.ToString() + "</DetailDepth>");//幾個單身
                    sbRequest.AppendLine("<SiteName>" + SiteName + "</SiteName>");//EF的站台名稱
                    sbRequest.AppendLine("<Subject>" + sSubject + "</Subject>");//表單主旨
                    sbRequest.AppendLine("<RequestContent>");
                    //單頭內容
                    sbRequest.AppendLine("<Head tableName='project_pm'>");
                    sbRequest.AppendLine("<projecta003>" + "1" + "</projecta003>");//專案代碼
                    sbRequest.AppendLine("<projecta004>" + "0" + "</projecta004>");//專案名稱
                    sbRequest.AppendLine("<projecta005>" + "0" + "</projecta005>");//客戶
                    sbRequest.AppendLine("<projecta006>" + "5004" + "</projecta006>");//FAE
                    sbRequest.AppendLine("<projecta007>" + "DS" + "</projecta007>");//PM主管
                    sbRequest.AppendLine("<projecta008>" + "TEST" + "</projecta008>");//PM部門主管
                    sbRequest.AppendLine("<projecta009>" + "" + "</projecta009>");//GM
                    sbRequest.AppendLine("<projecta010>" + "20180411" + "</projecta010>");//ME                   
                    sbRequest.AppendLine("</Head>");
                    sbRequest.AppendLine("</RequestContent>");
                    //條件式
                    sbRequest.AppendLine("<Condition>");
                    //sbRequest.AppendLine("<Record id='efstr003' type='2' value='efstr003'/>");
                    sbRequest.AppendLine("</Condition>");
                    sbRequest.AppendLine("</Request>");

                    //開單
                    aryReturn = tefws.RemoteCreateForm(sbRequest.ToString());
                    if (aryReturn != null)
                    {
                        if (aryReturn[0] == "Y")
                        {
                            //success
                            txtMsg.Text += "開單成功" + aryReturn[1] + "\r\n";                            
                        }
                        else
                        {
                            //fail
                            txtMsg.Text += "開單失敗" + aryReturn[1] + "\r\n";
                        }
                        txtMsg.SelectionStart =txtMsg.Text.Length;
                        txtMsg.ScrollToCaret();
                    }
                }
            }
            catch (Exception ex)
            {
                txtMsg.Text += "Error:" + ex.Message;
                txtMsg.SelectionStart = txtMsg.Text.Length;
                txtMsg.ScrollToCaret();
            }
        }

        private void txtWebServiceURL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
