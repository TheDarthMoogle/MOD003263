﻿using System;
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

namespace SoftEngProject
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();            
            
            //=========================== TODO ==============================//
            
            //Create Event Handlers for dynamic toolstrip menu items

            //Use event handlers to populate group box controls
            
            //Methods for users loading database at runtime (or permanent local connection?)
            
            //Integrate login stuff

            //Create preview window

            //Complete PDF stuff

            //Write more testing code

            //Do some more testing

            //Get good grades

        }
        /// <summary>
        /// Populates the ComboBox's drop-down menu with ResponseNames from the Responses table.
        /// </summary>
        void FillComboBox(ComboBox cbxAdd)
        {
            string cnString = Properties.Settings.Default.TemplateDBString;
            string Query = Constants.sqlQuerySelResponses;
            SqlConnection connection = new SqlConnection(cnString);
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string responseName = reader.GetString(0);
                cbxAdd.Items.Add(responseName);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet dsTemplate = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelectAll);

            DataTable dtTemplate = dsTemplate.Tables[0];

            foreach(DataRow row in dtTemplate.Rows)
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
                items[i].Name = "dynamicItem" + i.ToString();
                items[i].Tag = "specialDataHere";
                items[i].Text = menuItemName;
                items[i].Click += new EventHandler(MenuItemClickHandler);
            }

            templateToolStripMenuItem1.DropDownItems.AddRange(items);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            // Take some action based on the data in clickedItem
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }        

        private void templateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGroupBox();
        }

        /// <summary>
        /// Creates a new GroupBox underneath the previously created one
        /// </summary>
        private void CreateGroupBox()
        {
            GroupBox _gbxAdd = new GroupBox();
            ResponseGroupBox gbxAdd = new ResponseGroupBox();
            GroupBox lastGroupBox = getLastGroupBox();

            _gbxAdd.Name = "";
            _gbxAdd.BackColor = lastGroupBox.BackColor;
            _gbxAdd.Text = gbxAdd.Text;
            _gbxAdd.Location = new System.Drawing.Point(gbxAdd.X + lastGroupBox.Location.X, gbxAdd.Y + lastGroupBox.Bottom);
            _gbxAdd.Size = new System.Drawing.Size(gbxAdd.Width, gbxAdd.Height);

            this.Controls.Add(_gbxAdd);

            CreateComboBox(_gbxAdd);
            CreateTextBox(_gbxAdd);
        }

        private void CreateComboBox(GroupBox gbxAdd)
        {
            ComboBox _cbxAdd = new ComboBox();
            ResponseComboBox cbxAdd = new ResponseComboBox();
            GroupBox lastgroupBox = getLastGroupBox();

            _cbxAdd.Parent = gbxAdd;

            _cbxAdd.Name = "";
            _cbxAdd.BackColor = cbxAdd.Color;
            _cbxAdd.Location = new System.Drawing.Point(cbxAdd.X, cbxAdd.Y);
            _cbxAdd.Size = new System.Drawing.Size(cbxAdd.Width, cbxAdd.Height);
            
            Console.WriteLine(gbxAdd.Location.X);

            gbxAdd.Controls.Add(_cbxAdd);
            
            Console.WriteLine(gbxAdd.Contains(_cbxAdd));

            FillComboBox(_cbxAdd);

            //Event Handler for all new Combo Boxes
            _cbxAdd.SelectedIndexChanged += new System.EventHandler(newComboBox_SelectedIndexChanged);
        }

        private void CreateTextBox(GroupBox gbxAdd)
        {
            TextBox _tbxAdd = new TextBox();
            ResponseTextBox tbxAdd = new ResponseTextBox();
            GroupBox lastGroupBox = getLastGroupBox();

            _tbxAdd.Parent = gbxAdd;

            _tbxAdd.Name = "";
            _tbxAdd.BackColor = tbxAdd.Color;
            _tbxAdd.Location = new Point(tbxAdd.X, tbxAdd.Y);
            _tbxAdd.Size = new Size(tbxAdd.Width, tbxAdd.Height);
            _tbxAdd.Multiline = true;

            gbxAdd.Controls.Add(_tbxAdd);

        }
        /// <summary>
        /// Debug for checking if a form control is visible (TODO: Finish GetChildAtPoint x2)
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool isChildVisible(Control child)
        {
            var pos = this.PointToClient(child.PointToScreen(Point.Empty));
            if (this.GetChildAtPoint(pos) == child) return true;
            if (this.GetChildAtPoint(new Point(pos.X + child.Width - 1, pos.Y)) == child) return true;
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

            string selResponseName = cbxAdd.SelectedItem.ToString();
            string connectionString = Properties.Settings.Default.TemplateDBString;
            string sqlQuerySelMessage = "SELECT Message FROM Responses WHERE ResponseName = '" + selResponseName + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuerySelMessage, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                tbxAdd.Text = reader.GetString(0);
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
            string connectionString = Properties.Settings.Default.TemplateDBString;
            string sqlQuerySelMessage = "SELECT Message FROM Responses WHERE ResponseName = '" + selResponseName + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuerySelMessage, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader.GetString(0);
            }
        }
    }
}
