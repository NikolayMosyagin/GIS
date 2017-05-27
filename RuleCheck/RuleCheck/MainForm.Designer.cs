namespace RuleCheck
{
    partial class MainForm
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
            this.adminButton = new System.Windows.Forms.Button();
            this.analysisButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adminButton
            // 
            this.adminButton.BackColor = System.Drawing.SystemColors.Control;
            this.adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminButton.Location = new System.Drawing.Point(61, 46);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(240, 44);
            this.adminButton.TabIndex = 0;
            this.adminButton.Text = "Режим администрирования";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.OnClickAdminButton);
            // 
            // analysisButton
            // 
            this.analysisButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analysisButton.Location = new System.Drawing.Point(61, 156);
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(240, 44);
            this.analysisButton.TabIndex = 1;
            this.analysisButton.Text = "Режим анализа";
            this.analysisButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.analysisButton);
            this.Controls.Add(this.adminButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button analysisButton;
    }
}