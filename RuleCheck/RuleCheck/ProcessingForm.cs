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
    public partial class ProcessingForm : Form
    {
        protected List<int> currentIds;
        protected List<int> availableIds;

        public ProcessingForm()
        {
            InitializeComponent();
            this.currentIds = new List<int>();
            this.availableIds = new List<int>();
            this.SetCurrentList();
            this.SetAvailableList();
        }

        protected virtual void SetCurrentList()
        {

        }
        protected virtual void SetAvailableList()
        {

        }
        protected virtual bool OnDelete(List<int> indices)
        {
            return false;
        }

        protected virtual List<int> OnAdd(List<int> indices)
        {
            return null;
        }

        private void OnClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickDeleteButton(object sender, EventArgs e)
        {
            if (this.currentList.SelectedIndices.Count <= 0)
            {
                return;
            }
            List<int> indices = new List<int>(this.currentList.SelectedIndices.Count);
            for (int i = 0; i < this.currentList.SelectedIndices.Count; ++i)
            {
                indices.Add(this.currentList.SelectedIndices[i]);
            }
            indices.Sort((a, b) => { return a.CompareTo(b); });
            if (!this.OnDelete(indices))
            {
                return;
            }
            for (int i = indices.Count - 1; i >= 0; --i)
            {
                this.currentList.Items.RemoveAt(indices[i]);
                this.currentIds.RemoveAt(indices[i]);
            }
        }

        private void OnClickAddButton(object sender, EventArgs e)
        {
            if (this.availableList.SelectedIndices.Count <= 0)
            {
                return;
            }
            var indices = this.availableList.SelectedIndices;
            var addIndices = new List<int>();
            for (int i = 0; i < indices.Count; ++i)
            {
                bool find = false;
                var items = this.currentList.Items;
                for (int j = 0; j < items.Count; ++j)
                {
                    var a = items[j];
                    if (items[j].Equals(this.availableList.Items[indices[i]]))
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    addIndices.Add(indices[i]);
                    
                }
            }
            var ids = this.OnAdd(addIndices);
            if (ids != null)
            {
                for (int i = 0; i < ids.Count; ++i)
                {
                    this.currentIds.Add(ids[i]);
                    this.currentList.Items.Add(this.availableList.Items[addIndices[i]]);
                }
            }
            
        }
    }
}
