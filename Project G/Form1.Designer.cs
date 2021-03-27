namespace Project_G
{
    partial class Project_G
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Project_G));
            this.Exit = new System.Windows.Forms.Button();
            this.XO = new System.Windows.Forms.Button();
            this.Sappering = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.K2048 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(12, 114);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // XO
            // 
            this.XO.Location = new System.Drawing.Point(55, 85);
            this.XO.Name = "XO";
            this.XO.Size = new System.Drawing.Size(108, 23);
            this.XO.TabIndex = 3;
            this.XO.Text = "Крестики-Нолики";
            this.XO.UseVisualStyleBackColor = true;
            this.XO.Click += new System.EventHandler(this.XO_Click);
            // 
            // Sappering
            // 
            this.Sappering.Location = new System.Drawing.Point(55, 27);
            this.Sappering.Name = "Sappering";
            this.Sappering.Size = new System.Drawing.Size(108, 23);
            this.Sappering.TabIndex = 4;
            this.Sappering.Text = "Сапер";
            this.Sappering.UseVisualStyleBackColor = true;
            this.Sappering.Click += new System.EventHandler(this.Sappering_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(205, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.CreditsToolStripMenuItem_Click);
            // 
            // K2048
            // 
            this.K2048.Location = new System.Drawing.Point(55, 56);
            this.K2048.Name = "K2048";
            this.K2048.Size = new System.Drawing.Size(108, 23);
            this.K2048.TabIndex = 8;
            this.K2048.Text = "2048";
            this.K2048.UseVisualStyleBackColor = true;
            this.K2048.Click += new System.EventHandler(this.K2048_Click);
            // 
            // Project_G
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 150);
            this.Controls.Add(this.K2048);
            this.Controls.Add(this.Sappering);
            this.Controls.Add(this.XO);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Project_G";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project G";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button XO;
        private System.Windows.Forms.Button Sappering;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.Button K2048;
    }
}

