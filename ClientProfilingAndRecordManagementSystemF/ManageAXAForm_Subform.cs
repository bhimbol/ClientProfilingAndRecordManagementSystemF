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
    public partial class ManageAXAForm_Subform : Form
    {
        public string input { get; set; }
        public ManageAXAForm_Subform()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            input = textBoxCategory.Text;
        }

        private void ManageAXAForm_Subform_Load(object sender, EventArgs e)
        {
            textBoxCategory.Text = input;
        }
    }
}
