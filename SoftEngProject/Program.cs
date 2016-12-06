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
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //set the connection string
            string connectionString = Properties.Settings.Default.TemplateDBString;
            DBConnection.ConnectionStr = connectionString;
            
            Application.Run(new LogInForm.frmLogin());
        }
    }
}
