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
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void OnClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickEnterButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.userTextBox.Text))
            {
                var form = MessageForm.Create("Введите пользователя");
                return;
            }
            if (string.IsNullOrEmpty(this.passwordTextBox.Text))
            {
                var form = MessageForm.Create("Введите пароль");
                return;
            }
            QueryProvider.s_cns = string.Format(Config.s_connectionString, this.userTextBox.Text, this.passwordTextBox.Text);
            QueryProvider.OpenConnection();
            if (QueryProvider.s_connection.State != ConnectionState.Open)
            {
                var form = MessageForm.Create("Не удалось подключиться к базе данных.\nПроверьте подключение к сети");
                return;
            }
            this.Hide();
            var mainForm = new MainForm();
            mainForm.Show();
            mainForm.FormClosing += (s, v) =>
            {
                this.Close();
            };
        }

        private void OnClickUserTextBox(object sender, EventArgs e)
        {
            this.userTextBox.Text = "";
        }

        private void OnClickPasswordTextBox(object sender, EventArgs e)
        {
            this.passwordTextBox.Text = "";
            this.passwordTextBox.UseSystemPasswordChar = true;
        }
    }
}
