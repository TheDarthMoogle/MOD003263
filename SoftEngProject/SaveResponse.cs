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

        List<Response> newResponseList = new List<Response>();

        ResponseGroup newResponseGroup;

        int groupIDMax = 0;

        int responseIDMax = 0;

        public List<Response> newResponseListCreated
        {
            get { return newResponseList; }
        }

        public ResponseGroup newResponseGroupCreated
        {
            get { return newResponseGroup; }
        }

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

        }

        ///
        private void templateSaveButton_Click(object sender, EventArgs e)
        {
            string responseGroupName = responseNameTextBox.Text;
            int selectedTemplateID = templateSelectComboBox.SelectedIndex + 1;
            int groupID = Int32.Parse(newResponseList[0].GroupID);
            Console.WriteLine(selectedTemplateID);
            DataSet dsSelectedGroup = DBConnection.getDBConnectionInstance().getDataSet("SELECT * FROM ResponseGroup WHERE TemplateID = " + groupID + "");
            DataTable dtSelectedGroup = dsSelectedGroup.Tables[0];
            DataSet dsSelectedResponses = DBConnection.getDBConnectionInstance().getDataSet("SELECT * FROM Responses WHERE GroupID = " + groupID + "");
            DataTable dtSelectedResponses = dsSelectedResponses.Tables[0];
            string sqlQueryResponseGroup;
            string sqlQueryResponse;


            string connectionString = Properties.Settings.Default.TemplateDBString;

            //string sqlQueryResponseGroup = @"INSERT INTO ResponseGroup (Id, Title, TemplateID) VALUES ('" + (groupIDMax + 1) + "','" + responseGroupName + "','" + selectedTemplateID + "')";
            //string sqlQueryResponseGroup = @"INSERT INTO ResponseGroup (Id, Title, TemplateID) VALUES (@Id,@Title,@TemplateID)";

            //string sqlQueryResponse = @"INSERT INTO Responses (Id, ResponseName, Message, GroupID) VALUES ('" + (r.ID + responseIDMax + 1) + "','" + r.ResponseName + "','" + r.Message + "','" + r.GroupID + "')";
            //string sqlQueryResponse = @"REPLACE INTO Responses (Id, ResponseName, Message, GroupID) VALUES (@Id,@ResponseName,@Message,@GroupID)";

            using (SqlConnection openCon = new SqlConnection(connectionString))
            {

                if (groupID < groupIDMax)
                {
                    Console.WriteLine("True");
                    sqlQueryResponseGroup = "UPDATE ResponseGroup SET Title = @Title, TemplateID = " + selectedTemplateID + " WHERE Id = @Id";
                    sqlQueryResponse = @"IF EXISTS (SELECT * FROM Responses WHERE Id = @Id and GroupID = " + groupID + ") UPDATE Responses SET ResponseName = @ResponseName, Message = @Message WHERE GroupID = " + groupID + " and Id = @Id ELSE INSERT INTO Responses (ResponseName, Message, GroupID) VALUES (@ResponseName, @Message, @GroupID)";


                    string selectedResponseGroupName = dtSelectedGroup.Rows[0].Field<string>(1);
                    responseGroupName = selectedResponseGroupName;
                    responseIDMax = 0;
                    groupIDMax = 0;

                    /*
                    if (newResponseList.Count < dtSelectedResponses.Rows.Count)
                    {
                        DataSet compareset = DBConnection.getDBConnectionInstance().getDataSet("SELECT * FROM Responses WHERE GroupID = " + groupID + "");
                        DataTable comparetable = compareset.Tables[0];
                        Console.WriteLine("LessResponses");
                        sqlQueryResponse = @"IF EXISTS (SELECT * FROM Responses WHERE GroupID = " + groupID + ") UPDATE Responses SET ResponseName = @ResponseName, Message = @Message WHERE GroupID = " + groupID + " and Id = @Id ELSE DELETE FROM Responses WHERE Id <> @Id";
                        //sqlQueryResponse = "IF EXISTS (SELECT * FROM Responses WHERE GroupID = " + groupID + " and Id = @Id) UPDATE Responses SET ResponseName = @ResponseName, Message = @Message WHERE GroupID = " + groupID + " AND ID = @Id ELSE DELETE FROM Responses WHERE GroupID = @GroupID";
                    }
                    else
                    {
                    }
                    */
                }
                else
                {
                    Console.WriteLine("Else");
                    sqlQueryResponseGroup = "INSERT INTO ResponseGroup (Title, TemplateID) VALUES (@Title,@TemplateID)";

                    sqlQueryResponse = "INSERT INTO Responses (ResponseName, Message, GroupID) VALUES (@ResponseName, @Message, " + groupID + ")";

                    responseIDMax++;
                    groupIDMax++;
                }

                /*
                if (dtSelectedResponses.Rows.Count < newResponseList.Count)
                {
                    sqlQueryResponse = "IF EXISTS (SELECT * FROM Responses WHERE Id = @Id and GroupID = "+groupID+") UPDATE Responses SET ResponseName = @ResponseName, Message = @Message WHERE GroupID = " + groupID + " and Id = @Id";
                }
                */


                using (SqlCommand saveResponseGroup = new SqlCommand(sqlQueryResponseGroup))
                {
                    saveResponseGroup.Connection = openCon;
                    saveResponseGroup.Parameters.Add("@Id", SqlDbType.Int).Value = groupID;
                    saveResponseGroup.Parameters.Add("@Title", SqlDbType.VarChar, responseGroupName.Length).Value = responseGroupName;
                    //saveResponseGroup.Parameters.Add("@TemplateID", SqlDbType.Int).Value = selectedTemplateID;
                    saveResponseGroup.Parameters.Add("@TemplateID", SqlDbType.Int).Value = selectedTemplateID;
                    openCon.Open();
                    saveResponseGroup.ExecuteNonQuery();
                    saveResponseGroup.Parameters.Clear();
                    openCon.Close();
                }

                foreach (Response r in newResponseList)
                {
                    using (SqlCommand saveReponse = new SqlCommand(sqlQueryResponse))
                    {
                        saveReponse.Connection = openCon;
                        saveReponse.Parameters.Add("@Id", SqlDbType.Int).Value = r.ID + responseIDMax;
                        Console.WriteLine((r.ID + responseIDMax) + r.ResponseName + r.Message + r.GroupID);
                        saveReponse.Parameters.Add("@ResponseName", SqlDbType.VarChar, r.ResponseName.Length).Value = r.ResponseName;
                        saveReponse.Parameters.Add("@Message", SqlDbType.VarChar, r.Message.Length).Value = r.Message;
                        saveReponse.Parameters.Add("@GroupID", SqlDbType.VarChar, r.GroupID.Length).Value = r.GroupID.ToString();
                        openCon.Open();
                        saveReponse.ExecuteNonQuery();
                        saveReponse.Parameters.Clear();
                        openCon.Close();
                    }
                }
            }

            DataSet dsGroup = DBConnection.getDBConnectionInstance().getDataSet("SELECT * FROM Responses");

            DataTable dtGroup = dsGroup.Tables[0];

            dataGridView1.DataSource = dtGroup;

            Console.WriteLine("I made it here");
        }
    }
}
