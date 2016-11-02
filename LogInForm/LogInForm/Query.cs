using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LogInForm
{
    class Login
    {

        // Takes an input of the two string variables and checks them against the rows of the table
        // Returns true if they login details are correct and false if they are incorrect

        // To do - Add in different user levels
        //       - Possibly add in X number of tries    
        public bool LogInQuery(string username, string password)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Users.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Users where Username='" + username + "' and Password='" + password + "'", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        } 
    }
}
