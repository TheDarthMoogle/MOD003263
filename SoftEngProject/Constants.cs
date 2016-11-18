using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngProject
{
    class Constants
    {
        public static String sqlQuerySelectAll = "SELECT * FROM Templates";
        public static String sqlQuerySelResponses = "SELECT ResponseName FROM Responses";
        public static String sqlQuerySel = "Select Count(*) From Users where Username= @username and Password= @password";
        public static String sqlQuerySelRole = "Select Role From Users where Username= @username and Password= @password";
    }
}