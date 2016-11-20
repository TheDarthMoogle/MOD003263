using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngProject
{
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
            // Iterates through all existing text boxes in the User form, and copies text into the preview.
        }
        /// <summary>
        /// Method to be called from User; places each string on a new line within tbxPreview.
        /// </summary>
        /// <param name="responseMessage"></param>
        public void AddText(string responseMessage)
        {
            tbxPreview.Text += responseMessage + Environment.NewLine;
        }
    }
}
