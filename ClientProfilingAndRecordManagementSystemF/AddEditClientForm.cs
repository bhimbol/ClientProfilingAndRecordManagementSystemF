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
        public DataGridViewRow selected_client { set; get; }

        public string action { set; get; }

        private void fillDataForms()
        {
            txtClientsID.Text = selected_client.Cells["ID"].Value.ToString();
            txtLastname.Text = selected_client.Cells["LASTNAME"].Value.ToString();
            txtFirstname.Text = selected_client.Cells["FIRSTNAME"].Value.ToString();
            txtMiddlename.Text = selected_client.Cells["MIDDLENAME"].Value.ToString();
            txtSLastname.Text = selected_client.Cells["SPOUSELASTNAME"].Value.ToString();
            txtSFirstname.Text = selected_client.Cells["SPOUSEFIRSTNAME"].Value.ToString();
            txtSMiddlename.Text = selected_client.Cells["SPOUSEMIDDLENAME"].Value.ToString();
            txtBirthplace.Text = selected_client.Cells["BIRTHPLACE"].Value.ToString();
            txtHeight.Text = selected_client.Cells["HEIGHT"].Value.ToString();
            txtweight.Text = selected_client.Cells["WEIGHT"].Value.ToString();
            txtresidenceaddress.Text = selected_client.Cells["RESIDENCEADDRESS"].Value.ToString();
            txtcpnumber.Text = selected_client.Cells["CPNUMBER"].Value.ToString();
            txttelephonenumber.Text = selected_client.Cells["TELEPHONENUMBER"].Value.ToString();
            txtemailaddress.Text = selected_client.Cells["EMAILADDRESS"].Value.ToString();
            txtOccupation.Text = selected_client.Cells["OCCUPATION"].Value.ToString();
            txtWorkSalary.Text = selected_client.Cells["WORKSALARY"].Value.ToString();
            txtBusinessIncome.Text = selected_client.Cells["BUSINESSINCOME"].Value.ToString();
            txtOtherSource.Text = selected_client.Cells["OTHERSOURCE"].Value.ToString();
            txtCompanyName.Text = selected_client.Cells["COMPANYNAME"].Value.ToString();
            txtCompanyAddress.Text = selected_client.Cells["COMPANYADDRESS"].Value.ToString();
            txtCompanyConctactNumber.Text = selected_client.Cells["COMPANYCONTACT"].Value.ToString();
            txtNatureofBusiness.Text = selected_client.Cells["NATUREOFBUSINESS"].Value.ToString();
            txtTaxIDNumber.Text = selected_client.Cells["TAXIDNUMBER"].Value.ToString();
            txtSSSGSISNumber.Text = selected_client.Cells["sss_gsis_number"].Value.ToString();
            txtsubanswer2.Text = selected_client.Cells["ANSWERSUB2"].Value.ToString();
            txtsubanswer3.Text = selected_client.Cells["ANSWERSUB3"].Value.ToString();
            dtpBdate.Value = (DateTime)selected_client.Cells["BIRTHDAY"].Value;

            try
            {
                using (axaDBEntities db = new axaDBEntities())
                {
                    var selected_fa = db.FinancialAdvisors.Find(selected_client.Cells["financial_advisor_id"].Value);
                    cboxfinancial_advisor.Text = selected_fa.fullname;
                    cboxfinancial_advisor.Refresh();
                }
            }
            catch { }

            string gender = selected_client.Cells["GENDER"].Value.ToString();
            string civilstatus = selected_client.Cells["CIVILSTATUS"].Value.ToString();
            string answersub1 = selected_client.Cells["ANSWERSUB1"].Value.ToString();

            if (gender == "Male")
            {
                rbGenderM.Checked = true;
            }
            else
            {
                rbGenderF.Checked = true;
            }

            if (civilstatus == "Single")
            {
                rbSingle.Checked = true;
            }
            else if (civilstatus == "Married")
            {
                rbMarried.Checked = true;
            }
            else
            {
                rbWidowed.Checked = true;
            }

            if (answersub1 == "YES")
            {
                rbYES.Checked = true;
            }
            else
            {
                rbNo.Checked = true;
            }
            fillBeneficiariesForm(Int64.Parse(txtClientsID.Text));
        }
        public void fillfinancial_advisor_cbox()
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                cboxfinancial_advisor.DataSource = db.FinancialAdvisors.ToList();
                cboxfinancial_advisor.DisplayMember = "fullname";
                cboxfinancial_advisor.ValueMember = "id";
            }
        }

        public void fillBeneficiariesForm(long id)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                dgvBeneficiaries.DataSource = (from cb in db.ClientBeneficiaries
                                               where cb.CLIENT_ID == id
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
        
        public AddEditClientForm()
        {
            InitializeComponent();
        }

        private void AddEditClientForm_Load(object sender, EventArgs e)
        {
            fillfinancial_advisor_cbox();
            if (this.action == "Edit")
            {
                btnAddClient.Enabled = false;
                btnUpdateClient.Enabled = true;
                panelBeneficiaries.Enabled = true;
                fillDataForms();
            }
            else if (this.action == "Add")
            {
                btnAddClient.Enabled = true;
                btnUpdateClient.Enabled = false;
                panelBeneficiaries.Enabled = false;
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
                double h = 0, w = 0, ws = 0, bi = 0, oi = 0;

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
                double h = 0, w = 0, ws = 0, bi = 0, oi = 0;
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
                db.Clients.Add(c);
                db.SaveChanges();
                MessageBox.Show("Record successfully added.");
                txtClientsID.Text = c.id.ToString();
                fillBeneficiariesForm(c.id);
                btnAddClient.Enabled = false;
                btnUpdateClient.Enabled = true;
                panelBeneficiaries.Enabled = true;
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
                fillBeneficiariesForm(Int64.Parse(txtClientsID.Text));
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
                fillBeneficiariesForm(Int64.Parse(txtClientsID.Text));
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
            fillBeneficiariesForm(Int64.Parse(txtClientsID.Text));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void cboxfinancial_advisor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}