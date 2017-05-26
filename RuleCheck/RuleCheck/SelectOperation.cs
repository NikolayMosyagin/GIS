using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuleCheck
{
    public partial class SelectOperation : SearchBase
    {
        public int selectedId;
        public string selectedName;
        public string selectedDescription;

        public Action<SelectOperation> onClose;

        protected override void LoadData()
        {
            base.LoadData();
            string query = "select {0}.operation_id, {0}.operation_name, {0}.operation_description from {0}"
                + this.EndSelectQueryToLoadData();
            var result = QueryProvider.Execute(string.Format(query, Config.s_operation), parameters.ToArray());
            for (int i = 0; i < result.values.Count; ++i)
            {
                int opId = int.Parse(result.values[i][0].ToString());
                if (this.blockedIds == null || this.blockedIds.IndexOf(opId) < 0)
                {
                    this.ids.Add(opId);
                    this.data.Add(new KeyValuePair<string, string>(
                        result.values[i][1].ToString(),
                        result.values[i][2].ToString()));
                    this.table.Rows.Add(result.values[i][1], result.values[i][2]);
                }
            }
        }

        public SelectOperation(List<int> blockedIds = null) : base(blockedIds)
        {
            this.selectedId = -1;
        }

        public override string TextForm
        {
            get
            {
                return "Выбор операции";
            }
        }

        protected override bool RefreshButtons()
        {
            var result = base.RefreshButtons();
            this.selectButton.Enabled = this.table.SelectedRows.Count == 1;
            return true;
        }

        private void OnClickSelectButton(object sender, EventArgs e)
        {
            int num = this.table.SelectedRows[0].Index;
            this.selectedId = this.ids[num];
            this.selectedName = this.data[num].Key;
            this.selectedDescription = this.data[num].Value;
            this.Close();
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
            if (this.onClose != null)
            {
                var m = this.onClose;
                this.onClose = null;
                m(this);
            }
        }
    }
}
