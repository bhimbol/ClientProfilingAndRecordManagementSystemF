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
    public partial class ManageFinancialAdvisorForm : Form
    {
        public ManageFinancialAdvisorForm()
        {
            InitializeComponent();
        }

        private void ManageFinancialAdvisorForm_Load(object sender, EventArgs e)
        {
            using(axaDBEntities db = new axaDBEntities())
            {
                dataGridViewFA.DataSource = db.FinancialAdvisors.ToList();
                btnUpdate.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using(axaDBEntities db = new axaDBEntities())
            {
                FinancialAdvisor fa = new FinancialAdvisor();
                fa.fullname = txtFullName.Text; 
                db.FinancialAdvisors.Add(fa);
                db.SaveChanges();
                MessageBox.Show("Successfully added advisor.");
                ManageFinancialAdvisorForm_Load(null, null);

                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Would  you like to create log-in account for this advisor?","Create log-in account:",MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    AddEditUserForm addedituserform = new AddEditUserForm();
                    addedituserform.role = "Advisor";
                    ((TextBox)addedituserform.Controls["txtFullname"]).Text = fa.fullname;
                    ((Button)addedituserform.Controls["btnUpdate"]).Enabled= false;
                    ((Button)addedituserform.Controls["btnDelete"]).Enabled = false; 
                    addedituserform.ShowDialog();
                    addedituserform.role = null;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridViewFA.SelectedRows.Count > 0)
            {
                long faid = (Int64)dataGridViewFA.SelectedRows[0].Cells["id"].Value;
                using (axaDBEntities db = new axaDBEntities())
                {
                    FinancialAdvisor fa = db.FinancialAdvisors.Find(faid);
                    fa.fullname = txtFullName.Text;
                    db.SaveChanges();
                    btnUpdate.Enabled = false;
                    btnAdd.Enabled = true;
                    dataGridViewFA.Enabled = true;
                }
                ManageFinancialAdvisorForm_Load(null, null);
            }
        }

        private void dataGridViewFA_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFA.SelectedRows.Count > 0)
            {
                txtFullName.Text = dataGridViewFA.SelectedRows[0].Cells["fullname"].Value.ToString();
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                dataGridViewFA.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewFA.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow br in dataGridViewFA.SelectedRows)
                {
                    if (MessageBox.Show("Delete? " + br.Cells["FULLNAME"].Value.ToString(), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (axaDBEntities db = new axaDBEntities())
                        {
                            FinancialAdvisor fa = db.FinancialAdvisors.Find(br.Cells["ID"].Value);
                            db.FinancialAdvisors.Remove(fa);
                            db.SaveChanges();
                            dataGridViewFA.Enabled = true;
                            btnAdd.Enabled = true;
                            ManageFinancialAdvisorForm_Load(null, null);
                        }
                    }
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                using(axaDBEntities db = new axaDBEntities())
                {
                    dataGridViewFA.DataSource = db.FinancialAdvisors.Where(fa => fa.fullname.Contains(txtSearch.Text)).ToList();
                }
            }
        }
    }
}
