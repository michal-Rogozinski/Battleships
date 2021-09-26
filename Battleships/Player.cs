using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class Player
    {
        public string playerName { get; set; }
        public Field field { get; set; }
        public HitsBoard hitsBoard { get; set; }
        public List<Ship> fleet { get; set; }

        public Player(string name)
        {
            playerName = name;
            fleet = initializeFleet();
            field = new Field();
            hitsBoard = new HitsBoard();
        }

        public List<Ship> initializeFleet()
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
                return fleet.TrueForAll(e => e.IsSunk);
            }
        }

        public void PlaceShips()
        {
            Random rng = new Random();
            foreach (var entry in fleet)
            {
                bool loopCondition = true;
                while (loopCondition)
                {
                    int startRow = rng.Next(1, 11);
                    int startCol = rng.Next(1, 11);
                    int tempRow = startRow, tempCol = startCol;
                    if (Util.getBool()) //true for vertical
                    {
                        tempCol += entry.shipSize;
                    }
                    else
                    {
                        tempRow += entry.shipSize;
                    }
                    if (tempCol > 10 || tempRow > 10)
                    {
                        loopCondition = true;
                        continue;
                    }

                    var panelList = field.SquaresList.FetchPanelRange(startRow, startCol, tempRow, tempCol);

                    if (panelList.Any(e => e.IsOccupied))
                    {
                        loopCondition = true;
                        continue;
                    }
                    foreach (var panel in panelList)
                    {
                        panel.tileStatus = entry.shipType;
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
                    Console.Write(field.SquaresList.At(i, k).ReturnStatus + " ");
                }
                Console.Write("            ");
                for (int o = 1; o <= 10; o++)
                {
                    Console.Write(hitsBoard.SquaresList.At(i, o).ReturnStatus + " ");
                }
                Console.WriteLine("\r\n");
            }
            Console.WriteLine("\r\n");
        }

        public Coordinates PlaceShot()
        {
            var squareNeighbour = hitsBoard.GetHitNeighbours();
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
            var tile = field.SquaresList.At(coordinates.row, coordinates.col);
            if (!tile.IsOccupied)
            {
                Console.WriteLine("Miss at coordinates: {0} , {1} .", coordinates.row, coordinates.col);
                return FiringResult.Miss;
            }
            else
            {
                var ship = fleet.Find(e => e.shipType == tile.tileStatus);
                ship.hitsCount += 1;
                Console.WriteLine("Hit at coordinates: {0} , {1} at player {2}.", coordinates.row, coordinates.col,playerName);
                if (ship.IsSunk)
                {
                    Console.WriteLine("The {0} of player {1} has been sunk.", ship.name,playerName);
                }
                return FiringResult.Strike;
            }
        }

        public void UpdateBoardTiles(Coordinates coordinates,FiringResult result)
        {
            var entry = hitsBoard.SquaresList.At(coordinates.row, coordinates.col);
            if (result.Equals(FiringResult.Strike))
            {
                entry.tileStatus = TypeEnumeration.Hit;
            }
            else
            {
                entry.tileStatus = TypeEnumeration.Miss;
            }
        }

        public Coordinates FireAtRandomCoords()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            var panels = hitsBoard.GetOpenPanels();
            return panels.ElementAt(rng.Next(panels.Count));
        }

        public Coordinates FireAtNeighbouringSquares()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            var panels = hitsBoard.GetHitNeighbours();
            return panels.ElementAt(rng.Next(panels.Count));
        }
    }
}
