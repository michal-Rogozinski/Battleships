using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Field
    {
        public List<Square> SquaresList { get; set; }

        public Field()
        {
            SquaresList = new();

            for(int row = 1; row <= 10; row++)
            {
                for(int col = 1;col <= 10; col++)
                {
                    SquaresList.Add(new Square(new Coordinates(row, col)));
                }
            }
        }
    }
}
