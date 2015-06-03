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

        public Game()
        {
            this.RedPlayer = new Player();
            this.RedPlayer.PlayerColour = PlayerColour.RedPlayer;
            this.RedPlayer.CounterImageString = "RedCounter.png";
            this.BluePlayer = new Player();
            this.BluePlayer.PlayerColour = PlayerColour.BluePlayer;
            this.BluePlayer.CounterImageString = "BlueCounter.png";
            this.CurrentPlayer = BluePlayer;
        }

        public void PlayGame()
        {
            if (this.CurrentPlayer == BluePlayer)
            {
                this.CurrentPlayer = RedPlayer;
            }

            else
            {
                this.CurrentPlayer = BluePlayer;
            }
        }
    }

    
}
