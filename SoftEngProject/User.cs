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

namespace SoftEngProject
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();

            //=========================== TODO ==============================//

            //Create Event Handlers for dynamic toolstrip menu items (DONE?)

            //Use event handlers to populate group box controls (DONE)

            //Methods for users loading database at runtime (DONE)

            //Integrate login stuff (DONE)

            //Create preview window (DONE)

            //Merge Admin and User into single Form

            //Functions for Creating New Templates (Responses and ResponseGroups DONE)

            //Move Form Code into Classes(50% - Create New Methods for duplicate code)
            
            //RESPONSES - SET ID TO WHAT'S IN THE TABLE BASED ON RESPONSEGROUP ID, APPEND OTHEREWISE

            //Complete PDF stuff 

            //Complete email stuff

            //Write more testing code

            //Do some more testing

            //Get good grades

        }

        /*Previously, each new instance of GroupBox, ComboBox, and TextBox was given the exact same name.
          Now each instance will be given an index (gbxIndex), making it possible to
          execute the same function on mutiple instances.
        s*/
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
        public List<Button> btnUpList = new List<Button>();
        public List<Button> btnDownList = new List<Button>();
        public List<Button> btnDeleteList = new List<Button>();
        public List<Button> btnSaveList = new List<Button>();
        public List<Button> btnEditList = new List<Button>();
        public List<Button> btnNewList = new List<Button>();
        public List<Button> btnRemoveList = new List<Button>();

        public ResponseListList responseListList = new ResponseListList(0);

        DataSet dsTemplate = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelectAll);

        public string selectedTemplate;
        /// <summary>
        /// A list of ResponseLists
        /// </summary>
        public class ResponseListList : List<ResponseList>
        {
            int _id;
            public ResponseListList(int id)
            {
                this._id = id;
            }

            public int ID { get { return _id; } }
        }
        public class ResponseList : List<Response>
        {
            int _id;
            public ResponseList(int id)
            {
                this._id = id;
            }

            public int ID { get { return _id; } }
        }

        /// <summary>
        /// Populates the ComboBox's drop-down menu with ResponseNames from the Responses table.
        /// </summary>
        void FillComboBox(ComboBox cbxAdd, int groupID)
        {
            ResponseList responseList = new ResponseList(groupID);            

            string cnString = Properties.Settings.Default.TemplateDBString;
            string Query = "SELECT * FROM Responses WHERE GroupID = '" + groupID + "'";
            SqlConnection connection = new SqlConnection(cnString);
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int _id = reader.GetInt32(0);
                string _responseName = reader.GetString(1);
                string _message = reader.GetString(2);
                string _groupID = reader.GetInt32(3).ToString();

                Response cbxResponse = new Response(_id,_responseName,_message,_groupID);
                string responseName = cbxResponse.ResponseName;
                cbxAdd.Items.Add(responseName);
                responseList.Add(cbxResponse);
            }
            responseListList.Add(responseList);

            if (responseList.Count == 0)
            {
                Response defaultResponse = new Response(0, "Default", "Please enter a message here", gbxIndex.ToString());
                responseList.Add(defaultResponse);
                cbxAdd.Items.Add(defaultResponse.ResponseName);
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
        /// <summary>
        /// Removes all existing GroupBoxes and creates new ones for each ResponseGroup in the table with matching TemplateID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            DataSet dsResponseGroup = DBConnection.getDBConnectionInstance().getDataSet("SELECT * FROM ResponseGroup WHERE TemplateID  = '" + clickedItem.Tag + "'");

            DataTable dtResponseGroup = dsResponseGroup.Tables[0];

            foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
            {
                foreach (Control c in gb.Controls)
                {
                    gb.Controls.Remove(c);
                }
            }

            foreach (DataRow row in dtResponseGroup.Rows)
            {
                CreateGroupBox(row.Field<string>(1), row.Field<int>(0));
            }

            selectedTemplate = clickedItem.Tag.ToString();

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
            GroupBox groupBox = gbxList[gbxIndex];

            groupBox.Name = gbxName + "GroupBox";
            groupBox.BackColor = lastGroupBox.BackColor;
            groupBox.Text = gbxName;
            groupBox.Location = new System.Drawing.Point(gbxAdd.X + lastGroupBox.Location.X, gbxAdd.Y + lastGroupBox.Bottom);
            groupBox.Size = new System.Drawing.Size(gbxAdd.Width, gbxAdd.Height);
            groupBox.Tag = gbxIndex;

            this.Controls.Add(gbxList[gbxIndex]);

            CreateComboBox(groupBox, groupID);
            CreateTextBox(groupBox);
            CreateUpButton(groupBox);
            CreateDownButton(groupBox);
            CreateDeleteButton(groupBox);
            CreateResponseNewButton(groupBox);
            CreateResponseEditbutton(groupBox);
            CreateResponseSaveButton(groupBox);
            CreateResponseRemoveButton(groupBox);

            gbxIndex++;
        }

        private void CreateComboBox(GroupBox gbxAdd, int groupID)
        {
            cbxList.Add(new ComboBox());
            ResponseComboBox cbxAdd = new ResponseComboBox();
            GroupBox lastgroupBox = getLastGroupBox();

            List<Response> comboBoxList = new List<Response>();

            cbxList[gbxIndex].Parent = gbxList[gbxIndex];

            cbxList[gbxIndex].Name = "";
            cbxList[gbxIndex].BackColor = cbxAdd.Color;
            cbxList[gbxIndex].Location = new System.Drawing.Point(cbxAdd.X, cbxAdd.Y);
            cbxList[gbxIndex].Size = new System.Drawing.Size(cbxAdd.Width, cbxAdd.Height);

            cbxList[gbxIndex].DropDownStyle = ComboBoxStyle.DropDown;
            
            gbxAdd.Controls.Add(cbxList[gbxIndex]);
            
            FillComboBox(cbxList[gbxIndex], groupID);

            //Event Handler for all new Combo Boxes
            cbxList[gbxIndex].SelectedIndexChanged += new System.EventHandler(newComboBox_SelectedIndexChanged);
            //Event Handler for text changed
            cbxList[gbxIndex].TextChanged += new EventHandler(newComboBox_TextChanged);
        }
        private void newComboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
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

        private void CreateUpButton(GroupBox gbxAdd)
        {
            btnUpList.Add(new Button());
            ResponseButton btnUpAdd = new ResponseButton();
            GroupBox lastGroupBox = getLastGroupBox();
            Button upButton = btnUpList[gbxIndex];

            upButton.Name = "btnUp" + gbxIndex;
            upButton.BackColor = gbxAdd.BackColor;
            upButton.Location = new Point(btnUpAdd.X, btnUpAdd.Y);
            upButton.Size = new Size(btnUpAdd.Width, btnUpAdd.Height);
            upButton.Text = "▲";
            upButton.Tag = gbxAdd.Tag;

            gbxAdd.Controls.Add(upButton);

            upButton.Click += new EventHandler(newBtnUp_Clicked);
        }

        private void newBtnUp_Clicked(object sender, EventArgs e)
        {
            Button btnUp = sender as Button;
            GroupBox parentBox = btnUp.Parent as GroupBox;
            Point parentBoxPos = parentBox.Location;
            int parentBoxIndex = Int32.Parse(parentBox.Tag.ToString());
            ResponseList _responseList = responseListList[parentBoxIndex];

            if (parentBoxIndex > 0)
            {
                GroupBox groupBoxAbove = gbxList[parentBoxIndex - 1];
                Point groupBoxAbovePos = groupBoxAbove.Location;
                int groupBoxAboveIndex = Int32.Parse(groupBoxAbove.Tag.ToString());

                parentBox.Location = new Point(groupBoxAbovePos.X, groupBoxAbovePos.Y);

                var item = gbxList[parentBoxIndex];

                gbxList.RemoveAt(parentBoxIndex);

                gbxList.Insert(groupBoxAboveIndex, item);

                responseListList.RemoveAt(parentBoxIndex);

                responseListList.Insert(groupBoxAboveIndex, _responseList);
                
                parentBox.Tag = parentBoxIndex - 1;

                groupBoxAbove.Location = new Point(parentBoxPos.X, parentBoxPos.Y);

                groupBoxAbove.Tag = groupBoxAboveIndex + 1;
            }
        }

        private void CreateDownButton(GroupBox gbxAdd)
        {
            btnDownList.Add(new Button());
            ResponseButton btnDownAdd = new ResponseButton();
            GroupBox lastGroupBox = getLastGroupBox();
            Button downButton = btnDownList[gbxIndex];

            downButton.Name = "btnDown" + gbxIndex;
            downButton.BackColor = gbxAdd.BackColor;
            downButton.Location = new Point(btnDownAdd.X, btnDownAdd.Y + 30);
            downButton.Size = new Size(btnDownAdd.Width, btnDownAdd.Height);
            downButton.Text = "▼";
            downButton.Tag = gbxAdd.Tag;

            gbxAdd.Controls.Add(downButton);

            downButton.Click += new EventHandler(newBtnDown_Clicked);

        }

        private void newBtnDown_Clicked(object sender, EventArgs e)
        {
            Button btnUp = sender as Button;
            GroupBox parentBox = btnUp.Parent as GroupBox;
            Point parentBoxPos = parentBox.Location;
            int parentBoxIndex = Int32.Parse(parentBox.Tag.ToString());
            ResponseList _reponseList = responseListList[parentBoxIndex];

            if (parentBoxIndex < (gbxList.Count - 1))
            {
                GroupBox groupBoxBelow = gbxList[parentBoxIndex + 1];
                Point groupBoxBelowPos = groupBoxBelow.Location;
                int groupBoxBelowIndex = Int32.Parse(groupBoxBelow.Tag.ToString());

                parentBox.Location = new Point(groupBoxBelowPos.X, groupBoxBelowPos.Y);

                var item = gbxList[parentBoxIndex];

                gbxList.RemoveAt(parentBoxIndex);

                gbxList.Insert(groupBoxBelowIndex, item);

                responseListList.RemoveAt(parentBoxIndex);

                responseListList.Insert(groupBoxBelowIndex, _reponseList);

                parentBox.Tag = parentBoxIndex + 1;

                groupBoxBelow.Location = new Point(parentBoxPos.X, parentBoxPos.Y);

                groupBoxBelow.Tag = groupBoxBelowIndex - 1;
            }
        }

        private void CreateDeleteButton(GroupBox gbxAdd)
        {
            btnDeleteList.Add(new Button());
            ResponseButton btnDelAdd = new ResponseButton();
            GroupBox lastGroupBox = getLastGroupBox();
            Button delButton = btnDeleteList[gbxIndex];

            delButton.Name = "btnDel" + gbxIndex;
            delButton.BackColor = gbxAdd.BackColor;
            delButton.Location = new Point(571, 76);
            delButton.Size = new Size(btnDelAdd.Width, btnDelAdd.Height);
            delButton.Font = new Font("Wingdings 2", 11.25F);
            delButton.Text = "3";
            delButton.Tag = gbxAdd.Tag;

            gbxAdd.Controls.Add(delButton);

            delButton.Click += new EventHandler(newBtnDel_Clicked);
        }

        private void newBtnDel_Clicked(object sender, EventArgs e)
        {
            Button btnDel = sender as Button;
            GroupBox parentBox = btnDel.Parent as GroupBox;
            int parentBoxIndex = Int32.Parse(parentBox.Tag.ToString());

            for (int i = parentBoxIndex; i < (gbxList.Count - 1); i++)
            {
                newBtnDown_Clicked(btnDel, e);
            }

            int parentBoxIndexNew = Int32.Parse(parentBox.Tag.ToString());
            parentBox.Controls.Clear();
            parentBox.Dispose();
            gbxList.RemoveAt(parentBoxIndexNew);
            cbxList.RemoveAt(parentBoxIndexNew);
            tbxList.RemoveAt(parentBoxIndexNew);
            btnUpList.RemoveAt(parentBoxIndexNew);
            btnDownList.RemoveAt(parentBoxIndexNew);
            btnDeleteList.RemoveAt(parentBoxIndexNew);

            gbxIndex--;
        }

        private void CreateResponseNewButton(GroupBox gbxAdd)
        {
            btnNewList.Add(new Button());
            ResponseButton btnNewAdd = new ResponseButton();
            GroupBox lastGroupBox = getLastGroupBox();
            Button newButton = btnNewList[gbxIndex];

            newButton.Name = "btnNew" + gbxIndex;
            newButton.BackColor = gbxAdd.BackColor;
            newButton.Location = new Point(7, 47);
            newButton.Size = new Size(btnNewAdd.Width, btnNewAdd.Height);
            newButton.Font = new Font("Wingdings 2", 11.25F);
            newButton.Text = @"/";
            newButton.Tag = gbxAdd.Tag;

            gbxAdd.Controls.Add(newButton);

            newButton.Click += new EventHandler(newBtnNew_Clicked);
        }

        private void newBtnNew_Clicked(object sender, EventArgs e)
        {
            Button newButton = sender as Button;
            GroupBox parent = newButton.Parent as GroupBox;
            int tag = Int32.Parse(parent.Tag.ToString());
            ComboBox cbx = cbxList[tag];
            ResponseList _responseList = responseListList[tag];
            Response blankResponse = new Response(_responseList.Count, "New Response", "Text Here", _responseList.ID.ToString());
            _responseList.Add(blankResponse);
            cbx.Items.Add(blankResponse.ResponseName);
        }

        private void CreateResponseEditbutton(GroupBox gbxAdd)
        {
            btnEditList.Add(new Button());
            ResponseButton btnEditAdd = new ResponseButton();
            GroupBox lastGroupBox = getLastGroupBox();
            Button editButton = btnEditList[gbxIndex];

            editButton.Name = "btnSave" + gbxIndex;
            editButton.BackColor = gbxAdd.BackColor;
            editButton.Location = new Point(39, 47);
            editButton.Size = new Size(btnEditAdd.Width, btnEditAdd.Height);
            editButton.Font = new Font("Wingdings 2", 11.25F);
            editButton.Text = "\u0022";
            editButton.Tag = gbxAdd.Tag;

            gbxAdd.Controls.Add(editButton);

            editButton.Click += new EventHandler(newBtnEdit_Clicked);
        }

        private void newBtnEdit_Clicked (object sender, EventArgs e)
        {
            Button btnEdit = sender as Button;
            GroupBox parent = btnEdit.Parent as GroupBox;
            int tag = Int32.Parse(parent.Tag.ToString());
            ComboBox cbx = cbxList[tag];
            TextBox tbx = tbxList[tag];
            ResponseList _responseList = responseListList[tag];
            int i = comboBox1.SelectedIndex;
            Response newResponse = new Response(i, cbx.Text, tbx.Text, _responseList.ID.ToString());
            cbx.Items.RemoveAt(i);
            cbx.Items.Insert(i, newResponse.ResponseName);
            _responseList.RemoveAt(i);
            _responseList.Insert(i, newResponse);

        }

        private void CreateResponseSaveButton(GroupBox gbxAdd)
        {
            btnSaveList.Add(new Button());
            ResponseButton btnSaveAdd = new ResponseButton();
            GroupBox lastGroupBox = getLastGroupBox();
            Button saveButton = btnSaveList[gbxIndex];

            saveButton.Name = "btnSave" + gbxIndex;
            saveButton.BackColor = gbxAdd.BackColor;
            saveButton.Location = new Point(7, 76);
            saveButton.Size = new Size(btnSaveAdd.Width, btnSaveAdd.Height);
            saveButton.Font = new Font("Wingdings", 11.25F);
            saveButton.Text = @"<";
            saveButton.Tag = gbxAdd.Tag;

            gbxAdd.Controls.Add(saveButton);

            saveButton.Click += new EventHandler(newBtnSave_Clicked);
        }


        private void newBtnSave_Clicked(object sender, EventArgs e)
        {
            SaveResponse saveForm = new SaveResponse();
            saveForm.Show();
            Button saveBtn = sender as Button;
            GroupBox parent = saveBtn.Parent as GroupBox;
            parent.BackColor = Color.Green;
            int tag = Int32.Parse(parent.Tag.ToString());

            ResponseList _reponseList = responseListList[tag];

            foreach (var item in _reponseList)
            {
                saveForm.PopulateResponseList(item);
            }

            /*
            ComboBox cbx = cbxList[tag];
            TextBox tbx = tbxList[tag];
            cbx.ForeColor = Color.Green;
            int i = 0;
            foreach (var item in cbx.Items)
            {
                saveForm.PopulateResponseList(i, item.ToString(), tbx.Text);
                i++;
            }
            */

        }

        private void CreateResponseRemoveButton(GroupBox gbxAdd)
        {
            btnRemoveList.Add(new Button());
            ResponseButton btnRemoveAdd = new ResponseButton();
            GroupBox lastGroupBox = getLastGroupBox();
            Button removeButton = btnRemoveList[gbxIndex];

            removeButton.Name = "btnSave" + gbxIndex;
            removeButton.BackColor = gbxAdd.BackColor;
            removeButton.Location = new Point(39, 76);
            removeButton.Size = new Size(btnRemoveAdd.Width, btnRemoveAdd.Height);
            removeButton.Font = new Font("Wingdings", 11.25F);
            removeButton.Text = @"x";
            removeButton.Tag = gbxAdd.Tag;

            gbxAdd.Controls.Add(removeButton);

            removeButton.Click += new EventHandler(newBtnRemove_Clicked);
        }


        private void newBtnRemove_Clicked(object sender, EventArgs e)
        {
            Button btnRemove = sender as Button;
            GroupBox parent = btnRemove.Parent as GroupBox;
            int tag = Int32.Parse(parent.Tag.ToString());
            ComboBox cbx = cbxList[tag];
            int cbxIndex = cbx.SelectedIndex;
            ResponseList _responseList = responseListList[tag];
            _responseList.RemoveAt(cbxIndex);
            cbx.Items.RemoveAt(cbxIndex);
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
        /// DEPRECATED - Returns the last GroupBox in a list of all groupBoxes
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
            groupBoxes.Sort(new Comparison<GroupBox>(CompareTagIndex));

            return groupBoxes.Last();
        }

        /// <summary>
        /// Used to support the comparison in getLastGroupBox
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        private static int CompareTagIndex(GroupBox c1, GroupBox c2)
        {
            int c1Tag = Int32.Parse(c1.Tag.ToString());
            int c2Tag = Int32.Parse(c2.Tag.ToString());
            return c1Tag.CompareTo(c2Tag);
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
            GroupBox gbx = cbxAdd.Parent as GroupBox;
            int tag = Int32.Parse(gbx.Tag.ToString());
            ResponseList _responseList = responseListList[tag];

            Response _responseSelected = _responseList[cbxAdd.SelectedIndex];

            tbxList[i].Text = _responseSelected.Message;
            /*
            string selResponseName = cbxAdd.SelectedItem.ToString();
            string connectionString = Properties.Settings.Default.TemplateDBString;
            string sqlQuerySelMessage = "SELECT Message FROM Responses WHERE ResponseName = '" + selResponseName + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuerySelMessage, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                tbxList[i].Text = reader.GetString(0);
            }
            */
            comboBox1.SelectedIndex = cbxAdd.SelectedIndex;
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

        /// <summary>
        /// Event handler for "Window > Preview" menu item.
        /// Opens preview window; and executes preview.AddText on all TextBoxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preview frmPrev = new Preview();
            frmPrev.Show();
            for (int i = 0; i < tbxList.Count; i++)
            {
                frmPrev.AddText(tbxList[i].Text);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void templateToolStripMenuItemSaveTemplate_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
