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

namespace RuleCheck
{
    public partial class ControlSessions : ConstructorBase
    {
        public static ControlSessions current { get; set; }

        public ControlSessions() : base()
        {
            this.searchTextBox.Text = "";
            this.searchTextBox.Hide();
            this.searchTextBox.Enabled = false;
        }

        public void AddData(int sessionId, object date, string description)
        {
            this.ids.Add(sessionId);
            this.data.Add(new KeyValuePair<string, string>(date.ToString(), description));
            this.UpdateTable();
        }

        protected override void LoadData()
        {
            base.LoadData();
            string query = "select {0}.session_id, {0}.creation_date, {0}.session_description" +
                " from {0}"  + this.ConditionalSelectToLoadData();
            query = query + " and {0}.creation_date >= :date1 and {0}.creation_date <= :date2";
            this.parameters.Add(new OracleParameter("date1", this.dateTimeFrom.Value.Date));
            this.parameters.Add(new OracleParameter("date2", this.dateTimeTo.Value.Date));

            var result = QueryProvider.Execute(string.Format(query, Config.s_session), this.parameters.ToArray());
            result.values.Sort((a, b) => { return ((decimal)a[0]).CompareTo((decimal)b[0]); });
            for (int i = 0; i < result.values.Count; ++i)
            {
                this.ids.Add(int.Parse(result.values[i][0].ToString()));
                this.data.Add(new KeyValuePair<string, string>
                    (result.values[i][1].ToString(), result.values[i][2].ToString()));
                this.table.Rows.Add(result.values[i][1].ToString(), result.values[i][2].ToString());
            }
        }

        protected override bool RefreshButtons()
        {
            if (base.RefreshButtons())
            {
                return true;
            }
            this.deleteButton.Enabled = true;
            this.addButton.Enabled = true;
            this.updateButton.Enabled = true;
            return true;
        }

        public override string onDeleteText
        {
            get
            {
                return this.table.SelectedRows.Count == 0 
                    ? "сессию"
                    : "сессию за\n" + this.data[this.table.SelectedRows[0].Index].Key;
            }
        }

        protected override void OnDelete()
        {
            int num = this.table.SelectedRows[0].Index;
            int id = this.ids[num];
            this.ids.RemoveAt(num);
            this.table.Rows.RemoveAt(num);
            this.data.RemoveAt(num);
            string query = "delete from {0} where {0}.session_id = :session_id";
            QueryProvider.Execute(string.Format(query, Config.s_session), new OracleParameter[1]
            {
                new OracleParameter("session_id", id),
            });

            this.SelectedRow();
            this.RefreshButtons();
            this.Enabled = true;
        }

        protected override void OnAdd()
        {
            this.Enabled = false;
            int num = this.table.SelectedRows[0].Index;
            var t = this.data[num];
            var form = InfoSession.Create(this.ids[num], t.Key, t.Value);
            form.FormClosing += (s, e) =>
            {
                this.Enabled = true;
            };
        }

        protected override void OnUpdate()
        {
            this.Enabled = false;
            int num = this.table.SelectedRows[0].Index;
            var form = new CacheAttribute(this.ids[num]);
            form.FormClosing += (s, e) =>
            {
                this.Enabled = true;
            };

            form.Show();
        }

        public override string addButtonText
        {
            get
            {
                return "Просмотр результатов";
            }
        }

        public override string updateButtonText
        {
            get
            {
                return "Выполнить анализ";
            }
        }

        public override string TextForm
        {
            get
            {
                return "Сессии";
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            ControlSessions.current = null;
        }

    }
}
