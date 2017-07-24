using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using learningWindowsForms.Interfaces;
using System.Drawing;
using learningWindowsForms.Models;
using System.Net;

namespace learningWindowsForms
{
    public class FormStateHandler
    {
        private IRepo_WebServiceParameters _repo;

        public FormStateHandler()
        {
            _repo = new Repository_WebService();
        }


        public void SetComboBoxes(ComboBox comboboxWebServices, ComboBox comboxUri)
        {
            comboboxWebServices.Items.Insert(0, "--Select--");
            comboboxWebServices.SelectedIndex = 0;
            var allWebServices = _repo.AvailableWebServices();
            foreach (var item in allWebServices)
            {
                comboboxWebServices.Items.Add(item);
            }

            comboxUri.Items.Insert(0, "--Select--");
            comboxUri.SelectedIndex = 0;
        }

        public void SetUricomboBox(Label uriLabel, ComboBox combox_uri, List<UriOption> selections)
        {
            //combox_uri.Items.Insert(0, "--Select--");
            //combox_uri.SelectedIndex = 0;
            foreach(var item in selections)
            {
                combox_uri.Items.Add(item.Name);
            }
            uriLabel.Visible = true;
            combox_uri.Visible = true;
        }

        public void CreateRequest(UriOption uri, string companyLoginID, string username, string password)
        {

        }

        public void SendRequest(Panel parameterPanel, string companyLoginID, string username, string password, string webService, string uri)
        {
            

            StringBuilder sb = new StringBuilder();
            string urlUri = @"https://ws.xataxrs.com" + webService + uri;
            //string queryString = string.Join()
            
            // I think our model will need to be more complexe to account for all the variations in query strings
        }

        public void CreateForm(List<Parameter> parameters, Panel panel)
        {
            panel.Controls.Clear();

            int verticalSpaceLabel = 35;
            int verticalPaceTexbox = 32;

            foreach (var item in parameters)
            {
                if (parameters.First() == item)
                {
                    Label firstLabel = new Label();
                    firstLabel.Location = new Point(3, 9);
                    firstLabel.Size = new Size(80, 13);
                    firstLabel.Name = item.Name;
                    firstLabel.Text = item.Name;
                    panel.Controls.Add(firstLabel);

                    TextBox firstTextbox = new TextBox();
                    firstTextbox.Location = new System.Drawing.Point(99, 6);
                    firstTextbox.Size = new System.Drawing.Size(99, 20);
                    firstTextbox.Name = "textbox_" + item;
                    panel.Controls.Add(firstTextbox);

                    continue;
                }

                Label label = new Label();
                int labelCount = panel.Controls.OfType<Label>().ToList().Count;
                label.Location = new Point(3, verticalSpaceLabel);       //(25 * labelCount) + 5);
                label.Size = new Size(77, 13);
                label.Name = item.Name;
                label.Text = item.Name;
                panel.Controls.Add(label);
                verticalSpaceLabel += 26;

                TextBox textbox = new TextBox();
                int textBxCount = panel.Controls.OfType<TextBox>().ToList().Count;
                textbox.Location = new System.Drawing.Point(99, verticalPaceTexbox); // (25 * textBxCount) + 3);
                textbox.Size = new System.Drawing.Size(99, 20);
                textbox.Name = "textbox_" + item;
                panel.Controls.Add(textbox);
                verticalPaceTexbox += 26;

            }
        }

        public List<string> GetAvailableWebServices()
        {
            return _repo.AvailableWebServices();
        }

        public List<string> GetAllDriverParameters()
        {
            return _repo.GetAllDriversParameters();
        }

        public WebServiceRequest GetDriverWebService()
        {
            return _repo.DriverWebService();
        }

        public void SetTextboxValue(TextBox input, CheckBox whatever)
        {
            if (whatever.Checked == true)
            {
                input.Text = "Checked";
            }
            else
            {
                input.Text = "Not Checked";
            }
        }


    }
}
