///Zev Shoag
/// A basic game engine 
/// created on April 13 2016
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_Summative
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // transfers to a main screen
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
        }
    }
}
