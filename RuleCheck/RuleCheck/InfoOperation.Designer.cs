namespace RuleCheck
{
    partial class InfoOperation
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
            this.closeButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.objectTypeLabel1 = new System.Windows.Forms.Label();
            this.objectTypeLabel2 = new System.Windows.Forms.Label();
            this.operationTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.objectTypeBox1 = new System.Windows.Forms.ComboBox();
            this.objectTypeBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(264, 195);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.OnClickCloseButton);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(153, 195);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnClickApplyButton);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(37, 35);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(80, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Имя операции";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(37, 64);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(57, 13);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Описание";
            // 
            // objectTypeLabel1
            // 
            this.objectTypeLabel1.AutoSize = true;
            this.objectTypeLabel1.Location = new System.Drawing.Point(37, 90);
            this.objectTypeLabel1.Name = "objectTypeLabel1";
            this.objectTypeLabel1.Size = new System.Drawing.Size(80, 13);
            this.objectTypeLabel1.TabIndex = 4;
            this.objectTypeLabel1.Text = "Тип объекта 1";
            // 
            // objectTypeLabel2
            // 
            this.objectTypeLabel2.AutoSize = true;
            this.objectTypeLabel2.Location = new System.Drawing.Point(37, 117);
            this.objectTypeLabel2.Name = "objectTypeLabel2";
            this.objectTypeLabel2.Size = new System.Drawing.Size(80, 13);
            this.objectTypeLabel2.TabIndex = 5;
            this.objectTypeLabel2.Text = "Тип объекта 2";
            // 
            // operationTextBox
            // 
            this.operationTextBox.Location = new System.Drawing.Point(123, 35);
            this.operationTextBox.Name = "operationTextBox";
            this.operationTextBox.Size = new System.Drawing.Size(216, 20);
            this.operationTextBox.TabIndex = 6;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(123, 61);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(216, 20);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // objectTypeBox1
            // 
            this.objectTypeBox1.FormattingEnabled = true;
            this.objectTypeBox1.Location = new System.Drawing.Point(123, 87);
            this.objectTypeBox1.Name = "objectTypeBox1";
            this.objectTypeBox1.Size = new System.Drawing.Size(216, 21);
            this.objectTypeBox1.TabIndex = 8;
            // 
            // objectTypeBox2
            // 
            this.objectTypeBox2.FormattingEnabled = true;
            this.objectTypeBox2.Location = new System.Drawing.Point(123, 114);
            this.objectTypeBox2.Name = "objectTypeBox2";
            this.objectTypeBox2.Size = new System.Drawing.Size(216, 21);
            this.objectTypeBox2.TabIndex = 9;
            // 
            // InfoOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 230);
            this.Controls.Add(this.objectTypeBox2);
            this.Controls.Add(this.objectTypeBox1);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.operationTextBox);
            this.Controls.Add(this.objectTypeLabel2);
            this.Controls.Add(this.objectTypeLabel1);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.closeButton);
            this.Name = "InfoOperation";
            this.Text = "InfoOperation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label objectTypeLabel1;
        private System.Windows.Forms.Label objectTypeLabel2;
        private System.Windows.Forms.TextBox operationTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox objectTypeBox1;
        private System.Windows.Forms.ComboBox objectTypeBox2;
    }
}