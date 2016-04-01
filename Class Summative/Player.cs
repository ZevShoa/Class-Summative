using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Class_Summative
{
    class Player
    {
        public int x, y, size, speed;
        public Image imageDraw;
        public Image[] images;

        public Player(int _x, int _y, int _size, int _speed, Image[] _images)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            images = _images;

        }
       

        public void move(Player pl, string direction)
        {
            if (direction == "up")
            {
                pl.imageDraw = pl.images[0];
                pl.y -= speed;

            }
            else if (direction == "down")
            {
                pl.imageDraw = pl.images[1];
                pl.y += speed;
            }
            else if (direction == "right")
            {
                pl.imageDraw = pl.images[2];
                pl.x += speed;
            }
            else if (direction == "left")
            {
                pl.imageDraw = pl.images[3];
                pl.x -= speed;
            }
        }
        public bool collision(Player pl, Monster mo )
        {
            Rectangle plRec = new Rectangle(pl.x, pl.y, pl.size, pl.size);
            Rectangle moRec = new Rectangle(mo.x, mo.y, mo.size, mo.size);
            if (plRec.IntersectsWith(moRec))
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
