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
            base.LoadData();
            var query = "select {0}.object_id, {0}.object_name, {1}.in_out from {0} " +
                "inner join {1} on {0}.object_id = {1}.object_id" + this.ConditionalSelectToLoadData() +
            " and {0}.object_type = 'FUNCTION' and {1}.data_type = 'NUMBER' " +
                "order by {0}.object_id";

            var result = QueryProvider.Execute(string.Format(query, Config.s_user_procedures, Config.s_user_arguments), this.parameters.ToArray());
            if (result.values.Count == 0)
            {
                return;
            }
            int id = int.Parse(result.values[0][0].ToString());
            int countIn = result.values[0][2].ToString() == "IN" ? 1 : 0;
            int countOut = result.values[0][2].ToString() == "OUT" ? 1 : 0;
            List<string> nameOperations = new List<string>();

            for (int i = 1; i < result.values.Count; ++i)
            {
                int curId = int.Parse(result.values[i][0].ToString());
                if (curId == id)
                {
                    countIn += result.values[i][2].ToString() == "IN" ? 1 : 0;
                    countOut += result.values[i][2].ToString() == "OUT" ? 1 : 0;
                }
                else
                {
                    if (countIn == 2 && countOut == 1)
                    {
                        nameOperations.Add(result.values[i - 1][1].ToString());
                    }
                    id = curId;
                    countIn = result.values[i][2].ToString() == "IN" ? 1 : 0;
                    countOut = result.values[i][2].ToString() == "OUT" ? 1 : 0;
                }
            }
            if (countIn == 2 && countOut == 1)
            {
                nameOperations.Add(result.values[result.values.Count - 1][1].ToString());
            }
            query = "select {0}.operation_id, {0}.operation_description from {0} " +
                "where {0}.operation_procedure = :operation";
            for (int i = 0; i < nameOperations.Count; ++i)
            {
                result = QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[1]
                {
                    new OracleParameter("operation", nameOperations[i]),
                });
                this.ids.Add(result.values.Count > 0 ? int.Parse(result.values[0][0].ToString()) : -1);
                string description = result.values.Count > 0 ? result.values[0][1].ToString() : "";
                this.data.Add(new KeyValuePair<string, string>(nameOperations[i], description));
                this.table.Rows.Add(nameOperations[i], description);
            }
        }

        public override string searchName
        {
            get
            {
                return "object_name";
            }
        }

        protected override bool RefreshButtons()
        {
            if (base.RefreshButtons())
            {
                return true;
            }
            int index = this.table.SelectedRows[0].Index;
            bool result = this.ids[index] < 0;
            this.addButton.Enabled = result;
            this.updateButton.Enabled = !result;
            this.deleteButton.Enabled = !result;
            return true;
        }

        public override string TextForm
        {
            get
            {
                return "Конструктор операций";
            }
        }

        public override string onDeleteText
        {
            get
            {
                return this.table.SelectedRows.Count == 0 ? "операцию" 
                        : "операцию " + this.data[this.table.SelectedRows[0].Index].Key;
            }
        }

        protected override void OnAdd()
        {
            if (this.table.SelectedRows.Count == 0)
            {
                return;
            }
            this.Enabled = false;
            int num = this.table.SelectedRows[0].Index;
            var o = InfoOperation.Create(this.data[num].Key, TypeOperation.Add);
            o.onClose = (f) =>
            {
                this.Enabled = true;
                if (f.id != -1)
                {
                    this.ids[num] = f.id;
                    var value = this.data[num];
                    this.data[num] = new KeyValuePair<string, string>(value.Key, f.description);
                    this.table.Rows[num].SetValues(value.Key, f.description);
                    this.SelectedRow();
                    this.RefreshButtons();
                }
            };
        }

        protected override void OnUpdate()
        {
            this.Enabled = false;
            int num = this.table.SelectedRows[0].Index;
            var form = InfoOperation.Create(this.data[num].Key, TypeOperation.Change, this.ids[num]);
            form.onClose = (f) =>
            {
                this.Enabled = true;
                var value = this.data[num];
                this.table.Rows[num].SetValues(value.Key, f.description);
                this.data[num] = new KeyValuePair<string, string>(value.Key, f.description);
                this.SelectedRow();
                this.RefreshButtons();
            };
        }

        protected override void OnDelete()
        {
            this.Enabled = false;
            int num = this.table.SelectedRows[0].Index;
            if (this.ids[num] == -1)
            {
                return;
            }
            int id = this.ids[num];
            this.ids[num] = -1;
            this.data[num] = new KeyValuePair<string, string>(this.data[num].Key, "");
            this.table.Rows[num].SetValues(this.data[num].Key, "");
            string query = "delete from {0} where {0}.operation_id = :operation_id";
            QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[1]
            {
                new OracleParameter("operation_id", id),
            });
            this.RefreshButtons();
            var form = MessageForm.Create("Операция успешно удалена!");
            form.FormClosing += (s, e1) =>
            {
                this.Enabled = true;
            };
        }
    }
}
