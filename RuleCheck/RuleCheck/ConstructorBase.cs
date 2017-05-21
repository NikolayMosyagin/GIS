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
    public partial class ConstructorBase : SearchBase
    {

        protected override void LoadData()
        {
            if (this.table.RowCount > 0)
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

        protected virtual string addButtonText
        {
            get { return "Добавить"; }
        }

        protected virtual string deleteButtonText
        {
            get { return "Удалить"; }
        }

        protected virtual string updateButtonText
        {
            get { return "Изменить"; }
        }

        protected override bool RefreshButtons()
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

        private void OnClickAddButton(object sender, EventArgs e)
        {
            this.OnAdd();
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

    }
}
