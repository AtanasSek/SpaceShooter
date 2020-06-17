using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProgramiranjeGame
{
    class Projectile
    {
        Point firingPoint;
        int projectileVelocity = 10;
        public Projectile(Point firingPoint)
        {
            this.firingPoint = firingPoint;
        }

        public Point getFiringPoint()
        {
            return firingPoint;
        }
        
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Cyan);
            g.FillEllipse(brush, firingPoint.X , firingPoint.Y , 7, 15);
            brush.Dispose();
            
        }

        public void Move()
        {
            this.firingPoint.Y -= projectileVelocity;
        }
    }
}
