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
                    base.sprite = new Bitmap(Resources.enemy_red);
                    base.hitpoints = 2;
                    base.width = sprite.Width;
                    base.height = sprite.Width;             
                    base.speed = 3;
                    break;

                case Type.Tanky:
                    base.hitpoints = 10;
                    base.width = 80;
                    base.height = 60;
                    base.speed = 1;
                    break;

                case Type.Shooter:
                    base.sprite = new Bitmap(Resources.enemy_yellow);
                    base.hitpoints = 3;
                    base.width = sprite.Width;
                    base.height = sprite.Width;
                    base.speed = 2;
                    break;
            }

            base.hitbox.Width = base.width;
            base.hitbox.Height = base.height;
        }

        public void Move()
        {
            base.center = new Point(center.X, center.Y + base.speed);
            base.hitbox.Y = base.center.Y;
        }

    }
}
