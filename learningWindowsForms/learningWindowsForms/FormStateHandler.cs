using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using learningWindowsForms.Interfaces;
using System.Drawing;
using learningWindowsForms.Models;
namespace learningWindowsForms
{
    public class FormStateHandler
    {
        private IRepo_WebServiceParameters _repo;

        public FormStateHandler()
        {
            _repo = new Repo_WebServiceParameters();
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


        public void CreateForm(List<string> parameters, Panel panel)
        {
            panel.Controls.Clear();

            int iterations = parameters.Count;

            for(int i = 0; i < iterations; i++)
            {

            }

            foreach (var item in parameters)
            {
                Label label = new Label();
                int labelCount = panel.Controls.OfType<Label>().ToList().Count;
                label.Location = new Point(3, (25 * labelCount) + 5);
                label.Size = new Size(77, 13);
                label.Name = item;
                label.Text = item;
                panel.Controls.Add(label);

                TextBox textbox = new TextBox();
                int textBxCount = panel.Controls.OfType<TextBox>().ToList().Count;
                textbox.Location = new System.Drawing.Point(98, (25 * textBxCount) + 3);
                textbox.Size = new System.Drawing.Size(100, 20);
                textbox.Name = "textbox_" + item;
                panel.Controls.Add(textbox);

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

        public WebService GetDriverWebService()
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
