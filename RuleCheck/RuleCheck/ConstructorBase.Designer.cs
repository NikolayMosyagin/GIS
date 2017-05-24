namespace RuleCheck
{
    public partial class ConstructorBase
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
        public override void InitializeComponent()
        {
            base.InitializeComponent();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(451, 406);
            this.closeButton.Size = new System.Drawing.Size(121, 44);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(12, 353);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(121, 44);
            this.addButton.TabIndex = 4;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateButton.Location = new System.Drawing.Point(165, 353);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(121, 44);
            this.updateButton.TabIndex = 5;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.OnClickUpdateButton);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(319, 353);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(121, 44);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnClickDeleteButton);
            // 
            // ConstructorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Name = "ConstructorBase";
            this.Controls.SetChildIndex(this.addButton, 0);
            this.Controls.SetChildIndex(this.updateButton, 0);
            this.Controls.SetChildIndex(this.deleteButton, 0);
            this.Controls.SetChildIndex(this.searchLabel, 0);
            this.Controls.SetChildIndex(this.searchTextBox, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.Button updateButton;
        protected System.Windows.Forms.Button deleteButton;
    }
}