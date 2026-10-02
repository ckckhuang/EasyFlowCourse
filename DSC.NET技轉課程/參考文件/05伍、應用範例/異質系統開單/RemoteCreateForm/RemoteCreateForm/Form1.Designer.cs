namespace RemoteCreateForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtWebServiceURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.btnCreateForm = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNums = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "WebServiceURL";
            // 
            // txtWebServiceURL
            // 
            this.txtWebServiceURL.Location = new System.Drawing.Point(142, 17);
            this.txtWebServiceURL.Name = "txtWebServiceURL";
            this.txtWebServiceURL.Size = new System.Drawing.Size(632, 30);
            this.txtWebServiceURL.TabIndex = 1;
            this.txtWebServiceURL.Text = "http://192.168.1.232/EFNETService/EFERPService.asmx";
            this.txtWebServiceURL.TextChanged += new System.EventHandler(this.txtWebServiceURL_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "發文者";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(142, 53);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(90, 30);
            this.txtEmpID.TabIndex = 3;
            this.txtEmpID.Text = "DS";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(238, 53);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(101, 30);
            this.txtEmpName.TabIndex = 4;
            this.txtEmpName.Text = "管理員";
            // 
            // btnCreateForm
            // 
            this.btnCreateForm.Location = new System.Drawing.Point(637, 151);
            this.btnCreateForm.Name = "btnCreateForm";
            this.btnCreateForm.Size = new System.Drawing.Size(106, 35);
            this.btnCreateForm.TabIndex = 9;
            this.btnCreateForm.Text = "CreateForm";
            this.btnCreateForm.UseVisualStyleBackColor = true;
            this.btnCreateForm.Click += new System.EventHandler(this.btnCreateForm_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMsg.Location = new System.Drawing.Point(142, 116);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(478, 92);
            this.txtMsg.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "WebService Return Msg";
            // 
            // txtNums
            // 
            this.txtNums.Location = new System.Drawing.Point(423, 55);
            this.txtNums.Name = "txtNums";
            this.txtNums.Size = new System.Drawing.Size(57, 30);
            this.txtNums.TabIndex = 13;
            this.txtNums.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "張數";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 218);
            this.Controls.Add(this.txtNums);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnCreateForm);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWebServiceURL);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "異質系統開單";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWebServiceURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Button btnCreateForm;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNums;
        private System.Windows.Forms.Label label6;
    }
}

