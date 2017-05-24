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
            var form = new ConstructorOperation();
            form.Show();
        }

        private void OnClickRuleButton(object sender, EventArgs e)
        {
            var form = new ConstructorRule();
            form.Show();
        }
    }
}
