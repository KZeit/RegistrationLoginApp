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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RegistrationLoginApp
{
    public partial class frmMain : Form
    {
        //static string connString = "Data Source=DESKTOP-B4A7 3HM\\SQLEXPRESS;Initial Catalog=UserRegistration;Integrated Security=True";

        static string connString = ConfigurationManager.ConnectionStrings["RegistrationLoginApp.Properties.Settings.UserRegistrationConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public frmMain()
        {
            InitializeComponent();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter all fields");

                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtUsername.Focus();
            }

            else if (txtPassword.Text == txtConfirmPassword.Text)
            {
                conn.Open();

                string register = $"INSERT INTO tbl_users VALUES ('{txtUsername.Text}', '{txtPassword.Text}')";

                cmd = new SqlCommand(register, conn);
                cmd.ExecuteNonQuery();                

                MessageBox.Show("Your account has been created");
            }
            else
            {
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                MessageBox.Show("Passwords do not match");

                txtPassword.Focus();
            }
            conn.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = '*';
        }
    }
}
