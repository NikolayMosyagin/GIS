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
        protected override string TypeText
        {
            get
            {
                return "объекты";
            }
        }
        protected override void GetCurrentData()
        {
            string query = "select {1}.object_id, {1}.object_value from {0} " +
                "inner join {1} on {0}.object_id = {1}.object_id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_object, Config.s_storage_object), null);
            if (result != null && result.values.Count > 0)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.currentData.Add(result.values[i][1]);
                    this.currentIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override void GetAvailableData()
        {
            string query = "select {0}.object_id, {0}.object_value from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_object), null);
            if (result != null && result.values.Count > 0)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.availableData.Add(result.values[i][1]);
                    this.availableIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override bool CanAdd(List<int> indices)
        {
            return true;
        }

        protected override void Add(int id)
        {
            string query = "insert into {0}(object_id) values(:object_id)";
            var result = QueryProvider.Execute(string.Format(query, Config.s_object), new OracleParameter[1]
            {
                    new OracleParameter("object_id", id),
            });
        }

        protected override bool CanDelete(List<int> indices)
        {
            return true;
        }

        protected override void Delete(int id)
        {
            string query = "delete from {0} where {0}.object_id = :object_id";
            QueryProvider.Execute(string.Format(query, Config.s_object), new OracleParameter[1]
            {
                    new OracleParameter("object_id", id),
            });
        }
    }
}
