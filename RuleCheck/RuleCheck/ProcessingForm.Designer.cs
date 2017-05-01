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
            this.SuspendLayout();
            // 
            // currentList
            // 
            this.currentList.FormattingEnabled = true;
            this.currentList.Location = new System.Drawing.Point(23, 46);
            this.currentList.Name = "currentList";
            this.currentList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.currentList.Size = new System.Drawing.Size(120, 212);
            this.currentList.TabIndex = 1;
            // 
            // availableList
            // 
            this.availableList.FormattingEnabled = true;
            this.availableList.Location = new System.Drawing.Point(266, 46);
            this.availableList.Name = "availableList";
            this.availableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.availableList.Size = new System.Drawing.Size(120, 212);
            this.availableList.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(168, 87);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(168, 192);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnClickDeleteButton);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(370, 274);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Отмена";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.OnClickExitButton);
            // 
            // ProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 309);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.availableList);
            this.Controls.Add(this.currentList);
            this.Name = "ProcessingForm";
            this.Text = "ProcessingForm";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ListBox currentList;
        protected System.Windows.Forms.ListBox availableList;
        protected System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.Button deleteButton;
        protected System.Windows.Forms.Button exitButton;
    }
}