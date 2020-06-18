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
        public Rectangle projectileHitbox;
        public int projectileWidth = 7;
        public int projectileHeight = 15;
        public Projectile(Point firingPoint)
        {
            this.firingPoint = firingPoint;
            projectileHitbox.X = firingPoint.X;
            projectileHitbox.Y = firingPoint.Y;
            projectileHitbox.Width = projectileWidth;
            projectileHitbox.Height = projectileHeight;
        }

        public Point getFiringPoint()
        {
            return firingPoint;
        }
        
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Cyan);
            g.FillEllipse(brush, firingPoint.X , firingPoint.Y , projectileWidth, projectileHeight);
            brush.Dispose();
            
        }

        public void Move()
        {
            this.firingPoint.Y -= projectileVelocity;
            this.projectileHitbox.Y -= projectileVelocity;
        }
    }
}
