namespace RuleCheck
{
    partial class AdministrationForm
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
        private void InitializeComponent()
        {
            this.operationButton = new System.Windows.Forms.Button();
            this.ruleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // operationButton
            // 
            this.operationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationButton.Location = new System.Drawing.Point(61, 46);
            this.operationButton.Name = "operationButton";
            this.operationButton.Size = new System.Drawing.Size(240, 44);
            this.operationButton.TabIndex = 0;
            this.operationButton.Text = "Конструктор операций";
            this.operationButton.UseVisualStyleBackColor = true;
            this.operationButton.Click += new System.EventHandler(this.OnClickOperationButton);
            // 
            // ruleButton
            // 
            this.ruleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ruleButton.Location = new System.Drawing.Point(61, 156);
            this.ruleButton.Name = "ruleButton";
            this.ruleButton.Size = new System.Drawing.Size(240, 44);
            this.ruleButton.TabIndex = 1;
            this.ruleButton.Text = "Конструктор правил";
            this.ruleButton.UseVisualStyleBackColor = true;
            this.ruleButton.Click += new System.EventHandler(this.OnClickRuleButton);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.ruleButton);
            this.Controls.Add(this.operationButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 300);
            this.Name = "AdministrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button operationButton;
        private System.Windows.Forms.Button ruleButton;
    }
}