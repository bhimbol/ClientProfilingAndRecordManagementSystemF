using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class AddEditUserForm : Form
    {
        public string role { get; set; }
        public AddEditUserForm()
        {
            InitializeComponent();
        }

        private bool CheckForRequiredFields()
        {
            bool result = false;
            //if (!(!String.IsNullOrWhiteSpace(txtFullName.Text) && !String.IsNullOrWhiteSpace(txtUsername.Text) && !String.IsNullOrWhiteSpace(txtPassword.Text) && !String.IsNullOrWhiteSpace(txtRetypePassword.Text)))
            //{
            if (txtFullName.Text == "Full Name: (Last Name, First Name, Middle Name)" || txtUsername.Text == "Username" || txtContact_Num.Text == "Contact Number" || txtAddress.Text == "Address")
            {
                MessageBox.Show("Please fill-up required fields.");
                return result;
            }

            //}
            if (txtPassword.Text != txtRetypePassword.Text)
            {
                result = false;
                MessageBox.Show("Password did not match.");
                return result;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckForRequiredFields())
            {
                try
                {
                    using (axaDBEntities db = new axaDBEntities())
                    {
                        User usr = new User();
                        usr.fullname = txtFullName.Text;
                        usr.username = txtUsername.Text;
                        usr.password = txtPassword.Text;
                        usr.contact_num = txtContact_Num.Text;
                        usr.address = txtAddress.Text;
                        if (rbAdvisor.Checked == true) { usr.role = rbAdvisor.Text; }
                        if (rbClerkStaff.Checked == true) { usr.role = rbClerkStaff.Text; }
                        if (rbManager.Checked == true) { usr.role = rbManager.Text; }
                        if (rbM.Checked == true) { usr.gender = rbM.Text; }
                        if (rbF.Checked == true) { usr.gender = rbF.Text; }
                        db.Users.Add(usr);
                        db.SaveChanges();
                        MessageBox.Show("Successfully added user.");
                        if (this.role != null)
                        {
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            AddEditUserForm_Load(null, null);
                            btnDelete.Enabled = true;
                            this.role = null;
                        }
                    }
                    ClearTxtField();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.InnerException.InnerException.Message);
                    }
                }

            }
            else
            {
                ClearTxtField();
            }
        }

        private void ClearTxtField()
        {
            txtPassword.PasswordChar = '\0';
            txtRetypePassword.PasswordChar = '\0';
            txtFullName.Text = "Full Name: (Last Name, First Name, Middle Name)";
            txtUsername.Text = "Username";
            txtPassword.Text = "Password";
            txtRetypePassword.Text = "Re-type Password";
            txtContact_Num.Text = "Contact Number";
            txtAddress.Text = "Address";
        }

        private void AddEditUserForm_Load(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                dataGridViewUSR_.DataSource = db.Users.ToList();
                btnUpdate.Enabled = false;
                if (this.role != null)
                {
                    rbManager.Enabled = false;
                    rbClerkStaff.Enabled = false;
                }
                else
                {
                    rbManager.Enabled = true;
                    rbClerkStaff.Enabled = true;
                    this.role = null;
                }
            }
        }

        private void dataGridViewUSR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUSR_.SelectedRows.Count > 0)
            {
                try
                {
                    txtFullName.Text = dataGridViewUSR_.SelectedRows[0].Cells["fullname"].Value.ToString();
                    txtUsername.Text = dataGridViewUSR_.SelectedRows[0].Cells["username"].Value.ToString();
                    txtPassword.Text = dataGridViewUSR_.SelectedRows[0].Cells["password"].Value.ToString();
                    txtRetypePassword.Text = txtPassword.Text;
                    txtContact_Num.Text = dataGridViewUSR_.SelectedRows[0].Cells["contact_num"].Value.ToString();
                    txtAddress.Text = dataGridViewUSR_.SelectedRows[0].Cells["address"].Value.ToString();
                    if (dataGridViewUSR_.SelectedRows[0].Cells["role"].Value.ToString() == "ClerkStaff") { rbClerkStaff.Checked = true; }
                    if (dataGridViewUSR_.SelectedRows[0].Cells["role"].Value.ToString() == "Advisor") { rbAdvisor.Checked = true; }
                    if (dataGridViewUSR_.SelectedRows[0].Cells["role"].Value.ToString() == "Manager") { rbManager.Checked = true; }
                    if (dataGridViewUSR_.SelectedRows[0].Cells["gender"].Value.ToString() == "Male") { rbM.Checked = true; }
                    if (dataGridViewUSR_.SelectedRows[0].Cells["gender"].Value.ToString() == "Female") { rbF.Checked = true; }
                }
                catch { }

                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                dataGridViewUSR_.Enabled = false;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewUSR_.SelectedRows.Count > 0)
            {
                if (CheckForRequiredFields())
                {
                    int usrid = int.Parse(dataGridViewUSR_.SelectedRows[0].Cells["user_id"].Value.ToString());
                    using (axaDBEntities db = new axaDBEntities())
                    {
                        User usr = db.Users.Find(usrid);
                        usr.fullname = txtFullName.Text;
                        usr.username = txtUsername.Text;
                        usr.password = txtPassword.Text;
                        usr.contact_num = txtContact_Num.Text;
                        usr.address = txtAddress.Text;

                        if (rbAdvisor.Checked == true) { usr.role = rbAdvisor.Text; }
                        if (rbClerkStaff.Checked == true) { usr.role = rbClerkStaff.Text; }
                        if (rbManager.Checked == true) { usr.role = rbManager.Text; }
                        if (rbM.Checked == true) { usr.gender = rbM.Text; }
                        if (rbF.Checked == true) { usr.gender = rbF.Text; }

                        db.SaveChanges();
                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                        dataGridViewUSR_.Enabled = true;
                    }
                    MessageBox.Show("Update Successful");
                    AddEditUserForm_Load(null, null);
                    ClearTxtField();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUSR_.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow br in dataGridViewUSR_.SelectedRows)
                {
                    if (MessageBox.Show("Delete? " + br.Cells["FULLNAME"].Value.ToString(), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (axaDBEntities db = new axaDBEntities())
                        {
                            User usr = db.Users.Find(br.Cells["user_id"].Value);
                            if (usr.user_id.ToString() == Properties.Settings.Default.current_user_id)
                            {
                                MessageBox.Show("Sorry, can't delete current logged-in user.");
                            }
                            else
                            {
                                db.Users.Remove(usr);
                                db.SaveChanges();
                            }
                            dataGridViewUSR_.Enabled = true;
                            btnAdd.Enabled = true;
                            AddEditUserForm_Load(null, null);
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
                    dataGridViewUSR_.DataSource = db.Users.Where(u => u.username.Contains(txtSearch.Text) ||
                                                                u.fullname.Contains(txtSearch.Text) ||
                                                                u.role.Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void dataGridViewUSR_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewUSR_.Columns["user_id"].HeaderText = "Id";
            dataGridViewUSR_.Columns["username"].HeaderText = "Username";
            dataGridViewUSR_.Columns["role"].HeaderText = "Designated Position";
            dataGridViewUSR_.Columns["fullname"].HeaderText = "Full Name";
            dataGridViewUSR_.Columns["gender"].HeaderText = "Gender";
            dataGridViewUSR_.Columns["contact_num"].HeaderText = "Contact Number";
            dataGridViewUSR_.Columns["address"].HeaderText = "Address";
            dataGridViewUSR_.Columns["password"].Visible = false;
        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            if (txtFullName.Text == "Full Name: (Last Name, First Name, Middle Name)")
            {
                txtFullName.Text = "";
            }

        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            if (txtFullName.Text == "")
            {
                txtFullName.Text = "Full Name: (Last Name, First Name, Middle Name)";
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";

            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {

            if (txtPassword.Text == "")
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.Text = "Password";


            }
        }

        private void txtRetypePassword_Enter(object sender, EventArgs e)
        {
            txtRetypePassword.PasswordChar = '*';
            if (txtRetypePassword.Text == "Re-type Password")
            {
                txtRetypePassword.Text = "";

            }
        }

        private void txtRetypePassword_Leave(object sender, EventArgs e)
        {
            if (txtRetypePassword.Text == "")
            {
                txtRetypePassword.PasswordChar = '\0';
                txtRetypePassword.Text = "Re-type Password";

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

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void txtContact_Num_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
