using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class HitsBoard : Field
    {
        public List<Coordinates> GetOpenPanels()
        {
            return SquaresList.Where(e => e.tileStatus == TypeEnumeration.Empty).Select(e => e.coordinates).ToList();
        }

        public List<Square> GetNeighbouringSquares(Coordinates coords)
        {
            var outputList = new List<Square>();

            if(coords.row > 1)
            {
                outputList.Add(SquaresList.At(coords.row - 1, coords.col));
            }
            if(coords.col > 1)
            {
                outputList.Add(SquaresList.At(coords.row, coords.col - 1));
            }
            if(coords.row < 10)
            {
                outputList.Add(SquaresList.At(coords.row + 1, coords.col));
            }
            if(coords.col < 10)
            {
                outputList.Add(SquaresList.At(coords.row, coords.col + 1));
            }
            return outputList;
        }
        public List<Coordinates> GetHitNeighbours()
        {
            List<Square> outputList = new List<Square>();
            var hitsList = SquaresList.Where(e => e.tileStatus == TypeEnumeration.Hit);

            foreach(var entry in hitsList)
            {
                outputList.AddRange(GetNeighbouringSquares(entry.coordinates).ToList());
            }

            return hitsList.Distinct().Where(e => e.tileStatus == TypeEnumeration.Empty).Select(e => e.coordinates).ToList();
        }
    }
}
