using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VizuelnoProgramiranjeGame.Properties;

namespace VizuelnoProgramiranjeGame
{

    public enum Direction
    {
        Up,Down,Left,Right
    }
    class Player
    {
        public Point center;
        public Direction direction;
        public static readonly int playerHeight = 3;
        public static readonly int playerWidth = 3;
        public Bitmap playerSprite;

        public Player(Point center)
        {
            this.center = center;
            this.playerSprite = new Bitmap(Resources.PSprite);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(playerSprite, center.X, center.Y, playerWidth, playerHeight);
            Console.WriteLine("I'm dead inside");
        }

      
    }
}
