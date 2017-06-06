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
    public partial class CacheAttribute : Form
    {
        private int _session_id;

        private List<KeyValuePair<int, int>> _primaryKeysCache;
        private List<string> _dataTypes;
        private List<object> _values;

        private Dictionary<KeyValuePair<int, int>, object> _changedValues;

        public CacheAttribute(int session_id)
        {
            this._session_id = session_id;
            InitializeComponent();
            this._primaryKeysCache = new List<KeyValuePair<int,int>>();
            this._dataTypes = new List<string>();
            this._values = new List<object>();
            this.analisysButton.Enabled = false;
            this._changedValues = new Dictionary<KeyValuePair<int, int>, object>();
            this.LoadData();
        }

        private void LoadData()
        {
            this._dataTypes.Clear();
            this._primaryKeysCache.Clear();
            this._values.Clear();
            this.table.Rows.Clear();
            string query = "select {1}.attribute_name, {2}.object_name, {1}.data_type, {0}.attribute_id, {0}.object_value from {0}" +
                " inner join {1} on {1}.attribute_type_id = {0}.attribute_id" +
                " inner join {2} on {2}.object_type_id = {1}.object_type_id" +
                " where " +
                "{0}.session_id = :first and rownum <= :second";
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("first", this._session_id));
            parameters.Add(new OracleParameter("second", Config.maxCountRow));
            if (!string.IsNullOrEmpty(this.attributeTextBox.Text))
            {
                query = query + " and {1}.attribute_name = :third";
                parameters.Add(new OracleParameter("third", this.attributeTextBox.Text));
            }
            if (!string.IsNullOrEmpty(this.objectTextBox.Text))
            {
                query = query + " and {2}.object_name = :fourth";
                parameters.Add(new OracleParameter("fourth", this.objectTextBox.Text));
            }
            var result = QueryProvider.Execute(string.Format(query, Config.s_attribute, Config.s_attribute_type, Config.s_object_type, Config.s_object), parameters.ToArray());
            for (int i = 0; i < result.values.Count; ++i)
            {
                var row = result.values[i];
                string dataType = row[2].ToString();
                var primaryKey = new KeyValuePair<int, int>(int.Parse(row[3].ToString()), int.Parse(row[4].ToString()));
                object value = null;
                if (!this._changedValues.TryGetValue(primaryKey, out value))
                {
                    query = "select {0}.{1} from {0} where {0}.attribute_id = :first and {0}.object_value = :second and {0}.session_id = :third";
                    string nameColumn = this.GetColumnName(dataType);
                    var data = QueryProvider.Execute(string.Format(query, Config.s_attribute, nameColumn), new OracleParameter[3]
                    {
                        new OracleParameter("first", primaryKey.Key),
                        new OracleParameter("second", primaryKey.Value),
                        new OracleParameter("third", this._session_id),
                    });
                    value = data.values.Count > 0 ? data.values[0][0] : null;
                }
                this._dataTypes.Add(dataType);
                this._primaryKeysCache.Add(primaryKey);
                this._values.Add(value);
                this.table.Rows.Add(row[0], row[1], row[4], this._values[this._values.Count - 1]);
            }
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickAnalisysButton(object sender, EventArgs e)
        {
            object date;
            int session_id = Analysis.CreateSession("", out date);
            this.CloneCache(session_id);
            var form = new Analysis(session_id, date);
            form.Show();
            this.Close();
        }

        private string GetColumnName(string dataType)
        {
            string nameColumn = "number_val";
            switch (dataType)
            {
                case "NUMBER":
                    nameColumn = "number_val";
                    break;
                case "VARCHAR2":
                    nameColumn = "str_val";
                    break;
                case "DATE":
                    nameColumn = "date_val";
                    break;
                case "SDO_GEOMETRY":
                    nameColumn = "geometry_val";
                    break;
            }
            return nameColumn;
        }

        private DataType GetEnumDataType(string dataType)
        {
            switch (dataType)
            {
                case "NUMBER":
                    return DataType.Number;
                case "VARCHAR2":
                    return DataType.String;
                case "DATE":
                    return DataType.Date;
                case "SDO_GEOMETRY":
                    return DataType.Geometry;
                default:
                    return DataType.String;
            }
        }

        private void CloneCache(int sessionId)
        {
            string query = "select {1}.data_type, {0}.attribute_id, {0}.object_value from {0}" +
                " inner join {1} on {0}.attribute_id = {1}.attribute_type_id" + 
                " where {0}.session_id = :first";
            query = string.Format(query, Config.s_attribute, Config.s_attribute_type);
            using (var command = new OracleCommand(query, QueryProvider.s_connection))
            {
                command.Parameters.Add(new OracleParameter("first", this._session_id));
                command.CommandType = CommandType.Text;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string dataType = reader.GetValue(0).ToString();
                        int attributeId = int.Parse(reader.GetValue(1).ToString());
                        int objectValue = int.Parse(reader.GetValue(2).ToString());
                        object value = null;
                        if (!this._changedValues.TryGetValue(new KeyValuePair<int, int>(attributeId, objectValue), out value))
                        {
                            query = "select {0}.{1} from {0} where {0}.attribute_id = :first and {0}.object_value = :second and {0}.session_id = :third";
                            query = string.Format(query, Config.s_attribute, this.GetColumnName(dataType));
                            var result = QueryProvider.Execute(query, new OracleParameter[3]
                            {
                                new OracleParameter("first", attributeId),
                                new OracleParameter("second", objectValue),
                                new OracleParameter("third", this._session_id),
                            });
                            value = result.values.Count > 0 ? result.values[0][0] : null;
                        }
                        query = "insert into {0}(session_id, attribute_id, object_value, {1})" +
                            " values(:first, :second, :third, :fourth)";
                        QueryProvider.Execute(string.Format(query, Config.s_attribute, this.GetColumnName(dataType)), new OracleParameter[4]
                        {
                            new OracleParameter("first", sessionId),
                            new OracleParameter("second", attributeId),
                            new OracleParameter("third", objectValue),
                            new OracleParameter("fourth", value),
                        });
                    }
                    reader.Close();
                }
            }

        }

        private void OnClickChangeButton(object sender, EventArgs e)
        {
            int index = this.table.SelectedRows[0].Index;
            var row = this.table.SelectedRows[0];
            var form = ChangeAttribute.Create(
                row.Cells[0].Value.ToString(), 
                row.Cells[1].Value.ToString(), 
                int.Parse(row.Cells[2].Value.ToString()), 
                this.GetEnumDataType(this._dataTypes[index]), 
                this._values[index]);
            form.onClose = (f) =>
            {
                if (!object.Equals(this._values[index], f.value) && !this.analisysButton.Enabled)
                {
                    this.analisysButton.Enabled = true;
                }
                this._changedValues[this._primaryKeysCache[index]] = f.value;
                this._values[index] = f.value;
                row.Cells[3].Value = f.value;
            };
        }

        private void OnClickSearchButton(object sender, EventArgs e)
        {
            this.LoadData();
        }
    }
}
