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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrationForm));
            this.operationButton = new System.Windows.Forms.Button();
            this.ruleButton = new System.Windows.Forms.Button();
            this.operationGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ruleGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.operationGroupBox.SuspendLayout();
            this.ruleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationButton
            // 
            this.operationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationButton.Location = new System.Drawing.Point(190, 77);
            this.operationButton.Name = "operationButton";
            this.operationButton.Size = new System.Drawing.Size(143, 23);
            this.operationButton.TabIndex = 0;
            this.operationButton.Text = "Конструктор операций...";
            this.operationButton.UseVisualStyleBackColor = true;
            this.operationButton.Click += new System.EventHandler(this.OnClickOperationButton);
            // 
            // ruleButton
            // 
            this.ruleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ruleButton.Location = new System.Drawing.Point(206, 77);
            this.ruleButton.Name = "ruleButton";
            this.ruleButton.Size = new System.Drawing.Size(127, 23);
            this.ruleButton.TabIndex = 1;
            this.ruleButton.Text = "Конструктор правил...";
            this.ruleButton.UseVisualStyleBackColor = true;
            this.ruleButton.Click += new System.EventHandler(this.OnClickRuleButton);
            // 
            // operationGroupBox
            // 
            this.operationGroupBox.Controls.Add(this.label1);
            this.operationGroupBox.Controls.Add(this.operationButton);
            this.operationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.operationGroupBox.Name = "operationGroupBox";
            this.operationGroupBox.Size = new System.Drawing.Size(339, 106);
            this.operationGroupBox.TabIndex = 2;
            this.operationGroupBox.TabStop = false;
            this.operationGroupBox.Text = "Операции";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // ruleGroupBox
            // 
            this.ruleGroupBox.Controls.Add(this.label2);
            this.ruleGroupBox.Controls.Add(this.ruleButton);
            this.ruleGroupBox.Location = new System.Drawing.Point(12, 150);
            this.ruleGroupBox.Name = "ruleGroupBox";
            this.ruleGroupBox.Size = new System.Drawing.Size(339, 106);
            this.ruleGroupBox.TabIndex = 3;
            this.ruleGroupBox.TabStop = false;
            this.ruleGroupBox.Text = "Правила";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Просмотр, добавление, изменение и удаление правил.\r\nПравило - список операций, ко" +
    "торые необходимо проверить.";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(276, 266);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Назад";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.OnClickExitButton);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 301);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.ruleGroupBox);
            this.Controls.Add(this.operationGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 339);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 339);
            this.Name = "AdministrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование";
            this.operationGroupBox.ResumeLayout(false);
            this.operationGroupBox.PerformLayout();
            this.ruleGroupBox.ResumeLayout(false);
            this.ruleGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button operationButton;
        private System.Windows.Forms.Button ruleButton;
        private System.Windows.Forms.GroupBox operationGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ruleGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exitButton;
    }
}