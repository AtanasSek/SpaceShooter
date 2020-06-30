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

            base.hitpoints = 100;
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
        
    }
}
