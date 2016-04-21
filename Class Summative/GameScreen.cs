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

        Random randNum = new Random();
        int bulletSpeed = 10;
        int bulletSize = 5;
        int bulletDirection;
        int monsterDirection;
        int monsterCounter = 50;
        //Brush for the bullets
        SolidBrush bulletBrush = new SolidBrush(Color.LightGoldenrodYellow);
        // making the player
        Player pl = new Player(100, 100, 50, 5, new Image[]
        {
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
        }
    );
        
        //making the first monster 
        Monster mo = new Monster(300, 300, 100, 6, 2, new Image[]
{
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
}
);
        bool aKeyDown, wKeyDown, dKeyDown, sKeyDown, spaceKeyDown;
        //making lists for both the monster and the bullets
        List<Monster> monsters = new List<Monster>();
        List<Bullets> bullets = new List<Bullets>();

        Bullets bl = new Bullets(100, 100, 5, 20, 0);
        public GameScreen()
        {
            InitializeComponent();

        }
        private void GameScreen_Load(object sender, EventArgs e)
        {
            //Starting the game timer and positioning my player and monster
            gameTimer.Enabled = true;
            pl.x = 100;
            pl.y = 100;
            monsters.Add(mo);
            mo.direction = monsterDirection;
            this.Focus();
        }
        public void bulletShoot()
        {
            //if the space key is down then add a bullet
            if (spaceKeyDown == true)
            {
                Bullets bl = new Bullets(pl.x, pl.y, bulletSize, bulletSpeed, bulletDirection);
                bullets.Add(bl);
            }
            foreach (Bullets bl in bullets)
            {
                // makes the bullets move
                bl.move(bl);

            }
            foreach (Bullets bl in bullets)
            {
                // if the bullets go off screen then remove it
                if (bl.x < 0 || bl.x > this.Width || bl.y < 0 || bl.y > this.Height)
                {
                    bullets.Remove(bl);
                    break;
                }
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //take one away from the counter 
            monsterCounter--;
            //if it is at zero then add a monster and rest the counter
            if(monsterCounter == 0)
            {
                Monster mo = new Monster(randNum.Next(100, 800), randNum.Next(100, 800), 100, 6, monsterDirection, new Image[]
{
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
}
);
                monsters.Add(mo);
                monsterCounter = 50;
            }
            //if there are no monsters on the screen then add a monster
            if (monsters.Count == 0)
            {
                Monster mo = new Monster(randNum.Next(100, 800), randNum.Next(100, 800), 100, 6, monsterDirection, new Image[]
{
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
}
);
                monsters.Add(mo);
                // broken monster collision with bullets 
                //If the bullets rectangle hits the monster rectangle remove both of them
                foreach (Bullets bl in bullets)
                {
                    if (mo.collision(mo, bl) == true)
                    {
                        monsters.Remove(mo);
                        bullets.Remove(bl);
                    }

                }
            }
            //making sure the player and the monster don't go off the screen
            #region Player Wall Collision
            if (pl.x <= 0)
            {
                pl.x += pl.speed;
            }
            if (pl.x + pl.size >= this.Width)
            {
                pl.x -= pl.speed;
            }
            if (pl.y <= 0)
            {
                pl.y += pl.speed;
            }
            if (pl.y + pl.size >= this.Height)
            {
                pl.y -= pl.speed;
            }
            #endregion
            #region Monster Wall Collision
            foreach (Monster mo in monsters)
            {
                if (mo.x <= 0)
                {
                    mo.x += mo.speed;
                }
                if (mo.x + mo.size >= this.Width)
                {
                    mo.x -= mo.speed;
                }
                if (mo.y <= 0)
                {
                    mo.y += mo.speed;
                }
                if (mo.y + mo.size >= this.Height)
                {
                    mo.y -= mo.speed;
                }
            }
            #endregion
            //the logic for monster and player collisions
            foreach (Monster mo in monsters)
            {
                if (pl.collision(pl, mo) == true)
                {
                    gameTimer.Enabled = false;
                    Form f = this.FindForm();
                    endScreen es = new endScreen();
                    f.Controls.Remove(this);
                    f.Controls.Add(es);
                }
            }
            //logic for monster bullet collision
            foreach (Bullets bl in bullets)
            {
                if (mo.collision(mo, bl) == true)
                {
                    monsters.Remove(mo);
                }
            }
// player movement
            if (aKeyDown == true)
            {
                pl.move(pl, "left");
                bulletDirection = 0;
                monsterDirection = 1;
                foreach (Monster mo in monsters)
                {
                    mo.move(mo, monsterDirection);
                }
            }
            else if (wKeyDown == true)
            {
                pl.move(pl, "up");
                bulletDirection = 1;
                monsterDirection = 3;
                foreach (Monster mo in monsters)
                {
                    mo.move(mo, monsterDirection);
                }
            }
            else if (dKeyDown == true)
            {
                pl.move(pl, "right");
                bulletDirection = 2;
                monsterDirection = 0;
                foreach (Monster mo in monsters)
                {

                    mo.move(mo, monsterDirection);
                }
            }
            else if (sKeyDown == true)
            {
                pl.move(pl, "down");
                bulletDirection = 3;
                monsterDirection = 2;
                foreach (Monster mo in monsters)
                {
                    mo.move(mo, monsterDirection);
                }
            }

            if (spaceKeyDown == true)
            {
                bulletShoot();
            }
            if (bullets.Count > 0)
            {
                bulletShoot();
            }
            Refresh();
        }
         //keyup and down methods 
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
        // making the bullets, monsters and player
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawImage(pl.imageDraw, pl.x, pl.y, pl.size, pl.size);
            foreach (Monster mo in monsters)
            {
                e.Graphics.DrawImage(mo.monsterImages[monsterDirection], mo.x, mo.y, mo.size, mo.size);
            }
            foreach (Bullets bl in bullets)
            {
                e.Graphics.FillEllipse(bulletBrush, bl.x, bl.y, bl.size, bl.size);
            }
        }
    }
}
