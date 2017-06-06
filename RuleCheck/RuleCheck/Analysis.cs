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
        private List<int> _boundaryGeoId;
        private int _sessionId;
        private object _date;
        public Action<Analysis> onClose;

        public Analysis(int sessionId = -1, object date = null)
        {
            InitializeComponent();
            this._boundaryGeoId = new List<int>();
            this._ruleIds = new List<int>();
            this._sessionId = sessionId;
            this._date = date;
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

            query = "select {0}.docs_boundary_geo_id, {0}.name from {0}";
            result = QueryProvider.Execute(string.Format(query, Config.s_boundary), null);
            for (int i = 0; i < result.values.Count; ++i)
            {
                this._boundaryGeoId.Add(int.Parse(result.values[i][0].ToString()));
                this.regionComboBox.Items.Add(result.values[i][1]);
            }
        }

        private void OnClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }


        private void OnClickAnalysisButton(object sender, EventArgs e)
        {
            if (this.regionComboBox.SelectedIndex < 0)
            {
                MessageForm.Create("Выберите область!");
                return;
            }
            string query;
            bool loadCacheAttribute = false;
            if (this._sessionId == -1)
            {
                this._sessionId = CreateSession(this.sessionDescription.Text, out this._date);
                loadCacheAttribute = true;
            }
            else
            {
                query = "update {0} set {0}.session_description = :description" +
                " where {0}.session_id = :session_id";
                QueryProvider.Execute(string.Format(query, Config.s_session), new OracleParameter[2]
                {
                    new OracleParameter("description", this.sessionDescription.Text),
                    new OracleParameter("session_id", this._sessionId)
                });
            }

            query = "begin Load_Cache_Object(:first, :second); end;";
            QueryProvider.Execute(query, new OracleParameter[2]
            {
                new OracleParameter("first", this._sessionId),
                new OracleParameter("second", this._boundaryGeoId[this.regionComboBox.SelectedIndex]),
            });
            
            if (loadCacheAttribute)
            {
                query = "begin Load_Cache_Attribute(:session_id); end;";
                QueryProvider.Execute(query, new OracleParameter[1]
                {
                new OracleParameter("session_id", OracleDbType.Decimal, this._sessionId, ParameterDirection.Input),
                });
            }
            

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
                    var result = QueryProvider.Execute(string.Format(query, Config.s_rule_operation, Config.s_operation), new OracleParameter[1]
                    {
                        new OracleParameter("id", this._ruleIds[i]),
                    });
                    for (int j = 0; j < result.values.Count; ++j)
                    {
                        this.Log.Items.Add(string.Format("    Выполнение операции {0}", result.values[j][0]));
                        // вытаскиваем все объекты первого типа и второго.
                        query = "select {0}.object_value from {0} where {0}.object_type_id = :id and {0}.session_id = :sessionId";
                        var result1 = QueryProvider.Execute(string.Format(query, Config.s_object), new OracleParameter[2]
                        {
                            new OracleParameter("id", result.values[j][1]),
                            new OracleParameter("sessionId", this._sessionId)
                        });
                        var result2 = QueryProvider.Execute(string.Format(query, Config.s_object), new OracleParameter[2]
                        {
                            new OracleParameter("id", result.values[j][2]),
                            new OracleParameter("sessionId", this._sessionId),
                        });
                        for (int k1 = 0; k1 < result1.values.Count; ++k1)
                        {
                            if (result2.values.Count == 0)
                            {
                                this.ExecuteOperation(result.values[j][3].ToString(), int.Parse(result.values[j][4].ToString()), result1.values[k1][0], null);
                            }
                            for (int k2 = 0; k2 < result2.values.Count; ++k2)
                            {
                                this.ExecuteOperation(result.values[j][3].ToString(), int.Parse(result.values[j][4].ToString()), result1.values[k1][0], result2.values[k2][0]);
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

        public static int CreateSession(string description, out object date)
        {
            string query = "select sysdate from dual";
            var result = QueryProvider.Execute(query, null);
            query = "insert into {0}(creation_date, session_description) values(:idate, :descr)" +
                " returning {0}.session_id into :session_id";
            date = result.values[0][0];
            result = QueryProvider.Execute(string.Format(query, Config.s_session), new OracleParameter[3]
            {
                new OracleParameter("idate", result.values[0][0]),
                new OracleParameter("descr", description),
                new OracleParameter("session_id", OracleDbType.Decimal, ParameterDirection.Output),
            });
            return ((OracleDecimal)result.parametersOut[0]).ToInt32();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (ControlSessions.current != null)
            {
                ControlSessions.current.AddData(this._sessionId, this._date, this.sessionDescription.Text);
            }
        }

        private void ExecuteOperation(string name, int operationId, object obj1, object obj2)
        {
            string query = "select {0}(:first, :second";
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("first", this._sessionId));
            parameters.Add(new OracleParameter("second", obj1));
            if (obj2 != null)
            {
                query = query + ", :third";
                parameters.Add(new OracleParameter("third", obj2));
            }
            query = query + ") from dual";
            var resultFunction = QueryProvider.Execute(string.Format(query, name), parameters.ToArray());
            this.Log.Items.Add(string.Format("      Результат выполнения {0}-{1}: {2}", obj1, obj2, resultFunction.values[0][0]));
            query = "insert into {0}(session_id, operation_id, first_object_id, second_object_id, result)" +
                " values(:s_id, :o_id, :fo_id, :so_id, :result)";
            QueryProvider.Execute(string.Format(query, Config.s_log), new OracleParameter[5]
            {
                new OracleParameter("s_id", this._sessionId),
                new OracleParameter("o_id", operationId),
                new OracleParameter("fo_id", obj1),
                new OracleParameter("so_id", obj2),
                new OracleParameter("result", resultFunction.values[0][0]),
            });
        }

        private void OnClickMapButton(object sender, EventArgs e)
        {
            int i = -1;
            if ((i = this.regionComboBox.SelectedIndex) < 0)
            {
                MessageForm.Create("Выберите область.");
                return;
            }

            System.Diagnostics.Process.Start(string.Format(Config.urlMap, Config.s_themeBoundary, this._boundaryGeoId[i], Config.projectIdMap));
        }
    }
}
