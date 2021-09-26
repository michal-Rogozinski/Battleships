using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Coordinates
    {
        public int row;
        public int col;

        public Coordinates(int row,int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
