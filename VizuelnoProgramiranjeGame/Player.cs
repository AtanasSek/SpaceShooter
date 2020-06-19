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

        public Player(Point center)
        {
            base.center = center;
            base.sprite = new Bitmap(Resources.PSprite);
            this.CooldownTimer = new Stopwatch();
            this.CooldownTimer.Start();

            base.width = 50;
            base.height = 50;

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

        public bool isHit(Projectile p)
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
                    base.center = new Point(center.X, center.Y - 6);
                    base.hitbox.Y = center.Y;
                    break;

                case playerControls.Down:
                    base.center = new Point(center.X, center.Y + 6);
                    base.hitbox.Y = center.Y;
                    break;

                case playerControls.Left:
                    base.center = new Point(center.X - 6, center.Y);
                    base.hitbox.X = center.X;
                    break;

                case playerControls.Right:
                    base.center = new Point(center.X + 6, center.Y);
                    base.hitbox.X = center.X;
                    break;

            }
        }

    }
}
