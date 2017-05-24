﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace RuleCheck
{
    public partial class ConnectionForm : Form
    {
        private bool _enterUserTextBox;
        private bool _enterPasswordTextBox;
        private bool _enterServerTextBox;

        public ConnectionForm()
        {
            InitializeComponent();
            this._enterPasswordTextBox = false;
            this._enterServerTextBox = false;
            this._enterUserTextBox = false;
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
            if (string.IsNullOrEmpty(this.serverTextBox.Text) || !this._enterServerTextBox)
            {
                var form = MessageForm.Create("Введите сервер");
                return;
            }
            QueryProvider.s_cns = string.Format(Config.s_connectionString, this.serverTextBox.Text, this.userTextBox.Text, this.passwordTextBox.Text);
            QueryProvider.OpenConnection();
            if (QueryProvider.s_connection.State != ConnectionState.Open)
            {
                var form = MessageForm.Create("Не удалось подключиться к базе данных.\nПроверьте подключение к сети");
                return;
            }
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
            this._enterUserTextBox = true;
            this.userTextBox.Text = "";
            this.userTextBox.Enter -= this.OnEnterUserTextBox;
        }

        private void OnEnterServerTextBox(object sender, EventArgs e)
        {
            this._enterServerTextBox = true;
            this.serverTextBox.Text = "";
            this.serverTextBox.Enter -= this.OnEnterServerTextBox;
        }
    }
}
