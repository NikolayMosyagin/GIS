using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace RuleCheck
{
    public partial class ConnectionForm : Form
    {
        private bool _enterUserTextBox;
        private bool _enterPasswordTextBox;
        private bool _enterServiceTextBox;

        public ConnectionForm()
        {
            InitializeComponent();
            this._enterPasswordTextBox = false;
            this._enterServiceTextBox = false;
            this._enterUserTextBox = false;
            this.ReadXmlFile();
        }

        private void OnClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickEnterButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.userTextBox.Text) || !this._enterUserTextBox)
            {
                var form = MessageForm.Create("Введите пользователя");
                return;
            }
            if (string.IsNullOrEmpty(this.passwordTextBox.Text) || !this._enterPasswordTextBox)
            {
                var form = MessageForm.Create("Введите пароль");
                return;
            }
            if (string.IsNullOrEmpty(this.serviceTextBox.Text) || !this._enterServiceTextBox)
            {
                var form = MessageForm.Create("Введите сервер");
                return;
            }
            QueryProvider.s_cns = string.Format(Config.s_connectionString, this.serviceTextBox.Text, this.userTextBox.Text, this.passwordTextBox.Text);
            QueryProvider.OpenConnection();
            if (QueryProvider.s_connection.State != ConnectionState.Open)
            {
                string value = "";
                if (QueryProvider.s_ErrorNumber == -1 || !Config.s_messageException.TryGetValue(QueryProvider.s_ErrorNumber, out value))
                {
                    value = "Не удалось подключиться к базе данных.\nПроверьте подключение к сети";
                }
                var form = MessageForm.Create(value);
                QueryProvider.CloseConnection();
                return;
            }
            this.WriteXmlFile();
            string query = "select {0}.granted_role from {0}" +
                " where {0}.granted_role = :first or {0}.granted_role = :second";
            var result = QueryProvider.Execute(string.Format(query, Config.s_user_role_privs), new OracleParameter[2]
            {
                new OracleParameter("first", Config.role_admins),
                new OracleParameter("second", Config.role_users)
            });
            if (result.values.Count == 0)
            {
                var form = MessageForm.Create("Недостаточно прав");
                QueryProvider.CloseConnection();
                return;
            }
            MainForm.currentRole = Role.User;
            for (int i = 0; i < result.values.Count; ++i)
            {
                if (result.values[i][0].ToString() == Config.role_admins)
                {
                    MainForm.currentRole = Role.Admin;
                }
            }
            this.Hide();
            var mainForm = new MainForm();
            mainForm.Show();
            mainForm.FormClosing += (s, v) =>
            {
                this.Close();
                QueryProvider.CloseConnection();
            };
        }

        private void OnEnterPasswordTextBox(object sender, EventArgs e)
        {
            this._enterPasswordTextBox = true;
            this.passwordTextBox.Text = "";
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Enter -= this.OnEnterPasswordTextBox;
        }

        private void OnEnterUserTextBox(object sender, EventArgs e)
        {
            this.SetUserTextBox("");
        }

        private void OnEnterServerTextBox(object sender, EventArgs e)
        {
            this.SetServiceTextBox("");
        }

        private void SetUserTextBox(string text)
        {
            this._enterUserTextBox = true;
            this.userTextBox.Text = text;
            this.userTextBox.Enter -= this.OnEnterUserTextBox;
        }

        private void SetServiceTextBox(string text)
        {
            this._enterServiceTextBox = true;
            this.serviceTextBox.Text = text;
            this.serviceTextBox.Enter -= this.OnEnterServerTextBox;
        }

        private void WriteXmlFile()
        {
            var doc = new XmlDocument();
            var user = doc.CreateElement("user");
            var nameElem = doc.CreateElement("name");
            nameElem.AppendChild(doc.CreateTextNode(this.userTextBox.Text));
            var serviceElem = doc.CreateElement("service");
            serviceElem.AppendChild(doc.CreateTextNode(this.serviceTextBox.Text));
            user.AppendChild(nameElem);
            user.AppendChild(serviceElem);
            doc.AppendChild(user);
            if (!Directory.Exists(Config.PathDirectorySave))
            {
                Directory.CreateDirectory(Config.PathDirectorySave);
            }
            doc.Save(Config.PathSave);
        }

        private void ReadXmlFile()
        {
            var doc = new XmlDocument();
            var path = Config.PathSave;
            if (!File.Exists(path))
            {
                return;
            }
            doc.Load(path);
            var root = doc.DocumentElement;
            foreach (XmlNode node in root)
            {
                if (node.Name == "name" && node.FirstChild != null && node.FirstChild.NodeType == XmlNodeType.Text)
                {
                    this.SetUserTextBox(node.FirstChild.Value);
                }
                else if (node.Name == "service" && node.FirstChild != null && node.FirstChild.NodeType == XmlNodeType.Text)
                {
                    this.SetServiceTextBox(node.FirstChild.Value);
                }
            }
        }

    }
}
