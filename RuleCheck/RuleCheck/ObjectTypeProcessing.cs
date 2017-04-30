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
    public partial class ObjectTypeProcessing : Form
    {
        public ObjectTypeProcessing()
        {
            InitializeComponent();
            this.SetAvailableList();
            this.SetCurrentList();
        }

        protected void SetAvailableList()
        {
            string query = "select object_type_id, object_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_object_type), null);
            if (result != null && result.values != null)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.availableList.Items.Add(result.values[i][1]);
                }
            }
        }

        protected void SetCurrentList()
        {
            string query = "select table_id, table_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_tables), null);
            if (result != null && result.values != null)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.currentList.Items.Add(result.values[i][1]);
                }
            }
        }

        private void onClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
