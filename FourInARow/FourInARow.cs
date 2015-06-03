using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInARow
{
    public partial class FourInARow : Form
    {
        Game game;

        public FourInARow()
        {
            InitializeComponent();
        }

        private void FourInARow_Load(object sender, EventArgs e)
        {
            //7 COLUMNS AND 6 ROWS
            gameLabel.Text = "";
            game = new Game();
            game.PlayGame();
        }

        private void handleColumnClicks(PictureBox pb0, PictureBox pb1, PictureBox pb2, PictureBox pb3, PictureBox pb4, PictureBox pb5, int column)
        {
            gameLabel.Text = "";

            if (pb0.ImageLocation == null)
            {
                pb0.ImageLocation = game.CurrentPlayer.CounterImageString;
            }

            else if (pb1.ImageLocation == null)
            {
                pb1.ImageLocation = game.CurrentPlayer.CounterImageString;
            }

            else if (pb2.ImageLocation == null)
            {
                pb2.ImageLocation = game.CurrentPlayer.CounterImageString;
            }

            else if (pb3.ImageLocation == null)
            {
                pb3.ImageLocation = game.CurrentPlayer.CounterImageString;
            }

            else if (pb4.ImageLocation == null)
            {
                pb4.ImageLocation = game.CurrentPlayer.CounterImageString;
            }

            else if (pb5.ImageLocation == null)
            {
                pb5.ImageLocation = game.CurrentPlayer.CounterImageString;
            }

            else
            {
                gameLabel.Text = "Column " + column + " full...";
            }

            game.PlayGame();
        }

        private void column0Click(object sender, EventArgs e)
        {
            handleColumnClicks(zeroZero, zeroOne, zeroTwo, zeroThree, zeroFour, zeroFive, 1);
        }

        private void column1Click(object sender, EventArgs e)
        {
            handleColumnClicks(oneZero, oneOne, oneTwo, oneThree, oneFour, oneFive, 2);
        }

        private void column2Click(object sender, EventArgs e)
        {
            handleColumnClicks(twoZero, twoOne, twoTwo, twoThree, twoFour, twoFive, 3);
        }

        private void column3Click(object sender, EventArgs e)
        {
            handleColumnClicks(threeZero, threeOne, threeTwo, threeThree, threeFour, threeFive, 4);
        }

        private void column4Click(object sender, EventArgs e)
        {
            handleColumnClicks(fourZero, fourOne, fourTwo, fourThree, fourFour, fourFive, 5);
        }

        private void column5Click(object sender, EventArgs e)
        {
            handleColumnClicks(fiveZero, fiveOne, fiveTwo, fiveThree, fiveFour, fiveFive, 6);
        }

        private void column6Click(object sender, EventArgs e)
        {
            handleColumnClicks(sixZero, sixOne, sixTwo, sixThree, sixFour, sixFive, 7);
        }
    }
}
