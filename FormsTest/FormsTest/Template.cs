using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsTest
{
    public class Template
    {
        //Not implemented yet.
        public Form1 mainForm;
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string Author { get; set; }

        private List<TemplateCode> templatePlan = new List<TemplateCode>();
        public List<TemplateCode> TemplatePlan()
        {
            return templatePlan;
        }

        public struct Block
        {
            public int templateCodeID { get; set; }
            public string templateCodeName { get; set; }
            public int responsesNo { get; set; }
        }

        //Down here will be the method that builds the overall template, similar to the TemplateCode.cs
        //While what's in Form1 in functional, it is not secure. This Class will be where user and applicant data will be handled.
    }
}
