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
        protected List<object> currentData;
        protected List<object> availableData;

        private List<KeyValuePair<bool, int>> _changedIds;

        protected virtual string TypeText
        {
            get { return ""; }
        }

        public ProcessingForm()
        {
            InitializeComponent();
            this.currentIds = new List<int>();
            this.availableIds = new List<int>();
            this.availableData = new List<object>();
            this.currentData = new List<object>();
            this._changedIds = new List<KeyValuePair<bool, int>>();
            this.FillLists();
            this.SetLabels();
        }

        protected virtual void GetCurrentData() { }
        protected virtual void GetAvailableData() { }
        protected virtual void Add(int id) { }
        protected virtual void Delete(int id) { }

        protected virtual bool CanDelete(List<int> indices)
        {
            return false;
        }

        protected virtual bool CanAdd(List<int> indices)
        {
            return false;
        }

        private void SetLabels()
        {
            this.availableLabel.Text = string.Format("Доступные {0}", this.TypeText);
            this.currentLabel.Text = string.Format("Добавленные {0}", this.TypeText);
        }

        private void FillLists()
        {
            this.GetCurrentData();
            this.GetAvailableData();
            for (int i = 0; i < this.currentIds.Count; ++i)
            {
                for (int j = 0; j < this.availableIds.Count; ++j)
                {
                    if (this.currentIds[i] == this.availableIds[j])
                    {
                        this.availableIds.RemoveAt(j);
                        this.availableData.RemoveAt(j);
                        break;
                    }
                }
            }
            for (int i = 0; i < this.currentData.Count; ++i)
            {
                this.currentList.Items.Add(this.currentData[i]);
            }
            for (int i = 0; i < this.availableData.Count; ++i)
            {
                this.availableList.Items.Add(this.availableData[i]);
            }
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
            var result = this.CanDelete(indices);
            if (result)
            {
                for (int i = 0; i < indices.Count; ++i)
                {
                    this.availableIds.Add(this.currentIds[indices[i]]);
                    this.availableList.Items.Add(this.currentList.Items[indices[i]]);
                }
                for (int i = indices.Count - 1; i >= 0; --i)
                {
                    this.AddChangedList(new KeyValuePair<bool, int>(false, this.currentIds[indices[i]]));
                    this.currentList.Items.RemoveAt(indices[i]);
                    this.currentIds.RemoveAt(indices[i]);
                }
            }
            
        }

        private void OnClickAddButton(object sender, EventArgs e)
        {
            if (this.availableList.SelectedIndices.Count <= 0)
            {
                return;
            }
            var indices = this.availableList.SelectedIndices;
            List<int> addIndices = new List<int>(indices.Count);
            for (int i = 0; i < indices.Count; ++i)
            {
                addIndices.Add(indices[i]);
            }
            addIndices.Sort((a, b) => { return a.CompareTo(b); });
            var result = this.CanAdd(addIndices);
            if (result)
            {
                for (int i = 0; i < addIndices.Count; ++i)
                {
                    this.currentIds.Add(this.availableIds[addIndices[i]]);
                    this.currentList.Items.Add(this.availableList.Items[addIndices[i]]);
                }
                for (int i = addIndices.Count - 1; i >= 0; --i)
                {
                    this.AddChangedList(new KeyValuePair<bool, int>(true, this.availableIds[indices[i]]));
                    this.availableIds.RemoveAt(addIndices[i]);
                    this.availableList.Items.RemoveAt(addIndices[i]);
                }
            }
        }

        private void OnSizeChangeAvailableLable(object sender, EventArgs e)
        {
            int x = this.availableList.Location.X + this.availableList.ClientSize.Width / 2 - this.availableLabel.ClientSize.Width / 2;
            this.availableLabel.Location = new Point(x, this.availableLabel.Location.Y);
        }

        private void OnSizeChangedCurrentLabel(object sender, EventArgs e)
        {
            int x = this.currentList.Location.X + this.currentList.ClientSize.Width / 2 - this.currentLabel.ClientSize.Width / 2;
            this.currentLabel.Location = new Point(x, this.currentLabel.Location.Y);
        }

        private void AddChangedList(KeyValuePair<bool, int> value)
        {
            int index = -1;
            for (int i = 0; i < this._changedIds.Count; ++i)
            {
                var tmp = this._changedIds[i];
                if (tmp.Value == value.Value)
                {
                    if (tmp.Key != value.Key)
                    {
                        index = i;
                        break;
                    }
                    return;
                }
            }
            if (index == -1)
            {
                this._changedIds.Add(value);
            }
            else
            {
                this._changedIds.RemoveAt(index);
            }
            this.SetTextApplyButton();
        }

        private void SetTextApplyButton()
        {
            this.applyButton.Text = this._changedIds == null || this._changedIds.Count == 0 ?
                "Применить" :
                "Применить*";
        }

        private void OnClickApplyButton(object sender, EventArgs e)
        {
            if (this._changedIds == null || this._changedIds.Count == 0)
            {
                this.Close();
                return;
            }
            for (int i = 0; i < this._changedIds.Count; ++i)
            {
                var value = this._changedIds[i];
                if (value.Key == false)
                {
                    this.Delete(value.Value);
                }
                else
                {
                    this.Add(value.Value);
                }
            }
            this.Close();
        }
    }
}
