namespace RuleCheck
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.objectTypeButton = new System.Windows.Forms.Button();
            this.objectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(310, 227);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.onClickExitButton);
            // 
            // objectTypeButton
            // 
            this.objectTypeButton.Location = new System.Drawing.Point(196, 227);
            this.objectTypeButton.Name = "objectTypeButton";
            this.objectTypeButton.Size = new System.Drawing.Size(93, 23);
            this.objectTypeButton.TabIndex = 1;
            this.objectTypeButton.Text = "Типы объектов";
            this.objectTypeButton.UseVisualStyleBackColor = true;
            this.objectTypeButton.Click += new System.EventHandler(this.onClickObjectTypeButton);
            // 
            // objectButton
            // 
            this.objectButton.Location = new System.Drawing.Point(90, 227);
            this.objectButton.Name = "objectButton";
            this.objectButton.Size = new System.Drawing.Size(75, 23);
            this.objectButton.TabIndex = 2;
            this.objectButton.Text = "Объекты";
            this.objectButton.UseVisualStyleBackColor = true;
            this.objectButton.Click += new System.EventHandler(this.OnClickObjectButton);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 262);
            this.Controls.Add(this.objectButton);
            this.Controls.Add(this.objectTypeButton);
            this.Controls.Add(this.exitButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.onShownMainForm);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button objectTypeButton;
        private System.Windows.Forms.Button objectButton;
    }
}

