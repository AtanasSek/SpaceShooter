using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizuelnoProgramiranjeGame.Properties;

namespace VizuelnoProgramiranjeGame
{

  
    class ShipUpgrade : Spaceship
    {
        //vrednosti za upgrade
        public float projectileCooldown;

        //vrednosti za logika
        public int fallingSpeed;
        public bool assigned;

        //Prima enemy kako argument za da se otkrie pozicijata od koja sto treba da padne
        public ShipUpgrade(int RandomSeed,Enemy enemy)
        {
            this.fallingSpeed = 1;
            this.sprite = new Bitmap(Resources.ESprite);
            
            

            //se setiraat default vrednosti deka cel objekt ke go pratam do igracot i site vrednosti ke gi prevzeme
            //za da ne dade null exception . Ne e naj efikasen nacin
            this.projectileCooldown = 0;
            this.projectileDamage = 0;
            this.hitpoints = 0;
            this.assigned = false;


            //extra life
            if (RandomSeed > 10 && RandomSeed <= 20)
            {
                sprite = new Bitmap(Resources.PSprite);
                this.height = 32;
                this.width = 32;
                this.hitpoints = 1;
                assigned = true;
            }

            //damageUP
            else if (RandomSeed > 5 && RandomSeed <= 10)
            {
                sprite = new Bitmap(Resources.damageUpgrade);
                this.height = 32;
                this.width = 32;
                this.projectileDamage = 1;
                assigned = true;
            }

            //speedUP
            else if (RandomSeed <= 5)
            {
                sprite = new Bitmap(Resources.speedUpgrade);
                this.height = 32;
                this.width = 32;
                this.projectileCooldown = 50;
                assigned = true;
            }

            this.center = enemy.center;
            this.hitbox.X = this.center.X;
            this.hitbox.Y = this.center.Y;
            this.hitbox.Width = this.width;
            this.hitbox.Height = this.height;
        }

        public void Move()
        {
            this.center.Y += fallingSpeed;
            this.hitbox.Y = this.center.Y;
        }

    }
}
