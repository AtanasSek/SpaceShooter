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

    enum Direction
    {
        Up,Down,Left,Right
    }
    class Player
    {
        public Point center;
        public static readonly int playerHeight = 50;
        public static readonly int playerWidth = 50;
        public Bitmap playerSprite;

        public Player(Point center)
        {
            this.center = center;
            this.playerSprite = new Bitmap(Resources.PSprite);
        }
    
        public void Draw(Graphics g)
        {
            g.DrawImage(image: playerSprite, center.X, center.Y, playerWidth, playerHeight);
            Console.WriteLine("Drawing player");
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    this.center = new Point(center.X, center.Y - 12);
                    break;

                case Direction.Down:
                    this.center = new Point(center.X, center.Y + 12);
                    break;

                case Direction.Left:
                    this.center = new Point(center.X - 12, center.Y);
                    break;

                case Direction.Right:
                    this.center = new Point(center.X + 12, center.Y);
                    break;
            }

           
        }

    }
}
