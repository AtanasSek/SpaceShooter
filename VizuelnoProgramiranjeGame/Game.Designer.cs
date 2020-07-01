namespace VizuelnoProgramiranjeGame
{
    partial class Game
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
            this.panelPause = new System.Windows.Forms.Panel();
            this.quitGame = new System.Windows.Forms.Button();
            this.continueGame = new System.Windows.Forms.Button();
            this.panelWinLose = new System.Windows.Forms.Panel();
            this.lblFinalScore = new System.Windows.Forms.Label();
            this.lblGameEnd = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelPause.SuspendLayout();
            this.panelWinLose.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(76, 20);
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
            this.lblTimer.Location = new System.Drawing.Point(124, 14);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(36, 13);
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
            // panelPause
            // 
            this.panelPause.BackColor = System.Drawing.Color.Black;
            this.panelPause.Controls.Add(this.quitGame);
            this.panelPause.Controls.Add(this.continueGame);
            this.panelPause.Location = new System.Drawing.Point(190, 78);
            this.panelPause.Margin = new System.Windows.Forms.Padding(2);
            this.panelPause.Name = "panelPause";
            this.panelPause.Size = new System.Drawing.Size(420, 295);
            this.panelPause.TabIndex = 2;
            // 
            // quitGame
            // 
            this.quitGame.Location = new System.Drawing.Point(137, 182);
            this.quitGame.Name = "quitGame";
            this.quitGame.Size = new System.Drawing.Size(136, 33);
            this.quitGame.TabIndex = 1;
            this.quitGame.Text = "Main Menu";
            this.quitGame.UseVisualStyleBackColor = true;
            this.quitGame.Click += new System.EventHandler(this.quitGame_Click);
            // 
            // continueGame
            // 
            this.continueGame.Location = new System.Drawing.Point(137, 81);
            this.continueGame.Name = "continueGame";
            this.continueGame.Size = new System.Drawing.Size(136, 33);
            this.continueGame.TabIndex = 0;
            this.continueGame.Text = "Continue";
            this.continueGame.UseVisualStyleBackColor = true;
            this.continueGame.Click += new System.EventHandler(this.continueGame_Click);
            // 
            // panelWinLose
            // 
            this.panelWinLose.Controls.Add(this.lblFinalScore);
            this.panelWinLose.Controls.Add(this.lblGameEnd);
            this.panelWinLose.Controls.Add(this.btnRestart);
            this.panelWinLose.Controls.Add(this.button2);
            this.panelWinLose.Location = new System.Drawing.Point(730, 109);
            this.panelWinLose.Name = "panelWinLose";
            this.panelWinLose.Size = new System.Drawing.Size(480, 238);
            this.panelWinLose.TabIndex = 3;
            // 
            // lblFinalScore
            // 
            this.lblFinalScore.AutoSize = true;
            this.lblFinalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalScore.ForeColor = System.Drawing.Color.White;
            this.lblFinalScore.Location = new System.Drawing.Point(147, 50);
            this.lblFinalScore.Name = "lblFinalScore";
            this.lblFinalScore.Size = new System.Drawing.Size(159, 25);
            this.lblFinalScore.TabIndex = 5;
            this.lblFinalScore.Text = "Final Score: 0";
            // 
            // lblGameEnd
            // 
            this.lblGameEnd.AutoSize = true;
            this.lblGameEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameEnd.ForeColor = System.Drawing.Color.White;
            this.lblGameEnd.Location = new System.Drawing.Point(116, 11);
            this.lblGameEnd.Name = "lblGameEnd";
            this.lblGameEnd.Size = new System.Drawing.Size(243, 25);
            this.lblGameEnd.TabIndex = 4;
            this.lblGameEnd.Text = "You Won! / Destroyed";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(170, 96);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(136, 33);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "Restart Game";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "Main Menu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.quitGame_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1355, 537);
            this.Controls.Add(this.panelWinLose);
            this.Controls.Add(this.panelPause);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblScore);
            this.Name = "Game";
            this.Text = "Alien Shooter placeholder";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            this.panelPause.ResumeLayout(false);
            this.panelWinLose.ResumeLayout(false);
            this.panelWinLose.PerformLayout();
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
        private System.Windows.Forms.Panel panelPause;
        private System.Windows.Forms.Button continueGame;
        private System.Windows.Forms.Button quitGame;
        private System.Windows.Forms.Panel panelWinLose;
        private System.Windows.Forms.Label lblFinalScore;
        private System.Windows.Forms.Label lblGameEnd;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button button2;
    }
}

