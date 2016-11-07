﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LogInForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btn_reset_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsername.Clear();
            txtUsername.Focus();
        }

        // Adds the user input from the text boxes to the variables that given as the arguments for the LogInQuery method.
        // Creates an instance of the Query class and then sets the bool variable to the return value of the LogInQuery method.
        // The if statement then decides what to do based off the return value.

        // To do - Look at moving more of this code away from the button.
        //       - Add extra message boxes for things such as empty text boxes.
        private void btn_enter_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool boolReturnValue;


            var login = new Query();
            boolReturnValue = login.LogInQuery(username, password);

            if (boolReturnValue == true)
            {
                DataSet dsUser = DBConnection.getDBConnectionInstance().getDataSet(Constants.sq);
                DataTable dtUser = dsUser.Tables[3];

                foreach(DataRow row in dtUser.Rows)
                {
                    int userID = row.Field<int>(1);
                    if(userID == 1)
                    {
                        Admin form = new Admin();
                        form.Show();
                    }
                    else
                    {
                        User form = new User();
                        form.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }

        }

      

    }
}