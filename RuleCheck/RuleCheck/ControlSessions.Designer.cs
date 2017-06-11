namespace RuleCheck
{
    partial class ControlSessions
    {
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public override void InitializeComponent()
        {
            base.InitializeComponent();
            this.fromLabel = new System.Windows.Forms.Label();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.searchGroupBox1.SuspendLayout();
            this.tableGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchGroupBox1
            // 
            this.searchGroupBox1.Controls.Add(this.dateTimeTo);
            this.searchGroupBox1.Controls.Add(this.labelTo);
            this.searchGroupBox1.Controls.Add(this.dateTimeFrom);
            this.searchGroupBox1.Controls.Add(this.fromLabel);
            this.searchGroupBox1.Controls.SetChildIndex(this.searchTextBox, 0);
            this.searchGroupBox1.Controls.SetChildIndex(this.fromLabel, 0);
            this.searchGroupBox1.Controls.SetChildIndex(this.dateTimeFrom, 0);
            this.searchGroupBox1.Controls.SetChildIndex(this.labelTo, 0);
            this.searchGroupBox1.Controls.SetChildIndex(this.dateTimeTo, 0);
            this.searchGroupBox1.Controls.SetChildIndex(this.searchButton, 0);
            this.searchGroupBox1.Controls.SetChildIndex(this.searchLabel, 0);
            this.searchGroupBox1.Controls.SetChildIndex(this.label1, 0);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(98, 42);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(17, 13);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "С:";
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFrom.Location = new System.Drawing.Point(128, 39);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(331, 20);
            this.dateTimeFrom.TabIndex = 7;
            this.dateTimeFrom.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // labelTo
            // 
            this.labelTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(98, 65);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(24, 13);
            this.labelTo.TabIndex = 8;
            this.labelTo.Text = "По:";
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTo.Location = new System.Drawing.Point(128, 65);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(331, 20);
            this.dateTimeTo.TabIndex = 9;
            this.dateTimeTo.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // ControlSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Name = "ControlSessions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.ControlSessions_Load);
            this.Controls.SetChildIndex(this.searchGroupBox1, 0);
            this.Controls.SetChildIndex(this.tableGroupBox, 0);
            this.searchGroupBox1.ResumeLayout(false);
            this.searchGroupBox1.PerformLayout();
            this.tableGroupBox.ResumeLayout(false);
            this.tableGroupBox.PerformLayout();
            this.ResumeLayout(false);

    }
        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.Label labelTo;
    }
}