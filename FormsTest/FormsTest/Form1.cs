using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsTest
{
    public partial class Form1 : Form
    {
        //list of variables
        public string _fileName = "";
        private List<string> _templateCodeData = new List<string>();
        private List<int> templateResponseNo = new List<int>();

        public Form1()
        {
            InitializeComponent();
            //Bringing in the methods for building the templates, template codes and responses woould go here
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void boxUpdate()
        {
            //Clears form boxes
            //TODO - Find a better way to clear all reusable form controls
            templateCodeComboBox.Items.Clear();
            responsesComboBox.Items.Clear();
            //Poopulates a combobox will all the template sections in the data file
            for (var i = 0; i < _templateCodeData.Count; i++)
            {
                //Gets first item in string, adds to combobox
                templateCodeComboBox.Items.Add(_templateCodeData[i].Split(',').First());
                string subjectString = _templateCodeData[i].ToString();
                //DEBUG populates a listBox with the number of responses attached to the template code
                string resultString = Regex.Match(subjectString, @"\d+").Value;
                templateResponseNo.Add(Int32.Parse(resultString));
                listBox1.Items.Add(resultString);
            }
        }

        //Read contents of response file and append them to _responseList list
        private void ReadFile(string _fileName)
        {
            try
            {
                StreamReader reader = new
                    StreamReader(_fileName);
                string dataToAppend;

                while (!reader.EndOfStream)
                {
                    dataToAppend = reader.ReadLine();

                    if (dataToAppend.Length > 0)
                    {
                                _templateCodeData.Add(dataToAppend);
                    }
                }

                reader.Close();
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("File {0} not found. {1}", _fileName, e.Message);
            }


            catch (IOException e)
            {
                Console.WriteLine("Generic file exception {0}", e.Message);
            }
        }

        /*
        //Didn't get this working yet, will be necessary if new radioboxes are being created on the fly.

        public void checkBoxChange(object sender)
        {
            RadioButton btn = sender as RadioButton;
            if (btn != null && btn.Checked)
            {
                switch (btn.Name)
                {
                    case "rbtn1":
                        textBox1.Text = responses[0].Message;
                        break;
                    case "rbtn2":
                        textBox1.Text = responses[1].Message;
                        break;
                    case "rbtn3":
                        textBox1.Text = responses[2].Message;
                        break;
                }
            }
        }
        */

        private void templateCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            responsesComboBox.Items.Clear();
            int i = templateCodeComboBox.SelectedIndex;
            //Create a list containing all elements past the number. TODO - replace number with UID for use across multiple templates
            List<string> responses = _templateCodeData[i].Split(',').Skip(2).ToList();
            //Populates combo box with responses. TODO - Create RadioButtons instead
            foreach (string item in responses)
            {
                responsesComboBox.Items.Add(item);
            }
        }

        //TODO - Replace this with RadioButton stuff. Will need to play around in the designer.cs for this?
        private void responsesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pastes whatever's in the responses combo box into a rich text box. 
            //Could have a warning for if user has added free comment to response and chooses new response?
            richTextBox1.Text = responsesComboBox.Text;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens the load file dialog
            //TODO - Ask user confirmation before clearing lists
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Grabs the filename when the user clicks "OK"
                _fileName = openFileDialog1.FileName;
                //Cool thing that changes the form name at the top to the file name. Could take this and append to saved file names
                Form.ActiveForm.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                _templateCodeData.Clear();
                ReadFile(_fileName);
                boxUpdate();
            }
            

        }
    }
}
