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
using System.Windows.Forms.VisualStyles;

namespace VizuelnoProgramiranjeGame
{
    public partial class Form1 : Form
    {
        Player player;
        List<Projectile> projectiles;
        List<Enemy> enemies;
        bool keyLeft;
        bool keyRight;
        bool keyUp;
        bool keyDown;
        bool pause;
        int score;

        

        public Form1()
        {
            //Form1.ActiveForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            
            startGame();
        }
        
        private void startGame()
        {
            player = new Player(new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2));
            projectiles = new List<Projectile>();
            enemies = new List<Enemy>();
            
            score = 0;
            lblScore.Text = "Score:" + score;

            mainTimer.Start();
            enemyTimer.Start();
        }

        
        //controls
        //poradi nekoja pricina , so booleanite (pr. keyUp && keyRight) se dvizi dijagonalno ako kreiram poseben if, ali 
        //vo case-ot ne raboti, treba podobar fix od gorenavedeniot
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

                case Keys.Space: //moze podobro da se napravi ali me mrzi
                    if (player.CooldownTimer.Elapsed.Seconds >= player.shootCooldown)
                    {
                        projectiles.Add(player.Shoot());
                        player.CooldownTimer.Restart();
                    }
                    break;

                
            }

            if(keyUp && keyRight)
            {
                player.Move(playerControls.Right);
                player.Move(playerControls.Up);
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

        private void spawnEnemies()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            Random enemySpawnPoint = new Random();
            
            Enemy enemy = new Enemy(new Point(enemySpawnPoint.Next(1, screenWidth), 0));
            enemies.Add(enemy);
        }
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            Invalidate(true);


            //proveruva dali igracot e pogoden vo sekoj tick
            foreach (Enemy enemy in enemies)
            {
                if (player.isHit(enemy))
                {
                    startGame();
                }
            }
        }

        //Spawn timer , treba malce tweaking za tezina na igrata
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            enemyTimer.Interval = r.Next(300,3000);
            spawnEnemies();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            player.Draw(e.Graphics);

            //Brzina na neprijateli i proektili e povrzana so MainTimer tick interval, mozebi da se napravi
            //poseben timer za da se namali ili zgolemi tezina?
            //se spravuvam vo dvizenjeto vo form1_paint za da ne kreiram poseben foreach za dvizenje i crtanje
            foreach(Enemy enemy in enemies)
            {
                enemy.Move();
                enemy.Draw(e.Graphics);
            }
            
            foreach(Projectile p in projectiles)
            {
                p.Move();
                p.Draw(e.Graphics);
            }
        }

    }
}
