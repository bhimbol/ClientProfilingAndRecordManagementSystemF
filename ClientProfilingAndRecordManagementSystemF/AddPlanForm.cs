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
        public List<ClientPlan> plans { get; set; }

        public int client_id { get; set; }

        public AddPlanForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                var r_client_plans = db.ClientPlans.Where(_cp => _cp.client_id == this.client_id);
                db.ClientPlans.RemoveRange(r_client_plans);
                foreach (Control c in this.Controls)
                {
                    if(c is CheckBox)
                    {
                        if (((CheckBox)c).Checked == true)
                        {
                                ClientPlan cp = new ClientPlan();
                                cp.client_id = this.client_id;
                                cp.plan_id = int.Parse(((CheckBox)c).Tag.ToString());
                                db.ClientPlans.Add(cp);
                        }
                    }
                }
                db.SaveChanges();
                this.Close();
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void AddPlanForm_Load(object sender, EventArgs e)
        {
            using(axaDBEntities db = new axaDBEntities())
            {
               var client_plan_ids =  (from cp in db.ClientPlans
                                       where cp.client_id == this.client_id
                                       select cp.plan_id).ToList();
                foreach(int id in client_plan_ids)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is CheckBox)
                        {
                            if (int.Parse(((CheckBox)c).Tag.ToString()) == id)
                            {
                                ((CheckBox)c).Checked = true;
                            }
                        }
                    }

                }

            }
        }
    }
}
