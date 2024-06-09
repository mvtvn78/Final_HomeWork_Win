using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSINHVIEN
{
    public partial class HomePage : Form
    {
        //
        Hashtable hashtable = new Hashtable();
        SqlConnection conn;
        int yeu = 0;
        int tb = 0;
        int kha = 0;
        int gioi = 0;
        int xuasac = 0;
        public HomePage()
        {
            InitializeComponent();
            conn = new SqlConnection(Common.strCon);
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //
            label1.Text = DateTime.Now.ToString("hh:mm:ss");
            hashtable.Add("Yếu", yeu);
            hashtable.Add("Trung Bình", tb);
            hashtable.Add("Khá", kha);
            hashtable.Add("Giỏi", gioi);
            hashtable.Add("Xuất sắc", xuasac);
            chart1.Series[0].XValueMember = "key";
            chart1.Series[0].YValueMembers = "value";
            chart1.Series[0].Points.DataBindXY(hashtable.Keys,hashtable.Values);
            //
            //HS
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from HOCSINH", conn);
            SqlDataReader reader_HS = cmd.ExecuteReader();
            while(reader_HS.Read())
            {
                label2.Text = "Tổng số học sinh : "+reader_HS.GetValue(0).ToString();
            }
            reader_HS.Close();
            //MH
            cmd = new SqlCommand("select count(*) from MONHOC",conn);
            SqlDataReader reader_MH = cmd.ExecuteReader();
            while (reader_MH.Read())
            {
                label4.Text = "Tổng số môn học : "+ reader_MH.GetValue(0).ToString();
            }
            reader_MH.Close();
            //GV
            cmd = new SqlCommand("select count(*) from GIAOVIEN", conn);
            SqlDataReader reader_GV = cmd.ExecuteReader();
            while (reader_GV.Read())
            {

                label3.Text = "Tổng số giáo viên : " + reader_GV.GetValue(0).ToString();
            }
            reader_GV.Close();
            conn.Close();
            //
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from monhoc",conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TENMH";
            comboBox1.ValueMember = "MAMH";
            //
            conn.Close();
            //
            reload();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //prevent add character on combobox
            e.Handled = true;
        }
        void reload()
        {
             yeu = 0;
             tb = 0;
             kha = 0;
             gioi = 0;
             xuasac = 0;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand adp = new SqlCommand("select * from HS_HOC_LOP where MAMH = '" + comboBox1.SelectedValue + "'", conn);
            SqlDataReader reader = adp.ExecuteReader();
            while (reader.Read())
            {
                float x = float.Parse(reader.GetValue(2).ToString());
                float y = float.Parse(reader.GetValue(3).ToString());
                float k = (x + y) / 2;
                if (k > 0 && k < 5)
                    yeu += 1;
                else if (k >= 5 && k < 6.5)
                    tb += 1;
                else if (k >= 6.5 && k < 8.0)
                    kha += 1;
                else if (k >= 8.0 && k < 9.0)
                    gioi += 1;
                else
                    xuasac += 1;
            }
            reader.Close();
            conn.Close();
            hashtable["Yếu"] = yeu;
            hashtable["Trung Bình"] = tb;
            hashtable["Khá"] = kha;
            hashtable["Giỏi"] = gioi;
            hashtable["Xuất sắc"] = xuasac;
            chart1.Series[0].Points.DataBindXY(hashtable.Keys, hashtable.Values);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reload();
        }
    }
}
