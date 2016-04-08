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
        public int x, y, size, speed, direction;
        public Image monsterDraw;
        public Image[] monsterImages;

        public Monster(int _x, int _y, int _size, int _speed, int _direction, Image[] _monsterImages)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;

            monsterImages = _monsterImages;
        }
        public void move(Monster mo, int direction)
        {
            if (direction == 0)
            {
                mo.monsterDraw = mo.monsterImages[direction];
                mo.y -= speed;

            }
            if (direction == 1)
            {
                mo.monsterDraw = mo.monsterImages[direction];
                mo.x += speed;
            }
            if (direction == 2)
            {
                mo.monsterDraw = mo.monsterImages[direction];
                mo.y += speed;
            }
            if (direction == 3)
            {
                mo.monsterDraw = mo.monsterImages[direction];
                mo.x -= speed;
            }



        }
        public bool collision(Monster mo, Bullets bl)
        {
            Rectangle moRec = new Rectangle(mo.x, mo.y, mo.size, mo.size);
            Rectangle blRec = new Rectangle(bl.x, bl.y, bl.size, bl.size);
            if (blRec.IntersectsWith(moRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

