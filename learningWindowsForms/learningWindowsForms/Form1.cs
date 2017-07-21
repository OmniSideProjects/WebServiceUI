﻿using System;
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
        private WebService _currentWebService;
        private UriOption _currentUri;

        FormStateHandler _fsh = new FormStateHandler();
        Repo_WebServiceParameters _repo = new Repo_WebServiceParameters();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _fsh.SetComboBoxes(comboBox_webService, comboBox_uri);
            label_uri.Visible = false;
            comboBox_uri.Visible = false;

        }

        private void comboBox_webService_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedWS = (string)comboBox_webService.SelectedItem;
            switch (selectedWS)
            {
                case "/DriverWebService":
                    var driverWS = _fsh.GetDriverWebService();
                    _currentWebService = driverWS;
                    _fsh.SetUricomboBox(label_uri, comboBox_uri, driverWS.Uris);
                    break;
            }
        }

        private void comboBox_uri_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: this method gets triggered when the form loads and the SetComboBoxes() is called. The other comboBox doesnt, why is this? Why do we need this 'if' statement.
            if(_currentWebService != null)
            {
                var selection = (string)comboBox_uri.SelectedItem;
                var selectedUri = _currentWebService.Uris.Where(x => x.Name == selection).SingleOrDefault();
                _currentUri = selectedUri;
                _fsh.CreateForm(_currentUri.Parameters, parameterPanel);
            }

        }

        private void AsOfDateTime_Click(object sender, EventArgs e)
        {

        }
    }
}