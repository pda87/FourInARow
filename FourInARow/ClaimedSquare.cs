using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow
{
    class ClaimedSquare
    {
        private Player player = new Player();
        private Coordinate coordinate = new Coordinate();

        public Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }

        }

        public Coordinate Coordinate
        {
            get
            {
                return coordinate;
            }
            set
            {
                coordinate = value;
            }

        }
    }
}
