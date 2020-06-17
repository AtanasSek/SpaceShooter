using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizuelnoProgramiranjeGame.Properties;

namespace VizuelnoProgramiranjeGame
{
    class Enemy
    {
        Point center;
        int enemyWidth = 60;
        int enemyHeight = 60;
        public Bitmap enemySprite;
        public Rectangle enemyHitbox;
        
        public Enemy(Point center)
        {
            this.center = center;
            enemySprite = new Bitmap(Resources.ESprite);

            this.enemyHitbox.X = this.center.X;
            this.enemyHitbox.Y = this.center.Y;
            this.enemyHitbox.Width = enemyWidth;
            this.enemyHitbox.Height = enemyHeight;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image: enemySprite, center.X, center.Y, enemyWidth, enemyHeight);
        }

        public void Move()
        {
            center = new Point(center.X, center.Y + 4);
            enemyHitbox.Y = center.Y;
        }
    }
}
