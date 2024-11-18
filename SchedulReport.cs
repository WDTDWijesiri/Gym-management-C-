using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace GYMorginalcopy
{
    public partial class SchedulReport : Form
    {
        public SchedulReport()
        {
            InitializeComponent();
        }

        private void SchedulReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
          
               
            

           
                this.scheduleTableAdapter.Fill(this.schedulDataSet.Schedule, txt_id.Text);
                this.reportViewer1.RefreshReport();
            
        }
    }
}
