namespace RuleCheck
{
    partial class OperationProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
            this.closeButton = new System.Windows.Forms.Button();
            this.operationGrid = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.operationGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(283, 281);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.OnClickCloseButton);
            // 
            // operationGrid
            // 
            this.operationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.DescriptionColumn});
            this.operationGrid.Location = new System.Drawing.Point(12, 66);
            this.operationGrid.MultiSelect = false;
            this.operationGrid.Name = "operationGrid";
            this.operationGrid.ReadOnly = true;
            this.operationGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.operationGrid.Size = new System.Drawing.Size(346, 150);
            this.operationGrid.TabIndex = 1;
            this.operationGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnRowEnterOperationGrid);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Имя";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.HeaderText = "Описание";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            this.DescriptionColumn.Width = 205;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.Control;
            this.addButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addButton.Location = new System.Drawing.Point(12, 233);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(93, 233);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Изменить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.OnClickUpdateButton);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(174, 233);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnClickDeleteButton);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(9, 26);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(39, 13);
            this.searchLabel.TabIndex = 5;
            this.searchLabel.Text = "Поиск";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(54, 23);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(304, 20);
            this.searchTextBox.TabIndex = 6;
            this.searchTextBox.Text = "Введите имя...";
            this.searchTextBox.TextChanged += new System.EventHandler(this.OnChangeTextSearchTextBox);
            this.searchTextBox.Enter += new System.EventHandler(this.OnEnterSearchTextBox);
            // 
            // OperationProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 316);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.operationGrid);
            this.Controls.Add(this.closeButton);
            this.Name = "OperationProcessing";
            this.Text = "OperationProcessing";
            ((System.ComponentModel.ISupportInitialize)(this.operationGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button closeButton;
        protected System.Windows.Forms.DataGridView operationGrid;
        protected System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        protected System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.Button updateButton;
        protected System.Windows.Forms.Button deleteButton;
        protected System.Windows.Forms.Label searchLabel;
        protected System.Windows.Forms.TextBox searchTextBox;
    }
}