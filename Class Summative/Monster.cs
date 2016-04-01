using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Class_Summative
{
    class Monster
    {
        public int x, y, size, speed;
        public Image monsterDraw;
        public Image[] monsterImages;

        public Monster(int _x, int _y, int _size, int _speed, Image[] _monsterImages)
            {
             x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            monsterImages = _monsterImages;
            }
        public void move(Monster mo,string direction)
        {
            if (direction == "up")
            {
                mo.monsterDraw = mo.monsterImages[0];
                mo.y -= speed;

            }
            else if (direction == "down")
            {
                mo.monsterDraw = mo.monsterImages[1];
                mo.y += speed;
            }
            else if (direction == "right")
            {
                mo.monsterDraw = mo.monsterImages[2];
                mo.x += speed;
            }
            else if (direction == "left")
            {
                mo.monsterDraw = mo.monsterImages[3];
                mo.x -= speed;
            }

        }
    }
}
