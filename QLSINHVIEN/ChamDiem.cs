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
    public partial class ChamDiem : Form
    {
        SqlConnection conn;
        BindingSource bs;
        SqlDataAdapter adapter;
        DataSet dt;
        public ChamDiem()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
        }
        void Binding()
        {
            bs = new BindingSource(dt, "CHAMDIEM");
            cbMH.DataBindings.Add("SelectedValue", bs, "MAMH");
            cbHS.DataBindings.Add("SelectedValue", bs, "MAHS");
            DQT.DataBindings.Add("Text", bs, "diemQT");
            DTHI.DataBindings.Add("Text", bs, "diemThi");
        }
        void UnBinding()
        {
            cbMH.DataBindings.Clear();
            cbHS.DataBindings.Clear();
            DQT.DataBindings.Clear();
            DTHI.DataBindings.Clear();
        }
        private void ChamDiem_Load(object sender, EventArgs e)
        {
            //
            button7.Enabled = false;
            if (conn.State != ConnectionState.Open) 
                conn.Open();
            adapter = new SqlDataAdapter("select * from HOCSINH",conn);
            DataTable dt_SV = new DataTable();
            adapter.Fill(dt_SV);
            cbHS.DataSource = dt_SV;
            cbHS.DisplayMember = "MAHS";
            cbHS.ValueMember = "MAHS";
            //
            adapter = new SqlDataAdapter("select * from MONHOC", conn);
            DataTable dt_MON = new DataTable();
            adapter.Fill(dt_MON);
            cbMH.DataSource = dt_MON;
            cbMH.DisplayMember = "TENMH";
            cbMH.ValueMember = "MAMH";

            //
            adapter = new SqlDataAdapter("select * from HS_HOC_LOP", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
             dt= new DataSet();
            adapter.Fill(dt,"CHAMDIEM");
            //binding
            Binding();
            lbTrang.Text = "Trang " + (bs.Position + 1) + " Của " + bs.Count;
            conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            lbTrang.Text = "Trang " + (bs.Position + 1) + " Của " + bs.Count;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            lbTrang.Text = "Trang " + (bs.Position + 1) + " Của " + bs.Count;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bs.Position == 0)
                return;
            --bs.Position;
            lbTrang.Text = "Trang " + (bs.Position + 1) + " Của " + bs.Count;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bs.Position == bs.Count - 1)
                return;
            ++bs.Position;
            lbTrang.Text = "Trang " + (bs.Position + 1) + " Của " + bs.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.AddNew();
            button1.Enabled= false;
            button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                bs.EndEdit();
                int check = adapter.Update(dt, "CHAMDIEM");
                if (check > 0)
                {
                    MessageBox.Show("Lưu  thành công");
                }
                else
                    MessageBox.Show("Lưu thất bại");
            }
            catch
            {
                MessageBox.Show("Sinh viên đã học môn này hoặc có lỗi gì đó");
            }
            UnBinding();
            Binding();
            button1.Enabled = true;
            button7.Enabled = false;
        }
    }
}
