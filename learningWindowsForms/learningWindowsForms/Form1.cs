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
                button_createRequest.Visible = false;

            }
            else
            {
                _currentWebService = _allRequests.Where(x => x.Name == selectedWS).SingleOrDefault();
                comboBox_uri.Items.Clear();
                parameterPanel.Controls.Clear();
                button_createRequest.Visible = false;

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
                button_createRequest.Visible = false;
                return;
            }
            else
            {
                _currentUri = _currentWebService.UriOptions.Where(x => x.Name == selection).SingleOrDefault();
                _fsh.CreateForm(_currentUri.Parameters, parameterPanel);
                button_createRequest.Visible = true;
            }

        }

        private void button_createRequest_Click(object sender, EventArgs e)
        {
            //Transfere user input from each parameterPanel textbox to corresponding Uri parameters in _currentUri 
            // Create the logic in FormStateHandler _fsh.CreateRequestUrl(string environment, string webService, UriOption uriOption, Panel parameterPanel).
            // This should return a string which you can then display in the textBox_Url 

            //button_Send.Visible = true;
            textBox_url.Clear();
            string uri = _fsh.CreateRequestUrl(_environment, _currentWebService.Name, _currentUri, parameterPanel);
            textBox_url.Text = uri;
            textBox_url.Visible = true;
            button_Send.Visible = true;

        }


        private void button_Send_Click(object sender, EventArgs e)
        {
            textBox_url.Clear();
            string url = _fsh.CreateRequestUrl(_environment, _currentWebService.Name, _currentUri, parameterPanel);
            textBox_url.Text = url;
            string displayString = _fsh.SendRequest(url, textBox_companyID.Text, textBox_username.Text, textBox_password.Text);
            richTextBox_displayResponse.Text = displayString;
        }


    }
}
