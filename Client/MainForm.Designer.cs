namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cahtRichTextBox = new System.Windows.Forms.RichTextBox();
            this.msgRichTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.подключитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userList = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cahtRichTextBox
            // 
            this.cahtRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cahtRichTextBox.Location = new System.Drawing.Point(299, 40);
            this.cahtRichTextBox.Name = "cahtRichTextBox";
            this.cahtRichTextBox.ReadOnly = true;
            this.cahtRichTextBox.Size = new System.Drawing.Size(794, 334);
            this.cahtRichTextBox.TabIndex = 3;
            this.cahtRichTextBox.Text = "";
            this.cahtRichTextBox.TextChanged += new System.EventHandler(this.chatRichTextBox1_TextChanged);
            // 
            // msgRichTextBox2
            // 
            this.msgRichTextBox2.Location = new System.Drawing.Point(299, 380);
            this.msgRichTextBox2.Name = "msgRichTextBox2";
            this.msgRichTextBox2.Size = new System.Drawing.Size(794, 37);
            this.msgRichTextBox2.TabIndex = 4;
            this.msgRichTextBox2.Text = "";
            this.msgRichTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msgRichTextBox2_KeyDown);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(58, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 46);
            this.button2.TabIndex = 6;
            this.button2.Text = "Админ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // подключитьсяToolStripMenuItem
            // 
            this.подключитьсяToolStripMenuItem.Name = "подключитьсяToolStripMenuItem";
            this.подключитьсяToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.подключитьсяToolStripMenuItem.Text = "Подключиться";
            this.подключитьсяToolStripMenuItem.Click += new System.EventHandler(this.подключитьсяToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьсяToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1144, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.ItemHeight = 16;
            this.userList.Location = new System.Drawing.Point(12, 40);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(262, 340);
            this.userList.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 453);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.msgRichTextBox2);
            this.Controls.Add(this.cahtRichTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox cahtRichTextBox;
        private System.Windows.Forms.RichTextBox msgRichTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox userList;
    }
}

