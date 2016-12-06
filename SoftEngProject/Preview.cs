using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Charting;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;

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
            tbxPreview.Text += responseMessage + @"
";
        }

        /// <summary>
        /// Event handler to generate a PDF from the text in the TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Letter of feedback";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times", 12);
            XTextFormatter textFormatter = new XTextFormatter(gfx);
            XRect rectangle = new XRect(0, 0, page.Width, page.Height);
            gfx.DrawRectangle(XBrushes.White, rectangle);
            textFormatter.DrawString(tbxPreview.Text, font, XBrushes.Black, rectangle, XStringFormats.TopLeft);
            const string filename = "feedbackTest.pdf";
            document.Save(filename);
        }

        private void tbxPreview_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
