using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VizuelnoProgramiranjeGame.Properties;
using System.Windows.Forms;

namespace VizuelnoProgramiranjeGame
{

    enum playerControls
    {
        Up,Down,Left,Right
    }
    class Player
    {
        public Point center;
        public static readonly int playerHeight = 50;
        public static readonly int playerWidth = 50;
        public Bitmap playerSprite;
        float projectileCooldown = 1;
        Timer shootCooldown;

        public Player(Point center)
        {
            this.center = center;
            this.playerSprite = new Bitmap(Resources.PSprite);
            this.shootCooldown = new Timer();
        }
    
        public void Draw(Graphics g)
        {
            g.DrawImage(image: playerSprite, center.X, center.Y, playerWidth, playerHeight);
            Console.WriteLine("Drawing player");
        }

        public Projectile Shoot()//TODO: Cooldown treba na pukanje
        {
            
            shootCooldown.Start();
            
            Projectile p = new Projectile(this.center);
            return p;
           
        }

        public void Move(playerControls action)
        {
            switch (action)
            {
                case playerControls.Up:
                    this.center = new Point(center.X, center.Y - 12);
                    break;

                case playerControls.Down:
                    this.center = new Point(center.X, center.Y + 12);
                    break;

                case playerControls.Left:
                    this.center = new Point(center.X - 12, center.Y);
                    break;

                case playerControls.Right:
                    this.center = new Point(center.X + 12, center.Y);
                    break;

            }
        }

    }
}
