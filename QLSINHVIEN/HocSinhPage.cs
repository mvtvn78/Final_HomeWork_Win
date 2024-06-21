using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSINHVIEN
{
    public partial class HocSinhPage : Form
    {
        //
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataSet ds_SV;
        //
        DataTable genders;
        //
        bool modeThem = true;
        public HocSinhPage()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
            ds_SV = new DataSet();
            genders = new DataTable();
            genders.Columns.Add("TenGT", typeof(string));
            genders.Columns.Add("GiaTri", typeof(bool));
            genders.Rows.Add("Nữ", false);
            genders.Rows.Add("Nam", true);
        }

        void UnBinding()
        {
            maHS.DataBindings.Clear();
            TenHs.DataBindings.Clear();
            cbMaLop.DataBindings.Clear();
            cbQQ.DataBindings.Clear();
            cbGender.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
        }
        void Binding()
        {
            maHS.DataBindings.Add("Text", ds_SV.Tables["HocSinh"], "MAHS");
            TenHs.DataBindings.Add("Text", ds_SV.Tables["HocSinh"], "TENHS");
            cbMaLop.DataBindings.Add("SelectedValue", ds_SV.Tables["HocSinh"], "MALOP",true,DataSourceUpdateMode.OnPropertyChanged);
            cbQQ.DataBindings.Add("SelectedValue", ds_SV.Tables["HocSinh"], "MAQQ");
            cbGender.DataBindings.Add("SelectedValue", ds_SV.Tables["HocSinh"], "GioiTinh");
            dateTimePicker1.DataBindings.Add("Text", ds_SV.Tables["HocSinh"], "NgaySinh");
        }
        private void HocSinhPage_Load(object sender, EventArgs e)
        {
            //Combobox
            cbGender.DataSource = genders;
            cbGender.DisplayMember = "TenGT";
            cbGender.ValueMember = "GiaTri";
            //
            conn.Open();
            //
            adapter = new SqlDataAdapter("select * from LOP", conn);
            DataTable cb_LOP  = new DataTable();
            adapter.Fill(cb_LOP);
            cbMaLop.DataSource = cb_LOP;
            cbMaLop.DisplayMember = "TENLOP";
            cbMaLop.ValueMember = "MALOP";
            //
            adapter = new SqlDataAdapter("select * from QUEQUAN", conn);
            DataTable cb_QQ = new DataTable();
            adapter.Fill(cb_QQ);
            cbQQ.DataSource = cb_QQ;
            cbQQ.DisplayMember = "TENQQ";
            cbQQ.ValueMember = "MAQQ";
            //
            adapter = new SqlDataAdapter("select * from HOCSINH", conn);
            adapter.Fill(ds_SV,"HocSinh");
            dataGridViewHS.DataSource = ds_SV.Tables["HocSinh"];
            conn.Close();
            //Binding
            UnBinding();
            Binding();
            //Format binding
            //
            maHS.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                label7.Visible = true;
                return;
            }
            label7.Visible = false;
            conn.Open();
            string sql = "select * from HOCSINh where MAHS LIKE N'%" + textBox1.Text + "%'" + "OR TENHS LIKE N'%" + textBox1.Text + "%'";
            adapter = new SqlDataAdapter(sql, conn);
            ds_SV.Tables[0].Rows.Clear();
            adapter.Fill(ds_SV, "HocSinh");
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            dataGridViewHS.DataSource = ds_SV.Tables["HocSinh"];
            conn.Close();
        }
        void resetForm()
        {
            maHS.Text = string.Empty;
            TenHs.Text = string.Empty;
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
                maHS.Enabled = true;
                UnBinding();
            }
            else
            {
                if (maHS.Text == string.Empty || TenHs.Text == string.Empty)
                {
                    MessageBox.Show("Bạn vui lòng nhập đầy đủ thông tin");
                    return;
                }
                if (Common.checkExistCode("select * from HOCSINH where MAHS='" + maHS.Text + "'", conn))
                {
                    UnBinding();
                    resetForm();
                    MessageBox.Show("Đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //
                adapter = new SqlDataAdapter("select * from HOCSINH", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                //

                try
                {
                    ds_SV.Tables["HocSinh"].Rows.Add(maHS.Text.Trim(), cbQQ.SelectedValue, cbMaLop.SelectedValue, TenHs.Text.Trim(), cbGender.SelectedValue, Common.getFormatDateStore(dateTimePicker1.Text));
                    int kt = adapter.Update(ds_SV, "HocSinh");
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
                    maHS.Enabled = false;
                    UnBinding();
                    Binding();
                }
                catch
                {
                    MessageBox.Show("có lỗi xảy ra");
                }
            }
            modeThem = !modeThem;
        }

        private void dataGridViewHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!modeThem)
            {
                MessageBox.Show("Vui lòng thêm trước khi thao tác");
                dataGridViewHS.ClearSelection();
                return;
            }
            maHS.Enabled = false;
            UnBinding();
            Binding();
            UnBinding();
        }

        private void cbQQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                adapter = new SqlDataAdapter("select * from HOCSINH", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                conn.Close();
                if (maHS.Text != string.Empty && MessageBox.Show("Bạn có chắc muốn xóa mã " + maHS.Text.Trim(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    dataGridViewHS.Rows.Remove(dataGridViewHS.CurrentRow);
                    //
                    builder.GetDeleteCommand();
                    int check = adapter.Update(ds_SV, "HocSinh");
                    if (check > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại mã " + maHS.Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa mã" + maHS.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maHS.Text != string.Empty && MessageBox.Show("Bạn có chắc sửa mã " + maHS.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //
                if(conn.State != ConnectionState.Open) 
                    conn.Open();
                try
                {
                    Console.WriteLine("CHECK >>> >>" + maHS.Text + " " + cbQQ.SelectedValue + " " + TenHs.Text.Trim() + " " + cbGender.SelectedValue + dateTimePicker1.Text);
                    SqlCommand cmd = new SqlCommand("Update HOCSINH set MAQQ =@MAQQ ,MALOP =@MALOP, TENHS =@TENHS,GioiTinh =@GioiTinh , NgaySinh =@NgaySinh WHERE MAHS =@MAHS", conn);
                    cmd.Parameters.Add("MAHS", SqlDbType.Char);
                    cmd.Parameters.Add("TENHS", SqlDbType.NVarChar);
                    cmd.Parameters.Add("MAQQ", SqlDbType.Char);
                    cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime);
                    cmd.Parameters.Add("GioiTinh", SqlDbType.Bit);
                    cmd.Parameters.Add("MALOP", SqlDbType.Char);
                    //
                    cmd.Parameters["MAHS"].Value = maHS.Text.Trim();
                    cmd.Parameters["TENHS"].Value = TenHs.Text.Trim();
                    cmd.Parameters["MAQQ"].Value = cbQQ.SelectedValue;
                    cmd.Parameters["NgaySinh"].Value = Common.getFormatDateStore(dateTimePicker1.Text);
                    cmd.Parameters["GioiTinh"].Value = cbGender.SelectedValue;
                    cmd.Parameters["MALOP"].Value = cbMaLop.SelectedValue;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công", "Thông báo");
                    ds_SV.Tables[0].Clear();
                    adapter = new SqlDataAdapter("select * from HOCSINH", conn);
                    adapter.Fill(ds_SV, "HocSinh");
                    dataGridViewHS.DataSource = ds_SV.Tables[0];
                    UnBinding();
                    Binding();
                }
                catch
                {
                    MessageBox.Show("Vui lòng thử lại sau, lỗi không thể sửa cho mã " + maHS.Text, "Thông báo");
                }
                conn.Close();
            }
        }
    }
}
