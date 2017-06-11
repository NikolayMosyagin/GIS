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
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.searchGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeColumn,
            this.ObjectColumn,
            this.numObjectColumn,
            this.ValueColumn});
            this.table.Location = new System.Drawing.Point(0, 64);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(575, 272);
            this.table.TabIndex = 0;
            this.table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnClickCellTable);
            // 
            // AttributeColumn
            // 
            this.AttributeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AttributeColumn.HeaderText = "Атрибут";
            this.AttributeColumn.Name = "AttributeColumn";
            this.AttributeColumn.ReadOnly = true;
            // 
            // ObjectColumn
            // 
            this.ObjectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ObjectColumn.HeaderText = "Объект";
            this.ObjectColumn.Name = "ObjectColumn";
            this.ObjectColumn.ReadOnly = true;
            // 
            // numObjectColumn
            // 
            this.numObjectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numObjectColumn.HeaderText = "Номер объекта";
            this.numObjectColumn.Name = "numObjectColumn";
            this.numObjectColumn.ReadOnly = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueColumn.HeaderText = "Значение";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(504, 342);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(71, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.OnClickCloseButton);
            // 
            // analisysButton
            // 
            this.analisysButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.analisysButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analisysButton.Location = new System.Drawing.Point(338, 342);
            this.analisysButton.Name = "analisysButton";
            this.analisysButton.Size = new System.Drawing.Size(79, 23);
            this.analisysButton.TabIndex = 2;
            this.analisysButton.Text = "Анализ...";
            this.analisysButton.UseVisualStyleBackColor = true;
            this.analisysButton.Click += new System.EventHandler(this.OnClickAnalisysButton);
            // 
            // changeButton
            // 
            this.changeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeButton.Location = new System.Drawing.Point(423, 342);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 3;
            this.changeButton.Text = "Изменить...";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.OnClickChangeButton);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchLabel.Location = new System.Drawing.Point(6, 16);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(284, 13);
            this.searchLabel.TabIndex = 4;
            this.searchLabel.Text = "Используйте поиск для более точной выборки данных";
            // 
            // attributeLabel
            // 
            this.attributeLabel.AutoSize = true;
            this.attributeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attributeLabel.Location = new System.Drawing.Point(6, 38);
            this.attributeLabel.Name = "attributeLabel";
            this.attributeLabel.Size = new System.Drawing.Size(47, 13);
            this.attributeLabel.TabIndex = 5;
            this.attributeLabel.Text = "Атрибут";
            // 
            // attributeTextBox
            // 
            this.attributeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attributeTextBox.Location = new System.Drawing.Point(59, 35);
            this.attributeTextBox.Name = "attributeTextBox";
            this.attributeTextBox.Size = new System.Drawing.Size(405, 20);
            this.attributeTextBox.TabIndex = 6;
            // 
            // objectLabel
            // 
            this.objectLabel.AutoSize = true;
            this.objectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectLabel.Location = new System.Drawing.Point(8, 64);
            this.objectLabel.Name = "objectLabel";
            this.objectLabel.Size = new System.Drawing.Size(45, 13);
            this.objectLabel.TabIndex = 7;
            this.objectLabel.Text = "Объект";
            // 
            // objectTextBox
            // 
            this.objectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectTextBox.Location = new System.Drawing.Point(57, 61);
            this.objectTextBox.Name = "objectTextBox";
            this.objectTextBox.Size = new System.Drawing.Size(407, 20);
            this.objectTextBox.TabIndex = 8;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(500, 45);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(69, 23);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Искать";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.OnClickSearchButton);
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchGroupBox.Controls.Add(this.searchButton);
            this.searchGroupBox.Controls.Add(this.searchLabel);
            this.searchGroupBox.Controls.Add(this.objectTextBox);
            this.searchGroupBox.Controls.Add(this.attributeTextBox);
            this.searchGroupBox.Controls.Add(this.objectLabel);
            this.searchGroupBox.Controls.Add(this.attributeLabel);
            this.searchGroupBox.Location = new System.Drawing.Point(12, 12);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(575, 89);
            this.searchGroupBox.TabIndex = 10;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Поиск";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.table);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.analisysButton);
            this.groupBox1.Controls.Add(this.closeButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 374);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(565, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "Информация о значениях объектов, которые использовались в анализе. Макс. кол-во с" +
    "трок: 100. Выберите \r\nячейку с номером объекта, чтобы посмотреть на карте.\r\n\r\n";
            // 
            // CacheAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 493);
            this.Controls.Add(this.searchGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "CacheAttribute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Значения атрибутов";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button analisysButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label attributeLabel;
        private System.Windows.Forms.TextBox attributeTextBox;
        private System.Windows.Forms.Label objectLabel;
        private System.Windows.Forms.TextBox objectTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
    }
}