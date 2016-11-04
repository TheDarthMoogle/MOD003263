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

namespace SoftEngProject
{
    public partial class Form1 : Form
    {

        private ComboBox _cbxAdd = new ComboBox();
        private GroupBox _gbxAdd = new GroupBox();

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet dsTemplate = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelectAll);

            DataTable dtTemplate = dsTemplate.Tables[0];

            foreach(DataRow row in dtTemplate.Rows)
            {
                string templateName = row.Field<string>(1);
                randoBox.Items.Add(templateName);
                BuildToolStripTemplateItems(templateName);
            }

            dataGridView1.DataSource = dtTemplate;
        }

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


        private void CreateGroupBox()
        {
            ResponseGroupBox gbxAdd = new ResponseGroupBox();
            GroupBox lastGroupBox = getLastGroupBox();

            _gbxAdd.Name = "";
            _gbxAdd.BackColor = lastGroupBox.BackColor;
            _gbxAdd.Text = gbxAdd.Text;
            _gbxAdd.Location = new System.Drawing.Point(gbxAdd.X + lastGroupBox.Location.X, gbxAdd.Y + lastGroupBox.Bottom);
            _gbxAdd.Size = new System.Drawing.Size(gbxAdd.Width, gbxAdd.Height);

            this.Controls.Add(_gbxAdd);
        }


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


        private static int CompareTabIndex(GroupBox c1, GroupBox c2)
        {
            return c1.TabIndex.CompareTo(c2.TabIndex);
        }
    }
}
