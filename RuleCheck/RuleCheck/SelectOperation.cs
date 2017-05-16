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
    public partial class SelectOperation : SearchBase
    {
        public int selectId;

        public Action<SelectOperation> onClose;

        public SelectOperation(List<int> id, List<KeyValuePair<string, string>> info) : base()
        {
            this.selectId = -1;
            this.operationIds.AddRange(id);
            this.operations.AddRange(info);
            for (int i = 0; i < id.Count; ++i)
            {
                this.indices.Add(i);
            }
            for (int i = 0; i < info.Count; ++i)
            {
                var o = info[i];
                this.table.Rows.Add(o.Key, o.Value);
            }
            this.SelectedRow();
        }

        protected override string TextForm
        {
            get
            {
                return "Выбор операции";
            }
        }

        public static SelectOperation Create(List<int> id, List<KeyValuePair<string, string>> info)
        {
            var form = new SelectOperation(id, info);
            form.Show();
            return form;
        }

        private void OnClickSelectButton(object sender, EventArgs e)
        {
            if (!this.CheckSelectRow())
            {
                return;
            }
            int num = this.table.SelectedRows[0].Index;
            this.selectId = this.operationIds[this.indices[num]];
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
