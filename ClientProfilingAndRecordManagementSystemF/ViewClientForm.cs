using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class ViewClientForm : Form
    {
        public DataGridViewRow selected_client { get; set; }

        public ViewClientForm()
        {
            InitializeComponent();
        }

        private void ViewClientForm_Load(object sender, EventArgs e)
        {

            string fullname = this.selected_client.Cells["lastname"].Value.ToString() + ", " +
                              this.selected_client.Cells["firstname"].Value.ToString() + " " +
                              this.selected_client.Cells["middlename"].Value.ToString();
            string sfullname = this.selected_client.Cells["spouselastname"].Value.ToString() + ", " +
                              this.selected_client.Cells["spousefirstname"].Value.ToString() + " " +
                              this.selected_client.Cells["spousemiddlename"].Value.ToString();

            ReportParameterCollection report_parameters = new ReportParameterCollection();
            report_parameters.Add(new ReportParameter("client_full_name", fullname));
            report_parameters.Add(new ReportParameter("gender", this.selected_client.Cells["gender"].Value.ToString()));
            report_parameters.Add(new ReportParameter("civilstatus", this.selected_client.Cells["civilstatus"].Value.ToString()));
            report_parameters.Add(new ReportParameter("spouse_fullname", sfullname));
            report_parameters.Add(new ReportParameter("birthdate", this.selected_client.Cells["birthday"].Value.ToString()));
            report_parameters.Add(new ReportParameter("birthplace", this.selected_client.Cells["birthplace"].Value.ToString()));
            report_parameters.Add(new ReportParameter("height", this.selected_client.Cells["height"].Value.ToString()));
            report_parameters.Add(new ReportParameter("weight", this.selected_client.Cells["weight"].Value.ToString()));
            report_parameters.Add(new ReportParameter("residenceaddress", this.selected_client.Cells["residenceaddress"].Value.ToString()));
            report_parameters.Add(new ReportParameter("cpnumber", this.selected_client.Cells["cpnumber"].Value.ToString()));
            report_parameters.Add(new ReportParameter("telephonenumber", this.selected_client.Cells["telephonenumber"].Value.ToString()));
            report_parameters.Add(new ReportParameter("emailaddress", this.selected_client.Cells["emailaddress"].Value.ToString()));
            report_parameters.Add(new ReportParameter("occupation", this.selected_client.Cells["occupation"].Value.ToString()));
            report_parameters.Add(new ReportParameter("worksalary", this.selected_client.Cells["worksalary"].Value.ToString()));
            report_parameters.Add(new ReportParameter("businessincome", this.selected_client.Cells["businessincome"].Value.ToString()));
            report_parameters.Add(new ReportParameter("othersource", this.selected_client.Cells["othersource"].Value.ToString()));
            report_parameters.Add(new ReportParameter("companyname", this.selected_client.Cells["companyname"].Value.ToString()));
            report_parameters.Add(new ReportParameter("companyaddress", this.selected_client.Cells["companyaddress"].Value.ToString()));
            report_parameters.Add(new ReportParameter("companycontact", this.selected_client.Cells["companycontact"].Value.ToString()));
            report_parameters.Add(new ReportParameter("natureofbusiness", this.selected_client.Cells["natureofbusiness"].Value.ToString()));
            report_parameters.Add(new ReportParameter("taxidnumber", this.selected_client.Cells["taxidnumber"].Value.ToString()));
            report_parameters.Add(new ReportParameter("sss_gsis_number", this.selected_client.Cells["sss_gsis_number"].Value.ToString()));
            using (axaDBEntities db = new axaDBEntities())
            {
                var id = Int64.Parse(this.selected_client.Cells["id"].Value.ToString());
                var ds = (from cb in db.ClientBeneficiaries
                          where cb.CLIENT_ID == id
                          select cb).ToList();
                ReportDataSource datasource = new ReportDataSource("dsClientBeneficiary", ds);
                rvClient.LocalReport.DataSources.Add(datasource);
            }
            rvClient.LocalReport.SetParameters(report_parameters);
            rvClient.RefreshReport();
        }
    }
}
