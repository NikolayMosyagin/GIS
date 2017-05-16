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
            this.functionNameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.objectTypeLabel1 = new System.Windows.Forms.Label();
            this.objectTypeLabel2 = new System.Windows.Forms.Label();
            this.operationTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.objectTypeBox1 = new System.Windows.Forms.ComboBox();
            this.objectTypeBox2 = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(378, 318);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(94, 32);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.OnClickCloseButton);
            // 
            // applyButton
            // 
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.applyButton.Location = new System.Drawing.Point(258, 318);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(94, 32);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnClickApplyButton);
            // 
            // functionNameLabel
            // 
            this.functionNameLabel.AutoSize = true;
            this.functionNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.functionNameLabel.Location = new System.Drawing.Point(12, 35);
            this.functionNameLabel.Name = "functionNameLabel";
            this.functionNameLabel.Size = new System.Drawing.Size(95, 16);
            this.functionNameLabel.TabIndex = 2;
            this.functionNameLabel.Text = "Имя функции";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(12, 117);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(73, 16);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Описание";
            // 
            // objectTypeLabel1
            // 
            this.objectTypeLabel1.AutoSize = true;
            this.objectTypeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectTypeLabel1.Location = new System.Drawing.Point(12, 223);
            this.objectTypeLabel1.Name = "objectTypeLabel1";
            this.objectTypeLabel1.Size = new System.Drawing.Size(101, 16);
            this.objectTypeLabel1.TabIndex = 4;
            this.objectTypeLabel1.Text = "Тип объекта 1";
            // 
            // objectTypeLabel2
            // 
            this.objectTypeLabel2.AutoSize = true;
            this.objectTypeLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectTypeLabel2.Location = new System.Drawing.Point(12, 267);
            this.objectTypeLabel2.Name = "objectTypeLabel2";
            this.objectTypeLabel2.Size = new System.Drawing.Size(101, 16);
            this.objectTypeLabel2.TabIndex = 5;
            this.objectTypeLabel2.Text = "Тип объекта 2";
            // 
            // operationTextBox
            // 
            this.operationTextBox.Location = new System.Drawing.Point(123, 35);
            this.operationTextBox.Multiline = true;
            this.operationTextBox.Name = "operationTextBox";
            this.operationTextBox.Size = new System.Drawing.Size(349, 20);
            this.operationTextBox.TabIndex = 6;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(123, 119);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(349, 82);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // objectTypeBox1
            // 
            this.objectTypeBox1.FormattingEnabled = true;
            this.objectTypeBox1.Location = new System.Drawing.Point(123, 223);
            this.objectTypeBox1.Name = "objectTypeBox1";
            this.objectTypeBox1.Size = new System.Drawing.Size(349, 21);
            this.objectTypeBox1.TabIndex = 8;
            // 
            // objectTypeBox2
            // 
            this.objectTypeBox2.FormattingEnabled = true;
            this.objectTypeBox2.Location = new System.Drawing.Point(123, 266);
            this.objectTypeBox2.Name = "objectTypeBox2";
            this.objectTypeBox2.Size = new System.Drawing.Size(349, 21);
            this.objectTypeBox2.TabIndex = 9;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(12, 78);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(74, 16);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(123, 77);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(349, 20);
            this.nameTextBox.TabIndex = 11;
            // 
            // InfoOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.objectTypeBox2);
            this.Controls.Add(this.objectTypeBox1);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.operationTextBox);
            this.Controls.Add(this.objectTypeLabel2);
            this.Controls.Add(this.objectTypeLabel1);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.functionNameLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.closeButton);
            this.Name = "InfoOperation";
            this.Text = "Операция";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label functionNameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label objectTypeLabel1;
        private System.Windows.Forms.Label objectTypeLabel2;
        private System.Windows.Forms.TextBox operationTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox objectTypeBox1;
        private System.Windows.Forms.ComboBox objectTypeBox2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}