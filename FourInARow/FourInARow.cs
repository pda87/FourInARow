﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInARow
{
    public partial class FourInARow : Form
    {
        Game game;
        Coordinate coordinate = new Coordinate();
        bool allowClick = true;

        public FourInARow()
        {
            InitializeComponent();
        }

        private void FourInARow_Load(object sender, EventArgs e)
        {
            //7 COLUMNS AND 6 ROWS
            restartButton.Enabled = false;
            gameLabel.Text = "";
            game = new Game();
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
                if (game.CurrentPlayer == game.RedPlayer)
                {
                    gameLabel.Text = "Column " + (column + 1) + " full...";
                    return;   
                }

                
            }

            game.PlayGame();

            if (game.FourInARow)
            {
                gameLabel.Text = game.GameResult;
                allowClick = false;
                restartButton.Enabled = true;
                return;
            }

            if (game.CurrentPlayer.Equals(game.BluePlayer))
            {
                blueTurn();
            }

        }

        private void blueTurn()
        {
            if (game.BluePlayerColumn == 0)
            {
                column0();
            }

            else if (game.BluePlayerColumn == 1)
            {
                column1();
            }

            else if (game.BluePlayerColumn == 2)
            {
                column2();
            }

            else if (game.BluePlayerColumn == 3)
            {
                column3();
            }

            else if (game.BluePlayerColumn == 4)
            {
                column4();
            }

            else if (game.BluePlayerColumn == 5)
            {
                column5();
            }

            else if (game.BluePlayerColumn == 6)
            {
                column6();
            }

            else
            {
                throw new Exception("blueTurn();");
            }

        }

        private void column0Click(object sender, EventArgs e)
        {
            column0();
        }
        private void column1Click(object sender, EventArgs e)
        {
            column1();
        }
        private void column2Click(object sender, EventArgs e)
        {
            column2();
        }
        private void column3Click(object sender, EventArgs e)
        {
            column3();
        }
        private void column4Click(object sender, EventArgs e)
        {
            column4();
        }
        private void column5Click(object sender, EventArgs e)
        {
            column5();
        }
        private void column6Click(object sender, EventArgs e)
        {
            column6();
        }

        private void column0()
        {
            handleColumnClicks(
                zeroZero, coordinate = returnCoordinate(0, 0),
                zeroOne, coordinate = returnCoordinate(0, 1),
                zeroTwo, coordinate = returnCoordinate(0, 2),
                zeroThree, coordinate = returnCoordinate(0, 3),
                zeroFour, coordinate = returnCoordinate(0, 4),
                zeroFive, coordinate = returnCoordinate(0, 5),
                0);
        }
        private void column1()
        {
            handleColumnClicks(
                oneZero, coordinate = returnCoordinate(1, 0),
                oneOne, coordinate = returnCoordinate(1, 1),
                oneTwo, coordinate = returnCoordinate(1, 2),
                oneThree, coordinate = returnCoordinate(1, 3),
                oneFour, coordinate = returnCoordinate(1, 4),
                oneFive, coordinate = returnCoordinate(1, 5),
                1);
        }
        private void column2()
        {
            handleColumnClicks(
                twoZero, coordinate = returnCoordinate(2, 0),
                twoOne, coordinate = returnCoordinate(2, 1),
                twoTwo, coordinate = returnCoordinate(2, 2),
                twoThree, coordinate = returnCoordinate(2, 3),
                twoFour, coordinate = returnCoordinate(2, 4),
                twoFive, coordinate = returnCoordinate(2, 5),
                2);
        }
        private void column3()
        {
            handleColumnClicks(
                threeZero, coordinate = returnCoordinate(3, 0),
                threeOne, coordinate = returnCoordinate(3, 1),
                threeTwo, coordinate = returnCoordinate(3, 2),
                threeThree, coordinate = returnCoordinate(3, 3),
                threeFour, coordinate = returnCoordinate(3, 4),
                threeFive, coordinate = returnCoordinate(3, 5),
                3);
        }
        private void column4()
        {
            handleColumnClicks(
                fourZero, coordinate = returnCoordinate(4, 0),
                fourOne, coordinate = returnCoordinate(4, 1),
                fourTwo, coordinate = returnCoordinate(4, 2),
                fourThree, coordinate = returnCoordinate(4, 3),
                fourFour, coordinate = returnCoordinate(4, 4),
                fourFive, coordinate = returnCoordinate(4, 5),
                4);
        }
        private void column5()
        {
            handleColumnClicks(
                fiveZero, coordinate = returnCoordinate(5, 0),
                fiveOne, coordinate = returnCoordinate(5, 1),
                fiveTwo, coordinate = returnCoordinate(5, 2),
                fiveThree, coordinate = returnCoordinate(5, 3),
                fiveFour, coordinate = returnCoordinate(5, 4),
                fiveFive, coordinate = returnCoordinate(5, 5),
                5);
        }
        private void column6()
        {
            handleColumnClicks(
                sixZero, coordinate = returnCoordinate(6, 0),
                sixOne, coordinate = returnCoordinate(6, 1),
                sixTwo, coordinate = returnCoordinate(6, 2),
                sixThree, coordinate = returnCoordinate(6, 3),
                sixFour, coordinate = returnCoordinate(6, 4),
                sixFive, coordinate = returnCoordinate(6, 5),
                6);
        }

        private Coordinate returnCoordinate(int x, int y)
        {
            Coordinate coordinate = new Coordinate();

            coordinate.XCoordinate = x;
            coordinate.YCoordinate = y;

            return coordinate;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            var list = this.Controls;

            foreach (var item in list)
            {
                PictureBox pb;

                if (item is System.Windows.Forms.PictureBox)
                {
                    pb = (PictureBox)item;
                    pb.ImageLocation = null;
                }
            }

            game = new Game();
            gameLabel.Text = "";
            coordinate = new Coordinate();
            allowClick = true;
            restartButton.Enabled = false;
        }
    }
}
