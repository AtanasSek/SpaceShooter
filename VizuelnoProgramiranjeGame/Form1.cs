using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using VizuelnoProgramiranjeGame.Properties;

namespace VizuelnoProgramiranjeGame
{

    // Vo retrospekcija , ke bese poubavo da napravam klasa od koja sto boss,enemy i player ke nasleduvaat.
    public partial class Form1 : Form
    {
        
        Player player;
        List<Projectile> projectiles;
        List<Enemy> enemies;
        List<Boss> bosses;
        bool isEnemyAllowedToSpawn;
        bool keyLeft;
        bool keyRight;
        bool keyUp;
        bool keyDown;
        bool keyShoot;
        bool pause;
        int score;
        int screenWidth;
        int screenHeight;
        Random randSeed;
        int bossCountDown;

        public Form1()
        {

            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;//Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;//Screen.PrimaryScreen.WorkingArea.Height;
            InitializeComponent();
            this.DoubleBuffered = true;
            startGame();

        }
        
        private void startGame()
        {
            player = new Player(new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2));
            projectiles = new List<Projectile>();
            enemies = new List<Enemy>();
            bosses = new List<Boss>();
            randSeed = new Random();
            isEnemyAllowedToSpawn = true;

          
            bossCountDown = 20;
            lblTimer.Text = "ETA: " + bossCountDown;

            score = 0;
            lblScore.Text = "Score:" + score;

            mainTimer.Start();
            enemyTimer.Start();
            enemyProjectileTimer.Start();
            enemyTimer.Interval = 3000; //delayed start na neprijateli
        }


        //Preglasno, nema api za zvuk
        private void playMusic()
        {
            SoundPlayer bossMusic = new SoundPlayer(Resources.Wide_Putin_Walking__online_audio_converter_com_);
            bossMusic.Play();
        }

        


        //Spawnrates za sekoj tip na enemy
        private void spawnEnemies()
        {
            
            int spawnLocation = randSeed.Next(40, screenWidth - 40); //  40 vrednosta e za da ne klipuvaat premnogu nadvor od ekranot
            int type = randSeed.Next(0,100);


            // -30, -40, -60 se staveni za Y oska za po smooth tranzicija da ima na nivno pojavuvanje
            if(type >= 50)
            {
                Enemy enemy = new Enemy(new Point(spawnLocation, -30), Type.Regular);
                enemies.Add(enemy);
            }
            else if(type >=20 && type < 50)
            {
                Enemy enemy = new Enemy(new Point(spawnLocation, -40), Type.Shooter);
                enemies.Add(enemy);
            }
            else if(type < 20)
            {
                Enemy enemy = new Enemy(new Point(spawnLocation, -60), Type.Tanky);
                enemies.Add(enemy);
            }   
            
        }

        //HIT DETECTION ZA ENEMIES,PLAYER I PROEKTILI POVRZANI SO NIV
        public void enemyCollisionLogic()
        {
            for (int i = 0; i < enemies.Count; i++)
            {

                //Se brisat enemies offscreen , mora continue inace ke iterira posle vo index koj sto e prazen
                if (enemies[i].hitbox.Y > screenHeight)
                {
                    enemies.RemoveAt(i);
                    continue;
                }

                //Hit detection za enemies
                if (player.isHit(enemies[i]))
                {
                    startGame();
                    //mora break inace ke vadi out of bounds
                }
                //idna iteracija dokolku sakam , piercing bullets samo mozam duplicat od forot vo poseben if bez projectiles.removeat;

                //Hit detection za proektili od enemies i player
                for (int j = 0; j < projectiles.Count; j++)
                {

                    if (enemies[i].isHit(projectiles[j]))
                    {

                        enemies[i].Damage(projectiles[j]);
                        if (enemies[i].getHitPoints() <= 0)
                        {

                            if (enemies[i].type == Type.Regular)
                            {
                                score += 10;
                                lblScore.Text = "Score:" + score;
                            }
                            else if (enemies[i].type == Type.Shooter)
                            {
                                score += 20;
                                lblScore.Text = "Score:" + score;
                            }
                            else if (enemies[i].type == Type.Tanky)
                            {
                                score += 30;
                                lblScore.Text = "Score:" + score;
                            }
                            enemies.RemoveAt(i);

                        }

                        projectiles.RemoveAt(j);

                    }
                    else if (player.isHit(projectiles[j]))
                    {
                        startGame();
                    }

                }

            }
        }

        //HIT DETECTION ZA BOSS,PLAYER I PROEKTILI POVRZANI SO NIV
        public void bossCollisionLogic()
        {
            for (int i = 0; i < bosses.Count; i++)
            {
                if (player.isHit(bosses[i]))
                {
                    startGame();
                }
                for (int j = 0; j < projectiles.Count; j++)
                {
                    if (bosses[i].isHit(projectiles[j]))
                    {
                        bosses[i].Damage(projectiles[j]);
                        projectiles.RemoveAt(j);
                        if (bosses[i].getHitPoints() <= 0)
                        {
                            startGame();
                        }
                    }
                    else if(player.isHit(projectiles[j]))
                    {
                        startGame();
                    }
                }
            }
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
        //Metodov postoi samo za da bide iskoristen vo mainTimer_Tick za da nema delay vo akciite na igracot
        public void keyPress()
        {
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
        private void mainTimer_Tick(object sender, EventArgs e)
        {

            Invalidate(true);

            //Losa implementacija, nema vreme za podobra
            //HIT DETECTION ZA ENEMIES,PLAYER I PROEKTILI POVRZANI SO NIV
            enemyCollisionLogic();
            bossCollisionLogic();

            //staven e delov ovde za da nema delay vo key press
            keyPress();
            
        }

        //Spawn timer , treba malce tweaking za tezina na igrata
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            if (isEnemyAllowedToSpawn)
            {
                enemyTimer.Interval = randSeed.Next(300,1000);
                spawnEnemies();
            }
            else
            {
                if (!enemies.Any() && !bosses.Any())
                {
                    //potrebno e boss muzika i da se spavne
                    Point spawnPoint = new Point(screenWidth / 4, -300);
                    Boss boss = new Boss(spawnPoint, screenWidth / 2, screenHeight / 4);
                    bosses.Add(boss);
                    //playMusic();

                }
            }
        }


        //patern na pukanje za neprijateli
        private void enemyProjectileTimer_Tick(object sender, EventArgs e)
        {

            foreach(Enemy enemy in enemies)
            {
                enemyProjectileTimer.Interval = randSeed.Next(2000, 4000);
                if(enemy.type == Type.Shooter)
                {
                    projectiles.Add(enemy.Shoot());
                }
            }

            foreach(Boss boss in bosses)
            {
                enemyProjectileTimer.Interval = randSeed.Next(2000,4000);
                projectiles.Add(boss.Shoot());
            }

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

            foreach(Boss boss in bosses)
            {
                boss.Move();
                boss.Draw(e.Graphics);
            }
            
            foreach(Projectile p in projectiles)
            {
                p.Move();
                p.Draw(e.Graphics);
            }

        }

        //Countdown timer za bossot, na 0 spavnuva
        private void bossTimer_Tick(object sender, EventArgs e)
        {
            if (bossCountDown != 0)
            {
                bossCountDown -= 1;
                lblTimer.Text = "ETA: " + bossCountDown.ToString();
            }
            else
            {
                isEnemyAllowedToSpawn = false;
            }
            
        }
        private void bossBattleTimer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
