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
    public partial class Analysis : Form
    {
        private List<int> _ruleIds;
        public Analysis()
        {
            InitializeComponent();
            this._ruleIds = new List<int>();
            this.LoadData();
        }

        private void LoadData()
        {
            string query = "select {0}.rule_id, {0}.rule_name, {0}.rule_description" +
                " from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_rule), null);
            for (int i = 0; i < result.values.Count; ++i)
            {
                this._ruleIds.Add(int.Parse(result.values[i][0].ToString()));
                this.table.Rows.Add(false, result.values[i][1], result.values[i][2]);
            }
            this.table.AllowUserToAddRows = false;
        }

        private void OnClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickAnalysisButton(object sender, EventArgs e)
        {
            bool find = false;
            for (int i = 0; i < this.table.RowCount; ++i)
            {
                var row = this.table.Rows[i];
                if ((bool)row.Cells[0].Value)
                {
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                MessageForm.Create("Выберите хотя бы одно правило!");
                return;
            }
            for (int i = 0; i < this.table.RowCount; ++i)
            {
                var row = this.table.Rows[i];
                if ((bool)row.Cells[0].Value)
                {
                    this.Log.Items.Add(string.Format("Выполнение правила {0}", row.Cells[1].Value));
                    string query = "select {1}.operation_name from {0}" +
                        " inner join {1} on {0}.operation_id = {1}.operation_id" +
                        " where {0}.rule_id = :id";
                    var result = QueryProvider.Execute(string.Format(query, Config.s_rule_operation, Config.s_operation), new OracleParameter[1]
                    {
                        new OracleParameter("id", this._ruleIds[i]),
                    });
                    for (int j = 0; j < result.values.Count; ++j)
                    {
                        this.Log.Items.Add(string.Format("    Выполнение операции {0}", result.values[j][0]));
                    }
                }
            }
        }
    }
}
