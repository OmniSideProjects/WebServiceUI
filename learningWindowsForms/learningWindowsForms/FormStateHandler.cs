using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using learningWindowsForms.DAL.Repositories;
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
        //private IRepo_WebServiceParameters _repo;
        //TODO: create interface for easy database swap out
        private RequestRepository _repo;

        public FormStateHandler()
        {
            _repo = new RequestRepository();
        }

        public List<Request> GetAvailableRequests()
        {
            return _repo.GetAllRequestsWithUriOptionsAndParameters();
        }

        public void SetComboBoxes(ComboBox comboBoxEnvironments, ComboBox comboboxWebServices, ComboBox comboxUri, List<Request> allRequests)
        {
            //Environments
            comboBoxEnvironments.Items.Insert(0, "https://ws.xataxrs.com"); //production
            comboBoxEnvironments.Items.Insert(1, "https://a1ws.xataxrs.com"); // alpha
            comboBoxEnvironments.SelectedIndex = 0; // defaults to production


            //Web Services
            comboboxWebServices.Items.Insert(0, "--Select--");
            comboboxWebServices.SelectedIndex = 0;
            foreach (var item in allRequests)
            {
                comboboxWebServices.Items.Add(item.Name);
            }

            //Set initial values of uri combo box
            comboxUri.Items.Insert(0, "--Select--");
            comboxUri.SelectedIndex = 0;
        }

        public void SetUricomboBox(Label uriLabel, ComboBox combox_uri, List<UriOption> selections)
        {
            combox_uri.Items.Insert(0, "--Select--");
            combox_uri.SelectedIndex = 0;
            foreach (var item in selections)
            {
                combox_uri.Items.Add(item.Name);
            }
            uriLabel.Visible = true;
            combox_uri.Visible = true;
        }

        public string CreateRequestUrl(string environment, string webService, UriOption uriOption, Panel parameterPanel)
        {
            //TODO add ability to take in different environments (create drop down list to the left of web service drop down list

            //Create IEnumerable of TextBoxes
            IEnumerable<TextBox> textBoxes = parameterPanel.Controls.OfType<TextBox>();

            //Transfer textBox values to UriOption Parameters.Value because the Parameters have properties related to how the query string is created
            uriOption.Parameters.ForEach(param => param.Value = textBoxes.Where(tb => tb.Name == param.Name).Select(txb => txb.Text).SingleOrDefault());

            //Same thing, more verbous
            //foreach (Parameter param in uriOption.Parameters)
            //{
            //    param.Value = textBoxes.Where(txtBx => txtBx.Name == param.Name).Select(x => x.Text).SingleOrDefault();
            //}


            //UriOption may need the IsQueryString property and not the Parameter
            //Be sure to persist any model changes to the BaseRepository Table creation and data load methods

            StringBuilder sb = new StringBuilder();
            //Environment
            sb.Append(environment);
            //Web Service
            sb.Append(webService);
            //Uri
            sb.Append(uriOption.Name);

            StringBuilder queryStr = new StringBuilder();
            foreach (Parameter param in uriOption.Parameters)
            {
                //If there is no query, then there is only one parameter (PreQuery=true)
                //if (param.IsThereQuery)
                //{
                //    queryStr.Append("?");
                //}

                //if (param.PreQuery)
                //{
                //    queryStr.Insert(0, param.Value);
                //}

                //queryStr.Append(param.Name);
                //queryStr.Append()
                //if (param.PreQuery)
                //{
                //    if (!param.IsThereQuery)
                //    {
                //        queryStr.Append(param.Value);
                //        break;
                //    }
                //    queryStr.Append(param.Value);
                //    queryStr.Append("?");
                //}

            }


            return string.Empty;
        }

        public void SendRequest(string environment, string webService, UriOption uriOption, Panel parameterPanel, string companyLoginID, string username, string password)
        {
            string url = CreateRequestUrl(environment, webService, uriOption, parameterPanel);

            //Create request with credentials, password, return type (JSON or XML)

            // Call method to display response data (needs to be made)
            
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
                    firstLabel.Size = new Size(100, 20);
                    firstLabel.Name = item.Name;
                    firstLabel.Text = item.Name;
                    panel.Controls.Add(firstLabel);

                    TextBox firstTextbox = new TextBox();
                    firstTextbox.Location = new Point(110, 6);
                    firstTextbox.Size = new Size(99, 20);
                    firstTextbox.Name = item.Name;
                    panel.Controls.Add(firstTextbox);

                    continue;
                }

                Label label = new Label();
                int labelCount = panel.Controls.OfType<Label>().ToList().Count;
                label.Location = new Point(3, verticalSpaceLabel);       //(25 * labelCount) + 5);
                label.Size = new Size(100, 13);
                label.Name = item.Name;
                label.Text = item.Name;
                panel.Controls.Add(label);
                verticalSpaceLabel += 26;

                TextBox textbox = new TextBox();
                int textBxCount = panel.Controls.OfType<TextBox>().ToList().Count;
                textbox.Location = new Point(110, verticalPaceTexbox); // (25 * textBxCount) + 3);
                textbox.Size = new Size(99, 20);
                textbox.Name = item.Name;
                panel.Controls.Add(textbox);
                verticalPaceTexbox += 26;

            }
        }

        #region Old repo access (Repository_WebService)
        //public List<string> GetAvailableWebServices()
        //{
        //    return _repo.AvailableWebServices();
        //}

        //public List<string> GetAllDriverParameters()
        //{
        //    return _repo.GetAllDriversParameters();
        //}

        //public Request GetDriverWebService()
        //{
        //    return _repo.DriverWebService();
        //}

        //public void SetTextboxValue(TextBox input, CheckBox whatever)
        //{
        //    if (whatever.Checked == true)
        //    {
        //        input.Text = "Checked";
        //    }
        //    else
        //    {
        //        input.Text = "Not Checked";
        //    }
        //}
        #endregion
    }
}
