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
    public partial class MonHocPage : Form
    {
        SqlConnection   conn;
        DataTable genders;
        public MonHocPage()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
            genders = new DataTable();
            genders.Columns.Add("TenGT", typeof(string));
            genders.Columns.Add("GiaTri", typeof(bool));
            genders.Rows.Add("Nữ", false);
            genders.Rows.Add("Nam", true);
        }

        private void MonHocPage_Load(object sender, EventArgs e)
        {
            //
            gender.DataSource = genders;
            gender.DisplayMember = "TENGT";
            gender.ValueMember = "GiaTri";
            if(conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataAdapter adt = new SqlDataAdapter("select * from PHAN_CONG inner join GIAOVIEN  ON PHAN_CONG.MAGV = GIAOVIEN.MAGV  inner join MONHOC ON PHAN_CONG.MAMH = MONHOC.MAMH inner join QUEQUAN ON GIAOVIEN.MAQQ = QUEQUAN.MAQQ", conn);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "TENMH";
            //binding
            tenGV.DataBindings.Add("Text", dt, "TENGV");
            maGV.DataBindings.Add("Text", dt, "MAGV");
            tenQQ.DataBindings.Add("Text", dt, "TENQQ");
            gender.DataBindings.Add("SelectedValue", dt, "GioiTinh");
            tenMH.DataBindings.Add("Text", dt, "TENMH");
            dateTimePicker1.DataBindings.Add("Text", dt, "NgaySinh");
            conn.Close();
        }
    }
}
