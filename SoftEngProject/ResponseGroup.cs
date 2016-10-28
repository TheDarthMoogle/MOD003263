using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngProject
{
    public class ResponseGroup
    {
        private int _id;
        private string _title;
        private int _templateID;

        public ResponseGroup(int id, string title, int templateID)
        {
            this._id = id;
            this._title = title;
            this._templateID = templateID;
        }

        public int ID { get { return _id; } }
        public string Title { get { return _title; } }
        public int TemplateID { get { return _templateID; } }

    }
}
