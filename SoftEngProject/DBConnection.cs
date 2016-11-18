using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngProject
{
    class DBConnection
    {
        //attributes
        private static DBConnection _instance;

        private static string connectionStr;

        private System.Data.SqlClient.SqlConnection connectionToDB;

        private System.Data.SqlClient.SqlDataAdapter dataAdapter;

        //constructors


        //properties
        public static string ConnectionStr
        {
            set
            {
                connectionStr = value;
            }
        }


        //methods
        //return the connection to the database
        public static DBConnection getDBConnectionInstance()
        {
            if (_instance == null)
            {
                _instance = new DBConnection();
            }

            return _instance;
        }


        // Open the connection
        public void openConnection()
        {
            // create the connection to the database as an instance of System.Data.SqlClient.SqlConnection
            connectionToDB = new System.Data.SqlClient.SqlConnection(connectionStr);

            //open the connection
            connectionToDB.Open();
        }

        public void closeConnection()
        {
            //close the connection to the database
            connectionToDB.Close();

        }

        public System.Data.DataSet getDataSet(String sqlQuery)
        {
            System.Data.DataSet dataSet;

            openConnection();

            // create the dataAdapter object
            dataAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlQuery, connectionToDB);

            //create the dataSet object
            dataSet = new System.Data.DataSet();

            //fill in the dataSet with the data coming from the DB 
            dataAdapter.Fill(dataSet);

            closeConnection();
            //return the dataset
            return dataSet;
        }

        public int isIn(string sqlQuery, string username, string password)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            command.Parameters.Add(new SqlParameter("username", username));
            command.Parameters.Add(new SqlParameter("password", password));

            openConnection();
            command.Connection = connectionToDB;

            int n = 0;
            try
            {
                n = (Int32)command.ExecuteScalar();
            }
            catch (NullReferenceException e)
            { }

            closeConnection();

            Console.WriteLine("n-" + n);
            return n;
        }
    }
}
