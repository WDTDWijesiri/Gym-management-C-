using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GYMorginalcopy
{
    public partial class ResetPassword : Form
    {
        string email = sendcode.to;
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            Forgotpass fp = new Forgotpass();
            fp.Show();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            string password=txt_conpass.Text;
            if(txt_NPass.Text==password)
            {
                SqlConnection con = new SqlConnection("Data Source=THANUJA;Initial Catalog=GYM;Integrated Security=True");
                string q = "update [reg] set[password]='" + password + "'where Email='" + email + "'";
                SqlCommand cmd = con.CreateCommand();

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Password successfully change");
            }

            
            else
            {
                MessageBox.Show("Sorry your details worng");
            }
        }
    }
}
