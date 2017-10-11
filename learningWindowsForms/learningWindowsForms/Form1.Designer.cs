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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_CompanyID = new System.Windows.Forms.Label();
            this.textBox_companyID = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_webService = new System.Windows.Forms.Label();
            this.comboBox_webService = new System.Windows.Forms.ComboBox();
            this.parameterPanel = new System.Windows.Forms.Panel();
            this.label_uri = new System.Windows.Forms.Label();
            this.comboBox_uri = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.comboBox_Environments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_displayResponse = new System.Windows.Forms.RichTextBox();
            this.label_url = new System.Windows.Forms.Label();
            this.label_acceptType = new System.Windows.Forms.Label();
            this.radioButton_XML = new System.Windows.Forms.RadioButton();
            this.radioButton_JSON = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_Status_Value = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.label_Count_Value = new System.Windows.Forms.Label();
            this.label_Count_Description = new System.Windows.Forms.Label();
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
            this.textBox_username.Size = new System.Drawing.Size(131, 20);
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
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(503, 6);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(130, 20);
            this.textBox_password.TabIndex = 5;
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
            this.comboBox_webService.Location = new System.Drawing.Point(307, 31);
            this.comboBox_webService.Name = "comboBox_webService";
            this.comboBox_webService.Size = new System.Drawing.Size(201, 21);
            this.comboBox_webService.TabIndex = 7;
            this.comboBox_webService.SelectedIndexChanged += new System.EventHandler(this.comboBox_webService_SelectedIndexChanged);
            // 
            // parameterPanel
            // 
            this.parameterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parameterPanel.Location = new System.Drawing.Point(10, 111);
            this.parameterPanel.Name = "parameterPanel";
            this.parameterPanel.Size = new System.Drawing.Size(216, 501);
            this.parameterPanel.TabIndex = 8;
            // 
            // label_uri
            // 
            this.label_uri.AutoSize = true;
            this.label_uri.Location = new System.Drawing.Point(514, 34);
            this.label_uri.Name = "label_uri";
            this.label_uri.Size = new System.Drawing.Size(20, 13);
            this.label_uri.TabIndex = 9;
            this.label_uri.Text = "Uri";
            // 
            // comboBox_uri
            // 
            this.comboBox_uri.FormattingEnabled = true;
            this.comboBox_uri.Location = new System.Drawing.Point(540, 31);
            this.comboBox_uri.Name = "comboBox_uri";
            this.comboBox_uri.Size = new System.Drawing.Size(220, 21);
            this.comboBox_uri.TabIndex = 10;
            this.comboBox_uri.SelectedIndexChanged += new System.EventHandler(this.comboBox_uri_SelectedIndexChanged);
            // 
            // button_Send
            // 
            this.button_Send.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_Send.Enabled = false;
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Send.Location = new System.Drawing.Point(766, 31);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(197, 21);
            this.button_Send.TabIndex = 11;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = false;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // textBox_url
            // 
            this.textBox_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_url.Location = new System.Drawing.Point(43, 59);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.ReadOnly = true;
            this.textBox_url.Size = new System.Drawing.Size(920, 20);
            this.textBox_url.TabIndex = 13;
            // 
            // comboBox_Environments
            // 
            this.comboBox_Environments.FormattingEnabled = true;
            this.comboBox_Environments.Location = new System.Drawing.Point(74, 31);
            this.comboBox_Environments.Name = "comboBox_Environments";
            this.comboBox_Environments.Size = new System.Drawing.Size(152, 21);
            this.comboBox_Environments.TabIndex = 14;
            this.comboBox_Environments.SelectedIndexChanged += new System.EventHandler(this.comboBox_Environments_SelectedIndexChanged);
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
            // richTextBox_displayResponse
            // 
            this.richTextBox_displayResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_displayResponse.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox_displayResponse.Location = new System.Drawing.Point(232, 111);
            this.richTextBox_displayResponse.Name = "richTextBox_displayResponse";
            this.richTextBox_displayResponse.ReadOnly = true;
            this.richTextBox_displayResponse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox_displayResponse.Size = new System.Drawing.Size(731, 501);
            this.richTextBox_displayResponse.TabIndex = 16;
            this.richTextBox_displayResponse.Text = "";
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(7, 61);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(29, 13);
            this.label_url.TabIndex = 17;
            this.label_url.Text = "URL";
            // 
            // label_acceptType
            // 
            this.label_acceptType.AutoSize = true;
            this.label_acceptType.Location = new System.Drawing.Point(639, 8);
            this.label_acceptType.Name = "label_acceptType";
            this.label_acceptType.Size = new System.Drawing.Size(68, 13);
            this.label_acceptType.TabIndex = 18;
            this.label_acceptType.Text = "Accept Type";
            // 
            // radioButton_XML
            // 
            this.radioButton_XML.AutoSize = true;
            this.radioButton_XML.Checked = true;
            this.radioButton_XML.Location = new System.Drawing.Point(713, 7);
            this.radioButton_XML.Name = "radioButton_XML";
            this.radioButton_XML.Size = new System.Drawing.Size(47, 17);
            this.radioButton_XML.TabIndex = 19;
            this.radioButton_XML.TabStop = true;
            this.radioButton_XML.Text = "XML";
            this.radioButton_XML.UseVisualStyleBackColor = true;
            this.radioButton_XML.CheckedChanged += new System.EventHandler(this.radioButton_XML_CheckedChanged);
            // 
            // radioButton_JSON
            // 
            this.radioButton_JSON.AutoSize = true;
            this.radioButton_JSON.Location = new System.Drawing.Point(766, 7);
            this.radioButton_JSON.Name = "radioButton_JSON";
            this.radioButton_JSON.Size = new System.Drawing.Size(53, 17);
            this.radioButton_JSON.TabIndex = 20;
            this.radioButton_JSON.Text = "JSON";
            this.radioButton_JSON.UseVisualStyleBackColor = true;
            this.radioButton_JSON.CheckedChanged += new System.EventHandler(this.radioButton_JSON_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(553, 317);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Visible = false;
            // 
            // label_Status_Value
            // 
            this.label_Status_Value.Location = new System.Drawing.Point(809, 88);
            this.label_Status_Value.Name = "label_Status_Value";
            this.label_Status_Value.Size = new System.Drawing.Size(150, 13);
            this.label_Status_Value.TabIndex = 24;
            this.label_Status_Value.Text = "value";
            this.label_Status_Value.UseCompatibleTextRendering = true;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(763, 88);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(40, 13);
            this.label_Status.TabIndex = 25;
            this.label_Status.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Parameters ( * required)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(845, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Request Method:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(931, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "GET";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Search Data";
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(307, 85);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(131, 20);
            this.textSearch.TabIndex = 32;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(444, 84);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 21);
            this.button_Search.TabIndex = 33;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_Count_Value
            // 
            this.label_Count_Value.AutoSize = true;
            this.label_Count_Value.Location = new System.Drawing.Point(537, 88);
            this.label_Count_Value.Name = "label_Count_Value";
            this.label_Count_Value.Size = new System.Drawing.Size(33, 13);
            this.label_Count_Value.TabIndex = 34;
            this.label_Count_Value.Text = "value";
            // 
            // label_Count_Description
            // 
            this.label_Count_Description.AutoSize = true;
            this.label_Count_Description.Location = new System.Drawing.Point(576, 88);
            this.label_Count_Description.Name = "label_Count_Description";
            this.label_Count_Description.Size = new System.Drawing.Size(65, 13);
            this.label_Count_Description.TabIndex = 35;
            this.label_Count_Description.Text = "Occurences";
            this.label_Count_Description.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 621);
            this.Controls.Add(this.label_Count_Description);
            this.Controls.Add(this.label_Count_Value);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_Status_Value);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButton_JSON);
            this.Controls.Add(this.radioButton_XML);
            this.Controls.Add(this.label_acceptType);
            this.Controls.Add(this.label_url);
            this.Controls.Add(this.richTextBox_displayResponse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Environments);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.comboBox_uri);
            this.Controls.Add(this.label_uri);
            this.Controls.Add(this.parameterPanel);
            this.Controls.Add(this.comboBox_webService);
            this.Controls.Add(this.label_webService);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label_Username);
            this.Controls.Add(this.textBox_companyID);
            this.Controls.Add(this.label_CompanyID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_webService;
        private System.Windows.Forms.ComboBox comboBox_webService;
        private System.Windows.Forms.Panel parameterPanel;
        private System.Windows.Forms.Label label_uri;
        private System.Windows.Forms.ComboBox comboBox_uri;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.ComboBox comboBox_Environments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_displayResponse;
        private System.Windows.Forms.Label label_url;
        private System.Windows.Forms.Label label_acceptType;
        private System.Windows.Forms.RadioButton radioButton_XML;
        private System.Windows.Forms.RadioButton radioButton_JSON;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_Status_Value;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label_Count_Value;
        private System.Windows.Forms.Label label_Count_Description;
    }
}

