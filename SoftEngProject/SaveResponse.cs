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
    public partial class SaveResponse : Form
    {

        public List<Response> newResponseList = new List<Response>();

        int groupIDMax = 0;

        int responseIDMax = 0;

        //DataSets for all tables
        DataSet dsTemplate = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelectAll);
        DataSet dsResponseGroups = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelResponseGroups);
        DataSet dsResponses = DBConnection.getDBConnectionInstance().getDataSet(Constants.sqlQuerySelAllResponses);
        public SaveResponse()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Grabs all the templates, responses and groups to populate form and get maximum table values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveResponse_Load(object sender, EventArgs e)
        {
            DataTable dtTemplate = dsTemplate.Tables[0];

            foreach (DataRow row in dtTemplate.Rows)
            {
                string templateName = row.Field<string>(1);
                PopulateComboBox(templateName);
            }

            DataTable dtResponseGroups = dsResponseGroups.Tables[0];

            foreach (DataRow row in dtResponseGroups.Rows)
            {
                groupIDMax++;
            }

            DataTable dtResponses = dsResponses.Tables[0];

            foreach (DataRow row in dtResponses.Rows)
            {
                responseIDMax++;
            }
        }

        public void PopulateComboBox(string item)
        {
            templateSelectComboBox.Items.Add(item);
        }

        public void PopulateResponseList(Response newResponse)
        {
            newResponseList.Add(newResponse);

            Console.WriteLine(newResponse.ID + newResponse.ResponseName + newResponse.Message + newResponse.GroupID);
        }

        ///
        private void templateSaveButton_Click(object sender, EventArgs e)
        {
            string responseGroupName = responseNameTextBox.Text;
            int selectedTemplateID = templateSelectComboBox.SelectedIndex;

            string connectionString = Properties.Settings.Default.TemplateDBString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                
                string sqlQueryResponseGroup = @"INSERT INTO ResponseGroup (Id, Title, TemplateID) VALUES ('" + (groupIDMax + 1) + "','" + responseGroupName + "','" + selectedTemplateID + "')";

                Console.WriteLine(sqlQueryResponseGroup);

                foreach (Response r in newResponseList)
                {                    
                    string sqlQueryResponse = @"INSERT INTO Responses (Id, ResponseName, Message, GroupID) VALUES ('" + (r.ID + responseIDMax + 1) + "','" + r.ResponseName + "','" + r.Message + "','" + r.GroupID + "')";

                    Console.WriteLine(sqlQueryResponse);

                }
            }

            /*
            string selResponseName = comboBox1.SelectedItem.ToString();
            string sqlQuerySelMessage = "SELECT Message FROM Responses WHERE ResponseName = '" + selResponseName + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuerySelMessage, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                responseNameTextBox.Text = reader.GetString(0);
            }
            */
        }
    }
}
