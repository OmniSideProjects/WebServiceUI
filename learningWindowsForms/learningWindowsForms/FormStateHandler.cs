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
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace learningWindowsForms
{
    public class FormStateHandler
    {
        //private IRepo_WebServiceParameters _repo;
        //TODO: create interface for easy database swap out
        //TODO: create process for updating database from
        private RequestRepository _repo;
        private static HttpClient _client;

        public FormStateHandler()
        {
            _repo = new RequestRepository();
            _client = new HttpClient();
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

            //Create IEnumerable of TextBoxes
            IEnumerable<TextBox> textBoxes = parameterPanel.Controls.OfType<TextBox>();

            //Transfer textBox values to UriOption Parameters.Value because the Parameters have properties related to how the query string is created
            uriOption.Parameters.ForEach(param => param.Value = textBoxes.Where(tb => tb.Name == param.Name).Select(txb => txb.Text).SingleOrDefault());

            //Same thing, more verbous
            //foreach (Parameter param in uriOption.Parameters)
            //{
            //    param.Value = textBoxes.Where(txtBx => txtBx.Name == param.Name).Select(x => x.Text).SingleOrDefault();
            //}


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
                    if (param.Value != "")
                    {
                        requestString.Append(param.Name);
                        requestString.Append("=");
                        if (param != lastOne)
                        {
                            requestString.Append("&");
                        }

                        requestString.Append(param.Value);

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

        public async Task<WSResponse> SendRequestAsync(string uri, string companyLoginID, string userName, string password, string contentType)
        {
            WSResponse result = new WSResponse();
            //Set authorization for request
            string auth = companyLoginID + "|" + userName + ":" + password;
            var byteArray = Encoding.ASCII.GetBytes(auth);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            //TODO: Make this to take in a parameter to set the return type
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));


            try
            {
                using (HttpResponseMessage response = await _client.GetAsync(new Uri(uri)))
                {
                    using (HttpContent content = response.Content)
                    {
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        HttpStatusCode code = response.StatusCode;

                        StringBuilder sb = new StringBuilder();
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        settings.IndentChars = "      ";
                        settings.OmitXmlDeclaration = true;


                        using(XmlWriter xw = XmlWriter.Create(sb, settings))
                        {
                            XDocument xmlDoc = XDocument.Parse(resultString);

                            xmlDoc.WriteTo(xw);
                        }

                        if (contentType == "application/json")
                        {
                            XDocument jsonDoc = XDocument.Parse(sb.ToString());
                            string json = JsonConvert.SerializeXNode(jsonDoc);
                            var formatJSON = JValue.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);
                            result.Result = formatJSON;
                        }
                        else
                        {
                            result.Result = sb.ToString();
                        }

                        result.ReasonPhase = reasonPhrase;
                        result.Headers = headers;
                        result.StatusCode = code;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
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
                strResponse = e.Message;
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
