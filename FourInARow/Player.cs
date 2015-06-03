using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow
{
    class Player
    {
        public PlayerColour PlayerColour { get; set; }
        public string CounterImageString { get; set; }
    }

    enum PlayerColour
    {
        RedPlayer,
        BluePlayer
    }
}
