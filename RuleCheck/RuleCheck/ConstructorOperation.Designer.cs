namespace RuleCheck
{
    partial class ConstructorOperation
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
            this.searchGroupBox1.SuspendLayout();
            this.tableGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableGroupBox
            // 
            this.tableGroupBox.Enter += new System.EventHandler(this.tableGroupBox_Enter);
            // 
            // ConstructorOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Name = "ConstructorOperation";
            this.Controls.SetChildIndex(this.searchGroupBox1, 0);
            this.Controls.SetChildIndex(this.tableGroupBox, 0);
            this.searchGroupBox1.ResumeLayout(false);
            this.searchGroupBox1.PerformLayout();
            this.tableGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}