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
    public partial class ConstructorRule : ConstructorBase
    {
        protected override void LoadData()
        {
            string query = "select {0}.rule_id, {0}.rule_name, {0}.rule_description" +
                " from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_rule), null);
            for (int i = 0; i < result.values.Count; ++i)
            {
                this.operations.Add(new KeyValuePair<string, string>(result.values[i][1].ToString(), result.values[i][2].ToString()));
                this.operationIds.Add(int.Parse(result.values[i][0].ToString()));
                this.table.Rows.Add(result.values[i][1], result.values[i][2]);
                this.indices.Add(i);
            }
            base.LoadData();
        }

        protected override bool RefreshButtons()
        {
            base.RefreshButtons();
            this.addButton.Enabled = true;
            return true;
        }

        protected override void OnAdd()
        {
            var form = RuleProcessing.Create();
            form.onClose = (f) =>
            {
                this.operationIds.Add(f.id);
                this.operations.Add(new KeyValuePair<string, string>(f.name, f.description));
                this.table.Rows.Add(f.name, f.description);
                // вызвать функцию измения table;
            };
        }
    }
}
