﻿using System;
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
    public partial class AttributeProcessing : ProcessingForm
    {
        protected override void SetCurrentList()
        {
            string query = "select {0}.attribute_id, {0}.attribute_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_attributes), null);
            if (result != null && result.values != null)
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
            string query = "select {0}.attribute_type_id, {0}.attribute_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_attribute_type), null);
            if (result != null && result.values != null)
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
                string query = "select {1}.object_name from {0} inner join {1} on {0}.object_type_id = {1}.object_type_id where {0}.attribute_type_id = :attribute_type_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_storage_attribute_type, Config.s_storage_object_type), new OracleParameter[1]
                {
                    new OracleParameter("attribute_type_id", this.availableIds[indices[i]]),
                });
                string objectType = result.values[0][0].ToString();
                query = "select {0}.table_id from {0} where {0}.table_name = :table_name";
                result = QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[1]
                {
                    new OracleParameter("table_name", objectType),
                });
                if (result.values == null || result.values.Count == 0)
                {
                    DecisionForm.Create(string.Format("Для добавления aтрибута(ов)\nнеобходимо добавить тип объекта {0}.\nДобавить?", objectType),
                        (f) =>
                        {
                            if (f.result == DecisionResult.Yes)
                            {
                                var form1 = new ObjectTypeProcessing();
                                form1.Show();
                            }
                        });
                    return null;
                }
                tableIds.Add(decimal.ToInt32((decimal)result.values[0][0]));
            }
            var output = new List<int>(indices.Count);
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "insert into {0}(attribute_name, table_id) values(:attribute_name, :table_id) returning {0}.attribute_id into :attribute_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_attributes), new OracleParameter[3]
                {
                    new OracleParameter("attribute_name", this.availableList.Items[indices[i]]),
                    new OracleParameter("table_id", tableIds[i]),
                    new OracleParameter("attribute_id", OracleDbType.Decimal, ParameterDirection.Output),
                });
                output.Add(((OracleDecimal)result.parametersOut[0]).ToInt32());
            }
            return output;
        }

        protected override bool OnDelete(List<int> indices)
        {
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "delete from {0} where {0}.attribute_id = :attribute_id";
                QueryProvider.Execute(string.Format(query, Config.s_attributes),
                    new OracleParameter[1]
                    {
                        new OracleParameter("attribute_id", this.currentIds[indices[i]]),
                    });
            }
            return true;
        }
    }
}
