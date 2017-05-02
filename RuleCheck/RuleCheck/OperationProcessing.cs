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
    public partial class OperationProcessing : ProcessingForm
    {
        protected override void SetCurrentList()
        {
            string query = "select {0}.operation_id, {0}.operation_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_operation), null);
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
            string query = "select {0}.operation_id, {0}.operation_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_operation), null);
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
            List<int> tableIds = new List<int>(2 * indices.Count);
            List<string> operation = new List<string>(indices.Count);
            List<string> procedure = new List<string>(indices.Count);
            for (int i = 0; i < indices.Count; ++i)
            {
                string objectType;
                var result = this.CheckObjectType(this.availableIds[indices[i]], "first_object_type_id", out objectType);
                if (result.values == null || result.values.Count == 0)
                {
                    DecisionForm.Create(string.Format("Для добавления объекта(ов)\nнеобходимо добавить тип объекта {0}.\nДобавить?", objectType),
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
                result = this.CheckObjectType(this.availableIds[indices[i]], "second_object_type_id", out objectType);
                if (result.values == null || result.values.Count == 0)
                {
                    DecisionForm.Create(string.Format("Для добавления объекта(ов)\nнеобходимо добавить тип объекта {0}.\nДобавить?", objectType),
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
                string query = "select {0}.operation_name, {0}.operation_procedure from {0} where {0}.operation_id = :operation_id";
                result = QueryProvider.Execute(string.Format(query, Config.s_storage_operation), new OracleParameter[1]
                {
                    new OracleParameter("operation_id", this.availableIds[indices[i]]),
                });
                procedure.Add(result.values[0][1].ToString());
                operation.Add(result.values[0][0].ToString());
            }
            var output = new List<int>(indices.Count);
            int j = 0;
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "insert into {0}(first_table_id, second_table_id, operation_name, operation_procedure) values(:first_object_type_id, :second_object_type_id, :operation_name, :operation_procedure) returning {0}.operation_id into :operation_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[5]
                {
                    new OracleParameter("first_table_id", tableIds[j]),
                    new OracleParameter("second_table_id", tableIds[j + 1]),
                    new OracleParameter("operation_name", operation[i]),
                    new OracleParameter("operation_procedure", procedure[i]),
                    new OracleParameter("operation_id", OracleDbType.Decimal, ParameterDirection.Output),
                });
                j += 2;
                output.Add(((OracleDecimal)result.parametersOut[0]).ToInt32());
            }
            return output;
        }

        private DataTable CheckObjectType(int id, string type, out string objectType)
        {
            string query = "select {1}.object_name from {0} inner join {1} on {0}.{2} = {1}.object_type_id where {0}.operation_id = :operation_id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_operation, Config.s_storage_object_type, type), new OracleParameter[1]
            {
                    new OracleParameter("operation_id", id),
            });
            objectType = result.values[0][0].ToString();

            query = "select {0}.table_id from {0} where {0}.table_name = :table_name";
            result = QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[1]
            {
               new OracleParameter("table_name", objectType),
            });
            return result;
        }
    }
}
