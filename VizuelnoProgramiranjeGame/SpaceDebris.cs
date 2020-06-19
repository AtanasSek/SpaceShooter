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
        Point spawn;
        Bitmap sprite;

        public SpaceDebris(Point spawn)
        {
            this.spawn = spawn;
            this.sprite = new Bitmap(Resources.Space_Particle);
        }
        public void Draw(Graphics e)
        {
            e.DrawImage(sprite, spawn);
        }

        public void Move()
        {
            this.spawn.Y += 1;
        }
    }
}
