using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class AddPlanForm : Form
    {
        public int plan { get; set; }
        public AddPlanForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.plan = 1;
            this.Close();
            
            foreach(Control c in this.Controls)
            {
                if(c is RadioButton)
                {
                    if (((RadioButton)c).Checked == true)
                    {
                        string ids = ((RadioButton)c).Tag.ToString();
                        this.plan = int.Parse(ids);
                        break;
                    }
                }
            }
            
        }
    }
}
