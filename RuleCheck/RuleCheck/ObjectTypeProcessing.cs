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
    public partial class ObjectTypeProcessing : ProcessingForm
    {
        protected override string TypeText
        {
            get
            {
                return "типы объектов";
            }
        }
        protected override void GetAvailableData()
        {
            string query = "select object_type_id, object_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_object_type), null);
            if (result != null && result.values != null)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.availableData.Add(result.values[i][1]);
                    this.availableIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override void GetCurrentData()
        {
            string query = 
                "select {1}.object_type_id, {1}.object_name from {0} " +
                "inner join {1} on {0}.table_id = {1}.object_type_id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_tables, Config.s_object_type), null);
            if (result != null && result.values != null)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.currentData.Add(result.values[i][1]);
                    this.currentIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected override bool CanDelete(List <int> indices)
        {
            /*for (int i = 0; i < indices.Count; ++i)
            {
                string query = "select {0}.table_object_id from {0} where {0}.table_id = :table_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_objects), new OracleParameter[1]
                {
                    new OracleParameter("table_id", this.currentIds[indices[i]]),
                });
                if (result != null && result.values != null && result.values.Count > 0)
                {
                    StringBuilder text = new StringBuilder();
                    for (int j = 0; j < result.values.Count; ++j)
                    {
                        text.Append(result.values[j][0].ToString());
                        if (j < result.values.Count - 1)
                        {
                            text.Append(",");
                        }
                    }
                    DecisionForm.Create(string.Format("Для удаления типа(ов) объекта необходимо удалить\n объекты {0}", text.ToString()),
                        (f) =>
                        {
                            if (f.result == DecisionResult.Yes)
                            {
                                var form = new ObjectProcessing();
                                form.Show();
                            }
                        });
                        return false;
                    }
            }
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "select {0}.attribute_name from {0} where {0}.table_id = :table_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_attributes), new OracleParameter[1]
                {
                    new OracleParameter("table_id", this.currentIds[indices[i]]),
                });
                if (result != null && result.values != null && result.values.Count > 0)
                {
                    StringBuilder text = new StringBuilder();
                    for (int j = 0; j < result.values.Count; ++j)
                    {
                        text.Append(result.values[j][0].ToString());
                        if (j < result.values.Count - 1)
                        {
                            text.Append(",");
                        }
                    }
                    DecisionForm.Create(string.Format("Для удаления типа(ов) объекта необходимо удалить\n атрибуты {0}", text.ToString()),
                        (f) =>
                        {
                            if (f.result == DecisionResult.Yes)
                            {
                                var form = new AttributeProcessing();
                                form.Show();
                            }
                        });
                    return false;
                }
            }
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "select {0}.operation_name from {0} where {0}.first_table_id = :table_id or {0}.second_table_id = :table_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[1]
                {
                    new OracleParameter("table_id", this.currentIds[indices[i]]),
                });
                if (result != null && result.values != null && result.values.Count > 0)
                {
                    StringBuilder text = new StringBuilder();
                    for (int j = 0; j < result.values.Count; ++j)
                    {
                        text.Append(result.values[j][0].ToString());
                        if (j < result.values.Count - 1)
                        {
                            text.Append(",");
                        }
                    }
                    DecisionForm.Create(string.Format("Для удаления типа(ов) объекта необходимо удалить\n атрибуты {0}", text.ToString()),
                        (f) =>
                        {
                            if (f.result == DecisionResult.Yes)
                            {
                                var form = new AttributeProcessing();
                                form.Show();
                            }
                        });
                    return false;
                }
            }*/
            return true;
        }

        protected override void Delete(int id)
        {
            string query = "delete from {0} where {0}.table_id = :table_id";
            QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[1]
            {
                new OracleParameter("table_id", id),
            });
        }

        protected override bool CanAdd(List<int> indices)
        {
            return true;
        }

        protected override void Add(int id)
        {
            string query = "insert into {0}(table_id, scheme_id) values(:table_id, :scheme_id)";
            var result = QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[2]
            {
                new OracleParameter("table_id", id),
                new OracleParameter("scheme_id", 1),
            });
        }
    }
}
