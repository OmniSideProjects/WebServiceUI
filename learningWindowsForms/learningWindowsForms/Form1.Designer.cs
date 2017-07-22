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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limitBox = new System.Windows.Forms.TextBox();
            this.Limit = new System.Windows.Forms.Label();
            this.organizationIdBox = new System.Windows.Forms.TextBox();
            this.OrganizationID = new System.Windows.Forms.Label();
            this.AsOfDateTime = new System.Windows.Forms.Label();
            this.asOfDateTimeBox = new System.Windows.Forms.TextBox();
            this.label_uri = new System.Windows.Forms.Label();
            this.comboBox_uri = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.parameterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_CompanyID
            // 
            this.label_CompanyID.AutoSize = true;
            this.label_CompanyID.Location = new System.Drawing.Point(12, 32);
            this.label_CompanyID.Name = "label_CompanyID";
            this.label_CompanyID.Size = new System.Drawing.Size(97, 13);
            this.label_CompanyID.TabIndex = 0;
            this.label_CompanyID.Text = "Company Login ID:";
            // 
            // textBox_companyID
            // 
            this.textBox_companyID.Location = new System.Drawing.Point(115, 29);
            this.textBox_companyID.Name = "textBox_companyID";
            this.textBox_companyID.Size = new System.Drawing.Size(100, 20);
            this.textBox_companyID.TabIndex = 1;
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(221, 32);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(58, 13);
            this.label_Username.TabIndex = 2;
            this.label_Username.Text = "Username:";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(285, 29);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 20);
            this.textBox_username.TabIndex = 3;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(391, 32);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(56, 13);
            this.label_Password.TabIndex = 4;
            this.label_Password.Text = "Password:";
            // 
            // texBox_password
            // 
            this.texBox_password.Location = new System.Drawing.Point(453, 29);
            this.texBox_password.Name = "texBox_password";
            this.texBox_password.Size = new System.Drawing.Size(100, 20);
            this.texBox_password.TabIndex = 5;
            // 
            // label_webService
            // 
            this.label_webService.AutoSize = true;
            this.label_webService.Location = new System.Drawing.Point(559, 32);
            this.label_webService.Name = "label_webService";
            this.label_webService.Size = new System.Drawing.Size(72, 13);
            this.label_webService.TabIndex = 6;
            this.label_webService.Text = "Web Service:";
            // 
            // comboBox_webService
            // 
            this.comboBox_webService.FormattingEnabled = true;
            this.comboBox_webService.Location = new System.Drawing.Point(637, 29);
            this.comboBox_webService.Name = "comboBox_webService";
            this.comboBox_webService.Size = new System.Drawing.Size(166, 21);
            this.comboBox_webService.TabIndex = 7;
            this.comboBox_webService.SelectedIndexChanged += new System.EventHandler(this.comboBox_webService_SelectedIndexChanged);
            // 
            // parameterPanel
            // 
            this.parameterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parameterPanel.Controls.Add(this.textBox1);
            this.parameterPanel.Controls.Add(this.label1);
            this.parameterPanel.Controls.Add(this.limitBox);
            this.parameterPanel.Controls.Add(this.Limit);
            this.parameterPanel.Controls.Add(this.organizationIdBox);
            this.parameterPanel.Controls.Add(this.OrganizationID);
            this.parameterPanel.Controls.Add(this.AsOfDateTime);
            this.parameterPanel.Controls.Add(this.asOfDateTimeBox);
            this.parameterPanel.Location = new System.Drawing.Point(15, 97);
            this.parameterPanel.Name = "parameterPanel";
            this.parameterPanel.Size = new System.Drawing.Size(211, 391);
            this.parameterPanel.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // limitBox
            // 
            this.limitBox.Location = new System.Drawing.Point(99, 58);
            this.limitBox.Name = "limitBox";
            this.limitBox.Size = new System.Drawing.Size(99, 20);
            this.limitBox.TabIndex = 6;
            // 
            // Limit
            // 
            this.Limit.AutoSize = true;
            this.Limit.Location = new System.Drawing.Point(3, 61);
            this.Limit.Name = "Limit";
            this.Limit.Size = new System.Drawing.Size(28, 13);
            this.Limit.TabIndex = 5;
            this.Limit.Text = "Limit";
            // 
            // organizationIdBox
            // 
            this.organizationIdBox.Location = new System.Drawing.Point(99, 32);
            this.organizationIdBox.Name = "organizationIdBox";
            this.organizationIdBox.Size = new System.Drawing.Size(99, 20);
            this.organizationIdBox.TabIndex = 4;
            // 
            // OrganizationID
            // 
            this.OrganizationID.AutoSize = true;
            this.OrganizationID.Location = new System.Drawing.Point(3, 35);
            this.OrganizationID.Name = "OrganizationID";
            this.OrganizationID.Size = new System.Drawing.Size(77, 13);
            this.OrganizationID.TabIndex = 3;
            this.OrganizationID.Text = "OrganizationID";
            // 
            // AsOfDateTime
            // 
            this.AsOfDateTime.AutoSize = true;
            this.AsOfDateTime.Location = new System.Drawing.Point(3, 9);
            this.AsOfDateTime.Name = "AsOfDateTime";
            this.AsOfDateTime.Size = new System.Drawing.Size(76, 13);
            this.AsOfDateTime.TabIndex = 2;
            this.AsOfDateTime.Text = "AsOfDateTime";
            // 
            // asOfDateTimeBox
            // 
            this.asOfDateTimeBox.Location = new System.Drawing.Point(99, 6);
            this.asOfDateTimeBox.Name = "asOfDateTimeBox";
            this.asOfDateTimeBox.Size = new System.Drawing.Size(99, 20);
            this.asOfDateTimeBox.TabIndex = 1;
            // 
            // label_uri
            // 
            this.label_uri.AutoSize = true;
            this.label_uri.Location = new System.Drawing.Point(15, 59);
            this.label_uri.Name = "label_uri";
            this.label_uri.Size = new System.Drawing.Size(26, 13);
            this.label_uri.TabIndex = 9;
            this.label_uri.Text = "URI";
            // 
            // comboBox_uri
            // 
            this.comboBox_uri.FormattingEnabled = true;
            this.comboBox_uri.Location = new System.Drawing.Point(60, 59);
            this.comboBox_uri.Name = "comboBox_uri";
            this.comboBox_uri.Size = new System.Drawing.Size(155, 21);
            this.comboBox_uri.TabIndex = 10;
            this.comboBox_uri.SelectedIndexChanged += new System.EventHandler(this.comboBox_uri_SelectedIndexChanged);
            // 
            // button_Send
            // 
            this.button_Send.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Send.Location = new System.Drawing.Point(637, 59);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(166, 21);
            this.button_Send.TabIndex = 11;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = false;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 500);
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
            this.parameterPanel.ResumeLayout(false);
            this.parameterPanel.PerformLayout();
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
        private System.Windows.Forms.TextBox asOfDateTimeBox;
        private System.Windows.Forms.Label AsOfDateTime;
        private System.Windows.Forms.TextBox organizationIdBox;
        private System.Windows.Forms.Label OrganizationID;
        private System.Windows.Forms.Label Limit;
        private System.Windows.Forms.TextBox limitBox;
        private System.Windows.Forms.Label label_uri;
        private System.Windows.Forms.ComboBox comboBox_uri;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Send;
    }
}

