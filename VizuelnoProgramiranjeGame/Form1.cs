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
using System.Windows.Media;
using VizuelnoProgramiranjeGame.Properties;
using AxWMPLib;

using Color = System.Drawing.Color;
using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection;

namespace VizuelnoProgramiranjeGame
{

    // Vo retrospekcija , ke bese poubavo da napravam klasa od koja sto boss,enemy i player ke nasleduvaat.
    public partial class Form1 : Form
    {
        
        Player player;
        Bitmap regularSprite;
        Bitmap shooterSprite;
        Bitmap tankSprite;
        Bitmap placeholderSprite;
        Bitmap particleSprite;

        List<Projectile> projectiles;
        List<Enemy> enemies;
        List<Boss> bosses;
        List<SpaceDebris> spaceDebris;
        List<ShipUpgrade> shipUpgrades;
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
        int maxGameDuration;
        int bossCountDown = 300;
        Bitmap background;
      
        
        public Form1(int seconds)
        {

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;//Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;//Screen.PrimaryScreen.WorkingArea.Height;
            InitializeComponent();
            this.DoubleBuffered = true;
            this.background = new Bitmap(Resources.PixelGalaxy1);
            maxGameDuration = seconds;


            //Sprites se loadiraat na kreacija na forma sega, namesto na kreacija na objekt, bi trebalo da namali lag?
            regularSprite = new Bitmap(Resources.enemy_red);
            shooterSprite = new Bitmap(Resources.enemy_yellow);
            tankSprite = new Bitmap(Resources.enemy_green);
            placeholderSprite = new Bitmap(Resources.ESprite);
            particleSprite = new Bitmap(Resources.Space_Particle);


            //using Color , zapamti , mediaplayer issue
            //Pause Panel
            panelPause.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - panelPause.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - panelPause.Height / 2);
            panelPause.BackColor = Color.FromArgb(100, 0, 0, 0);
            panelPause.Visible = false;

            //Win/Lose Panel
            panelWinLose.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - panelPause.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - panelPause.Height / 2);
            panelWinLose.BackColor = Color.FromArgb(100, 0, 0, 0);
            panelWinLose.Visible = false;


            startGame();

        }

        //Preglasno, nema metodi za zvuk,druga biblioteka mozebi ili manuelno da namalam zvuk?
        public static void playMusic()
        {
           
            //Muzika
            AxWindowsMediaPlayer axwmp = new AxWindowsMediaPlayer();
            axwmp.CreateControl();
            axwmp.Enabled = true;
            axwmp.URL = Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), "Resources\\Audio\\Scandroid - 2517 (Instrumental).mp3");
            axwmp.settings.setMode("loop", true);
            axwmp.settings.volume = 10;
            axwmp.Ctlcontrols.play();

        }

        private void startGame()
        {
            player = new Player(new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2));
            projectiles = new List<Projectile>();
            enemies = new List<Enemy>();
            bosses = new List<Boss>();
            spaceDebris = new List<SpaceDebris>();
            shipUpgrades = new List<ShipUpgrade>();
            randSeed = new Random();
            isEnemyAllowedToSpawn = true;
          
            bossCountDown = maxGameDuration;
            lblTimer.Text = "ETA: " + bossCountDown;

            score = 0;
            lblScore.Text = "Score:" + score;

            mainTimer.Start();
            enemyTimer.Start();
            enemyProjectileTimer.Start();
            particleTimer.Start();
            bossTimer.Start();
            enemyTimer.Interval = 3000; //delayed start na neprijateli
            
        }  


        //Spawnrates za sekoj tip na enemy
        private void spawnEnemies()
        {

            
            int spawnLocation = randSeed.Next(40, screenWidth - 40); //  40 vrednosta e za da ne klipuvaat premnogu nadvor od ekranot
            int type = randSeed.Next(0,100);


            // -30, -40, -60 se staveni za Y oska za po smooth tranzicija da ima na nivno pojavuvanje
            if(type >= 50)
            {
                Enemy enemy = new Enemy(new Point(spawnLocation, -30), Type.Regular,regularSprite);
                enemies.Add(enemy);
            }
            else if(type >=20 && type < 50)
            {
                Enemy enemy = new Enemy(new Point(spawnLocation, -40), Type.Shooter,shooterSprite);
                enemies.Add(enemy);
            }
            else if(type < 20)
            {
                Enemy enemy = new Enemy(new Point(spawnLocation, -60), Type.Tanky, tankSprite);
                enemies.Add(enemy);
            }   
            
        }
    
        public void stopGame()
        {
            
            mainTimer.Stop();
            lblFinalScore.Text = "Final Score: " + score;
            if (player.hitpoints <= 0)
            {
                lblGameEnd.Text = "Destroyed";
            }
            else
            {
                lblGameEnd.Text = "You Won!";
            }
            panelWinLose.Visible = true;
        }

        //HIT DETECTION ZA ENEMIES,PLAYER I PROEKTILI POVRZANI SO NIV
        public void enemyCollisionLogic()
        {
            if (player.hitpoints <= 0)
            {
                stopGame();
            }
            for (int i = 0; i < enemies.Count; i++)
            {

                //Se brisat enemies offscreen , mora continue inace ke iterira posle vo index koj sto e prazen
                if (enemies[i].hitbox.Y > screenHeight)
                {
                    enemies.RemoveAt(i);
                    continue;
                }

                //Hit detection za kolizija
                if (player.isHit(enemies[i]))
                {
                    player.PureDamage(enemies[i].hitpoints);
                    enemies.RemoveAt(i);
                    continue;
                }
                //idna iteracija dokolku sakam , piercing bullets samo mozam duplicat od forot vo poseben if bez projectiles.removeat;

                //Hit detection za proektili od enemies i player
                for (int j = 0; j < projectiles.Count; j++)
                {

                    if(projectiles[j].projectileHitbox.Y > screenHeight || projectiles[j].projectileHitbox.Y < 0)
                    {
                        projectiles.RemoveAt(j);
                        continue;
                    }

                    if (enemies[i].isHit(projectiles[j]))
                    {
                        enemies[i].Damage(projectiles[j]);

                        if (enemies[i].hitpoints <= 0)
                        {

                            switch (enemies[i].type)
                            {
                                case (Type.Regular):
                                    score += 10;                                
                                    //Napraviv losa implementacija i upgrade.assigned e patchwork za da raboti, ako imam vreme ke go sredam
                                    ShipUpgrade upgrade = new ShipUpgrade(randSeed.Next(1, 100), enemies[i]);
                                    if (upgrade.assigned)
                                        shipUpgrades.Add(upgrade);
                                    break;

                                case (Type.Shooter):
                                    score += 20;                                   
                                    upgrade = new ShipUpgrade(randSeed.Next(1, 100), enemies[i]);
                                    if (upgrade.assigned)
                                        shipUpgrades.Add(upgrade);
                                    break;

                                case (Type.Tanky):
                                    score += 30;
                                    upgrade = new ShipUpgrade(randSeed.Next(1, 100), enemies[i]);
                                    if (upgrade.assigned)
                                        shipUpgrades.Add(upgrade);
                                    break;
                            }
                            lblScore.Text = "Score:" + score;


                            enemies.RemoveAt(i);

                        }

                        projectiles.RemoveAt(j);

                        continue;
                    }
                    else if (player.isHit(projectiles[j]))
                    {
                        
                        player.Damage(projectiles[j]);
                        projectiles.RemoveAt(j);
                                           
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
                    stopGame();
                }
                for (int j = 0; j < projectiles.Count; j++)
                {
                    if (bosses[i].isHit(projectiles[j]))
                    {
                        bosses[i].Damage(projectiles[j]);
                        projectiles.RemoveAt(j);
                        if (bosses[i].hitpoints <= 0)
                        {
                            stopGame();
                        }
                    }
                    else if(player.isHit(projectiles[j]))
                    {
                        player.Damage(projectiles[j]);
                        //startGame();
                    }
                }
            }
        }

        public void upgradeCollisionLogic()
        {
            for(int i = 0; i < shipUpgrades.Count; i++)
            {
                if(shipUpgrades[i].hitbox.Y > Screen.PrimaryScreen.Bounds.Height)
                {
                    shipUpgrades.RemoveAt(i);
                    continue;
                }
                if (player.isHit(shipUpgrades[i]))
                {
                    player.setUpgrade(shipUpgrades[i]);
                    shipUpgrades.RemoveAt(i);
                }
            }
        }


        //Bug , ako pauzira igracot konstantno , timerot se refreshira i so toa ne spawnuva nisto, se dodeka igracot spama pause
        public void pauseGame()
        {
            pause = !pause;
            if (pause)
            {
                panelPause.Visible = true;
                mainTimer.Stop();
                enemyTimer.Stop();
                enemyProjectileTimer.Stop();
                particleTimer.Stop();
                bossTimer.Stop();
            }
            else
            {
                panelPause.Visible = false;
                this.Focus();
                mainTimer.Start();
                enemyTimer.Start();
                enemyProjectileTimer.Start();
                particleTimer.Start();
                bossTimer.Start();
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

                case Keys.Escape:
                    
                    pauseGame();
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
                if (player.CooldownTimer.Elapsed.TotalMilliseconds >= player.shootCooldown)
                {
                    projectiles.Add(player.Shoot());
                    player.CooldownTimer.Restart();
                }
            }
        }

        void cleanUpParticle()
        {
            for (int i = 0; i < spaceDebris.Count; i++)
            {
                if (spaceDebris[i].center.Y >= screenHeight)
                    spaceDebris.RemoveAt(i);
            }
        }
        private void mainTimer_Tick(object sender, EventArgs e)
        {

            Invalidate(true);

            //Losa implementacija, nema vreme za podobra
            //HIT DETECTION ZA ENEMIES,PLAYER I PROEKTILI POVRZANI SO NIV
            enemyCollisionLogic();
            bossCollisionLogic();
            upgradeCollisionLogic();

            //staven e delov ovde za da nema delay vo key press
            keyPress();
            cleanUpParticle();
            
        }

        //Spawn timer , treba malce tweaking za tezina na igrata
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            if (isEnemyAllowedToSpawn)
            {
                enemyTimer.Interval = randSeed.Next(400,1250); 
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
            //backgroundot laguva mnogu ako e kompresiran, treba da se najde pogolema slika sto izgleda ok
            e.Graphics.DrawImage(background, 0 ,0 ); //screenwidth i screenheight za test
            foreach(SpaceDebris particle in spaceDebris)
            {
                particle.Draw(e.Graphics);
                particle.Move();
            }
            player.Draw(e.Graphics);
            
            

            //Brzina na neprijateli i proektili e povrzana so MainTimer tick interval, mozebi da se napravi
            //poseben timer za da se namali ili zgolemi tezina?
            //se spravuvam vo dvizenjeto vo form1_paint za da ne kreiram poseben foreach za dvizenje i crtanje
            foreach (Enemy enemy in enemies)
            {
                enemy.Move();
                enemy.Draw(e.Graphics);
            }

            foreach (ShipUpgrade upgrade in shipUpgrades)
            {
                upgrade.Move();
                upgrade.Draw(e.Graphics);
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

            player.DrawHUD(e.Graphics);

            e.Dispose();
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
        //da se dovrsi
        private void bossBattleTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void particleTimer_Tick(object sender, EventArgs e)
        {
            int spawn = randSeed.Next(screenWidth);
            Point spawnPoint = new Point(spawn, 0);
            SpaceDebris particle = new SpaceDebris(spawnPoint, particleSprite);
            spaceDebris.Add(particle);
        }

        private void continueGame_Click(object sender, EventArgs e)
        {
            pauseGame();
        }

        private void quitGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            
            startGame(); 
            panelWinLose.Visible = false;
            this.Focus();
        }
    }
}
