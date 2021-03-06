﻿using System;
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
    public partial class MainForm1 : Form
    {
        public static Role currentRole;

        public MainForm1()
        {
            InitializeComponent();
        }

        private void onShownMainForm(object sender, EventArgs e)
        {
            this.LoadCache();
        }

        private void onClickObjectTypeButton(object sender, EventArgs e)
        {
            var form = new ObjectTypeProcessing();
            form.Show();
        }

        private void onClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickObjectButton(object sender, EventArgs e)
        {
            /*var form = new ObjectProcessing();
            form.Show();*/
        }


        private void OnClickLoadButton(object sender, EventArgs e)
        {
            QueryProvider.Execute("Mosyagin.Load", null, CommandType.StoredProcedure);
            this.LoadCache();
        }

        private void LoadCache()
        {
            string query = "select * from {0}";
            var result = QueryProvider.Execute(string.Format(query, Config.s_attribute), null);
            if (result != null)
            {
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.Rows.Clear();
                if (result.columnName != null)
                {
                    for (int i = 0; i < result.columnName.Count; ++i)
                    {
                        this.dataGridView1.Columns.Add(result.columnName[i], result.columnName[i]);
                    }
                }
                if (result.values != null)
                {
                    for (int i = 0; i < result.values.Count; ++i)
                    {
                        this.dataGridView1.Rows.Add(result.values[i].ToArray());
                    }
                }
            }
        }

        private void OnClickOperationButton(object sender, EventArgs e)
        {
            var form = new ConstructorOperation();
            form.Show();
        }

        private void OnClickRuleButton(object sender, EventArgs e)
        {
            var form = new ConstructorRule();
            form.Show();
        }

        private void OnClickAnalysisButton(object sender, EventArgs e)
        {
            var form = new Analysis();
            form.Show();
        }

        private void OnClickSessionButton(object sender, EventArgs e)
        {
            var form = new ControlSessions();
            ControlSessions.current = form;
            form.Show();
        }
    }
}
