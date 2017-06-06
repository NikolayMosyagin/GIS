namespace RuleCheck
{
    partial class InfoSession
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
            this.creationDateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.table = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.operationLabel = new System.Windows.Forms.Label();
            this.operationTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultComboBox = new System.Windows.Forms.ComboBox();
            this.InfoGroupBox = new System.Windows.Forms.GroupBox();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstObjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondObjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.InfoGroupBox.SuspendLayout();
            this.searchGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // creationDateLabel
            // 
            this.creationDateLabel.AutoSize = true;
            this.creationDateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.creationDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.creationDateLabel.Location = new System.Drawing.Point(6, 18);
            this.creationDateLabel.Name = "creationDateLabel";
            this.creationDateLabel.Size = new System.Drawing.Size(87, 13);
            this.creationDateLabel.TabIndex = 0;
            this.creationDateLabel.Text = "Дата создания:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.Location = new System.Drawing.Point(236, 27);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 16);
            this.timeLabel.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(32, 44);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Описание:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(114, 41);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(451, 44);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(126, 27);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(451, 20);
            this.dateTextBox.TabIndex = 4;
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionColumn,
            this.firstObjectColumn,
            this.secondObjectColumn,
            this.resultColumn});
            this.table.Location = new System.Drawing.Point(6, 58);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(554, 233);
            this.table.TabIndex = 5;
            this.table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnClickCellTable);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(513, 527);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(68, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.OnClickCloseButton);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchLabel.Location = new System.Drawing.Point(6, 16);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(251, 13);
            this.searchLabel.TabIndex = 7;
            this.searchLabel.Text = "Используйте поиск для точной выборки данных";
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationLabel.Location = new System.Drawing.Point(6, 42);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(80, 13);
            this.operationLabel.TabIndex = 8;
            this.operationLabel.Text = "Имя операции";
            // 
            // operationTextBox
            // 
            this.operationTextBox.Location = new System.Drawing.Point(92, 39);
            this.operationTextBox.Name = "operationTextBox";
            this.operationTextBox.Size = new System.Drawing.Size(351, 20);
            this.operationTextBox.TabIndex = 9;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(490, 48);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(70, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.OnClickSearchButton);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLabel.Location = new System.Drawing.Point(6, 67);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(59, 13);
            this.resultLabel.TabIndex = 10;
            this.resultLabel.Text = "Результат";
            // 
            // resultComboBox
            // 
            this.resultComboBox.FormattingEnabled = true;
            this.resultComboBox.Items.AddRange(new object[] {
            "Выполнено",
            "Не выполнено"});
            this.resultComboBox.Location = new System.Drawing.Point(92, 64);
            this.resultComboBox.Name = "resultComboBox";
            this.resultComboBox.Size = new System.Drawing.Size(351, 21);
            this.resultComboBox.TabIndex = 11;
            // 
            // InfoGroupBox
            // 
            this.InfoGroupBox.Controls.Add(this.descriptionTextBox);
            this.InfoGroupBox.Controls.Add(this.creationDateLabel);
            this.InfoGroupBox.Controls.Add(this.descriptionLabel);
            this.InfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InfoGroupBox.Name = "InfoGroupBox";
            this.InfoGroupBox.Size = new System.Drawing.Size(569, 97);
            this.InfoGroupBox.TabIndex = 12;
            this.InfoGroupBox.TabStop = false;
            this.InfoGroupBox.Text = "Информация о анализе";
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.searchButton);
            this.searchGroupBox.Controls.Add(this.resultComboBox);
            this.searchGroupBox.Controls.Add(this.searchLabel);
            this.searchGroupBox.Controls.Add(this.resultLabel);
            this.searchGroupBox.Controls.Add(this.operationLabel);
            this.searchGroupBox.Controls.Add(this.operationTextBox);
            this.searchGroupBox.Location = new System.Drawing.Point(12, 115);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(569, 93);
            this.searchGroupBox.TabIndex = 13;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Поиск";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.table);
            this.groupBox1.Location = new System.Drawing.Point(12, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 307);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результаты";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "Информация результатов выполнения анализа. Макс. кол-во записей: 100. Нажмите на " +
    "ячейку с объектом, \r\nчтобы посмотреть его на карте\r\n";
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.HeaderText = "Имя операции";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            this.descriptionColumn.Width = 180;
            // 
            // firstObjectColumn
            // 
            this.firstObjectColumn.HeaderText = "Первый объект";
            this.firstObjectColumn.Name = "firstObjectColumn";
            this.firstObjectColumn.ReadOnly = true;
            this.firstObjectColumn.Width = 115;
            // 
            // secondObjectColumn
            // 
            this.secondObjectColumn.HeaderText = "Второй объект";
            this.secondObjectColumn.Name = "secondObjectColumn";
            this.secondObjectColumn.ReadOnly = true;
            this.secondObjectColumn.Width = 115;
            // 
            // resultColumn
            // 
            this.resultColumn.HeaderText = "Результат";
            this.resultColumn.Name = "resultColumn";
            this.resultColumn.ReadOnly = true;
            // 
            // InfoSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 562);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.InfoGroupBox);
            this.Controls.Add(this.searchGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "InfoSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.InfoGroupBox.ResumeLayout(false);
            this.InfoGroupBox.PerformLayout();
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label creationDateLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.TextBox operationTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.ComboBox resultComboBox;
        private System.Windows.Forms.GroupBox InfoGroupBox;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultColumn;
    }
}