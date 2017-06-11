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
        private bool _isUnary;

        public Action<InfoOperation> onClose;

        public InfoOperation()
        {
            InitializeComponent();
            this.objectTypeIds = new List<int>();
            this.FillObjectType();
        }

        public static InfoOperation Create(string nameOperation, TypeOperation type, bool isUnary, int id = -1)
        {
            var form = new InfoOperation();
            form.operationTextBox.Text = nameOperation;
            form.operationTextBox.ReadOnly = true;
            form._type = type;
            form.id = id;
            form._isUnary = isUnary;
            form.objectTypeBox2.Enabled = !isUnary;
            form.objectTypeLabel2.Enabled = !isUnary;
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
            var result = QueryProvider.Execute(string.Format(query, Config.s_object_type), null);
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
            string query = "select {0}.first_object_type_id, {0}.second_object_type_id, " +
                "{0}.operation_procedure, {0}.operation_description, " +  
                "{0}.operation_name from {0} where {0}.operation_id = :operation_id";

            var result = QueryProvider.Execute(string.Format(query, Config.s_operation), new OracleParameter[1]
            {
                new OracleParameter("operation_id", this.id),
            });
            if (result.values.Count > 0)
            {
                int first_id = int.Parse(result.values[0][0].ToString());
                int second_id = this._isUnary ? -1 : int.Parse(result.values[0][1].ToString());
                string procedure = result.values[0][2].ToString();
                this.description = result.values[0][3] != null ? result.values[0][3].ToString() : "";
                this.operationTextBox.Text = procedure;
                this.descriptionTextBox.Text = this.description;
                this.nameTextBox.Text = result.values[0][4].ToString();
                
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
            if (this.objectTypeBox2.SelectedIndex < 0 && !this._isUnary)
            {
                var f = MessageForm.Create("Необходимо выбрать тип объекта 2");
                return false;
            }
            if (string.IsNullOrEmpty(this.nameTextBox.Text))
            {
                MessageForm.Create("Необходимо задать название операции");
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
            string query = "insert into {0}(first_object_type_id, {1}operation_name, operation_procedure, " + 
                "operation_description)" +
                " values(:id1, {2}:name, :procedure, :description) returning {0}.operation_id into :operation_id";
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("id1", this.objectTypeIds[this.objectTypeBox1.SelectedIndex]));
            if (!this._isUnary)
            {
                parameters.Add(new OracleParameter("id2", this.objectTypeIds[this.objectTypeBox2.SelectedIndex]));
            }
            parameters.Add(new OracleParameter("name", this.nameTextBox.Text));
            parameters.Add(new OracleParameter("procedure", this.operationTextBox.Text));
            parameters.Add(new OracleParameter("description", this.descriptionTextBox.Text));
            parameters.Add(new OracleParameter("operation_id", OracleDbType.Decimal, ParameterDirection.Output));
            var result = QueryProvider.Execute(
                string.Format(query, 
                    Config.s_operation, 
                    !this._isUnary ? "second_object_type_id, " : "", 
                    !this._isUnary ? ":id2, " : ""), 
                parameters.ToArray());
            this.id = ((OracleDecimal)result.parametersOut[0]).ToInt32();
            this.description = this.descriptionTextBox.Text;
        }

        private void Change()
        {
            if (!this.CheckSelectedData())
            {
                return;
            }
            string query = "update {0} set {0}.first_object_type_id = :first, ";
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("first", this.objectTypeIds[this.objectTypeBox1.SelectedIndex]));
            if (!this._isUnary)
            {
                query = query + "{0}.second_object_type_id = :second, ";
                parameters.Add(new OracleParameter("second", this.objectTypeIds[this.objectTypeBox2.SelectedIndex]));
            } 
            query = query + "{0}.operation_procedure = :procedure, {0}.operation_description = :description, " +
                "{0}.operation_name = :name where {0}.operation_id = :operation_id";
            parameters.Add(new OracleParameter("procedure", this.operationTextBox.Text));
            parameters.Add(new OracleParameter("description", this.descriptionTextBox.Text));
            parameters.Add(new OracleParameter("name", this.nameTextBox.Text));
            parameters.Add(new OracleParameter("operation_id", this.id));
            QueryProvider.Execute(string.Format(query, Config.s_operation), parameters.ToArray());                
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
