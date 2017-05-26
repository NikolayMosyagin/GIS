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
using System.Collections.ObjectModel;

namespace RuleCheck
{
    public partial class SearchBase : Form
    {
        protected List<KeyValuePair<string, string>> data;
        protected List<int> ids;
        protected List<int> indices;
        protected List<OracleParameter> parameters;
        protected ReadOnlyCollection<int> blockedIds;

        public SearchBase(List<int> blockedIds = null)
        {
            this.InitializeComponent();
            this.Text = this.TextForm;
            this.data = new List<KeyValuePair<string, string>>();
            this.ids = new List<int>();
            this.indices = new List<int>();
            this.parameters = new List<OracleParameter>();
            this.blockedIds = blockedIds == null ? null : blockedIds.AsReadOnly();
            this.LoadData();
            this.SelectedRow();
            this.RefreshButtons();
        }

        public SearchBase()
        {
            this.InitializeComponent();
            this.Text = this.TextForm;
            this.data = new List<KeyValuePair<string, string>>();
            this.ids = new List<int>();
            this.indices = new List<int>();
            this.parameters = new List<OracleParameter>();
            this.blockedIds = null;
            this.LoadData();
            this.SelectedRow();
            this.RefreshButtons();
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
            this.data.Clear();
            this.ids.Clear();
            //this.indices.Clear();
            this.table.Rows.Clear();
            this.parameters.Clear();
        }

        protected string EndSelectQueryToLoadData()
        {
            string result = " where rownum <= :first";
            this.parameters.Add(new OracleParameter("first", Config.maxCountRow));
            if (!string.IsNullOrEmpty(this.searchTextBox.Text))
            {
                result = result + " and SUBSTR({0}.rule_name, 1, :second) = :third";
                parameters.Add(new OracleParameter("second", this.searchTextBox.Text.Length));
                parameters.Add(new OracleParameter("third", this.searchTextBox.Text));
            }
            return result;
        }

        protected void SelectedRow()
        {
            if (this.table.RowCount > 0)
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
            /*int num = this.table.SelectedRows[0].Index;
            if (num >= this.indices.Count)
            {
                var form = MessageForm.Create(this.messageEmptySelected);
                return false;
            }*/
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
            //this.indices.Clear();
            for (int i = 0; i < this.data.Count; ++i)
            {
                var pr = this.data[i];
                if (pr.Key.StartsWith(value))
                {
                    this.table.Rows.Add(pr.Key, pr.Value);
                    //this.indices.Add(i);
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
            this.SelectedRow();
            this.RefreshButtons();
        }
    }
}
