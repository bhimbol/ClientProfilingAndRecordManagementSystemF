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
    public partial class AddEditClientForm : Form
    {
        public Client selected_client { set; get; }

        public string action { set; get; }

        private void copy_browsed_id(string sourcepath, long client_id)
        {
            if (pbID.Image != null) { pbID.Image.Dispose(); }
            System.IO.File.Copy(sourcepath, Application.StartupPath + "\\ID_S\\" + client_id.ToString() + ".jpg", true);
        }

        public void populateClientIDImage(string id_path)
        {
            if (id_path != null)
            {
                if (System.IO.File.Exists(id_path))
                {
                    Bitmap id_image;
                    pbID.SizeMode = PictureBoxSizeMode.StretchImage;
                    id_image = new Bitmap(id_path);
                    pbID.Image = (Image)id_image;
                }
            }
        }

        private void populateFinancialAdvisors()
        {
            using(axaDBEntities db = new axaDBEntities())
            {
                cboxfinancial_advisor.DataSource = db.FinancialAdvisors.ToList();
                cboxfinancial_advisor.DisplayMember = "fullname";
                cboxfinancial_advisor.ValueMember = "id";
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
                    lbPlan.Items.Add(db.Plans.Where(p => p.id == _id).FirstOrDefault());
                    lbPlan.DisplayMember = "description";
                    lbPlan.ValueMember = "id";
                }
            }
        }

        public void populateClientBeneficiaries(long client_id)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                dgvBeneficiaries.DataSource = (from cb in db.ClientBeneficiaries
                                               where cb.CLIENT_ID == client_id
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
            txtClientsID.Text = selected_client.id.ToString();
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
            txtDue.Text = selected_client.due.ToString();

            if(selected_client.mode_of_payment == null){ lbModeofPayment.SelectedIndex = 1; }
            else{ lbModeofPayment.SelectedItem = selected_client.mode_of_payment; }

            try
            {
                using (axaDBEntities db = new axaDBEntities())
                {
                    FinancialAdvisor selected_fa = db.FinancialAdvisors.Find(selected_client.financial_advisor_id);
                    cboxfinancial_advisor.Text = selected_fa.fullname;

                }
            }
            catch { }

    
            if (selected_client.gender == "Male")
            {
                rbGenderM.Checked = true;
            }
            else
            {
                rbGenderF.Checked = true;
            }

            if (selected_client.civilstatus == "Single")
            {
                rbSingle.Checked = true;
            }
            else if (selected_client.civilstatus == "Married")
            {
                rbMarried.Checked = true;
            }
            else
            {
                rbWidowed.Checked = true;
            }

            if (selected_client.answersub1 == "YES")
            {
                rbYES.Checked = true;
            }
            else
            {
                rbNo.Checked = true;
            }
        }

        public AddEditClientForm()
        {
            InitializeComponent();
        }

        private void AddEditClientForm_Load(object sender, EventArgs e)
        {
            populateFinancialAdvisors();
            lbModeofPayment.SelectedIndex = 0;

            if (this.action == "Edit")
            {
                btnAddClient.Enabled = false;
                btnUpdateClient.Enabled = true;
                panelBeneficiaries.Enabled = true;
                btnAddPlan.Enabled = true;
                populateClient();
                populateClientBeneficiaries(selected_client.id);
                populateClientPlans(selected_client.id);
                populateClientIDImage(selected_client.id_path);
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
            string gender = "";
            string civilstatus = "";
            string answer1 = "";
            if (rbGenderM.Checked == true) { gender = "Male"; }
            if (rbGenderF.Checked == true) { gender = "Female"; }
            if (rbSingle.Checked == true) { civilstatus = "Single"; }
            if (rbMarried.Checked == true) { civilstatus = "Married"; }
            if (rbWidowed.Checked == true) { civilstatus = "Widowed"; }
            if (rbYES.Checked == true) { answer1 = "YES"; }
            if (rbNo.Checked == true) { answer1 = "NO"; }

            using (axaDBEntities db = new axaDBEntities())
            {
                Client c = db.Clients.Find(Int64.Parse(txtClientsID.Text));
                double h = 0, w = 0, ws = 0, bi = 0, oi = 0, d = 0;

                c.financial_advisor_id = (Int64)cboxfinancial_advisor.SelectedValue;
                c.firstname = txtFirstname.Text;
                c.middlename = txtMiddlename.Text;
                c.lastname = txtLastname.Text;
                c.spouselastname = txtSLastname.Text;
                c.spousefirstname = txtSFirstname.Text;
                c.spousemiddlename = txtSMiddlename.Text;
                c.birthplace = txtBirthplace.Text;
                Double.TryParse(txtHeight.Text, out h);
                c.height = h;
                Double.TryParse(txtweight.Text, out w);
                c.weight = w;
                c.residenceaddress = txtresidenceaddress.Text;
                c.cpnumber = txtcpnumber.Text;
                c.telephonenumber = txttelephonenumber.Text;
                c.emailaddress = txtemailaddress.Text;
                c.occupation = txtOccupation.Text;
                Double.TryParse(txtWorkSalary.Text, out ws);
                c.worksalary = ws;
                Double.TryParse(txtBusinessIncome.Text, out bi);
                c.businessincome = bi;
                Double.TryParse(txtOtherSource.Text, out oi);
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
                Double.TryParse(txtDue.Text, out d);
                c.due = d;
                c.mode_of_payment = lbModeofPayment.SelectedItem.ToString();

                if (!String.IsNullOrEmpty(txtIDDir.Text))
                {
                    copy_browsed_id(txtIDDir.Text, c.id);
                    c.id_path = Application.StartupPath + "\\ID_S\\" + c.id.ToString() + ".jpg";
                }

                db.SaveChanges();
                MessageBox.Show("Record successfully updated.");
                c = null;
                this.Close();
                this.Dispose();
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            string gender = "";
            string civilstatus = "";
            string answer1 = "";
            if (rbGenderM.Checked == true) { gender = "Male"; }
            if (rbGenderF.Checked == true) { gender = "Female"; }
            if (rbSingle.Checked == true) { civilstatus = "Single"; }
            if (rbMarried.Checked == true) { civilstatus = "Married"; }
            if (rbWidowed.Checked == true) { civilstatus = "Widowed"; }
            if (rbYES.Checked == true) { answer1 = "YES"; }
            if (rbNo.Checked == true) { answer1 = "NO"; }

            using (axaDBEntities db = new axaDBEntities())
            {
                Client c = new Client();
                double h = 0, w = 0, ws = 0, bi = 0, oi = 0, d = 0;
                c.financial_advisor_id = (Int64)cboxfinancial_advisor.SelectedValue;
                c.lastname = txtLastname.Text;
                c.firstname = txtFirstname.Text;
                c.middlename = txtMiddlename.Text;
                c.spouselastname = txtSLastname.Text;
                c.spousefirstname = txtSFirstname.Text;
                c.spousemiddlename = txtSMiddlename.Text;
                c.birthplace = txtBirthplace.Text;
                Double.TryParse(txtHeight.Text,out h);
                c.height = h;
                Double.TryParse(txtweight.Text, out w);
                c.weight = w;
                c.residenceaddress = txtresidenceaddress.Text;
                c.cpnumber = txtcpnumber.Text;
                c.telephonenumber = txttelephonenumber.Text;
                c.emailaddress = txtemailaddress.Text;
                c.occupation = txtOccupation.Text;
                Double.TryParse(txtWorkSalary.Text, out ws);
                c.worksalary = ws;
                Double.TryParse(txtBusinessIncome.Text, out bi);
                c.businessincome = bi;
                Double.TryParse(txtOtherSource.Text, out oi);
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
                Double.TryParse(txtDue.Text, out d);
                c.due = d;
                c.mode_of_payment = lbModeofPayment.SelectedItem.ToString();


                if (!String.IsNullOrEmpty(txtIDDir.Text))
                {
                    copy_browsed_id(txtIDDir.Text, c.id);
                    c.id_path = Application.StartupPath + "\\ID_S\\" + c.id.ToString() + ".jpg";
                }

                db.Clients.Add(c);
                db.SaveChanges();
                MessageBox.Show("Record successfully added.");
                txtClientsID.Text = c.id.ToString();

                this.selected_client = c;
                this.action = "Edit";
                AddEditClientForm_Load(null, null);
            }
        }

        private void btnAddBeneficiary_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                ClientBeneficiary cb = new ClientBeneficiary();
                double s = 0;
                cb.CLIENT_ID = Int64.Parse(txtClientsID.Text);
                cb.FULLNAME = txtBFullname.Text;
                cb.BIRTHDATE = dtpBBirthDate.Value;
                cb.BIRTHPLACE = txtBBirthPlace.Text;
                cb.RELATIONSHIP = txtBRelationship.Text;
                cb.OCCUPATION = txtBOccupation.Text;
                Double.TryParse(txtBShare.Text, out s);
                cb.SHARE = s;
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
            long bid = (Int64)dgvBeneficiaries.SelectedRows[0].Cells["ID"].Value;
            using (axaDBEntities db = new axaDBEntities())
            {
                ClientBeneficiary cb = db.ClientBeneficiaries.Find(bid);
                double s = 0;
                cb.FULLNAME = txtBFullname.Text;
                cb.BIRTHDATE = dtpBBirthDate.Value;
                cb.BIRTHPLACE = txtBBirthPlace.Text;
                cb.RELATIONSHIP = txtBRelationship.Text;
                cb.OCCUPATION = txtBOccupation.Text;
                Double.TryParse(txtBShare.Text, out s);
                cb.SHARE = s;
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
            btnBUpdate.Visible = true;
            btnAddBeneficiary.Enabled = false;
            if( dgvBeneficiaries.Rows.Count > 0)
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

        private void btnRemoveBeneficiary_Click(object sender, EventArgs e)
        {
            if(dgvBeneficiaries.Rows.Count > 0)
            {
                foreach(DataGridViewRow br in dgvBeneficiaries.SelectedRows)
                {
                    if (MessageBox.Show("Delete? " + br.Cells["FULLNAME"].Value.ToString(),"Delete",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using(axaDBEntities db = new axaDBEntities())
                        {
                            ClientBeneficiary cb = db.ClientBeneficiaries.Find(br.Cells["ID"].Value);
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
                txtIDDir.Text = opd.FileName;
            }
        }

        private void txtIDDir_TextChanged(object sender, EventArgs e)
        {
            populateClientIDImage(txtIDDir.Text);
        }

        private void lbModeofPayment_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}