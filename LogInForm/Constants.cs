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
        public static String sqlQuerySel = "Select Count(*) From Users where Username= @username and Password= @password";
        public static String sqlQuerySelRole = "Select Role From Users where Username= @username and Password= @password";      
    }
}
