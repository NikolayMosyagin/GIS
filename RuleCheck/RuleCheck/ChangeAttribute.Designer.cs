namespace RuleCheck
{
    partial class ChangeAttribute
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
            this.attributeName = new System.Windows.Forms.Label();
            this.attributeTextBox = new System.Windows.Forms.TextBox();
            this.objectLabel = new System.Windows.Forms.Label();
            this.objectTextBox = new System.Windows.Forms.TextBox();
            this.valueObjectLabel = new System.Windows.Forms.Label();
            this.objectValueTextBox = new System.Windows.Forms.TextBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // attributeName
            // 
            this.attributeName.AutoSize = true;
            this.attributeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attributeName.Location = new System.Drawing.Point(64, 28);
            this.attributeName.Name = "attributeName";
            this.attributeName.Size = new System.Drawing.Size(63, 16);
            this.attributeName.TabIndex = 0;
            this.attributeName.Text = "Атрибут";
            // 
            // attributeTextBox
            // 
            this.attributeTextBox.Location = new System.Drawing.Point(133, 27);
            this.attributeTextBox.Name = "attributeTextBox";
            this.attributeTextBox.Size = new System.Drawing.Size(259, 20);
            this.attributeTextBox.TabIndex = 1;
            // 
            // objectLabel
            // 
            this.objectLabel.AutoSize = true;
            this.objectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectLabel.Location = new System.Drawing.Point(70, 66);
            this.objectLabel.Name = "objectLabel";
            this.objectLabel.Size = new System.Drawing.Size(57, 16);
            this.objectLabel.TabIndex = 2;
            this.objectLabel.Text = "Объект";
            // 
            // objectTextBox
            // 
            this.objectTextBox.Location = new System.Drawing.Point(133, 65);
            this.objectTextBox.Name = "objectTextBox";
            this.objectTextBox.Size = new System.Drawing.Size(259, 20);
            this.objectTextBox.TabIndex = 3;
            // 
            // valueObjectLabel
            // 
            this.valueObjectLabel.AutoSize = true;
            this.valueObjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueObjectLabel.Location = new System.Drawing.Point(18, 103);
            this.valueObjectLabel.Name = "valueObjectLabel";
            this.valueObjectLabel.Size = new System.Drawing.Size(109, 16);
            this.valueObjectLabel.TabIndex = 4;
            this.valueObjectLabel.Text = "Номер объекта";
            // 
            // objectValueTextBox
            // 
            this.objectValueTextBox.Location = new System.Drawing.Point(133, 102);
            this.objectValueTextBox.Name = "objectValueTextBox";
            this.objectValueTextBox.Size = new System.Drawing.Size(259, 20);
            this.objectValueTextBox.TabIndex = 5;
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueLabel.Location = new System.Drawing.Point(54, 146);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(73, 16);
            this.valueLabel.TabIndex = 6;
            this.valueLabel.Text = "Значение";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(133, 146);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(259, 20);
            this.valueTextBox.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(299, 219);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(93, 32);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.OnClickCloseButton);
            // 
            // applyButton
            // 
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.applyButton.Location = new System.Drawing.Point(170, 218);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(93, 32);
            this.applyButton.TabIndex = 9;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnClickApplyButton);
            // 
            // ChangeAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 262);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.objectValueTextBox);
            this.Controls.Add(this.valueObjectLabel);
            this.Controls.Add(this.objectTextBox);
            this.Controls.Add(this.objectLabel);
            this.Controls.Add(this.attributeTextBox);
            this.Controls.Add(this.attributeName);
            this.Name = "ChangeAttribute";
            this.Text = "ChangeAttribute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label attributeName;
        private System.Windows.Forms.TextBox attributeTextBox;
        private System.Windows.Forms.Label objectLabel;
        private System.Windows.Forms.TextBox objectTextBox;
        private System.Windows.Forms.Label valueObjectLabel;
        private System.Windows.Forms.TextBox objectValueTextBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button applyButton;
    }
}