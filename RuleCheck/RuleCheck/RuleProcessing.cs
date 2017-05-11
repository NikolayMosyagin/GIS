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
    public partial class RuleProcessing : Form
    {
        public int id;
        public string description;
        public string name;

        private List<int> operationIds;
        private List<KeyValuePair<string, string>> infoOperations;

        public Action<RuleProcessing> onClose;

        public RuleProcessing()
        {
            InitializeComponent();
            this.operationIds = new List<int>();
            this.infoOperations = new List<KeyValuePair<string, string>>();
        }

        public static RuleProcessing Create(int id = -1)
        {
            var form = new RuleProcessing();
            if (id != -1)
            {
                form.id = id;
                form.LoadData();
            }
            form.Show();
            return form;
        }

        private void LoadData()
        {

        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
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

        private void OnClickApplyButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nameText.Text))
            {
                var form = MessageForm.Create("Необходимо указать имя правила.");
                return;
            }
            if (string.IsNullOrEmpty(this.descriptionText.Text))
            {
                var form = MessageForm.Create("Необходимо указать описание правила.");
                return;
            }
            /*if (this.operationIds.Count <= 0)
            {
                var form = MessageForm.Create("Добавьте хотя бы одну операцию.");
            }*/
            string query = "insert into {0}(rule_name, rule_description)" +
                " values(:name, :description) returning {0}.rule_id into :id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_rule), new OracleParameter[3]
            {
                new OracleParameter("name", this.nameText.Text),
                new OracleParameter("description", this.descriptionText.Text),
                new OracleParameter("id", OracleDbType.Decimal, ParameterDirection.Output),
            });
            this.id = ((OracleDecimal)result.parametersOut[0]).ToInt32();
            this.description = this.descriptionText.Text;
            this.name = this.nameText.Text;
        }
    }
}
