using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngProject
{
    public partial class NewTemplate : Form
    {
        DataSet dsTemplate = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelectAll);

        User userForm = new User();

        Template newTemplate;
        
        int templateIndex = 0;

        public Template newTemplateCreated
        {
            get { return newTemplate; }
        }

        public NewTemplate()
        {
            InitializeComponent();
        }

        private void newTemplateCreateButton_Click(object sender, EventArgs e)
        {
            //TODO - CHECK FOR VALID NAME

            string newTemplateName = newTemplateNameTextBox.Text;
                        
            newTemplate = new Template((templateIndex + 1), newTemplateName, "", null);

            userForm.templateList.Add(newTemplate);

            string insertQuery = "INSERT INTO Templates (Id, TemplateName) VALUES (@Id,@TemplateName)";

            Console.WriteLine((templateIndex+1)+newTemplateName);

            using (SqlConnection openCon = new SqlConnection(Properties.Settings.Default.TemplateDBString))
            {
                using (SqlCommand querySave = new SqlCommand(insertQuery))
                {
                    Console.WriteLine("This Works");
                    querySave.Connection = openCon;
                    querySave.Parameters.Add("@Id",SqlDbType.Int).Value=(newTemplate.ID);
                    querySave.Parameters.Add("@TemplateName", SqlDbType.VarChar, newTemplate.TemplateName.Length).Value = newTemplate.TemplateName;
                    openCon.Open();
                    querySave.ExecuteNonQuery();
                    querySave.Parameters.Clear();
                }
                openCon.Close();
            }
            this.Close();
        }

        private void NewTemplate_Load(object sender, EventArgs e)
        {

            DataTable dtTemplate = dsTemplate.Tables[0];

            foreach (DataRow row in dtTemplate.Rows)
            {
                templateIndex++;
            }
        }
    }
}
