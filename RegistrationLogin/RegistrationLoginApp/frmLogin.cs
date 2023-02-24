using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistrationLoginApp
{
    public partial class frmLogin : Form
    {
        static string connString = ConfigurationManager.ConnectionStrings["RegistrationLoginApp.Properties.Settings.UserRegistrationConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();

            string login = $"SELECT * FROM tbl_users WHERE username = '{txtUsername.Text}' AND password = '{txtPassword.Text}'";
            cmd = new SqlCommand(login, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            bool userExists = false;

            while (reader.Read())
            {
                userExists = true;
                MessageBox.Show("Logging in...");
            }
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Enter all fields");
            }
            else if (!userExists)
            {
                MessageBox.Show("Invalid username/password");

                txtUsername.Clear();
                txtPassword.Clear();

                txtUsername.Focus();
            }
            conn.Close();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            new frmMain().Show();
            this.Hide();
        }
    }
}
