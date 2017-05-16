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
    public partial class ConstructorRule : ConstructorBase
    {
        protected override void LoadData()
        {
            string query = "select {0}.rule_id, {0}.rule_name, {0}.rule_description" +
                " from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_rule), null);
            for (int i = 0; i < result.values.Count; ++i)
            {
                this.operations.Add(new KeyValuePair<string, string>(result.values[i][1].ToString(), result.values[i][2].ToString()));
                this.operationIds.Add(int.Parse(result.values[i][0].ToString()));
                this.table.Rows.Add(result.values[i][1], result.values[i][2]);
                this.indices.Add(i);
            }
            base.LoadData();
        }

        protected override bool RefreshButtons()
        {
            var result = base.RefreshButtons();
            this.addButton.Enabled = true;
            if (!result)
            {
                this.deleteButton.Enabled = true;
                this.updateButton.Enabled = true;
            }
            return true;
        }

        public override string TextForm
        {
            get
            {
                return "Конструктор правил";
            }
        }

        protected override void OnAdd()
        {
            var form = RuleProcessing.Create();
            form.onClose = (f) =>
            {
                if (f.id != -1)
                {
                    this.operationIds.Add(f.id);
                    this.operations.Add(new KeyValuePair<string, string>(f.name, f.description));
                    this.UpdateTable();
                }
            };
        }

        protected override void OnDelete()
        {
            int num = this.table.SelectedRows[0].Index;
            int id = this.operationIds[this.indices[num]];
            this.operationIds.RemoveAt(this.indices[num]);
            this.operations.RemoveAt(this.indices[num]);
            this.UpdateTable();
            string query = "delete from {0} where {0}.rule_id = :id";
            QueryProvider.Execute(string.Format(query, Config.s_rule_operation), new OracleParameter[1]
            {
                new OracleParameter("id", id),
            });
            QueryProvider.Execute(string.Format(query, Config.s_rule), new OracleParameter[1]
            {
                new OracleParameter("id", id),
            });
        }

        protected override void OnUpdate()
        {
            int num = this.table.SelectedRows[0].Index;
            var form = RuleProcessing.Create(this.operationIds[this.indices[num]]);
            form.onClose = (f) =>
            {
                this.operations[this.indices[num]] = new KeyValuePair<string, string>(f.name, f.description);
                this.UpdateTable();
            };
        }
    }
}
