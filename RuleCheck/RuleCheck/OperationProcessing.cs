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
        public OperationProcessing()
        {
            InitializeComponent();
            this.operations = new List<KeyValuePair<string, string>>();
            this.operationIds = new List<int>();
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
                    this.operationGrid.Rows.Add(name);
                    this.operations.Add(new KeyValuePair<string, string>(name, ""));
                    query = "select {0}.operation_id from {0} where {0}.operation_procedure = :operation";
                    table = QueryProvider.Execute(string.Format(query, Config.s_storage_operation), new OracleParameter[1]
                    {
                        new OracleParameter("operation", name),
                    });
                    int id;
                    this.operationIds.Add(table == null || table.values == null || 
                        table.values.Count == 0 || !int.TryParse(table.values[0][0].ToString(), out id) ?
                        -1 : id);
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
            for (int i = 0; i < this.operations.Count; ++i)
            {
                string name = this.operations[i].Key;
                if (name.StartsWith(value))
                {
                    this.operationGrid.Rows.Add(this.operations[i].Key);
                }
            }
        }

        private void OnEnterSearchTextBox(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
        }

        private void OnClickAddButton(object sender, EventArgs e)
        {
            if (this.operationGrid.SelectedRows.Count <= 0)
            {
                var form = MessageForm.Create("Необходимо выбрать операцию!");
                return;
            }
            if (this.operationGrid.SelectedRows.Count > 1)
            {
                var form = MessageForm.Create("Необходимо выбрать только одну операцию!");
                return;
            }
            string name = this.operationGrid.SelectedRows[0].Cells[0].Value.ToString();
            var o = InfoOperation.Create(name, TypeOperation.Add);
        }
    }
}
