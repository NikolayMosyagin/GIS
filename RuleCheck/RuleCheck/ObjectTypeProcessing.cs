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
        protected List<int> currentIds;
        protected List<int> availableIds;

        public ObjectTypeProcessing()
        {
            InitializeComponent();
            this.SetAvailableList();
            this.SetCurrentList();
        }

        protected override void SetAvailableList()
        {
            string query = "select object_type_id, object_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_object_type), null);
            if (result != null && result.values != null)
            {
                this.availableIds = new List<int>(result.values.Count);
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
                this.currentIds = new List<int>(result.values.Count);
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.currentList.Items.Add(result.values[i][1]);
                    this.currentIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        protected void OnDelete()
        {
            var indices = this.currentList.SelectedIndices;
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "delete from {0} where table_id = :table_id";
                QueryProvider.Execute(string.Format(query, Config.s_tables),
                    new OracleParameter[1]
                    {
                        new OracleParameter("table_id", this.currentIds[0]),
                    });
            }
        }

        protected List<int> OnAdd(List<int> indices)
        {
            List<int> idsOut = new List<int>(indices.Count);
            for (int i = 0; i < indices.Count; ++i)
            {
                string query = "insert into {0}(table_name, scheme_id, primary_column_name) values(:table_name, :scheme_id, :primary_column_name) returning table_id into :table_id";
                var result = QueryProvider.Execute(string.Format(query, Config.s_tables), new OracleParameter[4]
                    {
                        new OracleParameter("table_name", this.availableList.Items[indices[i]]),
                        new OracleParameter("scheme_id", 1),
                        new OracleParameter("primary_column_name", this.availableList.Items[indices[i]].ToString() + "_ID"),
                        new OracleParameter("table_id", OracleDbType.Decimal, ParameterDirection.Output),
                    });
                idsOut.Add(((OracleDecimal)result.parametersOut[0]).ToInt32());
            }
            return idsOut;
        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            if (this.currentList.SelectedIndices.Count <= 0)
            {
                return;
            }
            this.OnDelete();
            int[] indices = new int[this.currentList.SelectedIndices.Count];
            for (int i = 0; i < this.currentList.SelectedIndices.Count; ++i)
            {
                indices[i] = this.currentList.SelectedIndices[i];
            }
            Array.Sort<int>(indices, (a, b) => { return a.CompareTo(b); });
            for (int i = indices.Length - 1; i >= 0; --i)
            {
                this.currentList.Items.RemoveAt(indices[i]);
                this.currentIds.RemoveAt(indices[i]);
            }
        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            if (this.availableList.SelectedIndices.Count <= 0)
            {
                return;
            }
           
            var indices = this.availableList.SelectedIndices;
            var addIndices = new List<int>();
            for (int i = 0; i < indices.Count; ++i)
            {
                bool find = false;
                var items = this.currentList.Items;
                for (int j = 0; j < items.Count; ++j)
                {
                    var a = items[j];
                    if (items[j].Equals(this.availableList.Items[indices[i]]))
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    addIndices.Add(indices[i]);
                    this.currentList.Items.Add(this.availableList.Items[indices[i]]);
                }
            }
            var ids = this.OnAdd(addIndices);
            for (int i = 0; i < ids.Count; ++i)
            {
                this.currentIds.Add(ids[i]);
            }
        }
    }
}
