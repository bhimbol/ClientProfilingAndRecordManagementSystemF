using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class ManageFinancialAdvisorForm : Form
    {
        public ManageFinancialAdvisorForm()
        {
            InitializeComponent();
        }

        string directoryPath;

        private void ManageFinancialAdvisorForm_Load(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
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
                    fa.id_path = directoryPath;
                    db.FinancialAdvisors.Add(fa);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Successfully added advisor.");
                        ManageFinancialAdvisorForm_Load(null, null);
                        //DialogResult dr = new DialogResult();
                        //dr = MessageBox.Show("Would  you like to create log-in account for this advisor?", "Create log-in account:", MessageBoxButtons.YesNo);
                        //if (dr == DialogResult.Yes)
                        //{
                        //    AddEditUserForm addedituserform = new AddEditUserForm();
                        //    addedituserform.role = "Advisor";
                        //    ((TextBox)addedituserform.Controls["txtFullname"]).Text = fa.LName + ", " + fa.FName + " " + fa.MName;
                        //    ((Button)addedituserform.Controls["btnUpdate"]).Enabled = false;
                        //    ((Button)addedituserform.Controls["btnDelete"]).Enabled = false;
                        //    addedituserform.ShowDialog();
                        //    addedituserform.role = null;
                        //}
                        CleartxtFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up required fields.");
                    CleartxtFields();
                }
            }

        }

        private void CleartxtFields()
        {
            txtLastName.Text = "Last Name*";
            txtFirstName.Text = "First Name*";
            txtMiddleName.Text = "Middle Name*";
            txtCode_Num.Text = "Liscense Code *";
            txtContact_Num.Text = "Contact Number";
            txtEmail_Add.Text = "Email Address";
            txtAddress.Text = "Address";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewFA.SelectedRows.Count > 0)
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
                        fa.id_path = directoryPath;
                        db.SaveChanges();
                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;
                        dataGridViewFA.Enabled = true;
                    }
                    ManageFinancialAdvisorForm_Load(null, null);
                    MessageBox.Show("Record updated Successfully.");
                    CleartxtFields();
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
                        catch (Exception ex)
                        {
                            if (ex.InnerException != null)
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
            if (e.KeyCode == Keys.Enter)
            {
                using (axaDBEntities db = new axaDBEntities())
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
            dataGridViewFA.Columns[0].Visible = false;
            //dataGridViewFA.Columns[0].HeaderText = "Id";
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

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == "Last Name*")
            {
                txtLastName.Text = "";
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.Text = "Last Name*";
            }
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "First Name*")
            {
                txtFirstName.Text = "";
            }
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                txtFirstName.Text = "First Name*";
            }
        }

        private void txtMiddleName_Enter(object sender, EventArgs e)
        {
            if (txtMiddleName.Text == "Middle Name*")
            {
                txtMiddleName.Text = "";
            }
        }

        private void txtMiddleName_Leave(object sender, EventArgs e)
        {
            if (txtMiddleName.Text == "")
            {
                txtMiddleName.Text = "Middle Name*";
            }
        }

        private void txtCode_Num_Enter(object sender, EventArgs e)
        {
            if (txtCode_Num.Text == "Liscense Code *")
            {
                txtCode_Num.Text = "";
            }
        }

        private void txtCode_Num_Leave(object sender, EventArgs e)
        {
            if (txtCode_Num.Text == "")
            {
                txtCode_Num.Text = "Liscense Code *";
            }
        }

        private void txtContact_Num_Enter(object sender, EventArgs e)
        {
            if (txtContact_Num.Text == "Contact Number")
            {
                txtContact_Num.Text = "";
            }
        }

        private void txtContact_Num_Leave(object sender, EventArgs e)
        {
            if (txtContact_Num.Text == "")
            {
                txtContact_Num.Text = "Contact Number";
            }
        }

        private void txtEmail_Add_Enter(object sender, EventArgs e)
        {
            if (txtEmail_Add.Text == "Email Address")
            {
                txtEmail_Add.Text = "";
            }
        }

        private void txtEmail_Add_Leave(object sender, EventArgs e)
        {
            if (txtEmail_Add.Text == "")
            {
                txtEmail_Add.Text = "Email Address";
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (txtAddress.Text == "Address")
            {
                txtAddress.Text = "";
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                txtAddress.Text = "Address";
            }
        }

        private void txtCode_Num_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(sender, e);
        }

        public void isNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Browse Image file for ID";
            opd.DefaultExt = "jpg";
            opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            opd.Multiselect = false;


            if (opd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opd.FileName);
                directoryPath = Path.GetFullPath(opd.FileName);

            }
        }
    }
}
