using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VizuelnoProgramiranjeGame.Properties;
using System.Windows.Forms;
using System.Diagnostics;

namespace VizuelnoProgramiranjeGame
{

    enum playerControls
    {
        Up,Down,Left,Right
    }
    class Player
    {
        public Point center;
        public static readonly int playerHeight = 50;
        public static readonly int playerWidth = 50;
        public Bitmap playerSprite;
        public Rectangle playerHitbox;


        public float shootCooldown = 1;
        public Stopwatch CooldownTimer;

        public Player(Point center)
        {
            this.center = center;
            this.playerSprite = new Bitmap(Resources.PSprite);
            this.CooldownTimer = new Stopwatch();
            this.CooldownTimer.Start();

            this.playerHitbox.X = this.center.X;
            this.playerHitbox.Y = this.center.Y;
            this.playerHitbox.Width = playerWidth;
            this.playerHitbox.Height = playerHeight;
            
        }
    
        public void Draw(Graphics g)
        {
            g.DrawImage(image: playerSprite, center.X, center.Y, playerWidth, playerHeight);
        }

        //TODO: Cooldown treba na pukanje
        public Projectile Shoot()
        {
            
            Projectile p = new Projectile(this.center);
            return p;
        }

        public bool isHit(Enemy enemy)
        {
            if (enemy.enemyHitbox.IntersectsWith(playerHitbox))
                return true;
            else return false;
        }

        public void Move(playerControls action)
        {
            switch (action)
            {
                case playerControls.Up:
                    this.center = new Point(center.X, center.Y - 12);
                    this.playerHitbox.Y = center.Y;
                    break;

                case playerControls.Down:
                    this.center = new Point(center.X, center.Y + 12);
                    this.playerHitbox.Y = center.Y;
                    break;

                case playerControls.Left:
                    this.center = new Point(center.X - 12, center.Y);
                    this.playerHitbox.X = center.X;
                    break;

                case playerControls.Right:
                    this.center = new Point(center.X + 12, center.Y);
                    this.playerHitbox.X = center.X;
                    break;

            }
        }

    }
}
