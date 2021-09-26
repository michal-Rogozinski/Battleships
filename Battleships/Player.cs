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
        public bool LoosingCondition
        {
            get
            {
                return Fleet.TrueForAll(e => e.IsSunk);
            }
        }
        public void PlaceShips()
        {
            Random rng = new(Guid.NewGuid().GetHashCode());
            foreach (var entry in Fleet)
            {
                bool loopCondition = true;
                while (loopCondition)
                {
                    int startRow = rng.Next(1, 11);
                    int startCol = rng.Next(1, 11);
                    int tempRow = startRow, tempCol = startCol;
                    if (Util.GetBool()) //true for vertical
                    {
                        tempCol += entry.ShipSize;
                    }
                    else
                    {
                        tempRow += entry.ShipSize;
                    }
                    if (tempCol > 10 || tempRow > 10)
                    {
                        loopCondition = true;
                        continue;
                    }

                    var panelList = Field.SquaresList.FetchPanelRange(startRow, startCol, tempRow, tempCol);

                    if (panelList.Any(e => e.IsOccupied))
                    {
                        loopCondition = true;
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
            for (int i = 1; i <= 10; i++)
            {
                for (int k = 1; k <= 10; k++)
                {
                    Console.Write(Field.SquaresList.At(i, k).ReturnStatus + " ");
                }
                Console.Write("            ");
                for (int o = 1; o <= 10; o++)
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

        public FiringResult RegisterStrike(Coordinates coordinates)
        {
            var tile = Field.SquaresList.At(coordinates.row, coordinates.col);
            if (!tile.IsOccupied)
            {
                Console.WriteLine("Miss at coordinates: {0} , {1} .", coordinates.row, coordinates.col);
                return FiringResult.Miss;
            }
            else
            {
                var ship = Fleet.Find(e => e.ShipType == tile.TileStatus);
                ship.HitsCount += 1;
                Console.WriteLine("Hit at coordinates: {0} , {1} at player {2}.", coordinates.row, coordinates.col, PlayerName);
                if (ship.IsSunk)
                {
                    Console.WriteLine("The {0} of player {1} has been sunk.", ship.ShipName, PlayerName);
                }
                return FiringResult.Strike;
            }
        }

        public void UpdateBoardTiles(Coordinates coordinates, FiringResult result)
        {
            var entry = HitsBoard.SquaresList.At(coordinates.row, coordinates.col);
            if (result.Equals(FiringResult.Strike))
            {
                entry.TileStatus = TypeEnumeration.Hit;
            }
            else
            {
                entry.TileStatus = TypeEnumeration.Miss;
            }
        }

        public Coordinates FireAtRandomCoords()
        {
            Random rng = new(Guid.NewGuid().GetHashCode());
            var panels = HitsBoard.GetOpenPanels();
            return panels.ElementAt(rng.Next(panels.Count));
        }

        public Coordinates FireAtNeighbouringSquares()
        {
            Random rng = new(Guid.NewGuid().GetHashCode());
            var panels = HitsBoard.GetHitNeighbours();
            return panels.ElementAt(rng.Next(panels.Count));
        }
    }
}
