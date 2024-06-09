using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLSINHVIEN
{
    public partial class SignIn : Form
    {
        SqlConnection conn;
        SignUp signUp = null;
        ForgotPage forgotPage = null;
        public SignIn()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
        }
        private void SignPage_Load(object sender, EventArgs e)
        {
            //panel
            Common.makeOpacity(panel1,50,255,255,255);
            //Check user logined
            string jsonUser = string.Empty;
            // Can getValue
            if (FileHandler.getInfo(ref jsonUser))
            {
                User user= FileHandler.getObjectByStr<User>(jsonUser);
                //Query 
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from NGUOIDUNG where TENND = @TENND and PASS = @PASS", conn);
                //add
                cmd.Parameters.Add("TENND", SqlDbType.VarChar);
                cmd.Parameters.Add("PASS", SqlDbType.Char);
                //pass
                cmd.Parameters["TENND"].Value = user.UserName;
                cmd.Parameters["PASS"].Value = user.Password;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Dashboard dashboard = new Dashboard(user);
                    if(dashboard.ShowDialog() == DialogResult.Cancel)
                    {
                        this.Close();
                    }    
                }
                conn.Close();
                reader.Close();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Common.DisplayLabelBaseText(textBox1, label3);
            errorSignIn.Clear();
        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Common.DisplayLabelBaseText(textBox2, label4);
            errorSignIn.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            textBox1.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox2.Select();
            textBox2.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(signUp ==null) 
                signUp = new SignUp();
            // 
            if(signUp.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
                this.Activate();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(forgotPage ==null)
                forgotPage = new ForgotPage();
            //
            if(forgotPage.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
                this.Activate();
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty && textBox2.Text.Trim() == string.Empty)
            {
                errorSignIn.SetError(button1, "Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                User user = new User(textBox1.Text,textBox2.Text);
                //
                this.Hide();
                if(new LoadingPage(user).ShowDialog() == DialogResult.Cancel)
                {
                    this.Close();
                }
                else
                {
                    errorSignIn.SetError(textBox2, "Tài khoản hoặc mật khẩu không chính xác");
                    errorSignIn.SetError(textBox1, "Tài khoản hoặc mật khẩu không chính xác");
                    this.Show();
                    this.Activate();
                }
            }
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
