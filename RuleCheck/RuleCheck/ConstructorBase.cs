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
        public ConstructorBase() : base()
        {
            this.addButton.Text = this.addButtonText;
            this.updateButton.Text = this.updateButtonText;
            this.deleteButton.Text = this.deleteButtonText;
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

        public virtual string addButtonText
        {
            get { return "Добавить"; }
        }

        public virtual string deleteButtonText
        {
            get { return "Удалить"; }
        }

        public virtual string updateButtonText
        {
            get { return "Изменить"; }
        }

        public virtual string onDeleteText
        {
            get { return ""; }
        }

        protected override bool RefreshButtons()
        {
            if (this.table.SelectedRows.Count <= 0 ||
                this.table.SelectedRows.Count > 1)
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
            this.Enabled = false;
            DecisionForm.Create(string.Format("Вы действительно хотите удалить {0}", this.onDeleteText),
                (form) =>
                {
                    if (form.result == DecisionResult.Yes)
                    {
                        this.OnDelete();
                    }
                    else
                    {
                        this.Enabled = true;
                    }
                });
        }

    }
}
