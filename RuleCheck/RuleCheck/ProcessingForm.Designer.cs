namespace RuleCheck
{
    partial class ProcessingForm
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
        protected void InitializeComponent()
        {
            this.currentList = new System.Windows.Forms.ListBox();
            this.availableList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.availableLabel = new System.Windows.Forms.Label();
            this.currentLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentList
            // 
            this.currentList.FormattingEnabled = true;
            this.currentList.Location = new System.Drawing.Point(12, 46);
            this.currentList.Name = "currentList";
            this.currentList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.currentList.Size = new System.Drawing.Size(142, 212);
            this.currentList.TabIndex = 1;
            // 
            // availableList
            // 
            this.availableList.FormattingEnabled = true;
            this.availableList.Location = new System.Drawing.Point(303, 46);
            this.availableList.Name = "availableList";
            this.availableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.availableList.Size = new System.Drawing.Size(142, 212);
            this.availableList.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(183, 92);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(91, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "<---Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(183, 191);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(91, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить--->";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnClickDeleteButton);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(365, 274);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(80, 23);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Отмена";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.OnClickExitButton);
            // 
            // availableLabel
            // 
            this.availableLabel.AutoSize = true;
            this.availableLabel.Location = new System.Drawing.Point(300, 19);
            this.availableLabel.Name = "availableLabel";
            this.availableLabel.Size = new System.Drawing.Size(64, 13);
            this.availableLabel.TabIndex = 7;
            this.availableLabel.Text = "Доступные";
            this.availableLabel.SizeChanged += new System.EventHandler(this.OnSizeChangeAvailableLable);
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(12, 19);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(78, 13);
            this.currentLabel.TabIndex = 8;
            this.currentLabel.Text = "Добавленные";
            this.currentLabel.SizeChanged += new System.EventHandler(this.OnSizeChangedCurrentLabel);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(253, 274);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(80, 23);
            this.applyButton.TabIndex = 9;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnClickApplyButton);
            // 
            // ProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 309);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.availableLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.availableList);
            this.Controls.Add(this.currentList);
            this.Name = "ProcessingForm";
            this.Text = "ProcessingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ListBox currentList;
        protected System.Windows.Forms.ListBox availableList;
        protected System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.Button deleteButton;
        protected System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label availableLabel;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Button applyButton;
    }
}