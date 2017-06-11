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
using Oracle.ManagedDataAccess.Types;

namespace RuleCheck
{
    public partial class RuleProcessing : Form
    {
        public int id;
        public string description;
        public string name;

        private List<int> operationIds;
        private List<KeyValuePair<string, string>> infoOperations;

        private List<KeyValuePair<int, bool>> changedOperations;

        public Action<RuleProcessing> onClose;

        public RuleProcessing()
        {
            InitializeComponent();
            this.operationIds = new List<int>();
            this.infoOperations = new List<KeyValuePair<string, string>>();
            this.changedOperations = new List<KeyValuePair<int, bool>>();
        }

        public static RuleProcessing Create(int id = -1)
        {
            var form = new RuleProcessing();
            form.id = id;
            form.LoadData();
            form.Show();
            return form;
        }

        private void LoadData()
        {
            if (this.id != -1)
            {
                string query = "select {0}.rule_name, {0}.rule_description from {0} " +
                    "where {0}.rule_id = :id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_rule), new OracleParameter[1]
                {
                    new OracleParameter("id", this.id)
                });
                if (result.values.Count > 0)
                {
                    this.name = result.values[0][0].ToString();
                    this.description = result.values[0][1].ToString();
                    this.nameText.Text = this.name;
                    this.descriptionText.Text = this.description;
                }
                query = "select {1}.operation_id, {1}.operation_name," +
                    " {1}.operation_description from {0}" + 
                    " inner join {1} on {0}.operation_id = {1}.operation_id" + 
                    " where {0}.rule_id = :id";
                result = QueryProvider.Execute(string.Format(query, Config.s_rule_operation, Config.s_operation), new OracleParameter[1]
                {
                    new OracleParameter("id", this.id)
                });
                for (int i = 0; i < result.values.Count; ++i)
                {
                    int opId = int.Parse(result.values[i][0].ToString());
                    this.operationIds.Add(opId);
                    this.infoOperations.Add(new KeyValuePair<string, string>(
                        result.values[i][1].ToString(), result.values[i][2].ToString()));
                    this.operations.Rows.Add(result.values[i][1], result.values[i][2]);
                }
            }
            this.SelectRow();
            this.RefreshButtons();
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
            if (this.onClose != null)
            {
                var m = this.onClose;
                this.onClose = null;
                m(this);
            }
        }

        private void OnClickApplyButton(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (string.IsNullOrEmpty(this.nameText.Text))
            {
                var form = MessageForm.Create("Необходимо указать имя правила.");
                form.FormClosing += (s, e1) =>
                {
                    this.Enabled = true;
                };
                return;
            }
            if (string.IsNullOrEmpty(this.descriptionText.Text))
            {
                var form = MessageForm.Create("Необходимо указать описание правила.");
                form.FormClosing += (s, e1) =>
                {
                    this.Enabled = true;
                };
                return;
            }
            if (this.operationIds.Count <= 0)
            {
                var form = MessageForm.Create("Добавьте хотя бы одну операцию.");
                form.FormClosing += (s, e1) =>
                {
                    this.Enabled = true;
                };
                return;
            }
            string query;
            if (this.id == -1)
            {
                query = "insert into {0}(rule_name, rule_description)" +
                    " values(:name, :description) returning {0}.rule_id into :id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_rule), new OracleParameter[3]
                {
                    new OracleParameter("name", this.nameText.Text),
                    new OracleParameter("description", this.descriptionText.Text),
                    new OracleParameter("id", OracleDbType.Decimal, ParameterDirection.Output),
                });
                this.id = ((OracleDecimal)result.parametersOut[0]).ToInt32();
            }
            else
            {
                query = "update {0} set {0}.rule_name = :name, {0}.rule_description = :description " +
                    "where {0}.rule_id = :id";
                QueryProvider.Execute(string.Format(query, Config.s_rule), new OracleParameter[3]
                {
                    new OracleParameter("name", this.nameText.Text),
                    new OracleParameter("description", this.descriptionText.Text),
                    new OracleParameter("id", this.id)
                });
            }
            this.description = this.descriptionText.Text;
            this.name = this.nameText.Text;
            for (int i = 0; i < this.changedOperations.Count; ++i)
            {
                var o = this.changedOperations[i];
                if (o.Value)
                {
                    query = "insert into {0}(rule_id, operation_id, orderby) " +
                    "values(:rule_id, :operation_id, :orderby)";
                    QueryProvider.Execute(string.Format(query, Config.s_rule_operation), new OracleParameter[3]
                    {
                        new OracleParameter("rule_id", this.id),
                        new OracleParameter("operation_id", o.Key),
                        new OracleParameter("orderby", i + 1)
                    });
                }
                else
                {
                    query = "delete from {0} where {0}.operation_id = :o_id and {0}.rule_id = :r_id";
                    QueryProvider.Execute(string.Format(query, Config.s_rule_operation), new OracleParameter[2]
                    {
                        new OracleParameter("o_id", o.Key),
                        new OracleParameter("r_id", this.id)
                    });
                }
                
            }
            this.Enabled = true;
            this.Close();
        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            this.Enabled = false;
            var form = new SelectOperation(this.operationIds);
            form.onClose = (f) =>
            {
                this.Enabled = true;
                if (f.selectedId != -1)
                {
                    this.operationIds.Add(f.selectedId);
                    var info = new KeyValuePair<string, string>(f.selectedName, f.selectedDescription);
                    this.infoOperations.Add(info);
                    this.operations.Rows.Add(info.Key, info.Value);
                    this.OnChangedOperations(f.selectedId, true);
                    this.SelectRow();
                    this.RefreshButtons();
                }
            };
            form.Show();
        }

        private void OnChangedOperations(int id, bool add)
        {
            for (int i = 0; i < this.changedOperations.Count; ++i)
            {
                var v = this.changedOperations[i];
                if (v.Key == id)
                {
                    if (v.Value != add)
                    {
                        this.changedOperations.RemoveAt(i);
                    }
                    return;
                }
            }
            this.changedOperations.Add(new KeyValuePair<int, bool>(id, add));
        }

        private void OnClickDeleteButton(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (this.operations.SelectedRows.Count != 1)
            {
                //this.Enabled = false;
                var form = MessageForm.Create("Выберите одну операцию!");
                form.FormClosing += (s, e1) =>
                {
                    this.Enabled = true;
                };
                return;
            }
            int num = this.operations.SelectedRows[0].Index;
            DecisionForm.Create(string.Format("Вы действительно хотите удалить операцию {0}\nиз списка", this.infoOperations[num].Key), (f) =>
            {
                if (f.result == DecisionResult.Yes)
                {
                    int id = this.operationIds[num];
                    this.operationIds.RemoveAt(num);
                    this.infoOperations.RemoveAt(num);
                    this.operations.Rows.RemoveAt(num);
                    this.OnChangedOperations(id, false);
                    this.SelectRow();
                    this.RefreshButtons();
                }
                this.Enabled = true;
            });
        }

        private void SelectRow()
        {
            if (this.operations.RowCount > 0)
            {
                this.operations.Rows[0].Selected = true;
            }
        }

        private void OnRowEnterOperations(object sender, DataGridViewCellEventArgs e)
        {
            this.RefreshButtons();
        }

        private void RefreshButtons()
        {
            this.deleteButton.Enabled = this.operations.SelectedRows.Count > 0;
        }
    }
}
