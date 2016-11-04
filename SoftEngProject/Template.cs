using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngProject
{
    public class Template
    {
        private int _id;
        private string _templateName;
        private string _author;
        private List<Response> _responses = new List<Response>();

        public Template(int id, string templateName, string author, List<Response> responses )
        {
            this._id = id;
            this._templateName = templateName;
            this._author = author;
            this._responses = responses;
        }

        public int ID { get { return _id; } }
        public string TemplateName { get { return _templateName; } }
        public string Author { get { return _author; } }
        public List<Response> Responses { get { return _responses; } }
    }
}
