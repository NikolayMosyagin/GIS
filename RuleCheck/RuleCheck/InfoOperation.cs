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
using Oracle.ManagedDataAccess.Types;

namespace RuleCheck
{
    public enum TypeOperation
    {
        Add = 0,
        Change = 1,
    }
    public partial class InfoOperation : Form
    {
        public int id;
        public string description;
        private TypeOperation _type;
        private List<int> objectTypeIds;

        public Action<InfoOperation> onClose;

        public InfoOperation()
        {
            InitializeComponent();
            this.objectTypeIds = new List<int>();
            this.FillObjectType();
        }

        public static InfoOperation Create(string nameOperation, TypeOperation type, int id = -1)
        {
            var form = new InfoOperation();
            form.operationTextBox.Text = nameOperation;
            form.operationTextBox.ReadOnly = true;
            form._type = type;
            if (id > 0)
            {
                form.id = id;
            }
            if (type == TypeOperation.Change)
            {
                form.LoadOperationData();
            }
            form.Show();
            return form;
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillObjectType()
        {
            string query = "select {0}.object_type_id, {0}.object_name from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_object_type), null);
            if (result != null && result.values != null)
            {
                for (int i = 0; i < result.values.Count; ++i)
                {
                    this.objectTypeBox1.Items.Add(result.values[i][1]);
                    this.objectTypeBox2.Items.Add(result.values[i][1]);
                    this.objectTypeIds.Add(int.Parse(result.values[i][0].ToString()));
                }
            }
        }

        private void LoadOperationData()
        {
            string query = "select {0}.first_object_type_id, {0}.second_object_type_id," +
                " {0}.operation_procedure, {0}.operation_description" +
                " from {0} where {0}.operation_id = :operation_id";

            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_operation), new OracleParameter[1]
            {
                new OracleParameter("operation_id", this.id),
            });
            if (result != null && result.values != null && result.values.Count > 0)
            {
                int first_id = int.Parse(result.values[0][0].ToString());
                int second_id = int.Parse(result.values[0][1].ToString());
                string procedure = result.values[0][2].ToString();
                string description = result.values[0][3] != null ? result.values[0][3].ToString() : "";
                this.operationTextBox.Text = procedure;
                this.descriptionTextBox.Text = description;
                for (int i = 0; i < this.objectTypeIds.Count; ++i)
                {
                    if (this.objectTypeIds[i] == first_id)
                    {
                        this.objectTypeBox1.SelectedIndex = i;
                    }
                    if (this.objectTypeIds[i] == second_id)
                    {
                        this.objectTypeBox2.SelectedIndex = i;
                    }
                }
            }
        }

        private void OnClickApplyButton(object sender, EventArgs e)
        {
            switch (this._type)
            {
                case TypeOperation.Add:
                    this.Add();
                    break;
                case TypeOperation.Change:
                    this.Change();
                    break;
                default:
                    return;
            }
            this.Close();
        }

        private bool CheckSelectedData()
        {
            if (this.objectTypeBox1.SelectedIndex < 0)
            {
                var f = MessageForm.Create("Необходимо выбрать тип объекта 1");
                return false;
            }
            if (this.objectTypeBox2.SelectedIndex < 0)
            {
                var f = MessageForm.Create("Необходимо выбрать тип объекта 2");
                return false;
            }
            return true;
        }

        private void Add()
        {
            if (!this.CheckSelectedData())
            {
                return;
            }
            string query = "insert into {0}(first_object_type_id, second_object_type_id, operation_name, operation_procedure, operation_description)" +
                " values(:id1, :id2, :name, :procedure, :description) returning {0}.operation_id into :operation_id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_storage_operation), new OracleParameter[6]
            {
                new OracleParameter("id1", this.objectTypeIds[this.objectTypeBox1.SelectedIndex]),
                new OracleParameter("id2", this.objectTypeIds[this.objectTypeBox2.SelectedIndex]),
                new OracleParameter("name", "FIRST"),
                new OracleParameter("procedure", this.operationTextBox.Text),
                new OracleParameter("description", this.descriptionTextBox.Text),
                new OracleParameter("operation_id", OracleDbType.Decimal, ParameterDirection.Output)
            });
            this.id = ((OracleDecimal)result.parametersOut[0]).ToInt32();
            this.description = this.descriptionTextBox.Text;
        }

        private void Change()
        {
            if (!this.CheckSelectedData())
            {
                return;
            }
            string query = "update {0} set {0}.first_object_type_id = :first," +
                " {0}.second_object_type_id = :second, {0}.operation_procedure = :procedure," +
                " {0}.operation_description = :description" +
                " where {0}.operation_id = :operation_id";
            QueryProvider.Execute(string.Format(query, Config.s_storage_operation), new OracleParameter[5]
            {
                new OracleParameter("first", this.objectTypeIds[this.objectTypeBox1.SelectedIndex]),
                new OracleParameter("second", this.objectTypeIds[this.objectTypeBox2.SelectedIndex]),
                new OracleParameter("procedure", this.operationTextBox.Text),
                new OracleParameter("description", this.descriptionTextBox.Text),
                new OracleParameter("operation_id", this.id),
            });
            this.description = this.descriptionTextBox.Text;
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
