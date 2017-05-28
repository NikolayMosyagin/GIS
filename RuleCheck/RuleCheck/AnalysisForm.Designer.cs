namespace RuleCheck
{
    partial class AnalysisForm
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
            this.analysisButton = new System.Windows.Forms.Button();
            this.sessionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // analysisButton
            // 
            this.analysisButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analysisButton.Location = new System.Drawing.Point(61, 46);
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(240, 44);
            this.analysisButton.TabIndex = 0;
            this.analysisButton.Text = "Анализ";
            this.analysisButton.UseVisualStyleBackColor = true;
            this.analysisButton.Click += new System.EventHandler(this.OnClickAnalsysButton);
            // 
            // sessionButton
            // 
            this.sessionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sessionButton.Location = new System.Drawing.Point(61, 156);
            this.sessionButton.Name = "sessionButton";
            this.sessionButton.Size = new System.Drawing.Size(240, 44);
            this.sessionButton.TabIndex = 1;
            this.sessionButton.Text = "Просмотр сессий";
            this.sessionButton.UseVisualStyleBackColor = true;
            this.sessionButton.Click += new System.EventHandler(this.OnClickSessionButton);
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.sessionButton);
            this.Controls.Add(this.analysisButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 300);
            this.Name = "AnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button analysisButton;
        private System.Windows.Forms.Button sessionButton;
    }
}