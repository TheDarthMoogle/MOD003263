using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsTest
{
    public class TemplateCode
    {
        public Form1 mainForm;
        public int TemplateCodeID { get; set; }
        public string TemplateCodeName { get; set; }

        //Creates a list of Responses that the template code contains
        private List<Response> responseList = new List<Response>();
        public List<Response> ResponseList()
        {
            return responseList;
        }
        
        public struct Block
        {
            public int responseID { get; set; }
            public string message { get; set; }
        }

        public TemplateCode(string _fileName)
        {
            //This section will eventually contain and build data for template codes and their responses.
            //While what is in Form1.cs is functional, it is not yet secure.

            //Initialise the list of reponses

            /*
            List<Block> blocks = new List<Block>
            {
                new Block {responseID = 0, message = "Good" },
                new Block {responseID = 1, message = "Average" },
                new Block {responseID = 2, message = "Bad" },
            };

            string template = _fileName;
            int blockIndex = 0;

            //For each response in the template code, populate reponses with data. Important once reponses are gathered from file.

            for (var i = blockIndex; i < blocks.Count; i++)
            {
                Block block = blocks[blockIndex];
                responseList.Add(new Response { ResponseID = block.responseID, Message = block.message });
                blockIndex++;
            }
            */
        }
    }
}
