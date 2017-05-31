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
            this.administrationGroupBox = new System.Windows.Forms.GroupBox();
            this.analisysGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.administrationGroupBox.SuspendLayout();
            this.analisysGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminButton
            // 
            this.adminButton.BackColor = System.Drawing.SystemColors.Control;
            this.adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminButton.Location = new System.Drawing.Point(162, 77);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(171, 23);
            this.adminButton.TabIndex = 0;
            this.adminButton.Text = "Режим администрирования...";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.OnClickAdminButton);
            // 
            // analysisButton
            // 
            this.analysisButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analysisButton.Location = new System.Drawing.Point(225, 77);
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(108, 23);
            this.analysisButton.TabIndex = 1;
            this.analysisButton.Text = "Режим анализа...";
            this.analysisButton.UseVisualStyleBackColor = true;
            this.analysisButton.Click += new System.EventHandler(this.OnClickAnalisysButton);
            // 
            // administrationGroupBox
            // 
            this.administrationGroupBox.Controls.Add(this.label1);
            this.administrationGroupBox.Controls.Add(this.adminButton);
            this.administrationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.administrationGroupBox.Name = "administrationGroupBox";
            this.administrationGroupBox.Size = new System.Drawing.Size(339, 106);
            this.administrationGroupBox.TabIndex = 2;
            this.administrationGroupBox.TabStop = false;
            this.administrationGroupBox.Text = "Администрирование";
            // 
            // analisysGroupBox
            // 
            this.analisysGroupBox.Controls.Add(this.label2);
            this.analisysGroupBox.Controls.Add(this.analysisButton);
            this.analisysGroupBox.Location = new System.Drawing.Point(12, 138);
            this.analisysGroupBox.Name = "analisysGroupBox";
            this.analisysGroupBox.Size = new System.Drawing.Size(339, 106);
            this.analisysGroupBox.TabIndex = 3;
            this.analisysGroupBox.TabStop = false;
            this.analisysGroupBox.Text = "Анализ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Режим администрирования доступен пользователям,\r\nимеющим права администратора. Во" +
    "зможность добавлять,\r\nудалять и изменять операции и правила.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = "Режим анализа доступен пользователям, имеющим права \r\nпользователя и/или админист" +
    "ратора. Возможность \r\nвыполнения одного или нескольких правил и просмотр \r\nрезул" +
    "ьтатов.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.analisysGroupBox);
            this.Controls.Add(this.administrationGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма";
            this.administrationGroupBox.ResumeLayout(false);
            this.administrationGroupBox.PerformLayout();
            this.analisysGroupBox.ResumeLayout(false);
            this.analisysGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button analysisButton;
        private System.Windows.Forms.GroupBox administrationGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox analisysGroupBox;
        private System.Windows.Forms.Label label2;
    }
}