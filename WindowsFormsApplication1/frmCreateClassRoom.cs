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
    public partial class frmCreateClassRoom : MetroForm
    {

        public frmCreateClassRoom()
        {
            InitializeComponent();

        }

        private void frmCreateClassRoom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClassName.Text == "" || txtDescription.Text == "")
            {
                MessageBox.Show("Please fill up all the fields");
            }
            else
            {
                DialogResult result = MessageBox.Show("Add This Classrom?", "New Classroom", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string connectionAdd = "server=localhost;user id=root;database=dbvirtualclassroom";
                    string queryAdd = "INSERT INTO classroom(subject_code, schedule_date_from, schedule_date_to, description) VALUES ('" + this.txtClassName.Text + "' , '" + this.tpFrom.Text + "' , '" + this.tpTo.Text + "' , , '" + this.txtDescription.Text + "');";
                    MySqlConnection connAdd = new MySqlConnection(connectionAdd);
                    MySqlCommand commAdd = new MySqlCommand(queryAdd, connAdd);
                    MySqlDataReader readerAdd;
                    connAdd.Open();
                    readerAdd = commAdd.ExecuteReader();
                    MessageBox.Show("Data Saved"); 
                    txtClassName.Text = "";
                    


                }
            }
        }
    }
}
