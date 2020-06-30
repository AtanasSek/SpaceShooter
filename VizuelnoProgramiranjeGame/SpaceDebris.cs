using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizuelnoProgramiranjeGame.Properties;

namespace VizuelnoProgramiranjeGame
{
    class SpaceDebris
    {
        public Point center;
        Bitmap sprite;

        public SpaceDebris(Point center, Bitmap particleSprite)
        {
            this.center = center;
            this.sprite = particleSprite;
        }
        public void Draw(Graphics e)
        {
            e.DrawImage(sprite, center);
        }

        public void Move()
        {
            this.center.Y += 1;
        }
    }
}
