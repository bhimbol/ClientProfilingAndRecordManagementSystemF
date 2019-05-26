using System;
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
    public partial class ManageAXAForms : Form
    {
        public ManageAXAForms()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void ManageAXAForms_Load(object sender, EventArgs e)
        {
            comboBoxAXAForms.DisplayMember = "Name";
            comboBoxAXAForms.ValueMember = "FullName";
            listBoxAXAFiles.DisplayMember = "Name";
            listBoxAXAFiles.ValueMember = "FullName";
            
            var AllFiles = new DirectoryInfo(Application.StartupPath + "\\AXA FORMS").GetDirectories();
            comboBoxAXAForms.Items.Clear();
            foreach (var f in AllFiles)
            {
                comboBoxAXAForms.Items.Add(f);
            }
        }

        private void comboBoxAXAForms_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBoxAXAForms.Text != "")
            {
                var AllFiles = new DirectoryInfo(Application.StartupPath + "\\AXA FORMS\\" + comboBoxAXAForms.Text).GetFiles();
                listBoxAXAFiles.Items.Clear();
                foreach (var f in AllFiles)
                {
                    listBoxAXAFiles.Items.Add(f);
                }
            }
        }

        private void btnAddAXAForm_Click(object sender, EventArgs e)
        {
            var input = GetInputText("");
            if (input != "")
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\AXA FORMS\\" + input);
                    MessageBox.Show("New Category added successfully.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ManageAXAForms_Load(null, null);
                comboBoxAXAForms.Text = input;
            }
        }

        private String GetInputText(String settext)
        {
            ManageAXAForm_Subform form = new ManageAXAForm_Subform();
            form.input = settext;
            if (form.ShowDialog() == DialogResult.OK)
            {
                return form.input;
            }
            else
            {
                return "";
            }
        }

        private void btnEditAXAForm_Click(object sender, EventArgs e)
        {
            if (comboBoxAXAForms.Text != "" )
            {
                var input = GetInputText(comboBoxAXAForms.Text);
                if(input != "")
                {
                    System.IO.Directory.Move(Application.StartupPath + "\\AXA FORMS\\" + comboBoxAXAForms.Text, Application.StartupPath + "\\AXA FORMS\\" + input);
                    ManageAXAForms_Load(null, null);
                    comboBoxAXAForms.Text = input;
                    MessageBox.Show("Edit successfully.");
                }
            }
        }

        private void btnDeleteAXAForm_Click(object sender, EventArgs e)
        {
            if (comboBoxAXAForms.Text != "")
            {
                if(MessageBox.Show(null, "Are you sure? Delete " + comboBoxAXAForms.Text, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.IO.Directory.Delete(Application.StartupPath + "\\AXA FORMS\\" + comboBoxAXAForms.Text, true);
                    ManageAXAForms_Load(null, null);
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if(comboBoxAXAForms.Text != "")
            {
                OpenFileDialog opd = new OpenFileDialog();
                opd.Title = "Browse the form to be added.";
                opd.Filter = "All files (*.*)|*.*";
                opd.Multiselect = false;
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(opd.FileName, Application.StartupPath + "\\AXA FORMS\\" + comboBoxAXAForms.Text + "\\" + opd.SafeFileName);
                        MessageBox.Show("New AXA form added successfully.");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    comboBoxAXAForms_SelectedValueChanged(null, null);                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (comboBoxAXAForms.Text != "")
            {
                if(listBoxAXAFiles.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show(null, "Delete this " + listBoxAXAFiles.Text,"Delete",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            var dir = Application.StartupPath + "\\AXA FORMS\\" + comboBoxAXAForms.Text + "\\" + listBoxAXAFiles.SelectedItem.ToString();
                            File.Delete(dir);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        comboBoxAXAForms_SelectedValueChanged(null, null);
                    }
                }
            }
        }
    }
}
