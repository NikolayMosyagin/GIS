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
    public partial class InfoSession : Form
    {
        private int _session_id;

        public InfoSession()
        {
            InitializeComponent();
        }

        public static InfoSession Create(int session_id, string date, string description)
        {
            var form = new InfoSession();
            form._session_id = session_id;
            form.dateTextBox.Text = date;
            form.dateTextBox.ReadOnly = true;
            form.descriptionTextBox.Text = description;
            form.descriptionTextBox.ReadOnly = true;
            form.LoadData();
            form.Show();
            return form;
        }

        private void LoadData()
        {
            this.table.Rows.Clear();
            string query = "select {0}.first_object_id, {0}.second_object_id," + 
                " {0}.result, {1}.operation_name from {0} inner join {1} on " +
                "{0}.operation_id = {1}.operation_id where {0}.session_id = :session_id" + 
                " and rownum <= :second";
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("session_id", this._session_id));
            parameters.Add(new OracleParameter("second", Config.maxCountRow));
            if (!string.IsNullOrEmpty(this.operationTextBox.Text))
            {
                query = query + " and {1}.operation_name = :third";
                parameters.Add(new OracleParameter("third", this.operationTextBox.Text));
            }
            if (this.resultComboBox.SelectedIndex >= 0)
            {
                query = query + " and {0}.result = :fourth";
                parameters.Add(new OracleParameter("fourth", (this.resultComboBox.SelectedIndex ^ 1)));
            }
            var result = QueryProvider.Execute(string.Format(query, Config.s_log, Config.s_operation), parameters.ToArray());
            
            for (int i = 0; i < result.values.Count; ++i)
            {
                int status = int.Parse(result.values[i][2].ToString());
                this.table.Rows.Add(result.values[i][3], result.values[i][0],
                    result.values[i][1], status == 1 ? "Выполнено" : "Не выполнено");
            }
            //this.dateTextBox.Text = 
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickSearchButton(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void OnClickCellTable(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex != 1 && e.ColumnIndex != 2) || e.RowIndex < 0)
            {
                return;
            }
            DecisionForm.Create("Вы хотите посмотреть объект на карте?", (f) =>
            {
                if (f.result == DecisionResult.Yes)
                {
                    int objectValue = int.Parse(
                        this.table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    string query = "select {1}.theme_name, {1}.object_type_id from {0} inner join {1} " +
                        "on {0}.object_type_id = {1}.object_type_id " +
                        "where {0}.session_id = :first and {0}.object_value = :second";
                    var result = QueryProvider.Execute(string.Format(query, Config.s_object, Config.s_object_type), new OracleParameter[2]
                    {
                        new OracleParameter("first", this._session_id),
                        new OracleParameter("second", objectValue),
                    });

                    if (result.values.Count > 0)
                    {
                        string themeName = result.values[0][0].ToString();
                        int objectTypeId = int.Parse(result.values[0][1].ToString());
                        query = "select GetGeoId(:first, :second) from dual";
                        result = QueryProvider.Execute(query, new OracleParameter[2]
                        {
                            new OracleParameter("first", objectTypeId),
                            new OracleParameter("second", objectValue),
                        });
                        int geoObjectId = int.Parse(result.values[0][0].ToString());
                        System.Diagnostics.Process.Start(string.Format(Config.urlMap, themeName, geoObjectId, Config.projectIdMap));
                    }
                }
            });

        }
    }
}
