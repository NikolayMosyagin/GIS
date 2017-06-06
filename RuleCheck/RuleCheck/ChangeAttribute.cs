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
    public enum DataType
    {
        Number = 0,
        String = 1,
        Date = 2,
        Geometry = 3,
    }
    public partial class ChangeAttribute : Form
    {
        private DataType _type;
        public Action<ChangeAttribute> onClose;
        public object value;

        public ChangeAttribute()
        {
            InitializeComponent();
        }

        public static ChangeAttribute Create(string attribute, string objectType, int objectValue, DataType dataType, object value)
        {
            var form = new ChangeAttribute();
            form._type = dataType;
            form.attributeTextBox.Text = attribute;
            form.attributeTextBox.ReadOnly = true;
            form.objectTextBox.Text = objectType;
            form.objectTextBox.ReadOnly = true;
            form.objectValueTextBox.Text = objectValue.ToString();
            form.objectValueTextBox.ReadOnly = true;
            form.valueTextBox.Text = value.ToString();
            form.valueTextBox.ReadOnly = false;
            form.value = value;
            form.Show();
            return form;
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

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickApplyButton(object sender, EventArgs e)
        {
            if (this._type == DataType.String)
            {
                if (string.IsNullOrEmpty(this.valueTextBox.Text))
                {
                    MessageForm.Create("Недопустимое значение");
                    return;
                }
                this.value = this.valueTextBox.Text;
            }
            else if (this._type == DataType.Number)
            {
                float result;
                if (!float.TryParse(this.valueTextBox.Text, out result))
                {
                    MessageForm.Create("Недопустимое значение");
                    return;
                }
                this.value = result;
            }
            else if (this._type == DataType.Date)
            {
                DateTime date;
                if (!DateTime.TryParse(this.valueTextBox.Text, out date))
                {
                    MessageForm.Create("Недопустимое значение");
                    return;
                }
                this.value = date;
            }
            this.Close();
        }
    }
}
