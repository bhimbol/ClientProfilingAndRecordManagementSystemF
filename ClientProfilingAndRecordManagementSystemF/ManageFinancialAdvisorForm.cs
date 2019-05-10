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

        private bool CheckForRequiredFields()
        {
            return (!String.IsNullOrWhiteSpace(txtFirstName.Text) && !String.IsNullOrWhiteSpace(txtMiddleName.Text) && !String.IsNullOrWhiteSpace(txtLastName.Text) && !String.IsNullOrWhiteSpace(txtCode_Num.Text));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                if (CheckForRequiredFields())
                {
                    FinancialAdvisor fa = new FinancialAdvisor();
                    string gender = "";
                    if (rbM.Checked) { gender = rbM.Text; }
                    if (rbF.Checked) { gender = rbF.Text; }
                    fa.LName = txtLastName.Text;
                    fa.FName = txtFirstName.Text;
                    fa.MName = txtMiddleName.Text;
                    fa.Code_Num = txtCode_Num.Text;
                    fa.Contact_Num = txtContact_Num.Text;
                    fa.Email_Add = txtEmail_Add.Text;
                    fa.Address = txtAddress.Text;
                    fa.B_Date = dtpB_Date.Text;
                    fa.Gender = gender;
                    db.FinancialAdvisors.Add(fa);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Successfully added advisor.");
                        ManageFinancialAdvisorForm_Load(null, null);
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Would  you like to create log-in account for this advisor?", "Create log-in account:", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            AddEditUserForm addedituserform = new AddEditUserForm();
                            addedituserform.role = "Advisor";
                            ((TextBox)addedituserform.Controls["txtFullname"]).Text = fa.LName + ", " + fa.FName + " " + fa.MName;
                            ((Button)addedituserform.Controls["btnUpdate"]).Enabled = false;
                            ((Button)addedituserform.Controls["btnDelete"]).Enabled = false;
                            addedituserform.ShowDialog();
                            addedituserform.role = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up required fields.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridViewFA.SelectedRows.Count > 0)
            {
                if (CheckForRequiredFields())
                {
                    int faid = (Int32)dataGridViewFA.SelectedRows[0].Cells["FA_id"].Value;
                    using (axaDBEntities db = new axaDBEntities())
                    {
                        FinancialAdvisor fa = db.FinancialAdvisors.Find(faid);
                        string gender = "";
                        if (rbM.Checked) { gender = rbM.Text; }
                        if (rbF.Checked) { gender = rbF.Text; }
                        fa.LName = txtLastName.Text;
                        fa.FName = txtFirstName.Text;
                        fa.MName = txtMiddleName.Text;
                        fa.Code_Num = txtCode_Num.Text;
                        fa.Contact_Num = txtContact_Num.Text;
                        fa.Email_Add = txtEmail_Add.Text;
                        fa.Address = txtAddress.Text;
                        fa.B_Date = dtpB_Date.Text;
                        fa.Gender = gender;
                        db.SaveChanges();
                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;
                        dataGridViewFA.Enabled = true;
                    }
                    ManageFinancialAdvisorForm_Load(null, null);
                    MessageBox.Show("Record updated Successfully.");
                }
                else
                {
                    MessageBox.Show("Please fill up required fields.");
                }
            }
        }

        private void dataGridViewFA_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFA.SelectedRows.Count > 0)
            {
                txtFirstName.Text = dataGridViewFA.SelectedRows[0].Cells["FName"].Value.ToString();
                txtMiddleName.Text = dataGridViewFA.SelectedRows[0].Cells["MName"].Value.ToString();
                txtLastName.Text = dataGridViewFA.SelectedRows[0].Cells["LName"].Value.ToString();
                txtCode_Num.Text = dataGridViewFA.SelectedRows[0].Cells["Code_Num"].Value.ToString();
                txtContact_Num.Text = dataGridViewFA.SelectedRows[0].Cells["Contact_Num"].Value.ToString();
                txtEmail_Add.Text = dataGridViewFA.SelectedRows[0].Cells["Email_Add"].Value.ToString();
                txtAddress.Text = dataGridViewFA.SelectedRows[0].Cells["Address"].Value.ToString();

                dtpB_Date.Text = dataGridViewFA.SelectedRows[0].Cells["B_Date"].Value.ToString();
                if (dataGridViewFA.SelectedRows[0].Cells["Gender"].Value.ToString() == "Male") { rbM.Checked = true; }
                if (dataGridViewFA.SelectedRows[0].Cells["Gender"].Value.ToString() == "Female") { rbF.Checked = true; }

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
                    if (MessageBox.Show("Delete Financial Advisor with License Number: ? " + br.Cells["Code_Num"].Value.ToString(), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            using (axaDBEntities db = new axaDBEntities())
                            {
                                FinancialAdvisor fa = db.FinancialAdvisors.Find(br.Cells["FA_id"].Value);
                                db.FinancialAdvisors.Remove(fa);
                                db.SaveChanges();
                                dataGridViewFA.Enabled = true;
                                btnAdd.Enabled = true;
                                ManageFinancialAdvisorForm_Load(null, null);
                            }
                        }
                        catch(Exception ex)
                        {
                            if(ex.InnerException != null)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message);
                            }
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
                    dataGridViewFA.DataSource = db.FinancialAdvisors.Where(fa => fa.FName.Contains(txtSearch.Text) ||
                                                                                 fa.MName.Contains(txtSearch.Text) ||
                                                                                 fa.LName.Contains(txtSearch.Text) ||
                                                                                 fa.Address.Contains(txtSearch.Text) ||
                                                                                 fa.Email_Add.Contains(txtSearch.Text) ||
                                                                                 fa.Code_Num.Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void dataGridViewFA_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewFA.Columns[0].HeaderText = "Id";
            dataGridViewFA.Columns[1].HeaderText = "License Code";
            dataGridViewFA.Columns[2].HeaderText = "First Name";
            dataGridViewFA.Columns[3].HeaderText = "Middle Name";
            dataGridViewFA.Columns[4].HeaderText = "Last Name";
            dataGridViewFA.Columns[5].HeaderText = "Birth Date";
            dataGridViewFA.Columns[6].HeaderText = "Gender";
            dataGridViewFA.Columns[7].HeaderText = "Contact Number";
            dataGridViewFA.Columns[8].HeaderText = "Email Address";
            dataGridViewFA.Columns[9].HeaderText = "Address";
            dataGridViewFA.Columns["Clients"].Visible = false;
        }
    }
}
