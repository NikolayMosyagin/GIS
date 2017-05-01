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
    public partial class ObjectProcessing : ProcessingForm
    {
        public ObjectProcessing() : base()
        {
        }

        protected override void SetCurrentList()
        {
            string query = "select object_id, table_object_id from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_objects), null);
            if (result != null && result.values.Count > 0)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.currentList.Items.Add(result.values[i][1]);
                    this.currentIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override void SetAvailableList()
        {
            string query = "select object_id, object_value from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_object), null);
            if (result != null && result.values.Count > 0)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.availableList.Items.Add(result.values[i][1]);
                    this.availableIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override List<int> OnAdd(List<int> indices)
        {
            List<int> tableIds = new List<int>(indices.Count);
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "select {1}.object_name from {0} inner join {1} on {0}.object_type_id = {1}.object_type_id where {0}.object_id = :object_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_storage_object, Config.s_storage_object_type), new OracleParameter[1]
                    {
                    new OracleParameter("object_id", this.availableIds[indices[i]]),
                    });
                string objectType = result.values[0][0].ToString();
                query = "select {0}.table_id from {0} where {0}.table_name = :table_name";
                result = QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[1]
                {
                    new OracleParameter("table_name", objectType),
                });
                //int count = decimal.ToInt32((decimal)result.values[0][0]);
                if (result.values == null || result.values.Count == 0)
                {
                    var form1 = new ObjectTypeProcessing();
                    form1.Show();
                    return null;
                }
                tableIds.Add(decimal.ToInt32((decimal)result.values[0][0]));
            }
            var output = new List<int>(indices.Count);
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "insert into {0}(table_id, table_object_id) values(:table_id, :table_object_id) returning {0}.object_id into :object_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_objects), new OracleParameter[3]
                {
                    new OracleParameter("table_id", tableIds[i]),
                    new OracleParameter("table_object_id", this.availableList.Items[indices[i]]),
                    new OracleParameter("object_id", OracleDbType.Decimal, ParameterDirection.Output),
                });
                output.Add(((OracleDecimal)result.parametersOut[0]).ToInt32());
            }
            return output;
        }
    }
}
