using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow
{
    class Game
    {
        public Player RedPlayer { get; set; }
        public Player BluePlayer { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<ClaimedSquare> SquareTracker { get; set; }
        public bool FourInARow { get; set; }
        public string GameResult { get; set; }

        public Game()
        {
            this.RedPlayer = new Player();
            this.RedPlayer.PlayerColour = PlayerColour.RedPlayer;
            this.RedPlayer.CounterImageString = "RedCounter.png";
            this.BluePlayer = new Player();
            this.BluePlayer.PlayerColour = PlayerColour.BluePlayer;
            this.BluePlayer.CounterImageString = "BlueCounter.png";
            this.CurrentPlayer = BluePlayer;
            this.SquareTracker = new List<ClaimedSquare>();
        }

        public void PlayGame()
        {
            checkForFourInARow();

            if (this.CurrentPlayer == BluePlayer)
            {


                this.CurrentPlayer = RedPlayer;
            }

            else
            {
                this.CurrentPlayer = BluePlayer;
            }
        }

        private void checkForFourInARow()
        {
            this.GameResult = string.Empty;

            List<ClaimedSquare> playerSquaresHorizontal = this.SquareTracker.Where(o => o.Player.Equals(this.CurrentPlayer))/*OrderBy(o => o.Coordinate.XCoordinate)*/.ToList();

            checkFourInARowHorizontal(playerSquaresHorizontal);

            //List<ClaimedSquare> playerSquaresVertical = this.SquareTracker.Where(o => o.Player.Equals(this.CurrentPlayer))./*OrderBy(o => o.Coordinate.YCoordinate).*/ToList();

            checkFourInARowVertical(playerSquaresHorizontal);
            checkFourInARowRightAndUp(playerSquaresHorizontal);
            checkFourInARowLeftAndUp(playerSquaresHorizontal);


        }

        private void checkFourInARowLeftAndUp(List<ClaimedSquare> playerSquares)
        {
            foreach (ClaimedSquare claimedSquare in playerSquares)
            {
                if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate - 1) & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 1)) == 1)
                    if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate - 2) & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 2)) == 1)
                        if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate - 3) & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 3)) == 1)
                        {
                            this.FourInARow = true;
                            this.GameResult = "FOUR IN A ROW! The winner is: " + this.CurrentPlayer.PlayerColour.ToString() + "!";
                            return;
                        }
            }
        }

        private void checkFourInARowRightAndUp(List<ClaimedSquare> playerSquares)
        {
            foreach (ClaimedSquare claimedSquare in playerSquares)
            {
                if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + 1) 
                    & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 1)) == 1)
                    if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + 2) 
                        & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 2)) == 1)
                        if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + 3) 
                            & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 3)) == 1)
                        {
                            this.FourInARow = true;
                            this.GameResult = "FOUR IN A ROW! The winner is: " + this.CurrentPlayer.PlayerColour.ToString() + "!";
                            return;
                        }
            }
        }

        private void checkFourInARowHorizontal(List<ClaimedSquare> playerSquares)
        {
            foreach (ClaimedSquare claimedSquare in playerSquares)
            {
                if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + 1)
                    & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate)) == 1)
                    if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + 2)
                        & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate)) == 1)
                        if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + 3)
                            & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate)) == 1)
                        {
                            this.FourInARow = true;
                            this.GameResult = "FOUR IN A ROW! The winner is: " + this.CurrentPlayer.PlayerColour.ToString() + "!";
                            return;
                        }
            }
        }

        private void checkFourInARowVertical(List<ClaimedSquare> playerSquares)
        {
            foreach (ClaimedSquare claimedSquare in playerSquares)
            {
                if (playerSquares.Count(sq => sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 1)
                    & sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate)) == 1)
                    if (playerSquares.Count(sq => sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 2)
                        & sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate)) == 1)
                        if (playerSquares.Count(sq => sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 3)
                            & sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate)) == 1)
                        {
                            this.FourInARow = true;
                            this.GameResult = "FOUR IN A ROW! The winner is: " + this.CurrentPlayer.PlayerColour.ToString() + "!";
                            return;
                        }
            }
        }

    }


}
