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
    class Boss
    {
        Point center;
        public Rectangle bossHitbox;
        Bitmap bossSprite;
        int hitpoints;
        int width;
        int height;
        int bossSpeed;
        public Boss(Point center, int width, int height)
        {
            this.center = center;
            bossSprite = new Bitmap(Resources.ESprite);

            this.hitpoints = 3;
            this.width = width;
            this.height = height;
            this.bossHitbox.X = this.center.X;
            this.bossHitbox.Y = this.center.Y;
            this.bossHitbox.Width = width;
            this.bossHitbox.Height = height;
            this.bossSpeed = 1; 
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image: bossSprite, center.X, center.Y, width, height);
        }

        public void Damage(Projectile p)
        {
            this.hitpoints -= p.projectileDamage;
        }

        public int getHitPoints()
        {
            return this.hitpoints;
        }

        public void Move()
        {
            if (this.center.Y != 0)
            {
                center = new Point(center.X, center.Y + this.bossSpeed);
                bossHitbox.Y = center.Y;
            }
        }
        public Projectile Shoot()
        {
            Point shootingPoint = this.center;
            shootingPoint.X = this.center.X + width / 2;
            Projectile p = new Projectile(shootingPoint);
            p.isEnemyProjectile = true;
            return p;
        }

        public bool isHit(Projectile p)
        {
            if (this.bossHitbox.IntersectsWith(p.projectileHitbox) && !p.isEnemyProjectile)
            {
                return true;
            }
            else return false;
        }
    }
}
