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
    public partial class UserPage : Form
    {
        SqlConnection conn;
        DataSet ds_US;
        SqlDataAdapter adapter;
        //
        bool modeThem = true;
        public UserPage()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
            ds_US = new DataSet();
        }
        void Binding()
        {
            maND.DataBindings.Add("Text", ds_US.Tables["Nguoidung"], "MAND");
            TenNd.DataBindings.Add("Text", ds_US.Tables["Nguoidung"], "TENND");
            pass.DataBindings.Add("Text", ds_US.Tables["Nguoidung"], "PASS");
        }
        void UnBinding()
        {
            maND.DataBindings.Clear();
            TenNd.DataBindings.Clear();
            pass.DataBindings.Clear();
        }
        private void UserPage_Load(object sender, EventArgs e)
        {
            maND.Enabled = false;
            //sql
            conn.Open();
            adapter = new SqlDataAdapter("select * from NGUOIDUNG", conn);
            adapter.Fill(ds_US, "Nguoidung");
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            dataGridView1.DataSource = ds_US.Tables["Nguoidung"];
            conn.Close();
            //binding
            Binding();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (maND.Text != string.Empty && MessageBox.Show("Bạn có chắc sửa mã " + maND.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    UnBinding();
                    //
                    conn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Update NGUOIDUNG set PASS =@PASS , TENND =@TENND WHERE MAND =@MAND", conn);
                        cmd.Parameters.Add("PASS", SqlDbType.Char);
                        cmd.Parameters.Add("TENND", SqlDbType.VarChar);
                        cmd.Parameters.Add("MAND", SqlDbType.Char);
                        cmd.Parameters["PASS"].Value = pass.Text.Trim();
                        cmd.Parameters["TENND"].Value = TenNd.Text.Trim();
                        cmd.Parameters["MAND"].Value = maND.Text.Trim();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        dataGridView1.ClearSelection();
                        UnBinding();
                        Binding();
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng thử lại sau, lỗi không thể sửa cho mã " + maND.Text, "Thông báo");
                    }
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa thông tin" + maND.Text);
            }
        }

     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!modeThem)
            {
                MessageBox.Show("Vui lòng thêm người dùng trước khi thao tác");
                dataGridView1.ClearSelection();
                return;
            }
            maND.Enabled = false;
            TenNd.Enabled = true;
            pass.Enabled = true;
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            try
            {
                if (maND.Text != string.Empty && MessageBox.Show("Bạn có chắc muốn xóa mã " + maND.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    //
                    int check = adapter.Update(ds_US, "Nguoidung");
                    if (check > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa");
            }
            
        }
        void resetForm()
        {
            maND.Text = string.Empty;
            TenNd.Text = string.Empty;
            pass.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (modeThem)
            {
                Bitmap bitmap =  Properties.Resources.icons8_save_32;
                button1.Image = bitmap;
                button1.Text = "      Lưu";
                resetForm();
                maND.Enabled = true;
                UnBinding();
            }
            else
            {
                if (maND.Text == string.Empty || TenNd.Text == string.Empty || pass.Text == string.Empty)
                {
                    MessageBox.Show("Bạn vui lòng nhập đầy đủ thông tin");
                    return;
                }    
                if (Common.checkExistCode("select * from NGUOIDUNG where MAND='" + maND.Text + "'",conn))
                {
                    UnBinding();
                    resetForm();
                    MessageBox.Show("Đã tồn tại","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                //
                ds_US.Tables["Nguoidung"].Rows.Add(maND.Text.Trim(), TenNd.Text.Trim(), pass.Text.Trim());
                int  kt = adapter.Update(ds_US, "Nguoidung");
                if(kt <=0 )
                {
                    MessageBox.Show("Thêm thất bại");
                } 
                else
                {
                    MessageBox.Show("Thêm thành công");
                }
                //
                Bitmap bitmap = Properties.Resources.icons8_add_32;
                button1.Image = bitmap;
                button1.Text = "      Thêm";
                //
                maND.Enabled = false;
                UnBinding();
                Binding();
            }
            modeThem = !modeThem;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                label1.Visible = true;
                return;
            }
            label1.Visible = false;
            conn.Open();
            string sql = "select * from NGUOIDUNG where MAND LIKE '%" + textBox1.Text+"%'" + "OR TENND LIKE '%" + textBox1.Text + "%'";
            adapter = new SqlDataAdapter(sql,conn);
            ds_US.Tables[0].Rows.Clear();
            adapter.Fill(ds_US, "Nguoidung");
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            dataGridView1.DataSource = ds_US.Tables["Nguoidung"];
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            textBox1.Focus();
        }

      
    }
}
