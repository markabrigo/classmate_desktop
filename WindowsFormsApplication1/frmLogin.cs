using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace WindowsFormsApplication1
{
    public partial class frmLogin : MetroForm
    {

        private string conn;
        private MySqlConnection connect;
        string fullname;

        public frmLogin()
        {
            InitializeComponent();
        }

        

        private void db_connection()
        {
            try
            {
                conn = "server=localhost;user id=root;database=dbvirtualclassroom";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }
        private bool validate_login(string user, string pass )
        {
            
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM users WHERE username=@user and password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }
        
        private void btLogIn_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Please fill up all the fields");
                return;
            }
            bool r = validate_login(user, pass);
            if (r){

                MessageBox.Show("Wellcome " + user);
                this.Hide();
                frmMain newMain = new frmMain();
                newMain.PassusernamefromfrmLogintofrmMain = txtUsername.Text;
                newMain.Show();
   

            }
            else{
                MessageBox.Show("Incorrect Login Credentials");
            }
                

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
