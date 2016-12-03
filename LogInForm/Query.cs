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
    class Query
    {

        // Takes an input of the two string variables and checks them against the rows of the table
        // Returns true if they login details are correct and false if they are incorrect

        // To do - Add in different user levels
        //       - Possibly add in X number of tries    
        public int LogInQuery(string username, string password)
        {
            int no = DBConnection.getDBConnectionInstance().isIn(Constants.sqlQuerySelRole, username, password);
            return no;            
        } 


    }
}
