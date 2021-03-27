namespace Project_G
{
    partial class G2048
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(G2048));
            this.Score = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Clock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.Score.Location = new System.Drawing.Point(12, 47);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(114, 29);
            this.Score.TabIndex = 74;
            this.Score.Text = "Score : 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.Clock});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 58;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartMenu,
            this.creditsMenu,
            this.Exit});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.GameToolStripMenuItem_Click);
            // 
            // restartMenu
            // 
            this.restartMenu.Name = "restartMenu";
            this.restartMenu.Size = new System.Drawing.Size(111, 22);
            this.restartMenu.Text = "Restart";
            this.restartMenu.Click += new System.EventHandler(this.RestartMenu_Click);
            // 
            // creditsMenu
            // 
            this.creditsMenu.Name = "creditsMenu";
            this.creditsMenu.Size = new System.Drawing.Size(111, 22);
            this.creditsMenu.Text = "Credits";
            this.creditsMenu.Click += new System.EventHandler(this.CreditsMenu_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(111, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Clock
            // 
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(90, 20);
            this.Clock.Text = "Time [ 00:00 ]";
            this.Clock.Click += new System.EventHandler(this.Time0000ToolStripMenuItem_Click);
            // 
            // G2048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 528);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "G2048";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "2048";
            this.Load += new System.EventHandler(this.G2048_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem restartMenu;
        private System.Windows.Forms.ToolStripMenuItem creditsMenu;
        private System.Windows.Forms.ToolStripMenuItem Clock;
    }
}