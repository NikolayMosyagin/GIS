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
    public partial class AnalysisForm : Form
    {
        public AnalysisForm()
        {
            InitializeComponent();
        }

        private void OnClickAnalsysButton(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Analysis();
            form.FormClosing += (s, e1) =>
            {
                this.Show();
            };
            form.Show();
        }

        private void OnClickSessionButton(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ControlSessions();
            form.FormClosing += (s, e1) =>
            {
                this.Show();
            };
            form.Show();
        }
    }
}
