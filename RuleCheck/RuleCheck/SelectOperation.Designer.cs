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
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectButton.Location = new System.Drawing.Point(225, 318);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(94, 32);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.OnClickSelectButton);
            // 
            // SelectOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.selectButton);
            this.Name = "SelectOperation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingForm);
            this.Controls.SetChildIndex(this.selectButton, 0);
            this.Controls.SetChildIndex(this.searchLabel, 0);
            this.Controls.SetChildIndex(this.searchTextBox, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
    }
}