using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QLSINHVIEN
{
    public partial class GiaoVienPage : Form
    {
        SqlConnection conn;
        DataSet ds_GV;
        SqlDataAdapter adapter;
        //
        DataTable genders;
        //
        bool modeThem = true;
        public GiaoVienPage()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
            ds_GV = new DataSet();
            genders = new DataTable();
            genders.Columns.Add("TenGT", typeof(string));
            genders.Columns.Add("GiaTri", typeof(bool));
            genders.Rows.Add("Nữ", false);
            genders.Rows.Add("Nam",true);
        }
        void UnBinding()
        {
            maGV.DataBindings.Clear();
            TenGV.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            cbQQ.DataBindings.Clear();
            cbGender.DataBindings.Clear();
        }
        void Binding()
        {
            maGV.DataBindings.Add("Text", ds_GV.Tables["GiaoVien"], "MAGV");
            TenGV.DataBindings.Add("Text", ds_GV.Tables["GiaoVien"], "TENGV");
            dateTimePicker1.DataBindings.Add("Text", ds_GV.Tables["GiaoVien"], "NgaySinh");
            cbQQ.DataBindings.Add("SelectedValue", ds_GV.Tables["GiaoVien"], "MAQQ");
            cbGender.DataBindings.Add("SelectedValue", ds_GV.Tables["GiaoVien"], "GioiTinh");
        }
        private void GiaoVienPage_Load(object sender, EventArgs e)
        {
            //Combobox
            cbGender.DataSource = genders;
            cbGender.DisplayMember = "TenGT";
            cbGender.ValueMember = "GiaTri";
            //
            //sql
            conn.Open();
            adapter = new SqlDataAdapter("select * from GIAOVIEN",conn);
            adapter.Fill(ds_GV, "GiaoVien");
            dataGridView1.DataSource = ds_GV.Tables["GiaoVien"];
            //cb QQ
            adapter = new SqlDataAdapter("select * from QUEQUAN", conn);
            DataTable tbqq = new DataTable();
            adapter.Fill(tbqq);
            cbQQ.DataSource = tbqq;
            cbQQ.DisplayMember = "TENQQ";
            cbQQ.ValueMember = "MAQQ";
            conn.Close();

            //binding
            UnBinding();
            Binding();
            //
            dataGridView1.ClearSelection();
            maGV.Enabled = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (maGV.Text != string.Empty && MessageBox.Show("Bạn có chắc sửa mã " + maGV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                try
                {
                    Console.WriteLine("CHECK >>> >>" + maGV.Text + " " + cbQQ.SelectedValue + " " + TenGV.Text.Trim() + " " + cbGender.SelectedValue + dateTimePicker1.Text);
                    SqlCommand cmd = new SqlCommand("Update GIAOVIEN set MAQQ =@MAQQ , TenGV =@TenGV,GioiTinh =@GioiTinh , NgaySinh =@NgaySinh WHERE MAGV =@MAGV", conn);
                    cmd.Parameters.Add("MAGV", SqlDbType.Char);
                    cmd.Parameters.Add("TenGV", SqlDbType.NVarChar);
                    cmd.Parameters.Add("MAQQ", SqlDbType.Char);
                    cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime);
                    cmd.Parameters.Add("GioiTinh", SqlDbType.Bit);
                    //
                    cmd.Parameters["MAGV"].Value = maGV.Text.Trim();
                    cmd.Parameters["TenGV"].Value = TenGV.Text.Trim();
                    cmd.Parameters["MAQQ"].Value = cbQQ.SelectedValue;
                    cmd.Parameters["NgaySinh"].Value = Common.getFormatDateStore(dateTimePicker1.Text);
                    cmd.Parameters["GioiTinh"].Value = cbGender.SelectedValue;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công", "Thông báo");
                    ds_GV.Tables[0].Clear();
                    adapter = new SqlDataAdapter("select * from GIAOVIEN", conn);
                    adapter.Fill(ds_GV, "Giaovien");
                    dataGridView1.DataSource = ds_GV.Tables[0];
                    UnBinding();
                    Binding();
                }
                catch
                {
                    MessageBox.Show("Vui lòng thử lại sau, lỗi không thể sửa cho mã " + maGV.Text, "Thông báo");
                }
                conn.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            searchGV.Select();
            searchGV.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (searchGV.Text == string.Empty)
            {
                label4.Visible = true;
                return;
            }
            label4.Visible = false;
            if(conn.State !=ConnectionState.Open)
            conn.Open();
            string sql = "select * from GIAOVIEN where  MAGV LIKE N'%" + searchGV.Text + "%'" + "OR TenGV LIKE N'%" + searchGV.Text + "%'";
            adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds_GV.Tables[0].Rows.Clear();
            adapter.Fill(ds_GV, "GiaoVien");
            dataGridView1.DataSource = ds_GV.Tables["GiaoVien"];
            conn.Close();
        }
        void resetForm ()
        {
            maGV.Text = string.Empty;
            TenGV.Text = string.Empty;
            cbGender.Text = "Nam";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modeThem)
            {
                Bitmap bitmap = Properties.Resources.icons8_save_32;
                button1.Image = bitmap;
                button1.Text = "      Lưu";
                resetForm();
                maGV.Enabled = true;
                UnBinding();
            }
            else
            {
                if (maGV.Text == string.Empty || TenGV.Text == string.Empty)
                {
                    MessageBox.Show("Bạn vui lòng nhập đầy đủ thông tin");
                    return;
                }
                if (Common.checkExistCode("select * from GIAOVIEN where MAGV='" + maGV.Text + "'", conn))
                {
                    UnBinding();
                    resetForm();
                    MessageBox.Show("Đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //
                adapter = new SqlDataAdapter("select * from GIAOVIEN", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                //
                
                try
                {
                    ds_GV.Tables["Giaovien"].Rows.Add(maGV.Text.Trim(), cbQQ.SelectedValue, TenGV.Text.Trim(), cbGender.SelectedValue, Common.getFormatDateStore(dateTimePicker1.Text));
                    int kt = adapter.Update(ds_GV, "Giaovien");
                    if (kt <= 0)
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
                    maGV.Enabled = false;
                    UnBinding();
                    Binding();
                }
                catch
                {
                    MessageBox.Show("có lỗi xảy ra", "THem giao vien");
                }
            }
            modeThem = !modeThem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                adapter = new SqlDataAdapter("select * from GIAOVIEN", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                conn.Close();
                if (maGV.Text != string.Empty && MessageBox.Show("Bạn có chắc muốn xóa mã " + maGV.Text.Trim(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    //
                    builder.GetDeleteCommand();
                    int check = adapter.Update(ds_GV, "GiaoVien");
                    if (check > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại mã " + maGV.Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa mã" + maGV.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!modeThem)
            {
                MessageBox.Show("Vui lòng thêm trước khi thao tác");
                dataGridView1.ClearSelection();
                return;
            }
            maGV.Enabled = false;
            UnBinding();
            Binding();
            UnBinding();
        }
    }
}
