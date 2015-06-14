using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow
{
    class Coordinate
    {
        private int xCoordinate = 0;
        private int yCoordinate = 0;

        public int XCoordinate
        {
            get
            {
                return xCoordinate;
            }
            set
            {
                xCoordinate = value;
            }
        }

        public int YCoordinate
        {
            get
            {
                return yCoordinate;
            }
            set
            {
                yCoordinate = value;
            }
        }

    }
}
