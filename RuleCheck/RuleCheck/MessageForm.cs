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
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        public static MessageForm Create(string text)
        {
            var form = new MessageForm();
            form.text.Text = text;
            form.Show();
            return form;
        }

        private void onExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void text_SizeChanged(object sender, EventArgs e)
        {
            this.text.Location = new Point(
               this.ClientSize.Width / 2 - this.text.ClientSize.Width / 2,
               this.ClientSize.Height / 2 - this.text.ClientSize.Height / 2 - 15);
        }
    }
}
