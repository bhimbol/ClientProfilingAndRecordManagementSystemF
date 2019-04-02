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
                ManageFinancialAdvisorForm_Load(null, null);
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
    }
}
