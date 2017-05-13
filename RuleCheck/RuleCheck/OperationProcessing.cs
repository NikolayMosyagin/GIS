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
    public partial class OperationProcessing : Form
    {
        public List<KeyValuePair<string, string>> operations;
        public List<int> operationIds;
        public List<int> indices;
        public OperationProcessing()
        {
            InitializeComponent();
            this.operations = new List<KeyValuePair<string, string>>();
            this.operationIds = new List<int>();
            this.indices = new List<int>();
            this.LoadAllFunction();
        }

        private void LoadAllFunction()
        {
            var query = "select {0}.object_id, {0}.object_name from {0} " +
                "where {0}.object_type = 'FUNCTION'";
            var result = QueryProvider.Execute(string.Format(query, Config.s_user_procedures), null);
            if (result != null && result.values != null)
            {
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
                    this.operationGrid.Rows.Add(name, description);
                    this.operations.Add(new KeyValuePair<string, string>(name, description));
                }
                if (this.indices.Count > 0)
                {
                    this.operationGrid.Rows[0].Selected = true;
                }
            }
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnChangeTextSearchTextBox(object sender, EventArgs e)
        {
            string value = this.searchTextBox.Text;
            this.operationGrid.Rows.Clear();
            this.indices.Clear();
            for (int i = 0; i < this.operations.Count; ++i)
            {
                var pr = this.operations[i];
                if (pr.Key.StartsWith(value))
                {
                    this.operationGrid.Rows.Add(pr.Key, pr.Value);
                    this.indices.Add(i);
                }
            }
        }

        private void OnEnterSearchTextBox(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
        }

        private bool CheckSelectOperation()
        {
            if (this.operationGrid.SelectedRows.Count <= 0)
            {
                var form = MessageForm.Create("Необходимо выбрать операцию!");
                return false;
            }
            if (this.operationGrid.SelectedRows.Count > 1)
            {
                var form = MessageForm.Create("Необходимо выбрать только одну операцию!");
                return false;
            }
            int num = this.operationGrid.SelectedRows[0].Index;
            if (num >= this.indices.Count)
            {
                var form = MessageForm.Create("В данной строке нет операции!");
                return false;
            }
            return true;
        }

        private void OnClickAddButton(object sender, EventArgs e)
        {
            if (!CheckSelectOperation())
            {
                return;
            }
            int num = this.operationGrid.SelectedRows[0].Index;
            var o = InfoOperation.Create(this.operations[indices[num]].Key, TypeOperation.Add);
            o.onClose = (f) =>
            {
                this.operationIds[this.indices[num]] = f.id;
                var value = this.operations[this.indices[num]];
                this.operations[this.indices[num]] = new KeyValuePair<string, string>(value.Key, f.description);
                this.operationGrid.Rows[num].SetValues(value.Key, f.description);
                this.RefreshButtons();
            };
        }

        private void RefreshButtons()
        {
            int index;
            if (this.operationGrid.SelectedRows.Count <= 0 ||
                this.operationGrid.SelectedRows.Count > 1 ||
                (index = this.operationGrid.SelectedRows[0].Index) >= this.indices.Count)
            {
                this.addButton.Enabled = false;
                this.updateButton.Enabled = false;
                this.deleteButton.Enabled = false;
                return;
            }
            bool result = this.operationIds[this.indices[index]] <= 0;
            this.addButton.Enabled = result;
            this.updateButton.Enabled = !result;
            this.deleteButton.Enabled = !result;
        }

        private void OnRowEnterOperationGrid(object sender, DataGridViewCellEventArgs e)
        {
            this.RefreshButtons();
        }

        private void OnClickDeleteButton(object sender, EventArgs e)
        {
            if (!CheckSelectOperation())
            {
                return;
            }
            int num = this.operationGrid.SelectedRows[0].Index;
            if (this.operationIds[this.indices[num]] == -1)
            {
                return;
            }
            int id = this.operationIds[this.indices[num]];
            this.operationIds[this.indices[num]] = -1;
            this.operations[this.indices[num]] = new KeyValuePair<string, string>(
                this.operations[this.indices[num]].Key,
                "");
            this.operationGrid.Rows[num].SetValues(this.operations[this.indices[num]].Key, "");
            string query = "delete from {0} where {0}.operation_id = :operation_id";
            QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[1]
            {
                new OracleParameter("operation_id", id),
            });
            this.RefreshButtons();
            var form = MessageForm.Create("Операция успешно удалена!");
        }

        private void OnClickUpdateButton(object sender, EventArgs e)
        {
            if (!CheckSelectOperation())
            {
                return;
            }
            int num = this.operationGrid.SelectedRows[0].Index;
            var form = InfoOperation.Create(this.operations[this.indices[num]].Key, TypeOperation.Change, this.operationIds[this.indices[num]]);
            form.onClose = (f) =>
            {
                var value = this.operations[this.indices[num]];
                this.operationGrid.Rows[num].SetValues(value.Key, f.description);
                this.operations[this.indices[num]] = new KeyValuePair<string, string>(value.Key, f.description);
            };
        }
    }
}
