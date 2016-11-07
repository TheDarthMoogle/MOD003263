using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInForm
{
    class Constants
    {
        public static String sqlQuerySelectAll = "SELECT * FROM Templates";

        public void sqlQueryUserPass (string username, string password)
        {
            String sqlQueryUserPass = "Select Count(*) From Users where Username='" + username + "' and Password='" + password + "'";
        }
    }
}
