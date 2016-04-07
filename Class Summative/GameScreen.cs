using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_Summative
{
    public partial class GameScreen : UserControl
    {
        int bulletSpeed = 10;
        int bulletSize = 5;
        int bulletDirection;
        SolidBrush bulletBrush = new SolidBrush(Color.LightGoldenrodYellow);
        Player pl = new Player(100, 100, 50, 5, new Image[]
        {
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
        }
    );
        Monster mo = new Monster(300, 300, 20, 6, new Image[]
            {
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
            }
            );
        bool aKeyDown, wKeyDown, dKeyDown, sKeyDown, spaceKeyDown;
        List<Monster> monsters = new List<Monster>();
        List<Bullets> bullets = new List<Bullets>();

        public GameScreen()
        {
            InitializeComponent();
            
        }

      

        private void GameScreen_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            pl.x = 100;
            pl.y = 100;
            
            monsters.Add(mo);
            Bullets bl = new Bullets(100, 100, 5, 20, 0);
           

            this.Focus();
        }
       public void bulletShoot()
        {
            if (spaceKeyDown == true)
            {
                Bullets bl = new Bullets(pl.x, pl.y, bulletSize, bulletSpeed, bulletDirection);
                bullets.Add(bl);      
            }
            foreach (Bullets bl in bullets)
            {
                bl.move(bl, bulletDirection);
                
            }
            foreach (Bullets bl in bullets)
            {
                if (bl.x < 0 || bl.x > this.Width || bl.y < 0 || bl.y > this.Height)
                {
                    bullets.Remove(bl);
                    break;
                }
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
           
            if (aKeyDown == true)
            {
                pl.move(pl, "left");
                bulletDirection = 0;
                

            }
            else if (wKeyDown == true)
            {
                pl.move(pl, "up");
                bulletDirection = 1;
               
            }
            else if (dKeyDown == true)
            {
                pl.move(pl, "right");
                bulletDirection = 2;
                
            }
            else if (sKeyDown == true)
            {
                pl.move(pl, "down");
                bulletDirection = 3;
               
            }
            if(spaceKeyDown == true)
            {
                bulletShoot();
            }
            if (bullets.Count > 0)
            {
                bulletShoot();
            }
            Refresh();
        }
        

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
                default:
                    break;


            }
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(pl.imageDraw, pl.x, pl.y, pl.size, pl.size);
            e.Graphics.DrawImage(mo.monsterDraw, mo.x, mo.y, mo.size, mo.size);
            foreach (Bullets bl in bullets)
            {
                e.Graphics.FillEllipse(bulletBrush, bl.x, bl.y, bl.size, bl.size);
            }
        }
    }
}
