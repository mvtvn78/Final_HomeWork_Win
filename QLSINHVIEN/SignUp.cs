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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QLSINHVIEN
{
    public partial class SignUp : Form
    {
        SqlConnection conn;
        public SignUp()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Common.DisplayLabelBaseText(textBox1, label3);
            errSignUp.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Common.DisplayLabelBaseText(textBox3, label2);
            errSignUp.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Common.DisplayLabelBaseText(textBox2, label4);
            errSignUp.Clear();
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

        private void label2_Click(object sender, EventArgs e)
        {
            textBox3.Select();
            textBox3.Focus();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            //panel
            Common.makeOpacity(panel1, 50, 255, 255, 255);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        bool CheckUserExist()
        {
            bool x = false;
            if(conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from NGUOIDUNG  where TENND =@TENND",conn);
            sqlCommand.Parameters.Add("TENND", SqlDbType.VarChar);
            sqlCommand.Parameters["TENND"].Value = textBox1.Text;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                x = true;
            }
            //
            conn.Close();
            reader.Close();
            return x;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty)
            {
                if(!CheckUserExist() && textBox2.Text.Trim() == textBox3.Text.Trim())
                {
                    try
                    {
                        conn.Open();
                        Random rd = new Random();
                        string mand = "" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Year + rd.Next(0, 99);
                        if(mand.Length >10)
                            mand = mand.Substring(0,10);
                        Console.Write(mand);
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO NGUOIDUNG VALUES(@MAND,@TENND,@PASS)",conn);
                        sqlCommand.Parameters.Add("MAND", SqlDbType.Char);
                        sqlCommand.Parameters.Add("TENND", SqlDbType.VarChar);
                        sqlCommand.Parameters.Add("PASS", SqlDbType.Char);
                        sqlCommand.Parameters["MAND"].Value = mand;
                        sqlCommand.Parameters["TENND"].Value = textBox1.Text;
                        sqlCommand.Parameters["PASS"].Value = textBox2.Text;
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Đã đăng ký thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        conn.Close();
                        
                    }
                    catch(Exception ex)
                    {
                        Console.Write(ex.ToString());
                        MessageBox.Show( "Vui lòng thử lại sau", "Có lỗi xảy ra khi chèn dữ liệu");
                    }
                }
                else
                {
                    errSignUp.SetError(textBox1, "Hai mật khẩu không trùng hoặc người dùng đã tồn tại");
                    errSignUp.SetError(textBox2, "Hai mật khẩu không trùng hoặc người dùng đã tồn tại");
                    errSignUp.SetError(textBox3, "Hai mật khẩu không trùng hoặc người dùng đã tồn tại");
                } 
                    
            }
            else
            {
                errSignUp.SetError(button1, "Vui lòng nhập đầy đủ thông tin");
            }
        }
    }
}
