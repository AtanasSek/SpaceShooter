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
        Rectangle bossHitbox;
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
    }
}
