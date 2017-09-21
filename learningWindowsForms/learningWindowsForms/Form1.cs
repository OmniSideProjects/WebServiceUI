using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using learningWindowsForms.Models;

namespace learningWindowsForms
{
    public partial class Form1 : Form
    {
        private List<Request> _allRequests;
        private Request _currentWebService;
        private UriOption _currentUri;
        private FormStateHandler _fsh;
        private string _environment;
        private string _contentType;

        public Form1()
        {
            InitializeComponent();

            _allRequests = new List<Request>();
            _currentWebService = new Request();
            _currentUri = new UriOption();
            _fsh = new FormStateHandler();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _allRequests = _fsh.GetAvailableRequests();
            _fsh.SetComboBoxes(comboBox_Environments, comboBox_webService, comboBox_uri, _allRequests);

            _environment = "https://ws.xataxrs.com"; //default value: production
            label_uri.Visible = false;
            comboBox_uri.Visible = false;
            button_Send.Visible = false;
            _contentType = "application/xml";
            label_Status_Value.Visible = false;


        }

        private void comboBox_Environments_SelectedIndexChanged(object sender, EventArgs e)
        {
            _environment = (string)comboBox_Environments.SelectedItem;
        }

        private void comboBox_webService_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedWS = (string)comboBox_webService.SelectedItem;

            if (selectedWS == "--Select--")
            {
                _currentWebService = null;
                _currentUri = null;
                label_uri.Visible = false;
                comboBox_uri.Visible = false;
                comboBox_uri.Items.Clear();
                parameterPanel.Controls.Clear();

            }
            else
            {
                _currentWebService = _allRequests.Where(x => x.Name == selectedWS).SingleOrDefault();
                comboBox_uri.Items.Clear();
                parameterPanel.Controls.Clear();

                _fsh.SetUricomboBox(label_uri, comboBox_uri, _currentWebService.UriOptions);

            }

        }

        // TODO: this method gets triggered when the form loads and the SetComboBoxes() is called. The other comboBox doesnt, why is this? Why do we need this 'if' statement.
        private void comboBox_uri_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = (string)comboBox_uri.SelectedItem;


            if(selection == "--Select--")
            {
                parameterPanel.Controls.Clear();
            }
            else
            {
                _currentUri = _currentWebService.UriOptions.Where(x => x.Name == selection).SingleOrDefault();
                _fsh.CreateForm(_currentUri.Parameters, parameterPanel);
                button_Send.Visible = true;
            }
        }

        private async void button_Send_Click(object sender, EventArgs e)
        {
            textBox_url.Clear();
            richTextBox_displayResponse.Clear();
            label_Status_Value.Visible = false;

            //start the waiting animation
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            button_Send.Visible = false;

            string url = _fsh.CreateRequestUrl(_environment, _currentWebService.Name, _currentUri, parameterPanel);
            textBox_url.Text = " " + url;

            WSResponse result = await _fsh.SendRequestAsync(url, textBox_companyID.Text, textBox_username.Text, textBox_password.Text, _contentType);

            progressBar1.Visible = false;


            string displayString = result.Result; 
            if (result.ErrorMessage != null)
            {
                displayString = result.ErrorMessage;
            }
            richTextBox_displayResponse.Clear();
            richTextBox_displayResponse.Text = displayString;

            label_Status_Value.Text = $"{(int)result.StatusCode} " + result.StatusCode.ToString();
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                label_Status_Value.ForeColor = Color.Blue;
            }
            else
            {
                label_Status_Value.ForeColor = Color.Red;
                label_Status_Value.Visible = true;

                if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Please isolate root cause of '500 Internal Server Error', document URL/parameters used and escalate.");

                }
            }


            //TODO: show size of response
            // This is not working
            //var contentLengthHeader = result.Headers.Single(x => x.Key == "Content-Length"); 
            //label_Size_Value.Text = contentLengthHeader.Value.ToString();

            button_Send.Visible = true;
        }

        private void radioButton_XML_CheckedChanged(object sender, EventArgs e)
        {
            _contentType = "application/xml";
        }

        private void radioButton_JSON_CheckedChanged(object sender, EventArgs e)
        {
            _contentType = "application/json";
        }


    }
}
