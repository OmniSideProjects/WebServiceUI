namespace learningWindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_CompanyID = new System.Windows.Forms.Label();
            this.textBox_companyID = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.texBox_password = new System.Windows.Forms.TextBox();
            this.label_webService = new System.Windows.Forms.Label();
            this.comboBox_webService = new System.Windows.Forms.ComboBox();
            this.parameterPanel = new System.Windows.Forms.Panel();
            this.label_uri = new System.Windows.Forms.Label();
            this.comboBox_uri = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_createRequest = new System.Windows.Forms.Button();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.comboBox_Environments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_CompanyID
            // 
            this.label_CompanyID.AutoSize = true;
            this.label_CompanyID.Location = new System.Drawing.Point(7, 9);
            this.label_CompanyID.Name = "label_CompanyID";
            this.label_CompanyID.Size = new System.Drawing.Size(94, 13);
            this.label_CompanyID.TabIndex = 0;
            this.label_CompanyID.Text = "Company Login ID";
            // 
            // textBox_companyID
            // 
            this.textBox_companyID.Location = new System.Drawing.Point(103, 6);
            this.textBox_companyID.Name = "textBox_companyID";
            this.textBox_companyID.Size = new System.Drawing.Size(123, 20);
            this.textBox_companyID.TabIndex = 1;
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(232, 9);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(55, 13);
            this.label_Username.TabIndex = 2;
            this.label_Username.Text = "Username";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(307, 6);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 20);
            this.textBox_username.TabIndex = 3;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(444, 9);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 4;
            this.label_Password.Text = "Password";
            // 
            // texBox_password
            // 
            this.texBox_password.Location = new System.Drawing.Point(503, 6);
            this.texBox_password.Name = "texBox_password";
            this.texBox_password.Size = new System.Drawing.Size(100, 20);
            this.texBox_password.TabIndex = 5;
            // 
            // label_webService
            // 
            this.label_webService.AutoSize = true;
            this.label_webService.Location = new System.Drawing.Point(232, 36);
            this.label_webService.Name = "label_webService";
            this.label_webService.Size = new System.Drawing.Size(69, 13);
            this.label_webService.TabIndex = 6;
            this.label_webService.Text = "Web Service";
            // 
            // comboBox_webService
            // 
            this.comboBox_webService.FormattingEnabled = true;
            this.comboBox_webService.Location = new System.Drawing.Point(307, 32);
            this.comboBox_webService.Name = "comboBox_webService";
            this.comboBox_webService.Size = new System.Drawing.Size(164, 21);
            this.comboBox_webService.TabIndex = 7;
            this.comboBox_webService.SelectedIndexChanged += new System.EventHandler(this.comboBox_webService_SelectedIndexChanged);
            // 
            // parameterPanel
            // 
            this.parameterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parameterPanel.Location = new System.Drawing.Point(10, 85);
            this.parameterPanel.Name = "parameterPanel";
            this.parameterPanel.Size = new System.Drawing.Size(216, 406);
            this.parameterPanel.TabIndex = 8;
            // 
            // label_uri
            // 
            this.label_uri.AutoSize = true;
            this.label_uri.Location = new System.Drawing.Point(477, 35);
            this.label_uri.Name = "label_uri";
            this.label_uri.Size = new System.Drawing.Size(20, 13);
            this.label_uri.TabIndex = 9;
            this.label_uri.Text = "Uri";
            // 
            // comboBox_uri
            // 
            this.comboBox_uri.FormattingEnabled = true;
            this.comboBox_uri.Location = new System.Drawing.Point(503, 32);
            this.comboBox_uri.Name = "comboBox_uri";
            this.comboBox_uri.Size = new System.Drawing.Size(130, 21);
            this.comboBox_uri.TabIndex = 10;
            this.comboBox_uri.SelectedIndexChanged += new System.EventHandler(this.comboBox_uri_SelectedIndexChanged);
            // 
            // button_Send
            // 
            this.button_Send.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Send.Location = new System.Drawing.Point(849, 32);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(114, 21);
            this.button_Send.TabIndex = 11;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = false;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_createRequest
            // 
            this.button_createRequest.BackColor = System.Drawing.Color.DarkOrange;
            this.button_createRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_createRequest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_createRequest.Location = new System.Drawing.Point(729, 32);
            this.button_createRequest.Name = "button_createRequest";
            this.button_createRequest.Size = new System.Drawing.Size(114, 21);
            this.button_createRequest.TabIndex = 12;
            this.button_createRequest.Text = "Create Request";
            this.button_createRequest.UseVisualStyleBackColor = false;
            this.button_createRequest.Visible = false;
            this.button_createRequest.Click += new System.EventHandler(this.button_createRequest_Click);
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(10, 59);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(953, 20);
            this.textBox_url.TabIndex = 13;
            this.textBox_url.Visible = false;
            // 
            // comboBox_Environments
            // 
            this.comboBox_Environments.FormattingEnabled = true;
            this.comboBox_Environments.Location = new System.Drawing.Point(74, 33);
            this.comboBox_Environments.Name = "comboBox_Environments";
            this.comboBox_Environments.Size = new System.Drawing.Size(152, 21);
            this.comboBox_Environments.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Environment";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 503);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Environments);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.button_createRequest);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.comboBox_uri);
            this.Controls.Add(this.label_uri);
            this.Controls.Add(this.parameterPanel);
            this.Controls.Add(this.comboBox_webService);
            this.Controls.Add(this.label_webService);
            this.Controls.Add(this.texBox_password);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label_Username);
            this.Controls.Add(this.textBox_companyID);
            this.Controls.Add(this.label_CompanyID);
            this.Name = "Form1";
            this.Text = "Web Service UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CompanyID;
        private System.Windows.Forms.TextBox textBox_companyID;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox texBox_password;
        private System.Windows.Forms.Label label_webService;
        private System.Windows.Forms.ComboBox comboBox_webService;
        private System.Windows.Forms.Panel parameterPanel;
        private System.Windows.Forms.Label label_uri;
        private System.Windows.Forms.ComboBox comboBox_uri;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_createRequest;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.ComboBox comboBox_Environments;
        private System.Windows.Forms.Label label1;
    }
}

