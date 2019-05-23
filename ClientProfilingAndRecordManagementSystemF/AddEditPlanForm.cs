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
    public partial class AddEditPlanForm : Form
    {
        public AddEditPlanForm()
        {
            InitializeComponent();
        }

        private void AddEditPlanForm_Load(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                var categories = (from c in db.Plans select c.category).Distinct().ToList();
                var types = (from c in db.Plans select c.type).Distinct().ToList();
                foreach(var c in categories)
                {
                    comboBoxPlanCategory.Items.Add(c);
                }
                foreach (var t in types)
                {
                    comboBoxPlanType.Items.Add(t);
                }
                DataGridViewPlans.DataSource = db.Plans.ToList();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void DataGridViewPlans_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridViewPlans.Columns["ClientPlans"].Visible = false;
            DataGridViewPlans.Columns["plan_id"].HeaderText = "Plan ID";
            DataGridViewPlans.Columns["type"].HeaderText = "Plan Type";
            DataGridViewPlans.Columns["category"].HeaderText = "Plan Category";
            DataGridViewPlans.Columns["description"].HeaderText = "Description";
        }

        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            using (axaDBEntities db = new axaDBEntities())
            {
                Plan plan = new Plan();
                plan.type = comboBoxPlanType.Text;
                plan.category = comboBoxPlanCategory.Text;
                plan.description = textBoxPlanDescription.Text;
                db.Plans.Add(plan);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("New Plan added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                AddEditPlanForm_Load(null, null);
            }
        }

        private void DataGridViewPlans_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewPlans.Enabled = false;
            btnUpdatePlan.Enabled = true;
            btnCancelUpdate.Enabled = true;
            Remove.Enabled = false;
            textBoxPlanDescription.Text = DataGridViewPlans.SelectedRows[0].Cells["description"].Value.ToString();
            comboBoxPlanCategory.Text = DataGridViewPlans.SelectedRows[0].Cells["category"].Value.ToString();
            comboBoxPlanType.Text = DataGridViewPlans.SelectedRows[0].Cells["type"].Value.ToString();
            textBoxPlanDescription.Focus();
            textBoxPlanDescription.SelectAll();
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewPlans.Enabled = true;
            btnUpdatePlan.Enabled = false;
            btnCancelUpdate.Enabled = false;
            Remove.Enabled = true;
        }

        private void btnUpdatePlan_Click(object sender, EventArgs e)
        {
            if (DataGridViewPlans.SelectedRows.Count > 0)
            {
                using (axaDBEntities db = new axaDBEntities())
                {
                    Plan plan = db.Plans.Find(int.Parse(DataGridViewPlans.SelectedRows[0].Cells["plan_id"].Value.ToString()));
                    plan.type = comboBoxPlanType.Text;
                    plan.category = comboBoxPlanCategory.Text;
                    plan.description = textBoxPlanDescription.Text;
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Plan updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    btnUpdatePlan.Enabled = false;
                    btnCancelUpdate.Enabled = false;
                    DataGridViewPlans.Enabled = true;
                    Remove.Enabled = true;
                    AddEditPlanForm_Load(null, null);
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(null,"Are you sure you want to delete this item?","Delete",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (DataGridViewPlans.SelectedRows.Count > 0)
                {
                    using (axaDBEntities db = new axaDBEntities())
                    {
                        Plan plan = db.Plans.Find(int.Parse(DataGridViewPlans.SelectedRows[0].Cells["plan_id"].Value.ToString()));
                        try
                        {
                            db.Plans.Remove(plan);
                            db.SaveChanges();
                            MessageBox.Show("Plan deleted successfully.");
                        }
                        catch (Exception ex)
                        {
                            if(ex.InnerException != null)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message);
                            }
                            else
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        AddEditPlanForm_Load(null, null);
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
                    DataGridViewPlans.DataSource = db.Plans.Where(p => p.type.Contains(txtSearch.Text) ||
                                                                                 p.category.Contains(txtSearch.Text) ||
                                                                                 p.description.Contains(txtSearch.Text)).ToList();
                }
            }
        }
    }
}
