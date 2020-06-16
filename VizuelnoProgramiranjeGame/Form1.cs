using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizuelnoProgramiranjeGame
{
    public partial class Form1 : Form
    {
        Player player;
        Enemy enemy;
        List<Projectile> projectiles;
        bool keyLeft;
        bool keyRight;
        bool keyUp;
        bool keyDown;
        bool pause;
        int score;

        Random enemySpawnPoint = new Random();

        public Form1()
        {
            //Form1.ActiveForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.player = new Player(new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2));
            this.enemy = new Enemy(new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 8));
            this.projectiles = new List<Projectile>();
            startGame();

        }

        
        private void startGame()
        {
            score = 0;
            lblScore.Text = "Score:" + score;

            mainTimer.Start();
            
        }


        private void keyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keyLeft = true;
                    player.Move(playerControls.Left);
                    break;

                case Keys.Right:
                    keyRight = true;
                    player.Move(playerControls.Right);
                    break;

                case Keys.Up:
                    keyUp = true;
                    player.Move(playerControls.Up);
                    break;

                case Keys.Down:
                    keyDown = true;
                    player.Move(playerControls.Down);
                    break;

                case Keys.Space:
                    projectiles.Add(player.Shoot());
                    break;
            }
            
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keyLeft = false;
                    break;

                case Keys.Right:
                    keyRight = false;
                    break;

                case Keys.Up:
                    keyUp = false;
                    break;

                case Keys.Down:
                    keyDown = false;
                    break;

                case Keys.Space:
                    
                    break;
            }
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            player.Draw(e.Graphics);
            enemy.Draw(e.Graphics);
            
            foreach(Projectile p in projectiles)
            {
                p.Move();
                p.Draw(e.Graphics);
            }
        }
    }
}
