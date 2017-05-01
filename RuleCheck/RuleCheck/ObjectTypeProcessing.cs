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
    public partial class ObjectTypeProcessing : ProcessingForm
    {

        public ObjectTypeProcessing() : base()
        {
        }

        protected override void SetAvailableList()
        {
            string query = "select object_type_id, object_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_object_type), null);
            if (result != null && result.values != null)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.availableList.Items.Add(result.values[i][1]);
                    this.availableIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override void SetCurrentList()
        {
            string query = "select table_id, table_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_tables), null);
            if (result != null && result.values != null)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.currentList.Items.Add(result.values[i][1]);
                    this.currentIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override bool OnDelete(List <int> indices)
        {
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "delete from {0} where table_id = :table_id";
                QueryProvider.Execute(string.Format(query, Config.s_tables),
                    new OracleParameter[1]
                    {
                        new OracleParameter("table_id", this.currentIds[indices[i]]),
                    });
            }
            return true;
        }

        protected override List<int> OnAdd(List<int> indices)
        {
            List<int> idsOut = new List<int>(indices.Count);
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "insert into {0}(table_name, scheme_id, primary_column_name) values(:table_name, :scheme_id, :primary_column_name) returning table_id into :table_id";
                string value = this.availableList.Items[indices[i]].ToString();
                var result = QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[4]
                    {
                        new OracleParameter("table_name", value),
                        new OracleParameter("scheme_id", 1),
                        new OracleParameter("primary_column_name", value.Substring(0, value.Length - 1)  + "_ID"),
                        new OracleParameter("table_id", OracleDbType.Decimal, ParameterDirection.Output),
                    });
                idsOut.Add(((OracleDecimal)result.parametersOut[0]).ToInt32());
            }
            return idsOut;
        }
    }
}
