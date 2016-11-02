using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace LogInForm
{
    class DatabaseConnection
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Users.mdf;Integrated Security=True;Connect Timeout=30";

        //The object used to store the connection to the database
        System.Data.SqlClient.SqlConnection connectionToDB;

        //The data adapter used to open a table of the database
        private System.Data.SqlClient.SqlDataAdapter dataAdapter;

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Opens the connection
        public void openConnection()
        {
            //creates the connection to the database
            connectionToDB = new System.Data.SqlClient.SqlConnection(connectionString);

            //opens the connection
            connectionToDB.Open();
        }

        //closes the connection
        public void closeConnection()
        {
            connectionToDB.Close();
        }

        public DataSet getDataSet(string sqlStatement)
        {
            DataSet dataSet;

            dataAdapter = new
                System.Data.SqlClient.SqlDataAdapter(sqlStatement, connectionToDB);

            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet;
        }


    }
}
