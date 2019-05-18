using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class ViewClientForm : Form
    {
        public int selected_client_id;
        Client client = new Client();
        axaDBEntities db = new axaDBEntities();
        ReportDocument myReportDocument;

        public ViewClientForm()
        {
            InitializeComponent();
        }

        private void ViewClientForm_Load(object sender, EventArgs e)
        {
            client = db.Clients.Find(selected_client_id);
            myReportDocument = new ReportDocument();
            myReportDocument.Load((Application.StartupPath + "\\CrystalReport.rpt"));
            //myReportDocument.SetDatabaseLogon("bhimbol", "input32.dll", "PPYCHA-PC", "axaDB");
            myReportDocument.SetParameterValue("param_client_id", client.client_id);
            crystalReportViewer1.ReportSource = myReportDocument;
        }
    }
}