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
    public partial class ClientPlanForm : Form
    {
        public string mode_of_payment = String.Empty;
        public double due = 0;
        public int plan_id;
        
        public ClientPlanForm()
        {
            InitializeComponent();
        }

        private void ClientPlanForm_Load(object sender, EventArgs e)
        {
            AcceptButton = BtnAddPlan;
            CancelButton = BtnCancel;
            BtnCancel.DialogResult = DialogResult.Cancel;
            BtnAddPlan.DialogResult = DialogResult.OK;

            using (axaDBEntities db = new axaDBEntities())
            {
                Plan plan = db.Plans.Find(plan_id);
                txtPlanType.Text = plan.type;
                txtPlanCategory.Text = plan.category;
                txtPlanDescription.Text = plan.description;
            }
            lbModeofPayment.SelectedIndex = 0;
            lbModeofPayment.Text = "Monthly Premium";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void lbModeofPayment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lbModeofPayment.SelectedItem.ToString() == "Monthly Premium")
                lblDue.Text = "Monthly Due";
            else if (lbModeofPayment.SelectedItem.ToString() == "Quarterly Premium")
                lblDue.Text = "Quarterly Due";
            else if (lbModeofPayment.SelectedItem.ToString() == "Semi Anual Premium")
                lblDue.Text = "Semi Anual Due";
            else if (lbModeofPayment.SelectedItem.ToString() == "Anual Premium")
                lblDue.Text = "Anual Due";
        }

        private void BtnAddPlan_Click(object sender, EventArgs e)
        {
            mode_of_payment = lbModeofPayment.Text;
            Double.TryParse(txtDue.Text, out double d);
            due = d;
            this.Close();
        }
    }
}
