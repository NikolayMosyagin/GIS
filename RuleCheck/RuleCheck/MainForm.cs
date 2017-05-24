using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuleCheck
{
    public enum Role
    {
        Admin = 0,
        User = 1,
    }

    public partial class MainForm : Form
    {
        public static Role currentRole;

        public MainForm()
        {
            InitializeComponent();
            this.adminButton.Enabled = MainForm.currentRole == Role.Admin;
        }

        private void OnClickAdminButton(object sender, EventArgs e)
        {
            this.Enabled = false;
            var form = new AdministrationForm();
            form.Show();
            form.FormClosing += (s, e1) =>
            {
                this.Enabled = true;
            };
        }
    }
}
