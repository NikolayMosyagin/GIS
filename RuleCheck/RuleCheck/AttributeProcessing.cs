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
        protected override string TypeText
        {
            get
            {
                return "атрибуты";
            }
        }
        protected override void GetCurrentData()
        {
            string query = "select {1}.attribute_type_id, {1}.attribute_name from {0} " +
                "inner join {1} on {0}.attribute_id = {1}.attribute_type_id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_attributes, Config.s_storage_attribute_type), null);
            if (result != null && result.values != null)
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
            string query = "select {0}.attribute_type_id, {0}.attribute_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_attribute_type), null);
            if (result != null && result.values != null)
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
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "select {1}.object_type_id, {1}.object_name from {0} " +
                    "inner join {1} on {0}.object_type_id = {1}.object_type_id " +
                    "where {0}.attribute_type_id = :attribute_type_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_storage_attribute_type, Config.s_object_type), new OracleParameter[1]
                {
                    new OracleParameter("attribute_type_id", this.availableIds[indices[i]]),
                });
                int objectTypeId = int.Parse(result.values[0][0].ToString());
                string objectType = result.values[0][1].ToString();
                query = "select count(*) from {0} " +
                    "where {0}.table_id = :table_id";
                result = QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[1]
                {
                    new OracleParameter("table_id", objectTypeId),
                });
                int count = int.Parse(result.values[0][0].ToString());
                if (count == 0)
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
                    return false;
                }
            }
            return true;
        }

        protected override void Add(int id)
        {
            string query = "insert into {0}(attribute_id) values(:attribute_id)";
            var result = QueryProvider.Execute(string.Format(query, Config.s_attributes), new OracleParameter[1]
            {
                    new OracleParameter("attribute_id", id),
            });
        }

        protected override void Delete(int id)
        {
            string query = "delete from {0} where {0}.attribute_id = :attribute_id";
            QueryProvider.Execute(string.Format(query, Config.s_attributes), new OracleParameter[1]
            {
                    new OracleParameter("attribute_id", id),
            });
        }

        protected override bool CanDelete(List<int> indices)
        {
            return true;
        }
    }
}
