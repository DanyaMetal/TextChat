namespace Client
{
    partial class NewUser
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox1 = new System.Windows.Forms.TextBox();
            this.nameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(99, 45);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(195, 37);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Введите имя:";
            this.nameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // nameTextBox1
            // 
            this.nameTextBox1.Location = new System.Drawing.Point(300, 45);
            this.nameTextBox1.Multiline = true;
            this.nameTextBox1.Name = "nameTextBox1";
            this.nameTextBox1.Size = new System.Drawing.Size(167, 37);
            this.nameTextBox1.TabIndex = 2;
            // 
            // nameButton
            // 
            this.nameButton.Location = new System.Drawing.Point(220, 118);
            this.nameButton.Name = "nameButton";
            this.nameButton.Size = new System.Drawing.Size(128, 46);
            this.nameButton.TabIndex = 3;
            this.nameButton.Text = "Ok";
            this.nameButton.UseVisualStyleBackColor = true;
            this.nameButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 189);
            this.Controls.Add(this.nameButton);
            this.Controls.Add(this.nameTextBox1);
            this.Controls.Add(this.nameLabel);
            this.Name = "NewUser";
            this.Text = "NewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox1;
        private System.Windows.Forms.Button nameButton;
    }
}