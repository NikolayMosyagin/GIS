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
    public partial class ConstructorRule : ConstructorBase
    {
        protected override void LoadData()
        {
            base.LoadData();
            string query = "select {0}.rule_id, {0}.rule_name, {0}.rule_description" +
                " from {0} where rownum <= :first";
            var parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("first", Config.maxCountRow));
            if (!string.IsNullOrEmpty(this.searchTextBox.Text))
            {
                query = query + " and SUBSTR({0}.rule_name, 1, :second) = :third";
                parameters.Add(new OracleParameter("second", this.searchTextBox.Text.Length));
                parameters.Add(new OracleParameter("third", this.searchTextBox.Text));
            }
            var result = QueryProvider.Execute(string.Format(query, Config.s_rule), parameters.ToArray());
            for (int i = 0; i < result.values.Count; ++i)
            {
                this.data.Add(new KeyValuePair<string, string>(result.values[i][1].ToString(), result.values[i][2].ToString()));
                this.ids.Add(int.Parse(result.values[i][0].ToString()));
                this.table.Rows.Add(result.values[i][1], result.values[i][2]);
            }
        }

        public override string getInfoLabelText
        {
            get
            {
                return "Информация о существующих правилах. Добавьте новое правило или измените/удалите\nранее созданное. " + base.getInfoLabelText;
            }
        }

        protected override bool RefreshButtons()
        {
            var result = base.RefreshButtons();
            this.addButton.Enabled = true;
            if (!result)
            {
                this.deleteButton.Enabled = true;
                this.updateButton.Enabled = true;
            }
            return true;
        }

        public override string TextForm
        {
            get
            {
                return "Конструктор правил";
            }
        }

        public override string searchName
        {
            get
            {
                return "rule_name";
            }
        }

        protected override void OnAdd()
        {
            this.Hide();
            var form = RuleProcessing.Create();
            form.onClose = (f) =>
            {
                this.Show();
                if (f.id != -1)
                {
                    if (string.IsNullOrEmpty(this.searchTextBox.Text) || f.name.StartsWith(this.searchTextBox.Text))
                    {
                        this.ids.Add(f.id);
                        this.data.Add(new KeyValuePair<string, string>(f.name, f.description));
                        this.table.Rows.Add(f.name, f.description);
                    }
                }
            };
        }

        public override string onDeleteText
        {
            get
            {
                return this.table.SelectedRows.Count == 0 ? "правило"
                       : "правило " + this.data[this.table.SelectedRows[0].Index].Key;
            }
        }

        protected override void OnDelete()
        {
            int num = this.table.SelectedRows[0].Index;
            int id = this.ids[num];
            this.ids.RemoveAt(num);
            this.data.RemoveAt(num);
            this.table.Rows.RemoveAt(num);
            string query = "delete from {0} where {0}.rule_id = :id";
            QueryProvider.Execute(string.Format(query, Config.s_rule_operation), new OracleParameter[1]
            {
                new OracleParameter("id", id),
            });
            QueryProvider.Execute(string.Format(query, Config.s_rule), new OracleParameter[1]
            {
                new OracleParameter("id", id),
            });
            MessageForm.Create("Правило успешно удалено!").FormClosing += (s, e) =>
            {
                this.Enabled = true;
            };
        }

        protected override void OnUpdate()
        {
            this.Hide();
            int num = this.table.SelectedRows[0].Index;
            var form = RuleProcessing.Create(this.ids[num]);
            form.onClose = (f) =>
            {
                this.Show();
                if (string.IsNullOrEmpty(this.searchTextBox.Text) || f.name.StartsWith(this.searchTextBox.Text))
                {
                    this.data[num] = new KeyValuePair<string, string>(f.name, f.description);
                    this.table.Rows[num].SetValues(f.name, f.description);
                }
                else
                {
                    this.ids.RemoveAt(num);
                    this.table.Rows.RemoveAt(num);
                    this.data.RemoveAt(num);
                }
            };
        }
    }
}
