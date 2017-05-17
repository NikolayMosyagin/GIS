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
            // создание сессии 
            string query = "select sysdate from dual";
            var result = QueryProvider.Execute(query, null);
            query = "insert into {0}(creation_date, session_description) values(:idate, :descr)" + 
                " returning {0}.session_id into :session_id";
            result = QueryProvider.Execute(string.Format(query, Config.s_session), new OracleParameter[3]
            {
                new OracleParameter("idate", result.values[0][0]),
                new OracleParameter("descr", this.sessionDescription.Text),
                new OracleParameter("session_id", OracleDbType.Decimal, ParameterDirection.Output),
            });
            int session_id = ((OracleDecimal)result.parametersOut[0]).ToInt32();
            query = "begin LOAD(:session_id); end;";
            QueryProvider.Execute(query, new OracleParameter[1]
            {
                new OracleParameter("session_id", OracleDbType.Decimal, session_id, ParameterDirection.Input),
            });

            for (int i = 0; i < this.table.RowCount; ++i)
            {
                var row = this.table.Rows[i];
                if ((bool)row.Cells[0].Value)
                {
                    this.Log.Items.Add(string.Format("Выполнение правила {0}", row.Cells[1].Value));
                    query = "select {1}.operation_name, {1}.first_object_type_id" + 
                        ", {1}.second_object_type_id, {1}.operation_procedure, {1}.operation_id from {0}" +
                        " inner join {1} on {0}.operation_id = {1}.operation_id" +
                        " where {0}.rule_id = :id";
                    result = QueryProvider.Execute(string.Format(query, Config.s_rule_operation, Config.s_operation), new OracleParameter[1]
                    {
                        new OracleParameter("id", this._ruleIds[i]),
                    });
                    for (int j = 0; j < result.values.Count; ++j)
                    {
                        this.Log.Items.Add(string.Format("    Выполнение операции {0}", result.values[j][0]));
                        // вытаскиваем все объекты первого типа и второго.
                        query = "select {0}.object_value from {0} where {0}.object_type_id = :id";
                        var result1 = QueryProvider.Execute(string.Format(query, Config.s_object), new OracleParameter[1]
                        {
                            new OracleParameter("id", result.values[j][1]),
                        });
                        var result2 = QueryProvider.Execute(string.Format(query, Config.s_object), new OracleParameter[1]
                        {
                            new OracleParameter("id", result.values[j][2]),
                        });
                        for (int k1 = 0; k1 < result1.values.Count; ++k1)
                        {
                            for (int k2 = 0; k2 < result2.values.Count; ++k2)
                            {
                                // выполнить процедуру
                                query = "select {0}(:first, :second) from dual";
                                var resultFunction = QueryProvider.Execute(string.Format(query, result.values[j][3]), new OracleParameter[2]
                                {
                                    new OracleParameter("first", result1.values[k1][0]),
                                    new OracleParameter("second", result2.values[k2][0]),
                                });
                                this.Log.Items.Add(string.Format("      Результат выполнения {0}-{1}: {2}", result1.values[k1][0], result2.values[k2][0], resultFunction.values[0][0]));
                                query = "insert into {0}(session_id, operation_id, first_object_id, second_object_id, result)" +
                                    " values(:s_id, :o_id, :fo_id, :so_id, :result)";
                                QueryProvider.Execute(string.Format(query, Config.s_log), new OracleParameter[5]
                                {
                                    new OracleParameter("s_id", session_id),
                                    new OracleParameter("o_id", result.values[j][4]),
                                    new OracleParameter("fo_id", result1.values[k1][0]),
                                    new OracleParameter("so_id", result2.values[k2][0]),
                                    new OracleParameter("result", resultFunction.values[0][0]),
                                });
                            }
                        }
                    }
                }
            }
        }

        private void OnEnterRowTable(object sender, DataGridViewCellEventArgs e)
        {
            this.RefreshButtons();
        }

        private void RefreshButtons()
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
            this.analysisButton.Enabled = find;
        }

        private void table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.RefreshButtons();
            }
        }
    }
}
