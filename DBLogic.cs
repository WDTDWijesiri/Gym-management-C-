using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GYMorginalcopy
{
    internal class DBLogic
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        public DBLogic()
        {
            con = new SqlConnection("Data Source=THANUJA;Initial Catalog=GYM;Integrated Security=True");
        }
        public int save_update_delete(string a)
        {
            con.Open();
            cmd = new SqlCommand(a, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable Display(string a)
        {
            con.Open();
            da = new SqlDataAdapter(a, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            con.Close();
            return dt;
        }
    }

}
