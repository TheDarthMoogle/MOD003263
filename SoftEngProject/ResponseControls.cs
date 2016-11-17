using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SoftEngProject
{
    class ResponseControls
    {
        public Form1 mainForm;

        private GroupBox gbxAdd = new GroupBox();
        private ComboBox cbxAdd = new ComboBox();
        private TextBox tbxAdd = new TextBox();
        private List<Control> responseControls = new List<Control>();

        Control GetControlByName(string Name)
        {
            foreach (Control c in mainForm.Controls)
            {
                if (c.Name == Name)
                    return c;
            }

            return null;
        }

        public ResponseControls(GroupBox gbx, ComboBox cbx, TextBox tbx)
        {

            this.gbxAdd.BackColor = Color.Gray;
            this.gbxAdd.Text = "New Box";
            this.gbxAdd.Location = new System.Drawing.Point(GetControlByName("groupBox1").Location.X, GetControlByName("groupBox1").Location.Y + 20);
            this.gbxAdd.Size = new System.Drawing.Size(571, 117);

            this.gbxAdd = gbx;
            this.cbxAdd = cbx;
            this.tbxAdd = tbx;
        }

        public GroupBox Gbx { get { return gbxAdd; } }
        public ComboBox Cbx { get { return cbxAdd; } }
        public TextBox Tbx { get { return tbxAdd; } }

    }
}
