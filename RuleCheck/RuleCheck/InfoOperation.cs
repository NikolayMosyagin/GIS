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

namespace RuleCheck
{
    public enum TypeOperation
    {
        Add = 0,
        Delete = 1,
        Change = 2
    }
    public partial class InfoOperation : Form
    {
        private int _id;
        private TypeOperation _type;

        public InfoOperation()
        {
            InitializeComponent();
        }

        public static InfoOperation Create(string nameOperation, TypeOperation type, int id = -1)
        {
            var form = new InfoOperation();
            form.operationTextBox.Text = nameOperation;
            form.operationTextBox.ReadOnly = true;
            form._type = type;
            if (id > 0)
            {
                form._id = id;
            }
            form.Show();
            return form;
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickApplyButton(object sender, EventArgs e)
        {
            switch (this._type)
            {
                case TypeOperation.Add:
                    this.Add();
                    break;
                default:
                    return;
            }
                
        }

        private void Add()
        {
            string query = "insert into {0}(first_object_type_id, second_object_type_id, operation_name, operation_procedure)" +
                " values(:id1, :id2, :name, :procedure)";
            QueryProvider.Execute(string.Format(query, Config.s_storage_operation), new OracleParameter[4]
            {
                new OracleParameter("id1", 1),
                new OracleParameter("id2", 2),
                new OracleParameter("name", "FIRST"),
                new OracleParameter("procedure", this.operationTextBox.Text),
            });
        }
    }
}
