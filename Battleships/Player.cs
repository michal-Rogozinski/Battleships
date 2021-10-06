using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class Player
    {
        public string PlayerName { get; set; }
        public Field Field { get; set; }
        public HitsBoard HitsBoard { get; set; }
        public List<Ship> Fleet { get; set; }

        public readonly int minValue = 1;
        public readonly int maxValue = 10;

        public Player(string name)
        {
            PlayerName = name;
            Fleet = InitializeFleet();
            Field = new Field();
            HitsBoard = new HitsBoard();
        }

        public static List<Ship> InitializeFleet()
        {
            var shipList = new List<Ship>()
            {
                new Battleship(),
                new Cruiser(),
                new Carrier(),
                new Destroyer(),
                new Submarine()
            };
            return shipList;
        }
        public bool LosingCondition
        {
            get
            {
                return Fleet.TrueForAll(e => e.IsSunk);
            }
        }
        //Metoda losująca położenie statków w flocie
        public void PlaceShips()
        {
            Random rng = new(Guid.NewGuid().GetHashCode());
            foreach (var entry in Fleet)
            {
                bool loopCondition = true;
                while (loopCondition)
                {
                    int upperBound = 11;
                    int lowerBound = 1;
                    int startRow = rng.Next(lowerBound, upperBound);
                    int startCol = rng.Next(lowerBound, upperBound);
                    int tempRow = startRow, tempCol = startCol;
                    if (Util.GetBool()) //true for vertical
                    {
                        tempCol += entry.ShipSize;
                    }
                    else
                    {
                        tempRow += entry.ShipSize;
                    }
                    if (tempCol > maxValue || tempRow > maxValue)
                    {
                        continue;
                    }

                    var panelList = Field.SquaresList.FetchPanelRange(startRow, startCol, tempRow, tempCol);

                    if (panelList.Any(e => e.IsOccupied))
                    {
                        continue;
                    }
                    foreach (var panel in panelList)
                    {
                        panel.TileStatus = entry.ShipType;
                    }
                    loopCondition = false;
                }
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine("My board                          Enemy board");
            for (int i = 1; i <= maxValue; i++)
            {
                for (int k = 1; k <= maxValue; k++)
                {
                    Console.Write(Field.SquaresList.At(i, k).ReturnStatus + " ");
                }
                Console.Write("            ");
                for (int o = 1; o <= maxValue; o++)
                {
                    Console.Write(HitsBoard.SquaresList.At(i, o).ReturnStatus + " ");
                }
                Console.WriteLine("\r\n");
            }
            Console.WriteLine("\r\n");
        }

        public Coordinates PlaceShot()
        {
            var squareNeighbour = HitsBoard.GetHitNeighbours();
            Coordinates outputCoords;
            if (squareNeighbour.Any())
            {
                outputCoords = FireAtNeighbouringSquares();
                return outputCoords;
            }
            else
            {
                outputCoords = FireAtRandomCoords();
                return outputCoords;
            }

        }
        //Metoda aktualizująca ilość trafień statku.
        public void RegisterStrike(Coordinates coordinates)
        {
            var tileField = Field.SquaresList.At(coordinates.row, coordinates.col);
            var tileHitsBoard = HitsBoard.SquaresList.At(coordinates.row, coordinates.col);
            if (!tileField.IsOccupied)
            {
                tileHitsBoard.TileStatus = (TypeEnumeration)FiringResult.Miss;
            }
            else
            {
                var ship = Fleet.Find(e => e.ShipType == tileField.TileStatus);
                ship.HitsCount += 1;
                tileHitsBoard.TileStatus = (TypeEnumeration)FiringResult.Strike;
            }
        }
        public void PrintResult(Coordinates coordinates)
        {
            var tileField = Field.SquaresList.At(coordinates.row, coordinates.col);
            var tileHitsBoard = HitsBoard.SquaresList.At(coordinates.row, coordinates.col);
            if (!tileField.IsOccupied)
            {
                Console.WriteLine("Miss at {0},{1} by {2}", coordinates.row, coordinates.col, PlayerName);
            }
            else
            {
                var ship = Fleet.Find(e => e.ShipType == tileField.TileStatus);
                if (ship is not null && !ship.IsSunk)
                {
                    Console.WriteLine("Hit at {0} at coordinates {1},{2} by {3}", ship.ShipName, coordinates.row, coordinates.col, PlayerName);
                    if (ship.IsSunk)
                    {
                        Console.WriteLine("{0} belonging to {3} sunk at coordinates {1},{2}", ship.ShipName, coordinates.row, coordinates.col, PlayerName);
                    }
                }
            }
        }
        //Metoda wykonująca strzał na losowe koordynaty
        public Coordinates FireAtRandomCoords()
        {
            Random rng = new(Guid.NewGuid().GetHashCode());
            var panels = HitsBoard.GetOpenPanels();
            return panels.ElementAt(rng.Next(panels.Count));
        }
        //Metoda wykonująca strzał na pola sąsiadujace z polem trafienia
        public Coordinates FireAtNeighbouringSquares()
        {
            Random rng = new(Guid.NewGuid().GetHashCode());
            var panels = HitsBoard.GetHitNeighbours();
            return panels.ElementAt(rng.Next(panels.Count));
        }
    }
}
