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
    class Enemy : Spaceship
    {

        public Type type;

        public Enemy(Point center, Type type)
        {
            base.center = center;
            base.sprite = new Bitmap(Resources.ESprite);

            base.hitbox.X = base.center.X;
            base.hitbox.Y = base.center.Y;
            
            this.type = type;

            switch (type)
            {
                case Type.Regular:
                    base.hitpoints = 1;
                    base.width = 30;
                    base.height = 30;
                    
                    base.speed = 3;
                    break;

                case Type.Tanky:
                    base.hitpoints = 3;
                    base.width = 80;
                    base.height = 60;
                    base.speed = 1;
                    break;

                case Type.Shooter:
                    base.hitpoints = 1;
                    base.width = 40;
                    base.height = 40;
                    base.speed = 2;
                    break;
            }

            base.hitbox.Width = base.width;
            base.hitbox.Height = base.height;
        }

        //Treba da se dovrsi boss klasata i posle ova ke bide deprecated
        public Enemy(Point center,int width, int height)
        {
            base.center = center;
            base.sprite = new Bitmap(Resources.ESprite);

            base.hitpoints = 3;
            base.width = width;
            base.height = height;
            base.hitbox.X = this.center.X;
            base.hitbox.Y = this.center.Y;
            base.hitbox.Width = width;
            base.hitbox.Height = height;
            base.speed = 1;
        }

        public void Move()
        {
            base.center = new Point(center.X, center.Y + base.speed);
            base.hitbox.Y = base.center.Y;
        }

        //ShootingPoint e kreirano so cel proektilot da doagja od centarot
        public override Projectile Shoot()
        {
            Point shootingPoint = base.center;
            shootingPoint.X = base.center.X + base.width/2;
            Projectile p = new Projectile(shootingPoint);
            p.isEnemyProjectile = true;
            return p;
        }

        public bool isHit(Projectile p)
        {

            if (base.hitbox.IntersectsWith(p.projectileHitbox) && !p.isEnemyProjectile)
            {
                return true;
            }
            else return false;
  
        }
    }
}
