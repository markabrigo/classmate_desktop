namespace WindowsFormsApplication1
{
    partial class frmRGB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRGB));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.hsbG = new System.Windows.Forms.HScrollBar();
            this.hsbB = new System.Windows.Forms.HScrollBar();
            this.lblR = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.txtR = new System.Windows.Forms.Label();
            this.txtG = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.Label();
            this.hsbR = new System.Windows.Forms.HScrollBar();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-70, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(537, 463);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // hsbG
            // 
            this.hsbG.LargeChange = 1;
            this.hsbG.Location = new System.Drawing.Point(74, 37);
            this.hsbG.Maximum = 255;
            this.hsbG.Name = "hsbG";
            this.hsbG.Size = new System.Drawing.Size(375, 14);
            this.hsbG.TabIndex = 1;
            // 
            // hsbB
            // 
            this.hsbB.LargeChange = 1;
            this.hsbB.Location = new System.Drawing.Point(74, 64);
            this.hsbB.Maximum = 255;
            this.hsbB.Name = "hsbB";
            this.hsbB.Size = new System.Drawing.Size(375, 14);
            this.hsbB.TabIndex = 2;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(7, 10);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(15, 13);
            this.lblR.TabIndex = 5;
            this.lblR.Text = "R";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(7, 37);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(15, 13);
            this.lblG.TabIndex = 6;
            this.lblG.Text = "G";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(7, 64);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(14, 13);
            this.lblB.TabIndex = 7;
            this.lblB.Text = "B";
            // 
            // txtR
            // 
            this.txtR.AutoSize = true;
            this.txtR.Location = new System.Drawing.Point(43, 9);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(13, 13);
            this.txtR.TabIndex = 9;
            this.txtR.Text = "0";
            // 
            // txtG
            // 
            this.txtG.AutoSize = true;
            this.txtG.Location = new System.Drawing.Point(43, 37);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(13, 13);
            this.txtG.TabIndex = 10;
            this.txtG.Text = "0";
            // 
            // txtB
            // 
            this.txtB.AutoSize = true;
            this.txtB.Location = new System.Drawing.Point(43, 64);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(13, 13);
            this.txtB.TabIndex = 11;
            this.txtB.Text = "0";
            // 
            // hsbR
            // 
            this.hsbR.LargeChange = 1;
            this.hsbR.Location = new System.Drawing.Point(74, 9);
            this.hsbR.Maximum = 255;
            this.hsbR.Name = "hsbR";
            this.hsbR.Size = new System.Drawing.Size(375, 14);
            this.hsbR.TabIndex = 0;
            this.hsbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbR_Scroll);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(374, 549);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.TabIndex = 12;
            this.metroButton1.Text = "Ok";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Coral;
            this.button1.Location = new System.Drawing.Point(386, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmRGB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 579);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.hsbB);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.lblG);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.hsbG);
            this.Controls.Add(this.hsbR);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(180, 250);
            this.MaximumSize = new System.Drawing.Size(478, 600);
            this.Movable = false;
            this.Name = "frmRGB";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmRGB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.HScrollBar hsbG;
        private System.Windows.Forms.HScrollBar hsbB;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label txtR;
        private System.Windows.Forms.Label txtG;
        private System.Windows.Forms.Label txtB;
        private System.Windows.Forms.HScrollBar hsbR;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Button button1;
    }
}