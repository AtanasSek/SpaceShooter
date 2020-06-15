using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProgramiranjeGame
{
    class Enemy
    {
        Point center;
        int radius = 60;
        public Enemy(Point center)
        {
            this.center = center;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, center.X - radius, center.Y - radius,
                2 * radius, 2 * radius);

            brush.Dispose();
        }
    }
}
