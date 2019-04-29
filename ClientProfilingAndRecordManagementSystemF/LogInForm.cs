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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            using(axaDBEntities db = new axaDBEntities())
            {
                var user = db.Users.Where(u => u.username.Equals(txtusername.Text)).FirstOrDefault();
                if (user != null)
                {
                    if(user.password != txtpassword.Text)
                    {
                        status.Text = "Invalid Password.";
                    }
                    else
                    {
                        this.Close();
                        this.Dispose();
                        Properties.Settings.Default.current_user_fullname = user.fullname;
                        Properties.Settings.Default.current_user_username = user.username;
                        Properties.Settings.Default.current_user_role = user.role;
                        status.Text = "Welcome: " + user.fullname;
                    }
                }
                else
                {
                    status.Text = "No (" + txtusername.Text + ") user found";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            txtusername.TextAlign = HorizontalAlignment.Center;
            txtpassword.TextAlign = HorizontalAlignment.Center;
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
