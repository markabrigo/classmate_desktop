using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using MetroFramework.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmRGB : MetroForm
    {
        Color paintcolor;
        bool choose = false;
        
        
        public frmRGB()
        {
            InitializeComponent();
        }

        private void color()
        {
            
        }
        private void frmRGB_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            choose = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (choose)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();
                paintcolor = bmp.GetPixel(e.X, e.Y);
                hsbR.Value = paintcolor.R;
                hsbG.Value = paintcolor.G;
                hsbB.Value = paintcolor.B;
                txtR.Text = paintcolor.R.ToString();
                txtG.Text = paintcolor.G.ToString();
                txtB.Text = paintcolor.B.ToString();
               
                
             }
        }
        

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            choose = false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
           

        }

        private void hsbR_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
