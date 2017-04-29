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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            QueryProvider.OpenConnection();
        }


        private void onShownMainForm(object sender, EventArgs e)
        {
            if (QueryProvider.s_connection.State == ConnectionState.Open)
            {
                var form = MessageForm.Create("Не удалось подключиться к базе данных.\nПроверьте подключение к сети");
                form.FormClosing += (s, en) =>
                {
                    this.Close();
                };
            }
        }
    }
}
