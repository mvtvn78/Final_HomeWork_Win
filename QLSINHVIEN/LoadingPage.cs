using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
namespace QLSINHVIEN
{
    public partial class LoadingPage : Form
    {
        SqlConnection conn;
        int countTimer = 0;
        bool isLoaded = false;
        User user_ac;
        public LoadingPage(User user)
        {
            InitializeComponent();
            user_ac = user;
            conn = new SqlConnection(Common.strCon);
        }

        private void timerLabel_Tick(object sender, EventArgs e)
        {
            label1.Left -= 2;
            if(label1.Left <=200 )
            {
                timerLabel.Stop();
                timerLabel1.Start();
            }    
        }

        private void timerLabel1_Tick(object sender, EventArgs e)
        {
            label1.Left += 2;
            if (label1.Left >= 245)
            {
                timerLabel1.Stop();
                timerLabel.Start();
            }
        }

        private void timerProcess_Tick(object sender, EventArgs e)
        {
            // Continuous Stage
            panel2.Width += 10;
            if (countTimer == 0)
            {
                Thread s = new Thread(new ThreadStart(() =>
                {
                    while (!isLoaded)
                    {
                        float x =  (float) panel2.Width /270 * 100 ;
                        Console.WriteLine(x);
                        label1.Invoke((MethodInvoker)(() => label1.Text = "Đang tải " + Math.Round(x,2) + " %"));
                    }
                    label1.Invoke((MethodInvoker)(() => label1.Text = "Đã tải 100" + " %"));
                    //
                }));
                s.IsBackground = true;
                s.Start();
            }
            countTimer += 1;
            //Finish Stage
            if (panel2.Width >= 270)
            {
                timerProcess.Stop();
                isLoaded = true;
                //
                //sql
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from NGUOIDUNG where TENND = @TENND and PASS = @PASS", conn);
                //add
                cmd.Parameters.Add("TENND", SqlDbType.VarChar);
                cmd.Parameters.Add("PASS", SqlDbType.Char);
                //pass
                cmd.Parameters["TENND"].Value = user_ac.UserName;
                cmd.Parameters["PASS"].Value = user_ac.Password;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //Save file binary
                    FileHandler.StoreInfo(FileHandler.getJsonStrByObject(user_ac));
                    Dashboard dashboard = new Dashboard(user_ac);
                    this.Hide();
                    if (dashboard.ShowDialog() == DialogResult.Cancel)
                    {
                        this.Close();
                    }  
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
                //
                conn.Close();
                reader.Close();
                //
            }
        }
    }
}
