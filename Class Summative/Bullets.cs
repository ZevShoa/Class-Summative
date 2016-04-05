using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Summative
{
    class Bullets
    {
        public int x, y, size, speed, direction;

        public Bullets(int _x, int _y, int _size, int _speed, int _direction)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;
        }
        public void move(Bullets bl)
        {
            if (bl.direction == 0)
            {
                bl.y -= speed;
            }
            if (bl.direction == 1)
            {
                bl.x += speed;
            }
            if (bl.direction == 2)
            {
                bl.y += speed;
            }
            if (bl.direction == 3)
            {
                bl.x -= speed;
            }

        }

    }
}
