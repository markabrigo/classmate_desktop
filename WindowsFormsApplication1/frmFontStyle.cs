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

namespace WindowsFormsApplication1
{
    public partial class frmFontStyle : MetroForm
    {
        public frmFontStyle()
        {
            InitializeComponent();
        }

        private void frmFontStyle_Load(object sender, EventArgs e)
        {
            FontFamily[] family = FontFamily.Families;
            foreach (FontFamily font in family)
            {
                cmbFontFamily.Items.Add(font.GetName(1).ToString());
            }
            
        }

        private void frmFontStyle_MouseLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmFontStyle_Leave(object sender, EventArgs e)
        {
            
        }

        private void frmFontStyle_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}
