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
    public partial class ManageClientsForm : Form
    {
        public ManageClientsForm()
        {
            InitializeComponent();
        }

        private void ManageClientsForm_Load(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                dgvClients.DataSource = db.Clients.ToList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                using (AddEditClientForm addeditclientform = new AddEditClientForm())
                {
                    addeditclientform.action = "Edit";
                    using (axaDBEntities db = new axaDBEntities())
                    {
                        int client_id = (int)dgvClients.SelectedRows[0].Cells["client_id"].Value;
                        addeditclientform.selected_client = db.Clients.Find(client_id);
                        addeditclientform.ShowDialog();
                        ManageClientsForm_Load(null, null);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditClientForm addeditclientform = new AddEditClientForm())
            {
                addeditclientform.action = "Add";
                addeditclientform.ShowDialog();
                ManageClientsForm_Load(null, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if( dgvClients.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow cr in dgvClients.SelectedRows)
                {
                    if (MessageBox.Show("Delete ID: " + cr.Cells["client_id"].Value.ToString() + " Client's Name: " + cr.Cells["LASTNAME"].Value.ToString() + ".", "Delete User", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using(axaDBEntities db = new axaDBEntities())
                        {
                            Client c = db.Clients.Find(cr.Cells["client_id"].Value);
                            IEnumerable<ClientBeneficiary> client_beneficiaries = (from b in db.ClientBeneficiaries
                                                                                   where b.client_id == c.client_id
                                                                                   select b);
                            IEnumerable<ClientPlan> client_plans = (from p in db.ClientPlans
                                                                    where p.client_id == c.client_id
                                                                    select p);
                            db.ClientPlans.RemoveRange(client_plans);
                            db.ClientBeneficiaries.RemoveRange(client_beneficiaries);
                            db.Clients.Remove(c);
                            db.SaveChanges();
                        }
                    }
                }

            }
            ManageClientsForm_Load(null, null);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                    dgvClients.DataSource = db.Clients.Where(x => x.lastname.Contains(txtSearch.Text) ||
                                                                        x.firstname.Contains(txtSearch.Text) ||
                                                                        x.middlename.Contains(txtSearch.Text) ||
                                                                        x.residenceaddress.Contains(txtSearch.Text)).ToList();

            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
    }
}
