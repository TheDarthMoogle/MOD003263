using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using PdfSharp;
using PdfSharp.Charting;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;

namespace SoftEngProject
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();

            //=========================== TODO ==============================//

            //Create Event Handlers for dynamic toolstrip menu items (DONE?)

            //Use event handlers to populate group box controls (Incomplete - Add Remove Control Button)

            //Methods for users loading database at runtime (or permanent local connection?) (DONE)

            //Integrate login stuff (DONE)

            //Create preview window (DONE)

            //Merge Admin and User into single Form

            //Functions for Creating New Templates

            //Move Form Code into Classes

            //Complete PDF stuff 

            //Complete email stuff

            //Write more testing code

            //Do some more testing

            //Get good grades

            FillAppComboBox(cbxApplicant);
        }

        /*Previously, each new instance of GroupBox, ComboBox, and TextBox was given the exact same name.
          Now each instance will be given an index (gbxIndex), making it possible to
          execute the same function on mutiple instances.
        */
        public int gbxIndex = 0;
        /// <summary>
        /// Each new instance of GroupBox will be added to this list.
        /// </summary>
        public List<GroupBox> gbxList = new List<GroupBox>();
        /// <summary>
        ///  Each new instance of ComboBox will be added to this list.
        /// </summary>
        public List<ComboBox> cbxList = new List<ComboBox>();
        /// <summary>
        ///  Each new instance of TextBox will be added to this list.
        /// </summary>
        public List<TextBox> tbxList = new List<TextBox>();

        DataSet dsTemplate = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelectAll);

        /// <summary>
        /// Used for opening a connection the database to run a SQL query.
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        private SqlDataReader DBQuery(string Query)
        {
            string cnString = Properties.Settings.Default.TemplateDBString;
            SqlConnection connection = new SqlConnection(cnString);
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Populates the ComboBox's drop-down menu with ResponseNames from the Responses table.
        /// </summary>
        void FillComboBox(ComboBox cbxAdd, int groupID)
        {
            SqlDataReader reader = DBQuery("SELECT ResponseName FROM Responses WHERE GroupID = '" + groupID + "'");
            while (reader.Read())
            {
                string responseName = reader.GetString(0);
                cbxAdd.Items.Add(responseName);
            }
        }

        void FillAppComboBox(ComboBox cbxApplicant)
        {
            SqlDataReader reader = DBQuery("SELECT ApplicantID FROM Applicants");
            while (reader.Read())
            {
                string appID = reader.GetString(0);
                cbxApplicant.Items.Add(appID);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable dtTemplate = dsTemplate.Tables[0];

            foreach (DataRow row in dtTemplate.Rows)
            {
                string templateName = row.Field<string>(1);
                //randoBox.Items.Add(templateName);
                BuildToolStripTemplateItems(templateName);
            }

            //dataGridView1.DataSource = dtTemplate;



            //this.comboBoxToAdd.Items.Add("One");
            //this.comboBoxToAdd.Location = new System.Drawing.Point(200, 200);
            //this.comboBoxToAdd.Size = new System.Drawing.Size(130, 95);
            //this.Controls.Add(comboBoxToAdd);
        }

        /// <summary>
        /// Populates the toolstrip with items from the templates Data Table (WIP? Should rewrite queries)
        /// </summary>
        /// <param name="menuItemName"></param>
        private void BuildToolStripTemplateItems(string menuItemName)
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[1];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Name = menuItemName + "ToolStripMenuItem";
                items[i].Tag = i + 1;
                items[i].Text = menuItemName;
                items[i].Click += new EventHandler(MenuItemClickHandler);
            }

            templateToolStripMenuItem1.DropDownItems.AddRange(items);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            DataSet dsResponseGroup = DBConnection.getDBConnectionInstance().getDataSet("SELECT * FROM ResponseGroup WHERE TemplateID  = '" + clickedItem.Tag + "'");

            DataTable dtResponseGroup = dsResponseGroup.Tables[0];

            dataGridView1.DataSource = dtResponseGroup;

            foreach (DataRow row in dtResponseGroup.Rows)
            {
                CreateGroupBox(row.Field<string>(1), row.Field<int>(0));
            }


            /*
            //string selTemplateName = clickedItem.Text.ToString();
            string connectionString = Properties.Settings.Default.TemplateDBString;
            string sqlQuerySelMessage = "SELECT Title FROM ResponseGroup WHERE TemplateID = '" + clickedItem.Tag + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuerySelMessage, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine(reader.GetString(0)); 
            }
            */

            // Take some action based on the data in clickedItem
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void templateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGroupBox("", 0);
        }

        /// <summary>
        /// Creates a new GroupBox underneath the previously created one
        /// </summary>
        private void CreateGroupBox(string gbxName, int groupID)
        {
            gbxList.Add(new GroupBox());
            ResponseGroupBox gbxAdd = new ResponseGroupBox();
            GroupBox lastGroupBox = getLastGroupBox();

            gbxList[gbxIndex].Name = gbxName + "GroupBox";
            gbxList[gbxIndex].BackColor = lastGroupBox.BackColor;
            gbxList[gbxIndex].Text = gbxName;
            gbxList[gbxIndex].Location = new System.Drawing.Point(gbxAdd.X + lastGroupBox.Location.X, gbxAdd.Y + lastGroupBox.Bottom);
            gbxList[gbxIndex].Size = new System.Drawing.Size(gbxAdd.Width, gbxAdd.Height);

            this.Controls.Add(gbxList[gbxIndex]);

            CreateComboBox(gbxList[gbxIndex], groupID);
            CreateTextBox(gbxList[gbxIndex]);
            gbxIndex++;
        }

        private void CreateComboBox(GroupBox gbxAdd, int groupID)
        {
            cbxList.Add(new ComboBox());
            ResponseComboBox cbxAdd = new ResponseComboBox();
            GroupBox lastgroupBox = getLastGroupBox();

            cbxList[gbxIndex].Parent = gbxList[gbxIndex];

            cbxList[gbxIndex].Name = "";
            cbxList[gbxIndex].BackColor = cbxAdd.Color;
            cbxList[gbxIndex].Location = new System.Drawing.Point(cbxAdd.X, cbxAdd.Y);
            cbxList[gbxIndex].Size = new System.Drawing.Size(cbxAdd.Width, cbxAdd.Height);

            Console.WriteLine(gbxAdd.Location.X);

            gbxAdd.Controls.Add(cbxList[gbxIndex]);

            Console.WriteLine(gbxAdd.Contains(cbxList[gbxIndex]));

            FillComboBox(cbxList[gbxIndex], groupID);

            //Event Handler for all new Combo Boxes
            cbxList[gbxIndex].SelectedIndexChanged += new System.EventHandler(newComboBox_SelectedIndexChanged);
        }

        private void CreateTextBox(GroupBox gbxAdd)
        {
            tbxList.Add(new TextBox());
            ResponseTextBox tbxAdd = new ResponseTextBox();
            GroupBox lastGroupBox = getLastGroupBox();

            tbxList[gbxIndex].Parent = gbxList[gbxIndex];

            tbxList[gbxIndex].Name = "";
            tbxList[gbxIndex].BackColor = tbxAdd.Color;
            tbxList[gbxIndex].Location = new System.Drawing.Point(tbxAdd.X, tbxAdd.Y);
            tbxList[gbxIndex].Size = new Size(tbxAdd.Width, tbxAdd.Height);
            tbxList[gbxIndex].Multiline = true;

            gbxAdd.Controls.Add(tbxList[gbxIndex]);
        }
        /// <summary>
        /// Debug for checking if a form control is visible (TODO: Finish GetChildAtPoint x2)
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool isChildVisible(Control child)
        {
            var pos = this.PointToClient(child.PointToScreen(System.Drawing.Point.Empty));
            if (this.GetChildAtPoint(pos) == child) return true;
            if (this.GetChildAtPoint(new System.Drawing.Point(pos.X + child.Width - 1, pos.Y)) == child) return true;
            return false;
        }
        /// <summary>
        /// Returns the last GroupBox in a list of all groupBoxes
        /// </summary>
        /// <returns></returns>
        private GroupBox getLastGroupBox()
        {
            List<GroupBox> groupBoxes = new List<GroupBox>();
            foreach (Control c in this.Controls)
            {
                GroupBox groupBox = c as GroupBox;
                if (groupBox != null) groupBoxes.Add(groupBox);
            }
            groupBoxes.Sort(new Comparison<GroupBox>(CompareTabIndex));

            return groupBoxes.Last();
        }

        /// <summary>
        /// Used to support the comparison in getLastGroupBox
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        private static int CompareTabIndex(GroupBox c1, GroupBox c2)
        {
            return c1.TabIndex.CompareTo(c2.TabIndex);
        }

        /// <summary>
        /// Debug for checking the control that the user has clicked (TODO: Expand for multiple controls)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_Clicks(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control is ComboBox)
            {
                MessageBox.Show("eeeeeeeee");
            }
        }

        /// <summary>
        /// Eventhandler for all new comboboxes, populates the texbox based on the selected combo box entry
        /// </summary>
        /// <param name="sender">The control the user has selected, used to get the parent groupbox</param>
        /// <param name="e"></param>
        private void newComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            ComboBox cbxAdd = control as ComboBox;
            TextBox tbxAdd = control.Parent.Controls[1] as TextBox;
            int i = cbxList.IndexOf(cbxAdd);
            Console.WriteLine(i);

            string selResponseName = cbxAdd.SelectedItem.ToString();
            SqlDataReader reader = DBQuery("SELECT Message FROM Responses WHERE ResponseName = '" + selResponseName + "'");
            if (reader.Read())
            {
                tbxList[i].Text = reader.GetString(0);
            }
        }
        /// <summary>
        /// DEPRECATED. Left in to prevent Designer errors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selResponseName = comboBox1.SelectedItem.ToString();
            SqlDataReader reader = DBQuery("SELECT Message FROM Responses WHERE ResponseName = '" + selResponseName + "'");
            if (reader.Read())
            {
                textBox1.Text = reader.GetString(0);
            }
        }

        /// <summary>
        /// Event handler for "Window > Preview" menu item.
        /// Opens preview window; and executes preview.AddText on all TextBoxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Looks up the name corresponding to the selected applicant ID, and
            // inserts the name of the applicant into the beginning of the PDF
            string applicantName = "";
            string selAppID = cbxApplicant.SelectedItem.ToString();
            SqlDataReader reader = DBQuery("SELECT CONCAT (FirstName, ' ', Surname) AS name FROM Applicants WHERE ApplicantID = '" + selAppID + "'");
            if (reader.Read())
            {
                applicantName = reader.GetString(0);
            }
            // Loops through all currently open TextBoxes, and copies the text to be inserted into a PDF.

            // NOTE: DON'T DO BY LIST, DO BY TAG
            string text = "Dear " + applicantName + ",";
            for (int i = 0; i < tbxList.Count; i++)
            {
                text += Environment.NewLine + tbxList[i].Text;
            }
            // Instantiates a new PDF document and page.
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            // Set font and font size.
            XFont font = new XFont("Times", 12);
            XTextFormatter textFormatter = new XTextFormatter(gfx);
            // Rectangle is created to store text.  Without this rectangle, the text is not formatted properly.
            XRect rectangle = new XRect(40, 200, page.Width - 100, page.Height - 100);
            gfx.DrawRectangle(XBrushes.White, rectangle);
            // Inserts text copied from TextBoxes into PDF.
            textFormatter.DrawString(text, font, XBrushes.Black, rectangle, XStringFormats.TopLeft);
            // Saves PDF, and opens it for user to view.
            string filename = cbxApplicant.SelectedItem.ToString();
            document.Save(filename);
            Process.Start(filename);
        }
    }
}
