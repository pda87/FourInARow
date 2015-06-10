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
        Coordinate coordinate  = new Coordinate();
        bool allowClick = true;

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

        private void handleColumnClicks(PictureBox pb0, Coordinate pb0Coordinate,
            PictureBox pb1, Coordinate pb1Coordinate,
            PictureBox pb2, Coordinate pb2Coordinate,
            PictureBox pb3, Coordinate pb3Coordinate,
            PictureBox pb4, Coordinate pb4Coordinate,
            PictureBox pb5, Coordinate pb5Coordinate,
            int column)
        {
            if (!allowClick)
            {
                return;
            }

            gameLabel.Text = "";

            if (pb0.ImageLocation == null)
            {
                pb0.ImageLocation = game.CurrentPlayer.CounterImageString;
                game.SquareTracker.Add(new ClaimedSquare() { Player = game.CurrentPlayer, Coordinate = pb0Coordinate });
            }

            else if (pb1.ImageLocation == null)
            {
                pb1.ImageLocation = game.CurrentPlayer.CounterImageString;
                game.SquareTracker.Add(new ClaimedSquare() { Player = game.CurrentPlayer, Coordinate = pb1Coordinate });
            }

            else if (pb2.ImageLocation == null)
            {
                pb2.ImageLocation = game.CurrentPlayer.CounterImageString;
                game.SquareTracker.Add(new ClaimedSquare() { Player = game.CurrentPlayer, Coordinate = pb2Coordinate });
            }

            else if (pb3.ImageLocation == null)
            {
                pb3.ImageLocation = game.CurrentPlayer.CounterImageString;
                game.SquareTracker.Add(new ClaimedSquare() { Player = game.CurrentPlayer, Coordinate = pb3Coordinate });
            }

            else if (pb4.ImageLocation == null)
            {
                pb4.ImageLocation = game.CurrentPlayer.CounterImageString;
                game.SquareTracker.Add(new ClaimedSquare() { Player = game.CurrentPlayer, Coordinate = pb4Coordinate });
            }

            else if (pb5.ImageLocation == null)
            {
                pb5.ImageLocation = game.CurrentPlayer.CounterImageString;
                game.SquareTracker.Add(new ClaimedSquare() { Player = game.CurrentPlayer, Coordinate = pb5Coordinate });
            }

            else
            {
                gameLabel.Text = "Column " + column + " full...";
            }

            game.PlayGame();

            if (game.FourInARow)
            {
                gameLabel.Text = game.GameResult;
                allowClick = false;
            }

        }

        private void column0Click(object sender, EventArgs e)
        {
            handleColumnClicks(
                zeroZero, coordinate = returnCoordinate(0, 0),
                zeroOne, coordinate = returnCoordinate(0, 1),
                zeroTwo, coordinate = returnCoordinate(0, 2),
                zeroThree, coordinate = returnCoordinate(0, 3),
                zeroFour, coordinate = returnCoordinate(0, 4),
                zeroFive, coordinate = returnCoordinate(0, 5),
                1);
        }

        private void column1Click(object sender, EventArgs e)
        {
            handleColumnClicks(
                oneZero, coordinate = returnCoordinate(1, 0),
                oneOne, coordinate = returnCoordinate(1, 1),
                oneTwo, coordinate = returnCoordinate(1, 2),
                oneThree, coordinate = returnCoordinate(1, 3),
                oneFour, coordinate = returnCoordinate(1, 4),
                oneFive, coordinate = returnCoordinate(1, 5),
                2);
        }

        private void column2Click(object sender, EventArgs e)
        {
            handleColumnClicks(
                twoZero, coordinate = returnCoordinate(2, 0),
                twoOne, coordinate = returnCoordinate(2, 1),
                twoTwo, coordinate = returnCoordinate(2, 2),
                twoThree, coordinate = returnCoordinate(2, 3),
                twoFour, coordinate = returnCoordinate(2, 4),
                twoFive, coordinate = returnCoordinate(2, 5),
                3);
        }

        private void column3Click(object sender, EventArgs e)
        {
            handleColumnClicks(
                threeZero, coordinate = returnCoordinate(3, 0),
                threeOne, coordinate = returnCoordinate(3, 1),
                threeTwo, coordinate = returnCoordinate(3, 2),
                threeThree, coordinate = returnCoordinate(3, 3),
                threeFour, coordinate = returnCoordinate(3, 4),
                threeFive, coordinate = returnCoordinate(3, 5),
                4);
        }

        private void column4Click(object sender, EventArgs e)
        {
            handleColumnClicks(
                fourZero, coordinate = returnCoordinate(4, 0),
                fourOne, coordinate = returnCoordinate(4, 1),
                fourTwo, coordinate = returnCoordinate(4, 2),
                fourThree, coordinate = returnCoordinate(4, 3),
                fourFour, coordinate = returnCoordinate(4, 4),
                fourFive, coordinate = returnCoordinate(4, 5),
                5);
        }

        private void column5Click(object sender, EventArgs e)
        {
            handleColumnClicks(
                fiveZero, coordinate = returnCoordinate(5, 0),
                fiveOne, coordinate = returnCoordinate(5, 1),
                fiveTwo, coordinate = returnCoordinate(5, 2),
                fiveThree, coordinate = returnCoordinate(5, 3),
                fiveFour, coordinate = returnCoordinate(5, 4),
                fiveFive, coordinate = returnCoordinate(5, 5),
                6);
        }

        private void column6Click(object sender, EventArgs e)
        {
            handleColumnClicks(
                sixZero, coordinate = returnCoordinate(6, 0),
                sixOne, coordinate = returnCoordinate(6, 1),
                sixTwo, coordinate = returnCoordinate(6, 2),
                sixThree, coordinate = returnCoordinate(6, 3),
                sixFour, coordinate = returnCoordinate(6, 4),
                sixFive, coordinate = returnCoordinate(6, 5),
                7);
        }

        private Coordinate returnCoordinate(int x, int y)
        {
            Coordinate coordinate = new Coordinate();

            coordinate.XCoordinate = x;
            coordinate.YCoordinate = y;

            return coordinate;
        }
    }
}
