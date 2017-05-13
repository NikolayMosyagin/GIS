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
    public partial class ConstructorOperation : ConstructorBase
    {
        protected override void LoadData()
        {
            var query = "select {0}.object_id, {0}.object_name from {0} " +
                "where {0}.object_type = 'FUNCTION'";
            var result = QueryProvider.Execute(string.Format(query, Config.s_user_procedures), null);
            for (int i = 0; i < result.values.Count; ++i)
            {
                int objectId = int.Parse(result.values[i][0].ToString());
                query = "select count(*) from {0} where {0}.object_id = :object_id " +
                    "and {0}.in_out = 'IN' and {0}.data_type = 'NUMBER'";
                var table = QueryProvider.Execute(string.Format(query, Config.s_user_arguments), new OracleParameter[1]
                {
                    new OracleParameter("object_id", objectId)
                });
                if (table == null || table.values == null ||
                    int.Parse(table.values[0][0].ToString()) != 2)
                {
                    continue;
                }
                query = "select count(*) from {0} where {0}.object_id = :object_id " +
                    "and {0}.in_out = 'OUT' and {0}.data_type = 'NUMBER'";
                table = QueryProvider.Execute(string.Format(query, Config.s_user_arguments), new OracleParameter[1]
                {
                    new OracleParameter("object_id", objectId)
                });
                if (table == null || table.values == null ||
                    int.Parse(table.values[0][0].ToString()) != 1)
                {
                    continue;
                }
                string name = result.values[i][1].ToString();
                this.indices.Add(this.operations.Count);

                query = "select {0}.operation_id, {0}.operation_description from {0} where {0}.operation_procedure = :operation";
                table = QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[1]
                {
                    new OracleParameter("operation", name),
                });
                this.operationIds.Add(table.values.Count == 0 ? -1 : int.Parse(table.values[0][0].ToString()));
                string description = table.values.Count == 0 ? "" : table.values[0][1].ToString();
                this.table.Rows.Add(name, description);
                this.operations.Add(new KeyValuePair<string, string>(name, description));
            }
            base.LoadData();
        }

        protected override bool RefreshButtons()
        {
            if (base.RefreshButtons())
            {
                return true;
            }
            int index = this.table.SelectedRows[0].Index;
            bool result = this.operationIds[this.indices[index]] <= 0;
            this.addButton.Enabled = result;
            this.updateButton.Enabled = !result;
            this.deleteButton.Enabled = !result;
            return true;
        }

        protected override void OnAdd()
        {
            if (!this.CheckSelectRow())
            {
                return;
            }
            int num = this.table.SelectedRows[0].Index;
            var o = InfoOperation.Create(this.operations[indices[num]].Key, TypeOperation.Add);
            o.onClose = (f) =>
            {
                this.operationIds[this.indices[num]] = f.id;
                var value = this.operations[this.indices[num]];
                this.operations[this.indices[num]] = new KeyValuePair<string, string>(value.Key, f.description);
                this.table.Rows[num].SetValues(value.Key, f.description);
                this.RefreshButtons();
            };
        }

        protected override void OnUpdate()
        {
            int num = this.table.SelectedRows[0].Index;
            var form = InfoOperation.Create(this.operations[this.indices[num]].Key, TypeOperation.Change, this.operationIds[this.indices[num]]);
            form.onClose = (f) =>
            {
                var value = this.operations[this.indices[num]];
                this.table.Rows[num].SetValues(value.Key, f.description);
                this.operations[this.indices[num]] = new KeyValuePair<string, string>(value.Key, f.description);
            };
        }

        protected override void OnDelete()
        {
            int num = this.table.SelectedRows[0].Index;
            int id = this.operationIds[this.indices[num]];
            this.operationIds[this.indices[num]] = -1;
            this.operations[this.indices[num]] = new KeyValuePair<string, string>(
                this.operations[this.indices[num]].Key,
                "");
            this.table.Rows[num].SetValues(this.operations[this.indices[num]].Key, "");
            string query = "delete from {0} where {0}.operation_id = :operation_id";
            QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[1]
            {
                new OracleParameter("operation_id", id),
            });
            this.RefreshButtons();
            var form = MessageForm.Create("Операция успешно удалена!");
        }
    }
}
