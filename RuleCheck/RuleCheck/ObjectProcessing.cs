using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                }
            }
        }
    }
}
