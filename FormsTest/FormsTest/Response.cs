using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsTest
{
    public class Response
    {
        public int ResponseID { get; set; }
        public MessageState Message { get; set; }

        //We could use an enum to hold and build new responses?

        public enum MessageState
        {
            Good,
            Average,
            Bad,
        }
    }
}
