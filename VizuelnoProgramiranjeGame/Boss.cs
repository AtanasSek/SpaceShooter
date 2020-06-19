using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizuelnoProgramiranjeGame.Properties;

namespace VizuelnoProgramiranjeGame
{
    //Nedovrsena klasa
    class Boss : Spaceship
    {
        
        public Boss(Point center, int width, int height)
        {
            base.center = center;
            base.sprite = new Bitmap(Resources.ESprite);

            base.hitpoints = 3;
            base.width = width;
            base.height = height;
            base.hitbox.X = base.center.X;
            base.hitbox.Y = base.center.Y;
            base.hitbox.Width = width;
            base.hitbox.Height = height;
            base.speed = 1; 
        }

        public void Move()
        {
            if (base.center.Y != 0)
            {
                base.center = new Point(base.center.X, base.center.Y + base.speed);
                base.hitbox.Y = base.center.Y;
            }
        }
        public override Projectile Shoot()
        {
            Point shootingPoint = base.center;
            shootingPoint.X = base.center.X + width / 2;
            Projectile p = new Projectile(shootingPoint);
            p.isEnemyProjectile = true;
            return p;
        }

        public bool isHit(Projectile p)
        {
            if (this.hitbox.IntersectsWith(p.projectileHitbox) && !p.isEnemyProjectile)
            {
                return true;
            }
            else return false;
        }
    }
}
