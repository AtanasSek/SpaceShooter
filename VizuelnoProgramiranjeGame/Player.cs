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
    class Player : Spaceship
    {
 

        //Da koristam polygon namesto pravoagolnik za hitbox, mozebi ke resi hit detection problemi
        public Player(Point center)
        {
            base.center = center;
            base.sprite = new Bitmap(Resources.PSprite);
            this.CooldownTimer = new Stopwatch();
            this.CooldownTimer.Start();
            base.hitpoints = 3;
           

            base.width = sprite.Width;
            base.height = sprite.Height;

            base.hitbox.X = this.center.X;
            base.hitbox.Y = this.center.Y;
            base.hitbox.Width = base.width;
            base.hitbox.Height = base.height;
        }
    
        //ShootingPoint e kreirano so cel proektilot da doagja od centarot    
        public override Projectile Shoot()
        {
            Point shootingPoint = this.center;
            shootingPoint.X = this.center.X + width/2;
            Projectile p = new Projectile(shootingPoint);
            p.projectileDamage = this.projectileDamage;
            p.isEnemyProjectile = false;
            return p;
        }

        public bool isHit(Enemy enemy)
        {
            if (enemy.hitbox.IntersectsWith(hitbox))
                return true;
            else return false;
        }

        public bool isHit(Boss boss)
        {
            if (boss.hitbox.IntersectsWith(hitbox))
                return true;
            else return false;
        }

        public bool isHit(ShipUpgrade upgrade)
        {
            if (upgrade.hitbox.IntersectsWith(hitbox))
                return true;
            else return false;
        }

        public void setUpgrade(ShipUpgrade upgrade)
        {

            if(base.hitpoints + upgrade.hitpoints <= 30)
                base.hitpoints += upgrade.hitpoints;

            if(base.projectileDamage + upgrade.projectileDamage <= 4)
                base.projectileDamage += upgrade.projectileDamage;

            //za da ne se pretvori vo cist laser, ima crash povrzan so hit detection-ot  koga ke se sluci toa
            if(base.shootCooldown - upgrade.projectileCooldown > 50)
                base.shootCooldown -= upgrade.projectileCooldown;
        }
        
        public void DrawHUD(Graphics g)
        {
            int distance = 0;
            if (hitpoints >= 6)
            {
                g.DrawImage(base.sprite, Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Bottom - height, base.width, base.height);
                distance = width + 20;
                SolidBrush brush = new SolidBrush(Color.White);
                FontFamily ff = new FontFamily("Courier");
                System.Drawing.Font font = new System.Drawing.Font(ff, 30);
                g.DrawString("X"+hitpoints,font,brush, new Point(0 + width, Screen.PrimaryScreen.Bounds.Bottom - height));
            }
            else
            {
                for (int i = 0; i < hitpoints; i++)
                {
                    g.DrawImage(base.sprite, Screen.PrimaryScreen.Bounds.Left + distance, Screen.PrimaryScreen.Bounds.Bottom - height, base.width, base.height);
                    distance += (width + 20);
                }
            }
        }

        public override bool isHit(Projectile p)
        {
            if (this.hitbox.IntersectsWith(p.projectileHitbox) && p.isEnemyProjectile)
            {
                return true;
            }
            else return false;
        }



        public void Move(playerControls action)
        {
            switch (action)
            {
                case playerControls.Up:
                    if (this.center.Y <= 0)
                        break;
                    base.center = new Point(center.X, center.Y - 6);
                    base.hitbox.Y = center.Y;
                    break;

                case playerControls.Down:
                    if (this.center.Y >= Screen.PrimaryScreen.WorkingArea.Bottom)
                        break;
                    base.center = new Point(center.X, center.Y + 6);
                    base.hitbox.Y = center.Y;
                    break;

                case playerControls.Left:
                    if (this.center.X <= 0)
                        break;
                    base.center = new Point(center.X - 6, center.Y);
                    base.hitbox.X = center.X;
                    break;

                case playerControls.Right:
                    if (this.center.X >= Screen.PrimaryScreen.WorkingArea.Right - this.width)
                        break;
                    base.center = new Point(center.X + 6, center.Y);
                    base.hitbox.X = center.X;
                    break;

            }
        }

    }
}
