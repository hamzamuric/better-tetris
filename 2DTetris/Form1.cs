using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DTetris
{
    public partial class Form1 : Form
    {
        Game game;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            game = new Game();
            timer.Enabled = true;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
            DrawUtils.DrawLine(e.Graphics, 0, 4, game.matrixWidth, 4);
        }

        private void OnTick(object sender, EventArgs e)
        {
            game.Update();
            txtScore.Text = game.Score.ToString();
            Invalidate();
            Focus();
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            if (key == 'd')
            {
                game.MoveBlock(Direction.Right);
                Invalidate();
            }
            else if (key == 'a')
            {
                game.MoveBlock(Direction.Left);
                Invalidate();
            }
            else if (key == 's')
            {
                game.MoveBlock(Direction.Down);
                Invalidate();
            }
            else if (key == ' ')
            {
                game.Rotate();
                Invalidate();
            }
        }

        private void OnNewGame(object sender, EventArgs e)
        {
            game = new Game();
            Invalidate();
        }
    }
}
