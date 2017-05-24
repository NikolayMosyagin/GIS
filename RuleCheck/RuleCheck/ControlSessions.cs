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

        public void AddData(int sessionId, object date, string description)
        {
            this.operationIds.Add(sessionId);
            this.operations.Add(new KeyValuePair<string, string>(date.ToString(), description));
            this.UpdateTable();
        }

        protected override void LoadData()
        {
            string query = "select {0}.session_id, {0}.creation_date, {0}.session_description" +
                " from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_session), null);
            result.values.Sort((a, b) => { return ((decimal)a[0]).CompareTo((decimal)b[0]); });
            for (int i = 0; i < result.values.Count; ++i)
            {
                this.operationIds.Add(int.Parse(result.values[i][0].ToString()));
                this.operations.Add(new KeyValuePair<string, string>
                    (result.values[i][1].ToString(), result.values[i][2].ToString()));
                this.indices.Add(i);
                this.table.Rows.Add(result.values[i][1].ToString(), result.values[i][2].ToString());
            }
            base.LoadData();
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

        protected override void OnDelete()
        {
            int num = this.table.SelectedRows[0].Index;
            string query = "delete from {0} where {0}.session_id = :session_id";
            QueryProvider.Execute(string.Format(query, Config.s_session), new OracleParameter[1]
            {
                new OracleParameter("session_id", this.operationIds[this.indices[num]]),
            });
            this.operationIds.RemoveAt(this.indices[num]);
            this.table.Rows.RemoveAt(num);
            this.operations.RemoveAt(this.indices[num]);
            this.UpdateTable();
            if (this.table.RowCount > 0)
            {
                this.table.Rows[0].Selected = true;
            }
            this.RefreshButtons();
        }

        protected override void OnAdd()
        {
            int num = this.table.SelectedRows[0].Index;
            var t = this.operations[this.indices[num]];
            var form = InfoSession.Create(this.operationIds[this.indices[num]], t.Key, t.Value);
        }

        protected override void OnUpdate()
        {
            int num = this.table.SelectedRows[0].Index;
            var form = new CacheAttribute(this.operationIds[this.indices[num]]);
            form.Show();
        }

        public override string addButtonText
        {
            get
            {
                return "Просмотр";
            }
        }

        public override string updateButtonText
        {
            get
            {
                return "Атрибуты";
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
