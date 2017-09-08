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
using System.Xml.Linq;

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

            StringBuilder requestString = new StringBuilder();

            //Query string?
            if (uriOption.IsThereQuery == true)
            {
                requestString.Append("?");

                Parameter lastOne = uriOption.Parameters.Last();
                foreach( var param in uriOption.Parameters)
                {
                    if (param.PreQuery)
                    {
                        requestString.Insert(0, param.Value);
                    }

                    requestString.Append(param.Name);
                    requestString.Append("=");
                    if (param != lastOne)
                    {
                        requestString.Append("&");
                    }
                }
            }
            else
            {
                requestString.Append(uriOption.Parameters.FirstOrDefault().Value);
            }

            // prepend Uri
            requestString.Insert(0, uriOption.Name);
            // prepend Web Service
            requestString.Insert(0, webService);
            // prepend Environment
            requestString.Insert(0, environment);

            return requestString.ToString();
        }

        public string SendRequest(string uri, string companyLoginID, string userName, string password)
        {
            // Create HTTP GET request using driver web service
            var request = WebRequest.Create(uri);
            request.Method = "GET";
            // Create authorization header (replace these values with actual credentials)

            string auth = companyLoginID + "|" + userName + ":" + password;
            string authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));
            request.Headers["Authorization"] = authHeader;
            // Request response from web service
            string strResponse = null;

            try
            {
                var httpWebResponse = (HttpWebResponse)request.GetResponse();
                // Get response as string
                var responseEncoding = System.Text.Encoding.GetEncoding(httpWebResponse.CharacterSet);
                using (System.IO.StreamReader reader = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), responseEncoding))
                {
                    XDocument xmlDoc = new XDocument();
                    try
                    {
                        xmlDoc = XDocument.Parse(reader.ReadToEnd());

                    }
                    catch( Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    strResponse = xmlDoc.ToString();
                }
                Console.WriteLine(strResponse);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return strResponse;
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
