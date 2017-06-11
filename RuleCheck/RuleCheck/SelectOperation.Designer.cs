namespace RuleCheck
{
    partial class SelectOperation
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
            this.selectButton = new System.Windows.Forms.Button();
            this.searchGroupBox1.SuspendLayout();
            this.tableGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableGroupBox
            // 
            this.tableGroupBox.Controls.Add(this.selectButton);
            this.tableGroupBox.Controls.SetChildIndex(this.closeButton, 0);
            this.tableGroupBox.Controls.SetChildIndex(this.selectButton, 0);
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectButton.Location = new System.Drawing.Point(397, 352);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(76, 23);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.OnClickSelectButton);
            // 
            // SelectOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Name = "SelectOperation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingForm);
            this.Controls.SetChildIndex(this.searchGroupBox1, 0);
            this.Controls.SetChildIndex(this.tableGroupBox, 0);
            this.searchGroupBox1.ResumeLayout(false);
            this.searchGroupBox1.PerformLayout();
            this.tableGroupBox.ResumeLayout(false);
            this.tableGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
    }
}