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
    public partial class AdministrationForm : Form
    {
        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void OnClickOperationButton(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ConstructorOperation();
            form.FormClosing += (s, e1) =>
            {
                this.Show();//this.Enabled = true;
            };
            form.Show();
        }

        private void OnClickRuleButton(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ConstructorRule();
            form.FormClosing += (s, e1) =>
            {
                this.Show();
            };
            form.Show();
        }
    }
}
