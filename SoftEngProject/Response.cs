using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SoftEngProject
{
    public class Response
    {
        private int _id;
        private string _responseName;
        private string _groupID;
        private string _message;

        public Response(int id, string responseName, string message, string groupID)
        {
            this._id = id;
            this._responseName = responseName;
            this._message = message;
            this._groupID = groupID;
        }

        public int ID { get { return _id; } }
        public string ResponseName { get { return _responseName; } }
        public string Message { get { return _message; } }
        public string GroupID { get { return _groupID; } }
    }
}
