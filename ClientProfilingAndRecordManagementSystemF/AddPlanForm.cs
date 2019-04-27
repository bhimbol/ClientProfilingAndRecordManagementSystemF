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
        public List<ClientPlan> client_plans = new List<ClientPlan>();

        public int client_id;

        public string action = String.Empty;

        public AddPlanForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                foreach (Control c in this.Controls)
                {
                    if (c is CheckBox)
                    {
                        int cbox_id = int.Parse(((CheckBox)c).AccessibleName);
                        if (((CheckBox)c).Checked)
                        {
                            var tcp = db.ClientPlans.Where(cp => cp.client_id == client_id && cp.plan_id == cbox_id).FirstOrDefault();
                            if (tcp != null)
                            {
                                //update
                                var _tcp = client_plans.Where(cp => cp.client_id == client_id && cp.plan_id == cbox_id).FirstOrDefault();
                                if(_tcp != null)
                                {
                                    tcp.mode_of_payment = _tcp.mode_of_payment;
                                    tcp.due = _tcp.due;
                                    db.ClientPlans.Add(tcp);
                                    db.SaveChanges();
                                }
                            }
                            else
                            {
                                //add
                                tcp = new ClientPlan();
                                tcp = client_plans.Where(cp => cp.client_id == client_id && cp.plan_id == cbox_id).FirstOrDefault();
                                db.ClientPlans.Add(tcp);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            var tcp = db.ClientPlans.Where(cp => cp.client_id == client_id && cp.plan_id == cbox_id).FirstOrDefault();
                            if (tcp != null)
                            {
                                db.ClientPlans.Remove(tcp);
                                db.SaveChanges();
                            }
                        }
                    }
                }
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
            action = "FromLoad";
            using (axaDBEntities db = new axaDBEntities())
            {
                foreach (Control c in this.Controls)
                {
                    if (c is CheckBox)
                    {
                        int cbox_id = int.Parse(((CheckBox)c).AccessibleName);
                        var _cp = (from cp in db.ClientPlans where cp.plan_id == cbox_id && cp.client_id == client_id select cp).FirstOrDefault();
                        if (_cp != null)
                        {
                            //client_plans.Add(_cp);
                            ((CheckBox)c).Checked = true;
                        }
                    }
                }
            }
            action = "AfterLoad";
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (action != "FromLoad")
            {
                using (axaDBEntities db = new axaDBEntities())
                {

                    int plan_id = int.Parse(((CheckBox)sender).Tag.ToString());

                    if (((CheckBox)sender).Checked)
                    {
                        using (ClientPlanForm client_plan_form = new ClientPlanForm())
                        {
                            client_plan_form.plan_id = plan_id;
                            if (client_plan_form.ShowDialog() == DialogResult.OK)
                            {
                                ClientPlan cp = new ClientPlan();
                                cp.client_id = this.client_id;
                                cp.plan_id = plan_id;
                                cp.mode_of_payment = client_plan_form.mode_of_payment;
                                cp.due = client_plan_form.due;
                                client_plans.Add(cp);
                            }
                            else
                            {
                                ((CheckBox)sender).Checked = false;
                            }
                        }
                    }
                    else
                    {
                        var tcp = client_plans.Where(cp => cp.client_id == client_id && cp.plan_id == plan_id).FirstOrDefault();
                        client_plans.Remove(tcp);
                        ((CheckBox)sender).Checked = false;
                    }
                }
            }
        }
    }
}








/*
         private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(action == "AfterLoad")
            {
                int plan_id = int.Parse(((CheckBox)sender).AccessibleName);

                //if checked
                if (((CheckBox)sender).Checked)
                {
                    //if checked and exist
                    if (ExistInDBClientPlan(plan_id))
                    {
                        //if checked and exist in db but exist in for remove

                        using (ClientPlanForm client_plan_form = new ClientPlanForm())
                        {
                            //for update
                            client_plan_form.plan_id = plan_id;
                            if (client_plan_form.ShowDialog() == DialogResult.OK)
                            {
                                using(axaDBEntities db = new axaDBEntities())
                                {
                                    var result = db.ClientPlans.Where(ucp => ucp.client_id == client_id && ucp.plan_id == plan_id).FirstOrDefault();
                                    ClientPlan cp = result;
                                    cp.client_id = this.client_id;
                                    cp.plan_id = plan_id;
                                    cp.mode_of_payment = client_plan_form.mode_of_payment;
                                    cp.due = client_plan_form.due;
                                    for_update_cp.Add(cp);
                                }
                            }
                            else
                            {
                                ((CheckBox)sender).Checked = false;
                            }
                        }
                    }

                    //if checked and not exist
                    else
                    {
                        using (ClientPlanForm client_plan_form = new ClientPlanForm())
                        {
                            //for add
                            client_plan_form.plan_id = plan_id;
                            if (client_plan_form.ShowDialog() == DialogResult.OK)
                            {
                                ClientPlan cp = new ClientPlan();
                                cp.client_id = this.client_id;
                                cp.plan_id = plan_id;
                                cp.mode_of_payment = client_plan_form.mode_of_payment;
                                cp.due = client_plan_form.due;
                                for_add_cp.Add(cp);
                            }
                            else
                            {
                                ((CheckBox)sender).Checked = false;
                            }
                        }
                    }
                }

                //if unchecked
                else
                {
                    if (ExistInDBClientPlan(plan_id))
                    {
                        using (axaDBEntities db = new axaDBEntities())
                        {
                            ClientPlan result = db.ClientPlans.Where(rcp => rcp.client_id == client_id && rcp.plan_id == plan_id).FirstOrDefault();
                            for_remove_cp.Add(result);
                        }
                    }
                    else
                    {
                        //unchecked
                    }
                }
            }
        }

     
     */








//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace ClientProfilingAndRecordManagementSystemF
//{
//    public partial class AddPlanForm : Form
//    {
//        ClientPlan client_plan;
//        axaDBEntities db = new axaDBEntities();
//        public int client_id;
//        public string action = "FromButton";

//        public AddPlanForm()
//        {
//            InitializeComponent();
//        }

//        private void btnSelect_Click(object sender, EventArgs e)
//        {
//            using (axaDBEntities db = new axaDBEntities())
//            {
//                //db.ClientPlans.AddRange(client_plans);
//                db.SaveChangesAsync();
//                this.Close();
//                this.Dispose();
//            }
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.Close();
//            this.Dispose();
//        }

//        private void AddPlanForm_Load(object sender, EventArgs e)
//        {
//            this.action = "FromLoad";
//            foreach (Plan plan in db.Plans)
//            {
//                foreach (Control c in this.Controls)
//                {
//                    if (c is CheckBox)
//                    {
//                        if (int.Parse(((CheckBox)c).AccessibleName) == plan.plan_id)
//                        {
//                            ((CheckBox)c).Tag = plan;
//                        }
//                    }
//                }
//            }
//            this.action = "FromButton";
//        }

//        private void checkBox_CheckedChanged(object sender, EventArgs e)
//        {
//            if(action != "FromLoad")
//            {
//                ClientPlan cp = new ClientPlan();
//                int plan_id = int.Parse(((CheckBox)sender).Tag.ToString());

//                if (((CheckBox)sender).Checked)
//                {
//                    using (ClientPlanForm client_plan_form = new ClientPlanForm())
//                    {
//                        client_plan_form.plan_id = plan_id;
//                        if (client_plan_form.ShowDialog() == DialogResult.OK)
//                        {
//                            cp.client_id = this.client_id;
//                            cp.plan_id = plan_id;
//                            cp.mode_of_payment = client_plan_form.mode_of_payment;
//                            cp.due = client_plan_form.due;
//                            db.ClientPlans.Add(cp);
//                            //client_plans.Add(cp);
//                        }
//                        else
//                        {
//                            ((CheckBox)sender).Checked = false;
//                        }
//                    }
//                }
//                else
//                {
//                    db.ClientPlans.Find(((ClientPlan)((CheckBox)sender).Tag).id);

//                    db.ClientPlans.Remove((ClientPlan)((CheckBox)sender).Tag);
//                    ((CheckBox)sender).Checked = false;
//                }
//            }
//        }
//    }
//}
