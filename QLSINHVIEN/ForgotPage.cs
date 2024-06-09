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
    public partial class ForgotPage : Form
    {
        SqlConnection conn;
        public ForgotPage()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
        }

        private void ForgotPage_Load(object sender, EventArgs e)
        {
            //panel
            Common.makeOpacity(panel1, 50, 255, 255, 255);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Common.DisplayLabelBaseText(textBox1, label3);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from NGUOIDUNG  where TENND =@TENND", conn);
            sqlCommand.Parameters.Add("TENND", SqlDbType.VarChar);
            sqlCommand.Parameters["TENND"].Value = textBox1.Text;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    MessageBox.Show(reader.GetValue(2).ToString(), "Mật khẩu của bạn");
                }    
            }
            else
            {
                MessageBox.Show("Tên người dùng không tồn tại");
            }
            //
            conn.Close();
            reader.Close();
        }
    }
}
