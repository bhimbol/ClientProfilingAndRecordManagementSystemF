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
    public partial class AddEditUserForm : Form
    {
        public string role { get; set; }
        public AddEditUserForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                User usr = new User();
                usr.fullname = txtFullName.Text;
                usr.username = txtUsername.Text;
                usr.password = txtPassword.Text;
                if (rbAdvisor.Checked == true) { usr.role = rbAdvisor.Text; }
                if (rbClerkStaff.Checked == true) { usr.role = rbClerkStaff.Text; }
                if (rbManager.Checked == true) { usr.role = rbManager.Text; }
                db.Users.Add(usr);
                db.SaveChanges();
                MessageBox.Show("Successfully added user.");
                if(this.role != null)
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
        }

        private void AddEditUserForm_Load(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                dataGridViewUSR.DataSource = db.Users.ToList();
                btnUpdate.Enabled = false;
                if(this.role != null)
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
            if (dataGridViewUSR.SelectedRows.Count > 0)
            {
                txtFullName.Text = dataGridViewUSR.SelectedRows[0].Cells["fullname"].Value.ToString();
                txtUsername.Text = dataGridViewUSR.SelectedRows[0].Cells["username"].Value.ToString();
                txtPassword.Text = dataGridViewUSR.SelectedRows[0].Cells["password"].Value.ToString();
                txtRetypePassword.Text = txtPassword.Text;
                if (dataGridViewUSR.SelectedRows[0].Cells["role"].Value.ToString() == "ClerkStaff") { rbClerkStaff.Checked = true; }
                if (dataGridViewUSR.SelectedRows[0].Cells["role"].Value.ToString() == "Advisor") { rbAdvisor.Checked = true; }
                if (dataGridViewUSR.SelectedRows[0].Cells["role"].Value.ToString() == "Manager") { rbManager.Checked = true; }
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                dataGridViewUSR.Enabled = false;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewUSR.SelectedRows.Count > 0)
            {
                long usrid = (Int64)dataGridViewUSR.SelectedRows[0].Cells["id"].Value;
                using (axaDBEntities db = new axaDBEntities())
                {
                    User usr = db.Users.Find(usrid);
                    usr.fullname = txtFullName.Text;
                    usr.username = txtUsername.Text;
                    usr.password = txtPassword.Text;
                    
                    if(rbAdvisor.Checked == true) { usr.role = rbAdvisor.Text; }
                    if (rbClerkStaff.Checked == true) { usr.role = rbClerkStaff.Text; }
                    if (rbManager.Checked == true) { usr.role = rbManager.Text; }

                    db.SaveChanges();
                    btnUpdate.Enabled = false;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    dataGridViewUSR.Enabled = true;
                }
                AddEditUserForm_Load(null, null);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUSR.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow br in dataGridViewUSR.SelectedRows)
                {
                    if (MessageBox.Show("Delete? " + br.Cells["FULLNAME"].Value.ToString(), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (axaDBEntities db = new axaDBEntities())
                        {
                            User usr = db.Users.Find(br.Cells["ID"].Value);
                            db.Users.Remove(usr);
                            db.SaveChanges();
                            dataGridViewUSR.Enabled = true;
                            btnAdd.Enabled = true;
                            AddEditUserForm_Load(null, null);
                        }
                    }
                }
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                using (axaDBEntities db = new axaDBEntities())
                {
                    dataGridViewUSR.DataSource = db.Users.Where(u => u.username.Contains(txtSearch.Text) ||
                                                                u.fullname.Contains(txtSearch.Text) ||
                                                                u.role.Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void AddEditUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
