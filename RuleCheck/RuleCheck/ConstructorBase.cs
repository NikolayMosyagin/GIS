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
    public partial class ConstructorBase : Form
    {
        protected List<KeyValuePair<string, string>> operations;
        protected List<int> operationIds;
        protected List<int> indices;

        public ConstructorBase()
        {
            InitializeComponent();
            this.operations = new List<KeyValuePair<string, string>>();
            this.operationIds = new List<int>();
            this.indices = new List<int>();
            this.LoadData();
        }

        protected virtual void LoadData()
        {
            if (this.indices.Count > 0)
            {
                this.table.Rows[0].Selected = true;
            }
        }

        protected virtual void OnAdd()
        {
        }

        protected virtual void OnUpdate()
        {
        }

        protected virtual void OnDelete()
        {
        }

        protected virtual bool RefreshButtons()
        {
            int index;
            if (this.table.SelectedRows.Count <= 0 ||
                this.table.SelectedRows.Count > 1 ||
                (index = this.table.SelectedRows[0].Index) >= this.indices.Count)
            {
                this.addButton.Enabled = false;
                this.updateButton.Enabled = false;
                this.deleteButton.Enabled = false;
                return true;
            }
            return false;
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickAddButton(object sender, EventArgs e)
        {
            this.OnAdd();
        }

        protected bool CheckSelectRow()
        {
            if (this.table.SelectedRows.Count <= 0)
            {
                var form = MessageForm.Create("Необходимо выбрать операцию!");
                return false;
            }
            if (this.table.SelectedRows.Count > 1)
            {
                var form = MessageForm.Create("Необходимо выбрать только одну операцию!");
                return false;
            }
            int num = this.table.SelectedRows[0].Index;
            if (num >= this.indices.Count)
            {
                var form = MessageForm.Create("В данной строке нет операции!");
                return false;
            }
            return true;
        }

        private void OnClickUpdateButton(object sender, EventArgs e)
        {
            if (!this.CheckSelectRow())
            {
                return;
            }
            this.OnUpdate();
        }

        private void OnClickDeleteButton(object sender, EventArgs e)
        {
            if (!this.CheckSelectRow())
            {
                return;
            }
            int num = this.table.SelectedRows[0].Index;
            if (this.operationIds[this.indices[num]] == -1)
            {
                return;
            }
            this.OnDelete();
        }

        private void OnRowEnterTable(object sender, DataGridViewCellEventArgs e)
        {
            this.RefreshButtons();
        }

        private void OnEnterSearchTextBox(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
            this.searchTextBox.Enter -= this.OnEnterSearchTextBox;
        }

        private void OnTextChangedSearchTextBox(object sender, EventArgs e)
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
    }
}
