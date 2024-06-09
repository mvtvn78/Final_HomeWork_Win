using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSINHVIEN
{
     public partial class Dashboard : Form
    {
        //
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //
        HomePage homePage =null;
        HocSinhPage hsPage = null;
        GiaoVienPage gvPage = null;
        UserPage userPage = null;
        MonHocPage monhocPage =null;
        XemDiem xemDPage = null;
        ChamDiem chamDiem = null;
        //
        bool fire_drop_SV = true;
        bool fire_drop_GV = true;
        //User
        User user_Access = null;
        public Dashboard(User user_1 = null)
        {
            InitializeComponent();
            user_Access = user_1;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (user_Access.UserName.Length >10)
            {
                TenND.Text = "@"+user_Access.UserName.Substring(0,10);
            }
            else
            {
                TenND.Text = "@" + user_Access.UserName;
            }
            //Homepage
            if (homePage == null)
            {
                homePage = new HomePage();
                homePage.MdiParent = this;
                //fill the entire client size of its parent
                homePage.Dock = DockStyle.Fill;
                homePage.Show();
            }
            else
            {
                homePage.Activate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(homePage == null)
            {
                homePage = new HomePage();
                homePage.MdiParent = this;
                //fill the entire client size of its parent
                homePage.Dock = DockStyle.Fill;
                homePage.Show();
            }
            else
            {
                homePage.Activate();
            }
        }

        private void timerDropSV_Tick(object sender, EventArgs e)
        {
            if(fire_drop_SV)
            {
                dropdownSV.Height += 10;
                if(dropdownSV.Height >= 125)
                {
                    dropdownSV.Height = 125;
                    timerDropSV.Stop();
                    fire_drop_SV= false;
                }    
            }
            else
            {
                dropdownSV.Height -= 10;
                if (dropdownSV.Height <= 45)
                {
                    dropdownSV.Height = 45;
                    timerDropSV.Stop();
                    fire_drop_SV = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timerDropSV.Start();
            if (hsPage == null) 
            { 
                hsPage = new HocSinhPage();
                hsPage.MdiParent = this;
                //fill the entire client size of its parent
                hsPage.Dock = DockStyle.Fill;
                hsPage.Show(); }
             else
            {
                hsPage.Activate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timerDropGV.Start();
            if (gvPage == null)
            {  
             gvPage = new GiaoVienPage();
             gvPage.MdiParent = this;
             //fill the entire client size of its parent
             gvPage.Dock = DockStyle.Fill;
             gvPage.Show();
            }
             else
            {
                gvPage.Activate();
            }
        }

        private void timerDropGV_Tick(object sender, EventArgs e)
        {
            if (fire_drop_GV)
            {
                dropDownGV.Height += 10;
                if (dropDownGV.Height >= 75)
                {
                    dropDownGV.Height = 75;
                    timerDropGV.Stop();
                    fire_drop_GV = false;
                }
            }
            else
            {
                dropDownGV.Height -= 10;
                if (dropDownGV.Height <= 50)
                {
                    dropDownGV.Height = 46;
                    timerDropGV.Stop();
                    fire_drop_GV = true;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát khỏi chương trình","Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (userPage == null)
            {
                userPage = new UserPage();
                userPage.MdiParent = this;
                //fill the entire client size of its parent
                userPage.Dock = DockStyle.Fill;
                userPage.Show();
            }
            else
            {
                userPage.Activate();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FileHandler.removeFileInfo();
            SignIn signIn = new SignIn();
            this.Hide();
            if(signIn.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 
            this.DialogResult = DialogResult.Cancel;
        }

        //Drag on a control and moving window
        private void controlCustom_MouseDown(object sender, MouseEventArgs e)
        {
            //
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Maximum 
            if(this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Close 
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Minimize
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //monhoc
            if (monhocPage == null)
            {
                monhocPage = new MonHocPage();
                monhocPage.MdiParent = this;
                //fill the entire client size of its parent
                monhocPage.Dock = DockStyle.Fill;
                monhocPage.Show();
            }
            else
            {
                monhocPage.Activate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //xem diem
            if (xemDPage == null)
            {
                xemDPage = new XemDiem();
                xemDPage.MdiParent = this;
                //fill the entire client size of its parent
                xemDPage.Dock = DockStyle.Fill;
                xemDPage.Show();
            }
            else
            {
                xemDPage.Activate();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //chamdiem
            if (chamDiem == null)
            {
                chamDiem = new ChamDiem();
                chamDiem.MdiParent = this;
                //fill the entire client size of its parent
                chamDiem.Dock = DockStyle.Fill;
                chamDiem.Show();
            }
            else
            {
                chamDiem.Activate();
            }
        }

        private void ImgUser_Click(object sender, EventArgs e)
        {
            // get Anh
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImgUser.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}
