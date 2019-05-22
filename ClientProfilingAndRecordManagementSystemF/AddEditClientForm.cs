using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class AddEditClientForm : Form
    {
        public Client selected_client { set; get; }

        public string action { set; get; }

        private string Copy_browsed_id(string sourcepath, long client_id, string _id)
        {
            try
            {
                if (_id == "1") { pbID1.Image.Dispose(); }
                else if (_id == "2") { pbID2.Image.Dispose(); }
                else { }
                string final_destination_path = Application.StartupPath + "\\ID_S\\" + client_id.ToString() + _id + DateTime.Now.Ticks.ToString() + ".jpeg";
                System.IO.File.Copy(sourcepath, final_destination_path, true);
                PopulateClientIDImage(final_destination_path, Int32.Parse(_id));
                return final_destination_path;
            }
            catch
            {
                return Application.StartupPath + "\\ID_S\\" + "DefaultID.jpeg";
            }
        }

        public void PopulateClientIDImage(string id_path, int _id)
        {
            if ((id_path != null) && System.IO.File.Exists(id_path))
            {
                if (_id == 1)
                {
                    pbID1.Image = Image.FromFile(id_path);
                }
                else if (_id == 2)
                {
                    pbID2.Image = Image.FromFile(id_path);
                }
                else { }
            }
        }

        private void populateFinancialAdvisors()
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                var financial_advisor_list = db.FinancialAdvisors.ToList();
                if (financial_advisor_list.Count > 0)
                {
                    cboxfinancial_advisor.DataSource = financial_advisor_list;
                    cboxfinancial_advisor.DisplayMember = "FName";
                    cboxfinancial_advisor.ValueMember = "FA_id";
                }
            }
        }

        public void populateClientPlans(long client_id)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                var client_plan_ids = (from cp in db.ClientPlans
                                       where cp.client_id == client_id
                                       select cp.plan_id).ToList();
                foreach (int _id in client_plan_ids)
                {
                    lbPlan.Items.Add(db.Plans.Where(p => p.plan_id == _id).FirstOrDefault());
                    lbPlan.DisplayMember = "description";
                    lbPlan.ValueMember = "plan_id";
                }
            }
        }

        public void populateClientBeneficiaries(long client_id)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                dgvBeneficiaries.DataSource = (from cb in db.ClientBeneficiaries
                                               where cb.client_id == client_id
                                               select cb).ToList();
                dgvBeneficiaries.Columns[0].HeaderText = "Beneficiary's ID";
                dgvBeneficiaries.Columns[1].HeaderText = "Client's ID";
                dgvBeneficiaries.Columns[0].Visible = false;
                dgvBeneficiaries.Columns[1].Visible = false;
                dgvBeneficiaries.Columns[2].HeaderText = "FULL NAME";
                dgvBeneficiaries.Columns[3].HeaderText = "BIRTH DATE (dd/mm/yyyy)";
                dgvBeneficiaries.Columns[4].HeaderText = "BIRTH PLACE";
                dgvBeneficiaries.Columns[5].HeaderText = "RELATIONSHIP";
                dgvBeneficiaries.Columns[6].HeaderText = "OCCUPATION";
                dgvBeneficiaries.Columns[7].HeaderText = "PERCENT SHARE";
                btnBUpdate.Visible = false;
            }
        }

        private void populateClient()
        {
            txtClientsID.Text = selected_client.client_id.ToString();
            txtLastname.Text = selected_client.lastname;
            txtFirstname.Text = selected_client.firstname;
            txtMiddlename.Text = selected_client.middlename;
            txtSLastname.Text = selected_client.spouselastname;
            txtSFirstname.Text = selected_client.spousefirstname;
            txtSMiddlename.Text = selected_client.spousemiddlename;
            txtBirthplace.Text = selected_client.birthplace;
            txtHeight.Text = selected_client.height.ToString();
            txtweight.Text = selected_client.weight.ToString();
            txtresidenceaddress.Text = selected_client.residenceaddress;
            txtcpnumber.Text = selected_client.cpnumber;
            txttelephonenumber.Text = selected_client.telephonenumber;
            txtemailaddress.Text = selected_client.emailaddress;
            txtOccupation.Text = selected_client.occupation;
            txtWorkSalary.Text = selected_client.worksalary.ToString();
            txtBusinessIncome.Text = selected_client.businessincome.ToString();
            txtOtherSource.Text = selected_client.othersource.ToString();
            txtCompanyName.Text = selected_client.companyname;
            txtCompanyAddress.Text = selected_client.companyaddress;
            txtCompanyConctactNumber.Text = selected_client.companycontact;
            txtNatureofBusiness.Text = selected_client.natureofbusiness;
            txtTaxIDNumber.Text = selected_client.taxidnumber;
            txtSSSGSISNumber.Text = selected_client.sss_gsis_number;
            txtsubanswer2.Text = selected_client.answersub2;
            txtsubanswer3.Text = selected_client.answersub3;
            dtpBdate.Value = (DateTime)selected_client.birthday;

            if (selected_client.FinancialAdvisor != null)
            {
                string fullname = selected_client.FinancialAdvisor.LName + ", " + selected_client.FinancialAdvisor.FName + " " + selected_client.FinancialAdvisor.MName;
                cboxfinancial_advisor.Text = fullname;
            }

            if (selected_client.gender == "Male") { rbGenderM.Checked = true; }
            else { rbGenderF.Checked = true; }

            if (selected_client.civilstatus == "Single") { rbSingle.Checked = true; }
            else if (selected_client.civilstatus == "Married") { rbMarried.Checked = true; }
            else { rbWidowed.Checked = true; }

            if (selected_client.answersub1 == "YES") { rbYES.Checked = true; }
            else { rbNo.Checked = true; }
        }

        private Client SetClientDataForAddUpdate(Client c)
        {
            string gender = "", civilstatus = "", answer1 = "";

            if (rbGenderM.Checked == true) { gender = "Male"; }
            if (rbGenderF.Checked == true) { gender = "Female"; }
            if (rbSingle.Checked == true) { civilstatus = "Single"; }
            if (rbMarried.Checked == true) { civilstatus = "Married"; }
            if (rbWidowed.Checked == true) { civilstatus = "Widowed"; }
            if (rbYES.Checked == true) { answer1 = "YES"; }
            if (rbNo.Checked == true) { answer1 = "NO"; }

            Double.TryParse(txtHeight.Text, out double h);
            Double.TryParse(txtweight.Text, out double w);
            Double.TryParse(txtWorkSalary.Text, out double ws);
            Double.TryParse(txtBusinessIncome.Text, out double bi);
            Double.TryParse(txtOtherSource.Text, out double oi);

            c.FA_id = (Int32)cboxfinancial_advisor.SelectedValue;
            c.lastname = txtLastname.Text;
            c.firstname = txtFirstname.Text;
            c.middlename = txtMiddlename.Text;
            c.spouselastname = txtSLastname.Text;
            c.spousefirstname = txtSFirstname.Text;
            c.spousemiddlename = txtSMiddlename.Text;
            c.birthplace = txtBirthplace.Text;
            c.height = h;
            c.weight = w;
            c.residenceaddress = txtresidenceaddress.Text;
            c.cpnumber = txtcpnumber.Text;
            c.telephonenumber = txttelephonenumber.Text;
            c.emailaddress = txtemailaddress.Text;
            c.occupation = txtOccupation.Text;
            c.worksalary = ws;
            c.businessincome = bi;
            c.othersource = oi;
            c.companyname = txtCompanyName.Text;
            c.companyaddress = txtCompanyAddress.Text;
            c.companycontact = txtCompanyConctactNumber.Text;
            c.natureofbusiness = txtNatureofBusiness.Text;
            c.taxidnumber = txtTaxIDNumber.Text;
            c.sss_gsis_number = txtSSSGSISNumber.Text;
            c.answersub1 = answer1;
            c.answersub2 = txtsubanswer2.Text;
            c.answersub3 = txtsubanswer3.Text;
            c.birthday = dtpBdate.Value;
            c.gender = gender;
            c.civilstatus = civilstatus;

            if (!String.IsNullOrEmpty(txtIDDir1.Text))
            {
                // (System.IO.File.Exists(c.id_path1)) { System.IO.File.Delete(c.id_path1); }
                c.id_path1 = Copy_browsed_id(txtIDDir1.Text, c.client_id, "1");
            }
            if (!String.IsNullOrEmpty(txtIDDir2.Text))
            {
                //if (System.IO.File.Exists(c.id_path2)) { System.IO.File.Delete(c.id_path2); }
                c.id_path2 = Copy_browsed_id(txtIDDir2.Text, c.client_id, "2");
            }

            return c;
        }

        public AddEditClientForm()
        {
            InitializeComponent();
        }

        private void AddEditClientForm_Load(object sender, EventArgs e)
        {
            populateFinancialAdvisors();
            if (this.action == "Edit")
            {
                btnAddClient.Enabled = false;
                btnUpdateClient.Enabled = true;
                panelBeneficiaries.Enabled = true;
                btnAddPlan.Enabled = true;
                populateClient();
                populateClientBeneficiaries(selected_client.client_id);
                populateClientPlans(selected_client.client_id);
                PopulateClientIDImage(selected_client.id_path1, 1);
                PopulateClientIDImage(selected_client.id_path2, 2);
            }
            else if (this.action == "Add")
            {
                btnAddClient.Enabled = true;
                btnUpdateClient.Enabled = false;
                panelBeneficiaries.Enabled = false;
                btnAddPlan.Enabled = false;
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            //try
            //{
            using (axaDBEntities db = new axaDBEntities())
            {
                Client c = db.Clients.Find(Int32.Parse(txtClientsID.Text));
                c = SetClientDataForAddUpdate(c);
                db.SaveChanges();
                MessageBox.Show("Record successfully updated.");
                this.Close();
                this.Dispose();
            }
            // }
            //catch (Exception ex)
            //{
            //   MessageBox.Show(ex.Message);
            // }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            CheckTxtBoxIfnotEmpty();

        }

        private void CheckTxtBoxIfnotEmpty()
        {
            if (txtFirstname.Text != "First name" &&
                txtLastname.Text != "Last name" &&
                txtMiddlename.Text != "Middle name" &&
                txtweight.Text != "Weight" &&
                txtHeight.Text != "Height" &&
                txtBBirthPlace.Text != "Place of Birth" &&
                txtemailaddress.Text != "Email Address" &&
                txttelephonenumber.Text != "Home Telephone Number" &&
                txtcpnumber.Text != "Cellphone Number" &&
                txtresidenceaddress.Text != "Residence Address"
                )
            {
                SaveClient();
            }
        }

        private void SaveClient()
        {
            try
            {

                Client c = SetClientDataForAddUpdate(new Client());
                using (axaDBEntities db = new axaDBEntities())
                {
                    db.Clients.Add(c);
                    db.SaveChanges();
                    MessageBox.Show("Record successfully added.");
                    txtClientsID.Text = c.client_id.ToString();
                    this.selected_client = c;
                    this.action = "Edit";
                    AddEditClientForm_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddBeneficiary_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                ClientBeneficiary cb = new ClientBeneficiary();
                double s = 0;
                cb.client_id = Int32.Parse(txtClientsID.Text);
                cb.fullname = txtBFullname.Text;
                cb.birthdate = dtpBBirthDate.Value;
                cb.birthplace = txtBBirthPlace.Text;
                cb.relationship = txtBRelationship.Text;
                cb.occupation = txtBOccupation.Text;
                Double.TryParse(txtBShare.Text, out s);
                cb.share = s;
                db.ClientBeneficiaries.Add(cb);
                db.SaveChanges();
                MessageBox.Show("Beneficiary successfully added.");
                populateClientBeneficiaries(Int64.Parse(txtClientsID.Text));
                txtBFullname.Clear();
                txtBBirthPlace.Clear();
                txtBRelationship.Clear();
                txtBOccupation.Clear();
                txtBShare.Clear();
                cb = null;
            }
        }

        private void btnBUpdate_Click(object sender, EventArgs e)
        {
            int bid = (Int32)dgvBeneficiaries.SelectedRows[0].Cells["beneficiary_id"].Value;
            using (axaDBEntities db = new axaDBEntities())
            {
                ClientBeneficiary cb = db.ClientBeneficiaries.Find(bid);
                double s = 0;
                cb.fullname = txtBFullname.Text;
                cb.birthdate = dtpBBirthDate.Value;
                cb.birthplace = txtBBirthPlace.Text;
                cb.relationship = txtBRelationship.Text;
                cb.occupation = txtBOccupation.Text;
                Double.TryParse(txtBShare.Text, out s);
                cb.share = s;
                db.SaveChanges();
                MessageBox.Show("Beneficiary updated.");
                populateClientBeneficiaries(Int64.Parse(txtClientsID.Text));
                txtBFullname.Clear();
                txtBBirthPlace.Clear();
                txtBRelationship.Clear();
                txtBOccupation.Clear();
                txtBShare.Clear();
                btnBUpdate.Visible = false;
                btnAddBeneficiary.Enabled = true;
                dgvBeneficiaries.Enabled = true;
                btnRemoveBeneficiary.Enabled = true;
            }
        }

        private void dgvBeneficiaries_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnRemoveBeneficiary_Click(object sender, EventArgs e)
        {
            if (dgvBeneficiaries.Rows.Count > 0)
            {
                foreach (DataGridViewRow br in dgvBeneficiaries.SelectedRows)
                {
                    if (MessageBox.Show("Delete? " + br.Cells["FULLNAME"].Value.ToString(), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (axaDBEntities db = new axaDBEntities())
                        {
                            ClientBeneficiary cb = db.ClientBeneficiaries.Find(br.Cells["beneficiary_id"].Value);
                            db.ClientBeneficiaries.Remove(cb);
                            db.SaveChanges();
                        }
                    }
                }
            }
            populateClientBeneficiaries(Int64.Parse(txtClientsID.Text));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            AddPlanForm addplanform = new AddPlanForm();
            addplanform.client_id = Int32.Parse(txtClientsID.Text);
            addplanform.ShowDialog();
            lbPlan.Items.Clear();
            populateClientPlans(Int64.Parse(txtClientsID.Text));
        }

        private void btnBrowseID_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Browse Image file for ID";
            opd.DefaultExt = "jpg";
            opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            opd.Multiselect = false;
            if (opd.ShowDialog() == DialogResult.OK)
            {
                txtIDDir1.Text = opd.FileName;
            }
        }

        private void btnBrowseID2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Browse Image file for ID";
            opd.DefaultExt = "jpg";
            opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            opd.Multiselect = false;
            if (opd.ShowDialog() == DialogResult.OK)
            {
                txtIDDir2.Text = opd.FileName;
            }
        }

        private void txtIDDir1_TextChanged(object sender, EventArgs e)
        {
            PopulateClientIDImage(txtIDDir1.Text, 1);
        }
        private void txtIDDir2_TextChanged(object sender, EventArgs e)
        {
            PopulateClientIDImage(txtIDDir2.Text, 2);
        }

        private void dgvBeneficiaries_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnBUpdate.Visible = true;
            btnAddBeneficiary.Enabled = false;
            if (dgvBeneficiaries.Rows.Count > 0)
            {
                txtBFullname.Text = dgvBeneficiaries.SelectedRows[0].Cells["FULLNAME"].Value.ToString();
                dtpBBirthDate.Value = (DateTime)dgvBeneficiaries.SelectedRows[0].Cells["BIRTHDATE"].Value;
                txtBBirthPlace.Text = dgvBeneficiaries.SelectedRows[0].Cells["BIRTHPLACE"].Value.ToString();
                txtBRelationship.Text = dgvBeneficiaries.SelectedRows[0].Cells["RELATIONSHIP"].Value.ToString();
                txtBOccupation.Text = dgvBeneficiaries.SelectedRows[0].Cells["OCCUPATION"].Value.ToString();
                txtBShare.Text = dgvBeneficiaries.SelectedRows[0].Cells["SHARE"].Value.ToString();
                dgvBeneficiaries.Enabled = false;
                btnRemoveBeneficiary.Enabled = false;
            }


        }

        private void cboxfinancial_advisor_Format(object sender, ListControlConvertEventArgs e)
        {
            string lastname = ((FinancialAdvisor)e.ListItem).LName;
            string firstname = ((FinancialAdvisor)e.ListItem).FName;
            string middlename = ((FinancialAdvisor)e.ListItem).MName;
            e.Value = lastname + ", " + firstname + " " + middlename;
        }

        private void txtHeight_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void txtweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(sender, e);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(sender, e);
        }

        private void isNumeric(object sender, KeyPressEventArgs e)
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

        private void txtWorkSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(sender, e);
        }

        private void txtBusinessIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(sender, e);
        }

        private void txtOtherSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(sender, e);
        }






        // Enter and Leave txt design
        private void txtClientsID_Enter(object sender, EventArgs e)
        {
            if (txtClientsID.Text == "Proposed Insured Name")
            {
                txtClientsID.Text = "";

            }
        }

        private void txtClientsID_Leave(object sender, EventArgs e)
        {
            if (txtClientsID.Text == "")
            {
                txtClientsID.Text = "Proposed Insured Name";

            }
        }

        private void txtLastname_Enter(object sender, EventArgs e)
        {
            if (txtLastname.Text == "Last name")
            {
                txtLastname.Text = "";

            }
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            if (txtLastname.Text == "")
            {
                txtLastname.Text = "Last name";
            }
        }

        private void txtMiddlename_Enter(object sender, EventArgs e)
        {
            if (txtMiddlename.Text == "Middle name")
            {
                txtMiddlename.Text = "";
            }


        }

        private void txtMiddlename_Leave(object sender, EventArgs e)
        {
            if (txtMiddlename.Text == "")
            {
                txtMiddlename.Text = "Middle name";
            }
        }

        private void txtFirstname_Enter(object sender, EventArgs e)
        {
            if (txtFirstname.Text == "First name")
            {
                txtFirstname.Text = "";
            }
        }

        private void txtFirstname_Leave(object sender, EventArgs e)
        {
            if (txtFirstname.Text == "")
            {
                txtFirstname.Text = "First name";
            }
        }

        private void txtweight_Enter(object sender, EventArgs e)
        {
            if (txtweight.Text == "Weight")
            {
                txtweight.Text = "";
            }
        }

        private void txtweight_Leave(object sender, EventArgs e)
        {
            if (txtweight.Text == "")
            {
                txtweight.Text = "Weight";
            }
        }

        private void txtHeight_Enter(object sender, EventArgs e)
        {
            if (txtHeight.Text == "Height")
            {
                txtHeight.Text = "";
            }
        }

        private void txtHeight_Leave(object sender, EventArgs e)
        {
            if (txtHeight.Text == "")
            {
                txtHeight.Text = "Height";
            }
        }

        private void txtBirthplace_Enter(object sender, EventArgs e)
        {
            if (txtBirthplace.Text == "Place of Birth")
            {
                txtBirthplace.Text = "";
            }
        }

        private void txtBirthplace_Leave(object sender, EventArgs e)
        {
            if (txtBirthplace.Text == "")
            {
                txtBirthplace.Text = "Place of Birth";
            }
        }

        private void txtemailaddress_Enter(object sender, EventArgs e)
        {


            if (txtemailaddress.Text == "Email Address")
            {
                txtemailaddress.Text = "";
            }
        }

        private void txtemailaddress_Leave(object sender, EventArgs e)
        {
            if (txtemailaddress.Text == "")
            {
                txtemailaddress.Text = "Email Address";
            }
        }

        private void txttelephonenumber_Enter(object sender, EventArgs e)
        {




            if (txttelephonenumber.Text == "Home Telephone Number")
            {
                txttelephonenumber.Text = "";
            }
        }

        private void txttelephonenumber_Leave(object sender, EventArgs e)
        {
            if (txttelephonenumber.Text == "")
            {
                txttelephonenumber.Text = "Home Telephone Number";
            }
        }

        private void txtcpnumber_Enter(object sender, EventArgs e)
        {
            if (txtcpnumber.Text == "Cellphone Number")
            {
                txtcpnumber.Text = "";
            }
        }

        private void txtcpnumber_Leave(object sender, EventArgs e)
        {
            if (txtcpnumber.Text == "")
            {
                txtcpnumber.Text = "Cellphone Number";
            }
        }

        private void txtresidenceaddress_Enter(object sender, EventArgs e)
        {
            if (txtresidenceaddress.Text == "Residence Address")
            {
                txtresidenceaddress.Text = "";
            }
        }

        private void txtresidenceaddress_Leave(object sender, EventArgs e)
        {
            if (txtresidenceaddress.Text == "")
            {
                txtresidenceaddress.Text = "Residence Address";
            }
        }

        private void txtSLastname_Enter(object sender, EventArgs e)
        {
            if (txtSLastname.Text == "Last name")
            {
                txtSLastname.Text = "";
            }
        }

        private void txtSFirstname_Leave(object sender, EventArgs e)
        {
            if (txtSFirstname.Text == "")
            {
                txtSFirstname.Text = "First name";
            }
        }

        private void txtSLastname_Leave(object sender, EventArgs e)
        {
            if (txtSLastname.Text == "")
            {
                txtSLastname.Text = "Last name";
            }
        }

        private void txtSFirstname_Enter(object sender, EventArgs e)
        {
            if (txtSFirstname.Text == "First name")
            {
                txtSFirstname.Text = "";
            }
        }

        private void txtSMiddlename_Enter(object sender, EventArgs e)
        {
            if (txtSMiddlename.Text == "Middle name")
            {
                txtSMiddlename.Text = "";
            }

        }

        private void txtSMiddlename_Leave(object sender, EventArgs e)
        {
            if (txtSMiddlename.Text == "")
            {
                txtSMiddlename.Text = "Middle name";
            }
        }
    }
}