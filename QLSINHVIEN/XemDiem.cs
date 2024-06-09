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
    public partial class XemDiem : Form
    {
        SqlConnection conn;
        float a, b =0;
        public XemDiem()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
        }
        void reload()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from HS_HOC_LOP where MAHS = '" + comboBox2.SelectedValue + "'", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.Columns.Remove(dt.Columns["thoigianbatdau"]);
            dt.Columns.Remove(dt.Columns["thoigianketthuc"]);
            dt.Columns.Remove(dt.Columns["ngayhoc"]);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }

        private void XemDiem_Load(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataAdapter  adp = new SqlDataAdapter("select * from HOCSINH", conn);
            DataTable dt_SV = new DataTable();
            adp.Fill(dt_SV);
            comboBox2.DataSource = dt_SV;
            comboBox2.DisplayMember = "MAHS";
            comboBox2.ValueMember = "MAHS";
            conn.Close();
            //
            reload();
        }
        
    }
}
