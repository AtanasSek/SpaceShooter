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
        bool keyShoot;
        bool pause;
        int score;
        int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;


        public Form1()
        {
            
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.DoubleBuffered = true;
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
                    break;

                case Keys.Right:
                    keyRight = true;
                    
                    break;

                case Keys.Up:
                    keyUp = true;
                    
                    break;

                case Keys.Down:
                    keyDown = true;
                    break;

                case Keys.Z: //moze podobro da se napravi ali me mrzi
                    keyShoot = true;
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

                case Keys.Z:
                    keyShoot = false;
                    break;
            }
        }

        private void spawnEnemies()
        {
            
            Random enemySpawnPoint = new Random();
            
            Enemy enemy = new Enemy(new Point(enemySpawnPoint.Next(1, screenWidth), 0));
            enemies.Add(enemy);
        }
        private void mainTimer_Tick(object sender, EventArgs e)
        {

            Invalidate(true);

            //proveruva dali igracot e pogoden vo sekoj tick
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].enemyHitbox.Y > screenHeight)
                {
                    enemies.RemoveAt(i);
                }


                if (player.isHit(enemies[i]))
                {
                    startGame();
                }

                //idna iteracija dokolku sakam , piercing bullets samo mozam duplicat od forot vo poseben if bez projectiles.removeat;

                for(int j = 0; j < projectiles.Count; j++)
                {
                    if (enemies[i].isHit(projectiles[j]))
                    {
                        score += 10;
                        lblScore.Text = "Score:" + score;
                        enemies.RemoveAt(i);
                        projectiles.RemoveAt(j);
                    }
                }

                
            }

            //staven e delov ovde za da nema delay vo key press
            if (keyUp)
            {
                player.Move(playerControls.Up);
            }
            if (keyDown)
            {
                player.Move(playerControls.Down);    
            }
            if (keyLeft)
            {
                player.Move(playerControls.Left);
                
            }
            if (keyRight)
            {
                player.Move(playerControls.Right);
                
            }
            if (keyShoot)
            {   
                if (player.CooldownTimer.Elapsed.Seconds >= player.shootCooldown)
                {
                    projectiles.Add(player.Shoot());
                    player.CooldownTimer.Restart();
                }
            }

            
        }

        //Spawn timer , treba malce tweaking za tezina na igrata
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            enemyTimer.Interval = r.Next(300,1000);
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
