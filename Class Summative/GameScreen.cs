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
        Player pl = new Player(100, 100, 50, 5, new Image[]
        {
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
            Properties.Resources.dancingPanda,
        }
    );
        bool aKeyDown, wKeyDown, dKeyDown, sKeyDown, spaceKeyDown;
        List<Monster> monsters = new List<Monster>();
        List<Bullets> bullets = new List<Bullets>();

        public GameScreen()
        {
            InitializeComponent();
            
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(pl.imageDraw,pl.x,pl.y,pl.size,pl.size);
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            pl.x = 100;
            pl.y = 100;
            Monster mo = new Monster(300, 300, 20, 6, new Image[]
            {
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
                Properties.Resources.dancingObama,
            }
            );
            monsters.Add(mo);

            this.Focus();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (aKeyDown == true)
            {
                pl.move(pl, "left");
                
            }
            else if (wKeyDown == true)
            {
                pl.move(pl,"up");
            }
            else if (dKeyDown == true)
            {
                pl.move(pl, "right");
            }
            else if (sKeyDown == true)
            {
                pl.move(pl, "down");
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
    }
}
