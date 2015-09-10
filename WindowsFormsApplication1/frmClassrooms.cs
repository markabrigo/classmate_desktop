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
    public partial class frmClassrooms : MetroForm
    {
        public frmClassrooms()
        {
            InitializeComponent();
        }

        private void frmClassrooms_Load(object sender, EventArgs e)
        {
            

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCreateClassRoom newCreateClassRoom = new frmCreateClassRoom();
            newCreateClassRoom.ShowDialog();
        }
    }
}
