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

        private void dgvClients_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvClients.Columns)
            {
                if(col.HeaderText == "client_id") { col.HeaderText = "Client ID"; }
                if (col.HeaderText == "addedby_user_id") { col.Visible = false; }
                if (col.HeaderText == "lastname") { col.HeaderText = "Last Nmae"; }
                if (col.HeaderText == "firstname") { col.HeaderText = "First Name"; }
                if (col.HeaderText == "middlename") { col.HeaderText = "Middle Nmae"; }
                if (col.HeaderText == "spouselastname") { col.HeaderText = "Spouse Last Name"; }
                if (col.HeaderText == "spousefirstname") { col.HeaderText = "Spouse First Name"; }
                if (col.HeaderText == "spousemiddlename") { col.HeaderText = "Spouse Middle Name"; }
                if (col.HeaderText == "gender") { col.HeaderText = "Gender"; }
                if (col.HeaderText == "civilstatus") { col.HeaderText = "Civil Status"; }
                if (col.HeaderText == "birthday") { col.HeaderText = "Birth Date"; }
                if (col.HeaderText == "birthplace") { col.HeaderText = "Birth Place"; }
                if (col.HeaderText == "height") { col.HeaderText = "Height"; }
                if (col.HeaderText == "weight") { col.HeaderText = "Weight"; }
                if (col.HeaderText == "residenceaddress") { col.HeaderText = "Address"; }
                if (col.HeaderText == "cpnumber") { col.HeaderText = "Cellphone Number"; }
                if (col.HeaderText == "telephonenumber") { col.HeaderText = "Telephone Number"; }
                if (col.HeaderText == "emailaddress") { col.HeaderText = "E-Address"; }
                if (col.HeaderText == "occupation") { col.HeaderText = "Occupation"; }
                if (col.HeaderText == "worksalary") { col.HeaderText = "Work Salary"; }
                if (col.HeaderText == "businessincome") { col.HeaderText = "Business Income"; }
                if (col.HeaderText == "othersource") { col.HeaderText = "Other Source Income"; }
                if (col.HeaderText == "companyname") { col.HeaderText = "Company Name"; }
                if (col.HeaderText == "companyaddress") { col.HeaderText = "Company Address"; }
                if (col.HeaderText == "companycontact") { col.HeaderText = "Company Contact Number"; }
                if (col.HeaderText == "natureofbusiness") { col.HeaderText = "Nature of Business"; }
                if (col.HeaderText == "taxidnumber") { col.HeaderText = "TAX ID NUMBER"; }
                if (col.HeaderText == "sss_gsis_number") { col.HeaderText = "SSS/GSIS NUMBER"; }
                if (col.HeaderText == "FA_id") { col.Visible = false; }
                if (col.HeaderText == "id_path1") { col.Visible = false; }
                if (col.HeaderText == "id_path2") { col.Visible = false; }
                if (col.HeaderText == "ClientBeneficiaries") { col.Visible = false; }
                if (col.HeaderText == "ClientPlans") { col.Visible = false; }
                if (col.HeaderText == "FinancialAdvisor") { col.Visible = false; }
                if (col.HeaderText == "answersub1") { col.Visible = false; }
                if (col.HeaderText == "answersub2") { col.Visible = false; }
                if (col.HeaderText == "answersub3") { col.Visible = false; }
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {

        }

        private void button_Exit_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
