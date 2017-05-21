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

        private List<int> _cacheIds;
        private List<string> _dataTypes;
        private List<object> _values;

        public CacheAttribute(int session_id)
        {
            this._session_id = session_id;
            InitializeComponent();
            this._cacheIds = new List<int>();
            this._dataTypes = new List<string>();
            this._values = new List<object>();
            this.analisysButton.Enabled = false;
            this.LoadData();
        }

        private void LoadData()
        {
            string query = "select {1}.attribute_name, {2}.object_name, {3}.object_value, {1}.data_type, {0}.cache_id from {0}" +
                " inner join {1} on {1}.attribute_type_id = {0}.attribute_id" +
                " inner join {2} on {2}.object_type_id = {1}.object_type_id" +
                " inner join {3} on {3}.object_id = {0}.object_id where " +
                "{0}.session_id = :session_id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_attribute, Config.s_attribute_type, Config.s_object_type, Config.s_object), new OracleParameter[1]
            {
                new OracleParameter("session_id", this._session_id),
            });
            for (int i = 0; i < result.values.Count; ++i)
            {
                var row = result.values[i];
                string dataType = row[3].ToString();
                query = "select {0}.{1} from {0} where {0}.cache_id = :cache_id";
                string nameColumn = this.GetColumnName(dataType);
                var data = QueryProvider.Execute(string.Format(query, Config.s_attribute, nameColumn), new OracleParameter[1]
                {
                    new OracleParameter("cache_id", row[4]),
                });
                this._dataTypes.Add(dataType);
                this._cacheIds.Add(int.Parse(row[4].ToString()));
                this._values.Add(data.values.Count > 0 ? data.values[0][0] : "");
                this.table.Rows.Add(row[0], row[1], row[2], this._values[this._values.Count - 1]);
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
            for (int i = 0; i < this._cacheIds.Count; ++i)
            {
                string query = "select {0}.attribute_id, {0}.object_id from {0}" +
                    " where {0}.cache_id = :cache_id";
                string nameColumn = this.GetColumnName(this._dataTypes[i]);
                var result = QueryProvider.Execute(string.Format(query, Config.s_attribute, nameColumn), new OracleParameter[1]
                {
                    new OracleParameter("cache_id", this._cacheIds[i]),
                });
                query = "insert into {0}(session_id, attribute_id, object_id, {1})" +
                    " values(:session_id, :attribute_id, :object_id, :value)";
                QueryProvider.Execute(string.Format(query, Config.s_attribute, nameColumn), new OracleParameter[4]
                {
                    new OracleParameter("session_id", session_id),
                    new OracleParameter("attribute_id", result.values[0][0]),
                    new OracleParameter("object_id", result.values[0][1]),
                    new OracleParameter("value", this._values[i]),
                });
            }
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
                default:
                    return DataType.String;
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
                this._values[index] = f.value;
                row.Cells[3].Value = f.value;
            };
        }
    }
}
