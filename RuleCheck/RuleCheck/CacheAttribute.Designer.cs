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
            this.closeButton = new System.Windows.Forms.Button();
            this.analisysButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.AttributeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numObjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.table.Location = new System.Drawing.Point(12, 48);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(575, 342);
            this.table.TabIndex = 0;
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
            // CacheAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 493);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.analisysButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.table);
            this.Name = "CacheAttribute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Значения атрибутов";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

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
    }
}