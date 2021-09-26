using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class HitsBoard : Field
    {
        //Funkcja zwraca puste pola
        public List<Coordinates> GetOpenPanels()
        {
            return SquaresList.Where(e => e.TileStatus == TypeEnumeration.Empty).Select(e => e.Coordinates).ToList();
        }
        // Funkcja zwraca pola sąsiadujące z polem o podanych koordynatach
        public List<Square> GetNeighbouringSquares(Coordinates coords)
        {
            var outputList = new List<Square>();

            if (coords.row > 1)
            {
                outputList.Add(SquaresList.At(coords.row - 1, coords.col));
            }
            if (coords.col > 1)
            {
                outputList.Add(SquaresList.At(coords.row, coords.col - 1));
            }
            if (coords.row < 10)
            {
                outputList.Add(SquaresList.At(coords.row + 1, coords.col));
            }
            if (coords.col < 10)
            {
                outputList.Add(SquaresList.At(coords.row, coords.col + 1));
            }
            return outputList;
        }
        // Funkcja zwraca pola sąsiadujące z polem trafienia w promieniu jednego pola w każdą strone.
        public List<Coordinates> GetHitNeighbours()
        {
            List<Square> outputList = new();
            var hitsList = SquaresList.Where(e => e.TileStatus == TypeEnumeration.Hit);

            foreach (var entry in hitsList)
            {
                outputList.AddRange(GetNeighbouringSquares(entry.Coordinates).ToList());
            }

            return hitsList.Distinct().Where(e => e.TileStatus == TypeEnumeration.Empty).Select(e => e.Coordinates).ToList();
        }
    }
}
