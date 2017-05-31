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
            this.analisysGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.analisysGroupBox.SuspendLayout();
            this.sessionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // analysisButton
            // 
            this.analysisButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analysisButton.Location = new System.Drawing.Point(243, 77);
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(90, 23);
            this.analysisButton.TabIndex = 0;
            this.analysisButton.Text = "Анализ...";
            this.analysisButton.UseVisualStyleBackColor = true;
            this.analysisButton.Click += new System.EventHandler(this.OnClickAnalsysButton);
            // 
            // sessionButton
            // 
            this.sessionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sessionButton.Location = new System.Drawing.Point(213, 77);
            this.sessionButton.Name = "sessionButton";
            this.sessionButton.Size = new System.Drawing.Size(120, 23);
            this.sessionButton.TabIndex = 1;
            this.sessionButton.Text = "Просмотр сессий...";
            this.sessionButton.UseVisualStyleBackColor = true;
            this.sessionButton.Click += new System.EventHandler(this.OnClickSessionButton);
            // 
            // analisysGroupBox
            // 
            this.analisysGroupBox.Controls.Add(this.label1);
            this.analisysGroupBox.Controls.Add(this.analysisButton);
            this.analisysGroupBox.Location = new System.Drawing.Point(12, 12);
            this.analisysGroupBox.Name = "analisysGroupBox";
            this.analisysGroupBox.Size = new System.Drawing.Size(339, 106);
            this.analisysGroupBox.TabIndex = 2;
            this.analisysGroupBox.TabStop = false;
            this.analisysGroupBox.Text = "Анализ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выполнение одного или нескольких правил между\r\nдоступными объектами на выбранной " +
    "области.";
            // 
            // sessionGroupBox
            // 
            this.sessionGroupBox.Controls.Add(this.label2);
            this.sessionGroupBox.Controls.Add(this.sessionButton);
            this.sessionGroupBox.Location = new System.Drawing.Point(12, 144);
            this.sessionGroupBox.Name = "sessionGroupBox";
            this.sessionGroupBox.Size = new System.Drawing.Size(339, 106);
            this.sessionGroupBox.TabIndex = 3;
            this.sessionGroupBox.TabStop = false;
            this.sessionGroupBox.Text = "Сессия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = "Просмотр и удаление сессий. Просмотр результатов \r\nпроверки выбранной сессии, а т" +
    "акже копирование и \r\nизменение данных объектов и выполенине анализа над \r\nэтими " +
    "данными.";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.sessionGroupBox);
            this.Controls.Add(this.analisysGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 300);
            this.Name = "AnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ";
            this.analisysGroupBox.ResumeLayout(false);
            this.analisysGroupBox.PerformLayout();
            this.sessionGroupBox.ResumeLayout(false);
            this.sessionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button analysisButton;
        private System.Windows.Forms.Button sessionButton;
        private System.Windows.Forms.GroupBox analisysGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox sessionGroupBox;
        private System.Windows.Forms.Label label2;
    }
}