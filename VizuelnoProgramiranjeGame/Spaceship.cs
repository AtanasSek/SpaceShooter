using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProgramiranjeGame
{
    class Spaceship
    {
        public Point center;
        public int height;
        public int width;
        public Bitmap sprite;
        public Rectangle hitbox;
        public int hitpoints = 1;
        public int speed;

        public float shootCooldown = 1;
        public Stopwatch CooldownTimer;
        

        public void Draw(Graphics g)
        {
            g.DrawImage(image: sprite, center.X, center.Y, width, height);
        }

        public void Damage(Projectile p)
        {
            this.hitpoints -= p.projectileDamage;
        }

        public void PureDamage(int damage)
        {
            this.hitpoints -= damage;
        }

        public virtual Projectile Shoot()
        {
            Point shootingPoint = this.center;
            shootingPoint.X = this.center.X + width / 2;
            Projectile p = new Projectile(shootingPoint);
            p.isEnemyProjectile = true;
            return p;
        }

        public virtual bool isHit(Projectile p)
        {

            if (hitbox.IntersectsWith(p.projectileHitbox) && !p.isEnemyProjectile)
            {
                return true;
            }
            else return false;

        }
    }

    
}
