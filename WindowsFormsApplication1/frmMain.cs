using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using MetroFramework.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    
    public partial class frmMain : MetroForm
    {

        //Pass the username name in main form
        private string Nm;
        public string PassusernamefromfrmLogintofrmMain
        {
            get { return Nm; }
            set { Nm = value; }
        }

                
 
        //Chaat Module -------------------------------------------------------
        // Will hold the user name
        private string stdUserName = "Unknown";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;

        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);

        // Needed to set the form to a "disconnected" state from another thread
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;
        
        private delegate void UpdateStatusCallback(string strMessage);

        bool draw = false;
        int x, y, lx, ly = 0;
        Item currItem;
        int k = 0;
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);

        public frmMain()
        {
            // On application exit, don't forget to disconnect first
            Application.ApplicationExit += new EventHandler(stdOnApplicationExit);
            InitializeComponent();

        }

        public void stdOnApplicationExit(object sender, EventArgs e)
        {
            if (Connected == true)
            {
                // Closes the connections, streams, etc.
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (lblRoomName.Text == "--------------------")
            {
                MessageBox.Show("Select Claassroom First");
            }
            else
            {
                txtLog.Visible = false;
                stdtxtLog.Visible = true;

                // If we are not currently connected but awaiting to connect
                if (Connected == false)
                {
                    // Initialize the connection
                    InitializeConnection();
                }
                else // We are connected, thus disconnect
                {
                    CloseConnection("Disconnected at user's request.");
                }
            }
            
        }
        private void InitializeConnection()
        {
            // Parse the IP address from the TextBox into an IPAddress object
            ipAddr = IPAddress.Parse(txtIp.Text);
            // Start a new TCP connections to the chat server
            tcpServer = new TcpClient();
            tcpServer.Connect(ipAddr, 1986);

            // Helps us track whether we're connected or not
            Connected = true;
            // Prepare the form
            stdUserName = lblUsername.Text;

            // Disable and enable the appropriate fields
            txtIp.Enabled = false;
            txtMessage.Enabled = true;
            stdbtnSend.Enabled = true;
            stdbtnConnect.Text = "Disconnect";

            // Send the desired username to the server
            swSender = new StreamWriter(tcpServer.GetStream());
            swSender.WriteLine(lblUsername.Text);
            swSender.Flush();

            // Start the thread for receiving messages and further communication
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }
        private void ReceiveMessages()
        {
            // Receive the response from the server
            srReceiver = new StreamReader(tcpServer.GetStream());
            // If the first character of the response is 1, connection was successful
            string ConResponse = srReceiver.ReadLine();
            // If the first character is a 1, connection was successful
            if (ConResponse[0] == '1')
            {
                // Update the form to tell it we are now connected
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connected Successfully!" });
                
            }
            else // If the first character is not a 1 (probably a 0), the connection was unsuccessful
            {
                string Reason = "Not Connected: ";
                // Extract the reason out of the response message. The reason starts at the 3rd character
                Reason += ConResponse.Substring(2, ConResponse.Length - 2);
                // Update the form with the reason why we couldn't connect
                this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { Reason });
                // Exit the method
                return;
            }
            // While we are successfully connected, read incoming lines from the server
            while (Connected)
            {
                // Show the messages in the log TextBox
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { srReceiver.ReadLine() });
                
            }
        }
        // This method is called from a different thread in order to update the log TextBox
        private void UpdateLog(string Message)
        {
            // Append text also scrolls the TextBox to the bottom each time
            stdtxtLog.AppendText(Message + "\r\n");
        }

        // Closes a current connection
        private void CloseConnection(string Reason)
        {
            // Show the reason why the connection is ending
            stdtxtLog.AppendText(Reason + "\r\n");
            // Enable and disable the appropriate controls on the form
            txtIp.Enabled = true;
            txtMessage.Enabled = false;
            stdbtnSend.Enabled = false;
            stdbtnConnect.Text = "Connect";

            // Close the objects
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }
        // Sends the message typed in to the server
        private void stdSendMessage()
        {
            if (txtMessage.Lines.Length >= 1)
            {
                swSender.WriteLine(txtMessage.Text);
                swSender.Flush();
                txtMessage.Lines = null;
            }
            txtMessage.Text = "";
        }
        public enum Item
        {
            Rectangle, Ellipse, Line, Text, Brush, Pencil, Eraser, ColorPicker, Circle, EraserSize, InsertPicture
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Nm;
            
            metroPanel2.Enabled = false;
            metroPanel3.Enabled = false;
            metroPanel4.Enabled = false;
            metroPanel5.Enabled = false;


        }

        private void button32_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.Black;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.Green;
        }

        private void button34_Click(object sender, EventArgs e)
        {
           
            btColor.BackColor = System.Drawing.Color.Red;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.Blue;
           

            
        }

        private void button31_Click(object sender, EventArgs e)
        {
           
            btColor.BackColor = System.Drawing.Color.Yellow;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.Pink;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.Gray;
        }

        private void button28_Click(object sender, EventArgs e)
        {
           
            btColor.BackColor = System.Drawing.Color.Orange;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.Violet;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.Purple;
        }

        private void button25_Click(object sender, EventArgs e)
        {
           
            btColor.BackColor = System.Drawing.Color.Olive;

        }

        private void btColor_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {
            
        }

        private void btLine_Click(object sender, EventArgs e)
        {
            
        }

        private void btShape_Click(object sender, EventArgs e)
        {
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
            
            btColor.BackColor = System.Drawing.Color.White;
        }

        private void btColor_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
            draw = false;
            lx = e.X;
            ly = e.Y;
            if(currItem == Item.Line)
            {
                
                    Graphics g = wb1.CreateGraphics();
                    g.DrawLine(new Pen(btColor.BackColor, Convert.ToInt32(txtBrushSize.Text)), new Point(x, y), new Point(e.X, e.Y));
                    g.Dispose();
                
                
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           if (draw)
           {
               Graphics g = wb1.CreateGraphics();
               
               switch (currItem)
               {
                   case Item.Rectangle:
                       g.DrawRectangle(new Pen(btColor.BackColor, 3), e.X, e.Y, x, y);
                       break;
                   case Item.Circle:
                       g.DrawEllipse(new Pen(btColor.BackColor, 3), x, y, e.X - x - y, e.Y - y - x);
                       break;
                   case Item.Pencil:
                       
                       if(k == 1)
                       {
                           
                               Pen p = new Pen(btColor.BackColor, Convert.ToInt32(txtBrushSize.Text));
                               ep = e.Location;
                               g.DrawLine(p, sp, ep);
                           
                           
                       }
                       sp = ep;
                       break;
                    case Item.Eraser:
                       g.FillEllipse(new SolidBrush(wb1.BackColor), e.X - x + x, e.Y - y + y, 3, 3);
                       break;
                   case Item.EraserSize:
                       g.FillEllipse(new SolidBrush(wb1.BackColor), e.X - x + x, e.Y - y + y, Convert.ToInt32(txtBrushSize.Text), Convert.ToInt32(txtBrushSize.Text));
                       break;
                     g.Dispose();
 
                   
           }
           
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
            sp = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                k = 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            plLine.Visible = true;
            currItem = Item.Pencil;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            frmFontStyle newFontStyle = new frmFontStyle();
            newFontStyle.Close();
            plLine.Visible = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            plLine.Visible = false;
            txtBrushSize.Text = "3";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            plLine.Visible = false;
            txtBrushSize.Text = "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            plLine.Visible = false;
            txtBrushSize.Text = "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            plLine.Visible = false;
            txtBrushSize.Text = "10";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btSizeEraser.Visible = false;
            btSizePen.Visible = true;
            currItem = Item.Pencil;            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            currItem = Item.Eraser;
            btSizeEraser.Visible = true;
            btSizePen.Visible = false;
        }

        private void btSizeEraser_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button12_Click_1(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void btSizeEraser_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void classRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btStartClass.Visible = true;
            stdbtnConnect.Visible = false;
            
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            frmRGB newRGB = new frmRGB();
            newRGB.ShowDialog();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {

        }

        private void button59_Click(object sender, EventArgs e)
        {

        }

        private void button62_Click(object sender, EventArgs e)
        {
            
        }

        private void button45_Click(object sender, EventArgs e)
        {
            currItem = Item.Line;
            btSizePen.Visible = true;
            btSizeEraser.Visible = false;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            
        }

        private void button51_Click(object sender, EventArgs e)
        {
            currItem = Item.Rectangle;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            currItem = Item.Circle;
        }

        private void pl1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtBrushSize.Text = "3";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtBrushSize.Text = "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtBrushSize.Text = "7";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtBrushSize.Text = "10";
        }

        private void btSizeEraser_Click_2(object sender, EventArgs e)
        {
            currItem = Item.EraserSize;
            plLine.Visible = true; ;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(wb1.Width, wb1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = wb1.RectangleToScreen(wb1.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, wb1.Size);
            g.Dispose();
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "image";
            save.Filter = "Png files|*.png|Jpeg files|*.jpg|Bitmaps|*.bmp";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(System.IO.File.Exists(save.FileName))
                {
                    System.IO.File.Delete(save.FileName);
                }
                else {
                        if (save.FileName.Contains(".jpg"))
                        
                        {
                            bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        else if (save.FileName.Contains(".png"))
                        {
                            bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else if (save.FileName.Contains(".bmp"))
                        {
                            bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                    }       
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btInsertText_Click(object sender, EventArgs e)
        {
            
            frmFontStyle newFontStyle = new frmFontStyle();
            newFontStyle.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|.bmp";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {             
                wb1.Image = (Image)Image.FromFile(open.FileName).Clone();
            }
        }

        private void plFontStyle_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(wb1.Width, wb1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = wb1.RectangleToScreen(wb1.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, wb1.Size);
            g.Dispose();
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "image";
            save.Filter = "Png files|*.png|Jpeg files|*.jpg|Bitmaps|*.bmp";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (System.IO.File.Exists(save.FileName))
                {
                    System.IO.File.Delete(save.FileName);
                }
                else
                {
                    if (save.FileName.Contains(".jpg"))
                    {
                        bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (save.FileName.Contains(".png"))
                    {
                        bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (save.FileName.Contains(".bmp"))
                    {
                        bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|.bmp";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wb1.Image = (Image)Image.FromFile(open.FileName).Clone();
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult resultNewBoard = MessageBox.Show("Make new White Board. All your progress will be lost. Save it first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
           if(resultNewBoard == DialogResult.No)
           {
               wb1.Refresh();
           }
               else if(resultNewBoard == DialogResult.Yes)
           {
                   Bitmap bmp = new Bitmap(wb1.Width, wb1.Height);
                   Graphics g = Graphics.FromImage(bmp);
                   Rectangle rect = wb1.RectangleToScreen(wb1.ClientRectangle);
                   g.CopyFromScreen(rect.Location, Point.Empty, wb1.Size);
                   g.Dispose();
                   SaveFileDialog save = new SaveFileDialog();
                   save.FileName = "image";
                   save.Filter = "Png files|*.png|Jpeg files|*.jpg|Bitmaps|*.bmp";
                   if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                   {
                       if (System.IO.File.Exists(save.FileName))
                       {
                           System.IO.File.Delete(save.FileName);
                       }
                       else
                       {
                           if (save.FileName.Contains(".jpg"))
                           {
                               bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                           }
                           else if (save.FileName.Contains(".png"))
                           {
                               bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                           }
                           else if (save.FileName.Contains(".bmp"))
                           {
                               bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                           }
                       }
               }

           }
            
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            stdSendMessage();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the key is Enter
            if (e.KeyChar == (char)13)
            {
                stdSendMessage();
            }
        }

        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Call the method that updates the form
            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { e.EventMessage });
        }

        private void UpdateStatus(string strMessage)
        {
            // Updates the log with the message
            txtLog.AppendText(strMessage + "\r\n");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            txtLog.Visible = true;
            stdtxtLog.Visible = false;
            // Parse the server's IP address out of the TextBox
            IPAddress ipAddr = IPAddress.Parse(txtIp.Text);
            // Create a new instance of the ChatServer object
            ChatServer mainServer = new ChatServer(ipAddr);
            // Hook the StatusChanged event handler to mainServer_StatusChanged
            ChatServer.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
            // Start listening for connections
            mainServer.StartListening();
            // Show that we started to listen for connections
            txtLog.AppendText("Monitoring for connections...\r\n");
            metroPanel2.Enabled = true;
            metroPanel3.Enabled = true;
            metroPanel4.Enabled = true;
            metroPanel5.Enabled = true;
            toolStrip1.Enabled = true;
        }

        

        

        

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click_2(object sender, EventArgs e)
        {

        }

        private void cmbFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btFill_Click(object sender, EventArgs e)
        {

        }

        private void plVideo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmClassrooms newClassroom = new frmClassrooms();
            newClassroom.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

       
        
    }
}
