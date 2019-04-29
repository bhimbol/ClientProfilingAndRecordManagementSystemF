﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void ListClientsButton_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                ListLabel.Text = "List of: CLIENTS " + db.Clients.Count() + " client(s) found.";
                ListDataGridView.Tag = "CLIENTS";
                ListDataGridView.DataSource = db.Clients.ToList();
            }
        }

        private void ListAXAFormButton_Click(object sender, EventArgs e)
        {
            ListLabel.Text = "List of: AXA FORMS";
            ListDataGridView.Tag = "AXAFORMS";
            var AllFiles = new DirectoryInfo(Application.StartupPath + "\\AXA FORMS").GetDirectories();
            ListDataGridView.DataSource = AllFiles;
        }

        private void ListDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            if (ListDataGridView.Tag.ToString() == "AXAFORMS" || ListDataGridView.Tag.ToString() == "AXAFORMS-SUBFOLDERS")
            {

                foreach (DataGridViewColumn c in ListDataGridView.Columns)
                {
                    if (c.HeaderText != "Name")
                    {
                        c.Visible = false;
                    }
                }
            }
            else if (ListDataGridView.Tag.ToString() == "CLIENTS")
            {
                foreach (DataGridViewColumn c in ListDataGridView.Columns)
                {
                    c.Visible = false;
                    if ((c.HeaderText == "firstname") || (c.HeaderText == "lastname") || (c.HeaderText == "middlename"))
                    {
                        c.Visible = true;
                    }
                }
            }
            else if (ListDataGridView.Tag.ToString() == "FA")
            {
                foreach (DataGridViewColumn c in ListDataGridView.Columns)
                {
                    c.Visible = false;
                    c.HeaderText = c.HeaderText.ToLower();
                    if (c.HeaderText == "fullname")
                    {
                        c.Visible = true;
                    }
                }
            }
            else if (ListDataGridView.Tag.ToString() == "PLANS")
            {
                foreach (DataGridViewColumn c in ListDataGridView.Columns)
                {
                    c.Visible = false;
                    if (c.HeaderText == "description")
                    {
                        c.Visible = true;
                    }
                }
            }
            else { }

        }

        private void ListDataGridView_Click(object sender, EventArgs e)
        {
            if (ListDataGridView.Tag.ToString() == "AXAFORMS")
            {
                ListDataGridView.Tag = "AXAFORMS-SUBFOLDERS";
                var AllFiles = new DirectoryInfo(ListDataGridView.SelectedRows[0].Cells["FullName"].Value.ToString()).GetFiles();
                ListDataGridView.DataSource = AllFiles;
                if(ListDataGridView.RowCount > 0)
                {
                    ListLabel.Text = ListLabel.Text + " (" + ListDataGridView.RowCount.ToString() + " items: " + ") in " + ListDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                }
                ListDataGridView.ClearSelection();
            }
        }

        private void ListDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (ListDataGridView.Tag.ToString() == "AXAFORMS-SUBFOLDERS")
            {
                if (ListDataGridView.SelectedRows.Count > 0)
                {
                    System.Diagnostics.Process.Start(ListDataGridView.SelectedRows[0].Cells["FullName"].Value.ToString());
                }
            }
            if(ListDataGridView.Tag.ToString() == "CLIENTS")
            {
                if (ListDataGridView.SelectedRows.Count > 0)
                {
                    ViewClientForm viewclientform = new ViewClientForm();
                    viewclientform.selected_client_id = Int32.Parse(ListDataGridView.SelectedRows[0].Cells["client_id"].Value.ToString());
                    viewclientform.ShowDialog();
                }
            }
        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientsForm manageclientform = new ManageClientsForm();
            manageclientform.ShowDialog();
        }

        private void manageFinancialAdvisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageFinancialAdvisorForm managefinancialadvisorform = new ManageFinancialAdvisorForm();
            managefinancialadvisorform.ShowDialog();
        }

        private void ListFinancialAdvisorButton_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                ListLabel.Text = "List of: FINANCIAL ADVISORS " + db.FinancialAdvisors.Count() + " financial advisor(s) found.";
                ListDataGridView.Tag = "FA";
                ListDataGridView.DataSource = db.FinancialAdvisors.ToList();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                using(axaDBEntities db = new axaDBEntities())
                {
                    if (ListDataGridView.Tag.ToString() == "FA")
                    {
                        var result = db.FinancialAdvisors.Where(x => x.fullname.Contains(txtSearch.Text)).ToList();
                        ListDataGridView.DataSource = result;
                        ListLabel.Text = "Found " + result.Count.ToString() + " item(s).";
                    }
                    else if (ListDataGridView.Tag.ToString() == "CLIENTS")
                    {
                        var result = db.Clients.Where(x => x.lastname.Contains(txtSearch.Text) ||
                                                      x.firstname.Contains(txtSearch.Text) ||
                                                      x.middlename.Contains(txtSearch.Text)).ToList();
                        ListDataGridView.DataSource = result;
                        ListLabel.Text = "Found " + result.Count.ToString() + " item(s).";
                    }
                    else if (ListDataGridView.Tag.ToString() == "AXAFORMS")
                    {
                        
                    }
                    else if (ListDataGridView.Tag.ToString() == "AXAFORMS-SUBFOLDERS")
                    {

                    }
                    else if(ListDataGridView.Tag.ToString() == "PLANS")
                    {
                        var result = db.Plans.Where(x => x.description.Contains(txtSearch.Text) ||
                                                         x.type.Contains(txtSearch.Text) ||
                                                         x.category.Contains(txtSearch.Text)).ToList();
                        ListDataGridView.DataSource = result;
                        ListLabel.Text = "Found " + result.Count.ToString() + " item(s).";
                    }
                    else { }
                }
            }
        }

        private void ListPlanButton_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                ListLabel.Text = "List of: Plans " + db.Plans.Count() + " plan(s) found.";
                ListDataGridView.Tag = "PLANS";
                ListDataGridView.DataSource = db.Plans.ToList();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Load(null, null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Show();
            LogInForm loginform = new LogInForm();
            loginform.ShowDialog();
            if ((Properties.Settings.Default.current_user_role == "Clerk Staff") || (Properties.Settings.Default.current_user_role == "Advisor"))
            {
                manageUsersToolStripMenuItem.Enabled = false;
                manageFinancialAdvisorToolStripMenuItem.Enabled = false;
            }
            ListClientsButton_Click(null, null);
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUserForm addeditfuserform = new AddEditUserForm();
            addeditfuserform.ShowDialog();
        }
        
        private void txtSearch_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
    }
}
