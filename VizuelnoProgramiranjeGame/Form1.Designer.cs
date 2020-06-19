namespace VizuelnoProgramiranjeGame
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblScore = new System.Windows.Forms.Label();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.enemyTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyProjectileTimer = new System.Windows.Forms.Timer(this.components);
            this.bossTimer = new System.Windows.Forms.Timer(this.components);
            this.bossBattleTimer = new System.Windows.Forms.Timer(this.components);
            this.particleTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(16, 11);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(61, 17);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score: 0";
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 10;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(99, 11);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(48, 17);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "Timer ";
            // 
            // enemyTimer
            // 
            this.enemyTimer.Interval = 3000;
            this.enemyTimer.Tick += new System.EventHandler(this.enemyTimer_Tick);
            // 
            // enemyProjectileTimer
            // 
            this.enemyProjectileTimer.Enabled = true;
            this.enemyProjectileTimer.Interval = 2000;
            this.enemyProjectileTimer.Tick += new System.EventHandler(this.enemyProjectileTimer_Tick);
            // 
            // bossTimer
            // 
            this.bossTimer.Enabled = true;
            this.bossTimer.Interval = 1000;
            this.bossTimer.Tick += new System.EventHandler(this.bossTimer_Tick);
            // 
            // bossBattleTimer
            // 
            this.bossBattleTimer.Interval = 10;
            this.bossBattleTimer.Tick += new System.EventHandler(this.bossBattleTimer_Tick);
            // 
            // particleTimer
            // 
            this.particleTimer.Enabled = true;
            this.particleTimer.Interval = 200;
            this.particleTimer.Tick += new System.EventHandler(this.particleTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblScore);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Alien Shooter placeholder";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.Timer enemyProjectileTimer;
        private System.Windows.Forms.Timer bossTimer;
        private System.Windows.Forms.Timer bossBattleTimer;
        private System.Windows.Forms.Timer particleTimer;
    }
}

