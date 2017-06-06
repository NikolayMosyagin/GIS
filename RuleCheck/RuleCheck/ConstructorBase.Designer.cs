namespace RuleCheck
{
    public partial class ConstructorBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchGroupBox1.SuspendLayout();
            this.tableGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableGroupBox
            // 
            this.tableGroupBox.Controls.Add(this.deleteButton);
            this.tableGroupBox.Controls.Add(this.updateButton);
            this.tableGroupBox.Controls.Add(this.addButton);
            this.tableGroupBox.Controls.SetChildIndex(this.addButton, 0);
            this.tableGroupBox.Controls.SetChildIndex(this.updateButton, 0);
            this.tableGroupBox.Controls.SetChildIndex(this.deleteButton, 0);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 324);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "button1";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(111, 324);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "button1";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.OnClickUpdateButton);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(208, 324);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "button1";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnClickDeleteButton);
            // 
            // ConstructorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Name = "ConstructorBase";
            this.Controls.SetChildIndex(this.searchGroupBox1, 0);
            this.Controls.SetChildIndex(this.tableGroupBox, 0);
            this.searchGroupBox1.ResumeLayout(false);
            this.searchGroupBox1.PerformLayout();
            this.tableGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.Button updateButton;
        protected System.Windows.Forms.Button deleteButton;
    }
}