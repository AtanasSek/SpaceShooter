using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VizuelnoProgramiranjeGame.Properties;

namespace VizuelnoProgramiranjeGame
{
    public enum Type { Regular, Tanky, Shooter }
    class Enemy
    {
        Point center;
        int enemyWidth;
        int enemyHeight;
        int hitpoints;
        int enemySpeed;

        public Type type;
        public Bitmap enemySprite;
        public Rectangle enemyHitbox;
        

        public Enemy(Point center, Type type)
        {
            this.center = center;
            enemySprite = new Bitmap(Resources.ESprite);

            this.enemyHitbox.X = this.center.X;
            this.enemyHitbox.Y = this.center.Y;
            
            this.type = type;

            switch (type)
            {
                case Type.Regular:
                    this.hitpoints = 1;
                    this.enemyWidth = 30;
                    this.enemyHeight = 30;
                    this.enemyHitbox.Width = enemyWidth;
                    this.enemyHitbox.Height = enemyHeight;
                    this.enemySpeed = 3;
                    break;

                case Type.Tanky:
                    this.hitpoints = 3;
                    this.enemyWidth = 80;
                    this.enemyHeight = 60;
                    this.enemyHitbox.Width = enemyWidth;
                    this.enemyHitbox.Height = enemyHeight;
                    this.enemySpeed = 1;
                    break;

                case Type.Shooter:
                    this.hitpoints = 1;
                    this.enemyWidth = 40;
                    this.enemyHeight = 40;
                    this.enemyHitbox.Width = enemyWidth;
                    this.enemyHitbox.Height = enemyHeight;
                    this.enemySpeed = 2;
                    break;
            }
        }

        //Treba da se dovrsi boss klasata i posle ova ke bide deprecated
        public Enemy(Point center,int width, int height)
        {
            this.center = center;
            enemySprite = new Bitmap(Resources.ESprite);

            this.hitpoints = 3;
            this.enemyWidth = width;
            this.enemyHeight = height;
            this.enemyHitbox.X = this.center.X;
            this.enemyHitbox.Y = this.center.Y;
            this.enemyHitbox.Width = width;
            this.enemyHitbox.Height = height;
            this.enemySpeed = 1;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image: enemySprite, center.X, center.Y, enemyWidth, enemyHeight);
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
            center = new Point(center.X, center.Y + this.enemySpeed);
            enemyHitbox.Y = center.Y;
        }

        //ShootingPoint e kreirano so cel proektilot da doagja od centarot
        public Projectile Shoot()
        {
            Point shootingPoint = this.center;
            shootingPoint.X = this.center.X + enemyWidth/2;
            Projectile p = new Projectile(shootingPoint);
            p.isEnemyProjectile = true;
            return p;
        }

        public bool isHit(Projectile p)
        {

            if (this.enemyHitbox.IntersectsWith(p.projectileHitbox) && !p.isEnemyProjectile)
            {
                return true;
            }
            else return false;
  
        }
    }
}
