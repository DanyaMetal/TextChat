namespace Client
{
    partial class ConnectToServer
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
            this.SrvConnectButton = new System.Windows.Forms.Button();
            this.nameSrvTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SrvConnectButton
            // 
            this.SrvConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SrvConnectButton.Location = new System.Drawing.Point(254, 163);
            this.SrvConnectButton.Name = "SrvConnectButton";
            this.SrvConnectButton.Size = new System.Drawing.Size(197, 60);
            this.SrvConnectButton.TabIndex = 6;
            this.SrvConnectButton.Text = "Подключиться";
            this.SrvConnectButton.UseVisualStyleBackColor = true;
            // 
            // nameSrvTextBox1
            // 
            this.nameSrvTextBox1.Location = new System.Drawing.Point(369, 83);
            this.nameSrvTextBox1.Multiline = true;
            this.nameSrvTextBox1.Name = "nameSrvTextBox1";
            this.nameSrvTextBox1.Size = new System.Drawing.Size(177, 37);
            this.nameSrvTextBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Введите имя сервера:";
            // 
            // ConnectToServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SrvConnectButton);
            this.Controls.Add(this.nameSrvTextBox1);
            this.Name = "ConnectToServer";
            this.Text = "ConnectToServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SrvConnectButton;
        private System.Windows.Forms.TextBox nameSrvTextBox1;
        private System.Windows.Forms.Label label1;
    }
}