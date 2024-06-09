using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
namespace QLSINHVIEN
{
    // User Class
    public class User
    {
        public User() { }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

    }
    // Filehandler Class
    class FileHandler
    {
        public static void StoreInfo(string str)
        {
            System.IO.File.WriteAllText("info.mvt",str);
        }
        public static bool getInfo(ref string value)
        {
            try
            {
                value = System.IO.File.ReadAllText("info.mvt");
                return true;
            } 
            catch
            {
                return false;
            }
        }
        public static string getJsonStrByObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static T getObjectByStr<T>(string strjson)
        {
            return JsonConvert.DeserializeObject<T>(strjson);
        }
        public static bool removeFileInfo()
        {
            try
            {
                System.IO.File.Delete("info.mvt");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    // Common Class
     class Common
    {
        public static string strCon = "Data Source=MVT\\SQLEXPRESS01;Initial Catalog=qlsinhvien;Integrated Security=True;";
        //makeOpacity Method
        public static  void  makeOpacity(Control s, int alpha, int r, int g, int b)
        {
            //RGB for panel , alpha : 0 - 255
            s.BackColor = Color.FromArgb(alpha, r, g, b);
        }
        public static void label_Hover(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lb_r = sender as System.Windows.Forms.Label;
            lb_r.Font = new Font(lb_r.Font, FontStyle.Italic);
        }
        public static void label_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lb_r = sender as System.Windows.Forms.Label;
            lb_r.Font = new Font(lb_r.Font, FontStyle.Bold);
        }
        public static void DisplayLabelBaseText(System.Windows.Forms.TextBox a, System.Windows.Forms.Label b)
        {
            if (a.Text.Length == 0)
            {
                b.Visible = true;
            }
            else
                b.Visible = false;
        }
        //
        public static string getFormatDateDisplay(string s)
        {
            DateTime d = DateTime.ParseExact(s,"MM/dd/yyyy",System.Globalization.CultureInfo.InvariantCulture);
            return d.ToString("dd-MM-yyyyy");
        }
        public static string getFormatDateStore(string s)
        {
            DateTime d = DateTime.ParseExact(s, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return d.ToString("yyyy-MM-dd");
        }
        public static bool checkExistCode (string sql,SqlConnection conn)
        {
            bool check = false;
            if(conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                check =  true;
            }
            reader.Close();
            conn.Close();
            return check;
        }
     
    }
}
