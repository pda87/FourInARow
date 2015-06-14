using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow
{
    class Game
    {

        private Player redPlayer = new Player();
        private Player bluePlayer = new Player();
        private Player currentPlayer = new Player();
        private List<ClaimedSquare> squareTracker = new List<ClaimedSquare>();
        private int bluePlayerColumn = 0;
        private List<int> blueColumnsAvailable = new List<int>();
        private bool fourInARow = false;
        private string gameResult = string.Empty;

        public Player RedPlayer
        {
            get
            {
                return redPlayer;
            }
            set
            {
                redPlayer = value;
            }
        }

        public Player BluePlayer
        {
            get
            {
                return bluePlayer;
            }
            set
            {
                bluePlayer = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
            set
            {
                currentPlayer = value;
            }
        }

        public List<ClaimedSquare> SquareTracker
        {
            get
            {
                return squareTracker;
            }
            set
            {
                squareTracker = value;
            }
        }

        public int BluePlayerColumn
        {
            get
            {
                return bluePlayerColumn;
            }
            set
            {
                bluePlayerColumn = value;
            }
        }

        public List<int> BlueColumnsAvailable
        {
            get
            {
                return blueColumnsAvailable;
            }
            set
            {
                blueColumnsAvailable = value;
            }
        }

        public bool FourInARow
        {
            get
            {
                return fourInARow;
            }
            set
            {
                fourInARow = value;
            }
        }

        public string GameResult
        {
            get
            {
                return gameResult;
            }
            set
            {
                gameResult = value;
            }
        }

        public Game()
        {
            this.redPlayer.PlayerColour = PlayerColour.RedPlayer;
            this.redPlayer.CounterImageString = "RedCounter.png";
            this.bluePlayer.PlayerColour = PlayerColour.BluePlayer;
            this.bluePlayer.CounterImageString = "BlueCounter.png";
            this.currentPlayer = BluePlayer;
            this.blueColumnsAvailable = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

            Random random = new Random();
            int shuffle = random.Next(1, 3);

            if (shuffle == 1)
            {
                List<int> tempList = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
                this.blueColumnsAvailable.Clear();

                foreach (int column in tempList)
                {
                    int newValue = 6 - column;
                    this.blueColumnsAvailable.Add(newValue);
                }

            }

            else if (shuffle == 2)
            {
                this.blueColumnsAvailable = (from number in this.blueColumnsAvailable
                                             select number).OrderBy(o => o.Equals(this.blueColumnsAvailable.Min())).ToList();
            }

            else if (shuffle == 3)
            {
                this.blueColumnsAvailable = (from number in this.blueColumnsAvailable
                                             select number).OrderByDescending(o => o.Equals(this.blueColumnsAvailable.Max())).ToList();
            }

            this.PlayGame();
        }

        public void PlayGame()
        {
            checkFourInARow();

            if (this.fourInARow)
            {
                return;
            }

            if (this.currentPlayer == BluePlayer)
            {
                this.currentPlayer = RedPlayer;
            }

            else
            {
                this.currentPlayer = BluePlayer;
                bluePlayerTurn();
            }
        }

        private void bluePlayerTurn()
        {
            Random random = new Random();
            this.bluePlayerColumn = random.Next(0, this.blueColumnsAvailable.Count);
            this.bluePlayerColumn = this.blueColumnsAvailable[this.bluePlayerColumn];

            List<ClaimedSquare> bluePlayerSquares = this.squareTracker.Where(o => o.Player.Equals(this.bluePlayer)).ToList();
            List<ClaimedSquare> redPlayerSquares = this.squareTracker.Where(o => o.Player.Equals(this.redPlayer)).ToList();

            if (this.squareTracker.Count(sq => sq.Coordinate.XCoordinate.Equals(this.bluePlayerColumn)) == 6)
            {
                this.blueColumnsAvailable.RemoveAll(o => o.Equals(this.bluePlayerColumn));

                for (int i = 0; i < this.blueColumnsAvailable.Count; i++)
                {
                    if (this.squareTracker.Count(sq => sq.Coordinate.XCoordinate.Equals(i)) <= 5)
                    {
                        this.bluePlayerColumn = i;
                        this.bluePlayerColumn = this.blueColumnsAvailable[this.bluePlayerColumn];
                        return;
                    }
                }
            }


            else
            {
                return;
            }
        }

        private void checkFourInARow()
        {
            this.GameResult = string.Empty;

            List<ClaimedSquare> redPlayerSquares = this.squareTracker.Where(o => o.Player.Equals(this.redPlayer)).ToList();
            List<ClaimedSquare> bluePlayerSquares = this.squareTracker.Where(o => o.Player.Equals(this.bluePlayer)).ToList();

            checkFourInARowHorizontal(redPlayerSquares);
            checkFourInARowHorizontal(bluePlayerSquares);

            checkFourInARowVertical(redPlayerSquares);
            checkFourInARowVertical(bluePlayerSquares);

            checkFourInARowDiagonal(redPlayerSquares, 1, 2, 3);
            checkFourInARowDiagonal(bluePlayerSquares, 1, 2, 3);

            checkFourInARowDiagonal(redPlayerSquares, -1, -2, -3);
            checkFourInARowDiagonal(bluePlayerSquares, -1, -2, -3);
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
        private void checkFourInARowDiagonal(List<ClaimedSquare> playerSquares, int firstNumber, int secondNumber, int thirdNumber)
        {
            foreach (ClaimedSquare claimedSquare in playerSquares)
            {
                if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + firstNumber)
                    & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 1)) == 1)
                    if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + secondNumber)
                        & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 2)) == 1)
                        if (playerSquares.Count(sq => sq.Coordinate.XCoordinate.Equals(claimedSquare.Coordinate.XCoordinate + thirdNumber)
                            & sq.Coordinate.YCoordinate.Equals(claimedSquare.Coordinate.YCoordinate + 3)) == 1)
                        {
                            this.FourInARow = true;
                            this.GameResult = "FOUR IN A ROW! The winner is: " + this.CurrentPlayer.PlayerColour.ToString() + "!";
                            return;
                        }
            }
        }
    }
}
