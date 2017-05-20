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

        public CacheAttribute(int session_id)
        {
            this._session_id = session_id;
            InitializeComponent();
            this._cacheIds = new List<int>();
            this._dataTypes = new List<string>();
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
                this._dataTypes.Add(dataType);
                this._cacheIds.Add(int.Parse(row[4].ToString()));
                var data = QueryProvider.Execute(string.Format(query, Config.s_attribute, nameColumn), new OracleParameter[1]
                {
                    new OracleParameter("cache_id", row[4]),
                });
                this.table.Rows.Add(row[0], row[1], row[2], data.values.Count > 0 ? data.values[0][0] : "");
            }
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickAnalisysButton(object sender, EventArgs e)
        {
            int session_id = Analysis.CreateSession("");
            for (int i = 0; i < this._cacheIds.Count; ++i)
            {
                string query = "select {0}.attribute_id, {0}.object_id, {0}.{1} from {0}" +
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
                    new OracleParameter("value", result.values[0][2]),
                });
            }
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
    }
}
