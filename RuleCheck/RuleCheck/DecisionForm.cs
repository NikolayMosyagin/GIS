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
    public enum DecisionResult
    {
        Unknown = 0,
        No = 1,
        Yes = 2,
    }
    public partial class DecisionForm : Form
    {
        public DecisionResult result;
        private Action<DecisionForm> _onResult;

        public DecisionForm()
        {
            InitializeComponent();
            this.result = DecisionResult.Unknown;
        }

        public static DecisionForm Create(string text, Action<DecisionForm> action)
        {
            var form = new DecisionForm();
            form.text.Text = text;
            form._onResult = action;
            form.Show();
            return form;
        }

        private void text_SizeChanged(object sender, EventArgs e)
        {
            this.text.Location = new Point(
                this.ClientSize.Width / 2 - this.text.ClientSize.Width / 2,
                this.ClientSize.Height / 2 - this.text.ClientSize.Height / 2 - 20);
        }

        private void DecisionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var action = this._onResult;
            this._onResult = null;
            if (action != null)
            {
                action(this);
            }
        }

        private void OnClickYesButton(object sender, EventArgs e)
        {
            this.result = DecisionResult.Yes;
            var action = this._onResult;
            this._onResult = null;
            if (action != null)
            {
                action(this);
            }
            this.Close();
        }

        private void OnClickNoButton(object sender, EventArgs e)
        {
            this.result = DecisionResult.No;
            var action = this._onResult;
            this._onResult = null;
            if (action != null)
            {
                action(this);
            }
            this.Close();
        }
    }
}
