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
    public partial class InfoSession : Form
    {
        private int _session_id;
        public InfoSession()
        {
            InitializeComponent();
        }

        public static InfoSession Create(int session_id, string date, string description)
        {
            var form = new InfoSession();
            form._session_id = session_id;
            form.dateTextBox.Text = date;
            form.dateTextBox.ReadOnly = true;
            form.descriptionTextBox.Text = description;
            form.descriptionTextBox.ReadOnly = true;
            form.LoadData();
            form.Show();
            return form;
        }

        private void LoadData()
        {
            string query = "select {0}.first_object_id, {0}.second_object_id," + 
                " {0}.result, {1}.operation_description from {0} inner join {1} on " +
                "{0}.operation_id = {1}.operation_id where {0}.session_id = :session_id";
            var result = QueryProvider.Execute(string.Format(query, Config.s_log, Config.s_operation), new OracleParameter[1]
            {
                new OracleParameter("session_id", this._session_id),
            });
            
            for (int i = 0; i < result.values.Count; ++i)
            {
                int status = int.Parse(result.values[i][2].ToString());
                this.table.Rows.Add(result.values[i][3], result.values[i][0],
                    result.values[i][1], status == 1 ? "Выполнено" : "Не выполнено");
            }
            //this.dateTextBox.Text = 
        }

        private void OnClickCloseButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
