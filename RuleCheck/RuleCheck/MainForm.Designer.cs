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
            this.attributeButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.operationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(404, 227);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(93, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.onClickExitButton);
            // 
            // objectTypeButton
            // 
            this.objectTypeButton.Location = new System.Drawing.Point(309, 227);
            this.objectTypeButton.Name = "objectTypeButton";
            this.objectTypeButton.Size = new System.Drawing.Size(93, 23);
            this.objectTypeButton.TabIndex = 1;
            this.objectTypeButton.Text = "Типы объектов";
            this.objectTypeButton.UseVisualStyleBackColor = true;
            this.objectTypeButton.Click += new System.EventHandler(this.onClickObjectTypeButton);
            // 
            // objectButton
            // 
            this.objectButton.Location = new System.Drawing.Point(210, 227);
            this.objectButton.Name = "objectButton";
            this.objectButton.Size = new System.Drawing.Size(93, 23);
            this.objectButton.TabIndex = 2;
            this.objectButton.Text = "Объекты";
            this.objectButton.UseVisualStyleBackColor = true;
            this.objectButton.Click += new System.EventHandler(this.OnClickObjectButton);
            // 
            // attributeButton
            // 
            this.attributeButton.Location = new System.Drawing.Point(111, 227);
            this.attributeButton.Name = "attributeButton";
            this.attributeButton.Size = new System.Drawing.Size(93, 23);
            this.attributeButton.TabIndex = 3;
            this.attributeButton.Text = "Атрибуты";
            this.attributeButton.UseVisualStyleBackColor = true;
            this.attributeButton.Click += new System.EventHandler(this.attributeButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 227);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(93, 23);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "Загрузить";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.OnClickLoadButton);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(485, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // operationButton
            // 
            this.operationButton.Location = new System.Drawing.Point(309, 198);
            this.operationButton.Name = "operationButton";
            this.operationButton.Size = new System.Drawing.Size(93, 23);
            this.operationButton.TabIndex = 6;
            this.operationButton.Text = "Операции";
            this.operationButton.UseVisualStyleBackColor = true;
            this.operationButton.Click += new System.EventHandler(this.OnClickOperationButton);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 262);
            this.Controls.Add(this.operationButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.attributeButton);
            this.Controls.Add(this.objectButton);
            this.Controls.Add(this.objectTypeButton);
            this.Controls.Add(this.exitButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.onShownMainForm);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button objectTypeButton;
        private System.Windows.Forms.Button objectButton;
        private System.Windows.Forms.Button attributeButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button operationButton;
    }
}

