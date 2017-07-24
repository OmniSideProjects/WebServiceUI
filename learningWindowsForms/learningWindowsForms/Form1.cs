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
        private WebServiceRequest _currentWebService;
        private UriOption _currentUri;

        FormStateHandler _fsh = new FormStateHandler();
        Repository_WebService _repo = new Repository_WebService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _fsh.SetComboBoxes(comboBox_webService, comboBox_uri);
            label_uri.Visible = false;
            comboBox_uri.Visible = false;
            button_Send.Visible = false;

        }

        private void comboBox_webService_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedWS = (string)comboBox_webService.SelectedItem;

            switch (selectedWS)
            {
                case "--Select--":
                    _currentWebService = null;
                    label_uri.Visible = false;
                    comboBox_uri.Visible = false;
                    comboBox_uri.Items.Clear();
                    break;

                case "/DriverWebService.svc":
                    var driverWS = _fsh.GetDriverWebService();
                    _currentWebService = driverWS;
                    _fsh.SetUricomboBox(label_uri, comboBox_uri, driverWS.Uris);
                    break;
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
            if (_currentWebService != null)
            {
                var selectedUri = _currentWebService.Uris.Where(x => x.Name == selection).SingleOrDefault();
                _currentUri = selectedUri;
                _fsh.CreateForm(_currentUri.Parameters, parameterPanel);
                button_createRequest.Visible = true;
            }

        }

        private void button_createRequest_Click(object sender, EventArgs e)
        {
            button_Send.Visible = true;
        }


        private void button_Send_Click(object sender, EventArgs e)
        {
            //Transfere user input from each parameterPanel textbox to corresponding Uri parameters
            // Create the method in FormStateHandler _fsh.CreateRequest(UriOption uri, string companyLoginID, string username, string password)
        }

    }
}
