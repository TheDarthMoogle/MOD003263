using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //set the connection string
            string connectionString = Properties.Settings.Default.TemplateDBString;
            DBConnection.ConnectionStr = connectionString;
            
            Application.Run(new Form1());
        }
    }
}
