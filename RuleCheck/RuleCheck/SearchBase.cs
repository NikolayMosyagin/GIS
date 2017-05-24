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
    public partial class SearchBase : Form
    {
        protected List<KeyValuePair<string, string>> operations;
        protected List<int> operationIds;
        protected List<int> indices;

        public SearchBase()
        {
            this.InitializeComponent();
            this.Text = this.TextForm;
            this.operations = new List<KeyValuePair<string, string>>();
            this.operationIds = new List<int>();
            this.indices = new List<int>();
            this.LoadData();
            this.SelectedRow();
        }

        protected virtual string messageNotSelected
        {
            get { return ""; }
        }

        protected virtual string messageManySeleceted
        {
            get { return ""; }
        }

        protected virtual string messageEmptySelected
        {
            get { return ""; }
        }

        public virtual string TextForm
        {
            get { return "Поиск"; }
        }


        protected virtual void LoadData()
        {
            this.operations.Clear();
            this.operationIds.Clear();
            this.indices.Clear();
            this.table.Rows.Clear();
        }

        protected void SelectedRow()
        {
            if (this.indices.Count > 0)
            {
                this.table.Rows[0].Selected = true;
            }
        }

        protected virtual bool RefreshButtons()
        {
            return false;
        }

        protected bool CheckSelectRow()
        {
            if (this.table.SelectedRows.Count <= 0)
            {
                var form = MessageForm.Create(this.messageNotSelected);
                return false;
            }
            if (this.table.SelectedRows.Count > 1)
            {
                var form = MessageForm.Create(this.messageManySeleceted);
                return false;
            }
            int num = this.table.SelectedRows[0].Index;
            if (num >= this.indices.Count)
            {
                var form = MessageForm.Create(this.messageEmptySelected);
                return false;
            }
            return true;
        }

        private void OnEnterSearchTextBox(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
            this.searchTextBox.Enter -= this.OnEnterSearchTextBox;
        }

        private void OnEnterRowTable(object sender, DataGridViewCellEventArgs e)
        {
            this.RefreshButtons();
        }

        public void UpdateTable()
        {
            string value = this.searchTextBox.Text;
            this.table.Rows.Clear();
            this.indices.Clear();
            for (int i = 0; i < this.operations.Count; ++i)
            {
                var pr = this.operations[i];
                if (pr.Key.StartsWith(value))
                {
                    this.table.Rows.Add(pr.Key, pr.Value);
                    this.indices.Add(i);
                }
            }
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickSearchButton(object sender, EventArgs e)
        {
            this.LoadData();
        }
    }
}
