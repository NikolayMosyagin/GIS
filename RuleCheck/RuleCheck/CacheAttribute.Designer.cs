namespace RuleCheck
{
    partial class CacheAttribute
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
            this.table = new System.Windows.Forms.DataGridView();
            this.AttributeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numObjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.analisysButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.attributeLabel = new System.Windows.Forms.Label();
            this.attributeTextBox = new System.Windows.Forms.TextBox();
            this.objectLabel = new System.Windows.Forms.Label();
            this.objectTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeColumn,
            this.ObjectColumn,
            this.numObjectColumn,
            this.ValueColumn});
            this.table.Location = new System.Drawing.Point(12, 92);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(575, 332);
            this.table.TabIndex = 0;
            // 
            // AttributeColumn
            // 
            this.AttributeColumn.HeaderText = "Атрибут";
            this.AttributeColumn.Name = "AttributeColumn";
            this.AttributeColumn.ReadOnly = true;
            this.AttributeColumn.Width = 150;
            // 
            // ObjectColumn
            // 
            this.ObjectColumn.HeaderText = "Объект";
            this.ObjectColumn.Name = "ObjectColumn";
            this.ObjectColumn.ReadOnly = true;
            this.ObjectColumn.Width = 150;
            // 
            // numObjectColumn
            // 
            this.numObjectColumn.HeaderText = "Номер объекта";
            this.numObjectColumn.Name = "numObjectColumn";
            this.numObjectColumn.ReadOnly = true;
            this.numObjectColumn.Width = 110;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Значение";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            this.ValueColumn.Width = 120;
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(493, 449);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(94, 32);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.OnClickCloseButton);
            // 
            // analisysButton
            // 
            this.analisysButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analisysButton.Location = new System.Drawing.Point(293, 449);
            this.analisysButton.Name = "analisysButton";
            this.analisysButton.Size = new System.Drawing.Size(94, 32);
            this.analisysButton.TabIndex = 2;
            this.analisysButton.Text = "Анализ";
            this.analisysButton.UseVisualStyleBackColor = true;
            this.analisysButton.Click += new System.EventHandler(this.OnClickAnalisysButton);
            // 
            // changeButton
            // 
            this.changeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeButton.Location = new System.Drawing.Point(393, 449);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(94, 32);
            this.changeButton.TabIndex = 3;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.OnClickChangeButton);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchLabel.Location = new System.Drawing.Point(9, 9);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(51, 16);
            this.searchLabel.TabIndex = 4;
            this.searchLabel.Text = "Поиск:";
            // 
            // attributeLabel
            // 
            this.attributeLabel.AutoSize = true;
            this.attributeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attributeLabel.Location = new System.Drawing.Point(41, 36);
            this.attributeLabel.Name = "attributeLabel";
            this.attributeLabel.Size = new System.Drawing.Size(63, 16);
            this.attributeLabel.TabIndex = 5;
            this.attributeLabel.Text = "Атрибут";
            // 
            // attributeTextBox
            // 
            this.attributeTextBox.Location = new System.Drawing.Point(110, 36);
            this.attributeTextBox.Name = "attributeTextBox";
            this.attributeTextBox.Size = new System.Drawing.Size(239, 20);
            this.attributeTextBox.TabIndex = 6;
            // 
            // objectLabel
            // 
            this.objectLabel.AutoSize = true;
            this.objectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectLabel.Location = new System.Drawing.Point(47, 66);
            this.objectLabel.Name = "objectLabel";
            this.objectLabel.Size = new System.Drawing.Size(57, 16);
            this.objectLabel.TabIndex = 7;
            this.objectLabel.Text = "Объект";
            // 
            // objectTextBox
            // 
            this.objectTextBox.Location = new System.Drawing.Point(110, 66);
            this.objectTextBox.Name = "objectTextBox";
            this.objectTextBox.Size = new System.Drawing.Size(239, 20);
            this.objectTextBox.TabIndex = 8;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(468, 45);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(94, 32);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.OnClickSearchButton);
            // 
            // CacheAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 493);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.objectTextBox);
            this.Controls.Add(this.objectLabel);
            this.Controls.Add(this.attributeTextBox);
            this.Controls.Add(this.attributeLabel);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.analisysButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.table);
            this.Name = "CacheAttribute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Значения атрибутов";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button analisysButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label attributeLabel;
        private System.Windows.Forms.TextBox attributeTextBox;
        private System.Windows.Forms.Label objectLabel;
        private System.Windows.Forms.TextBox objectTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}