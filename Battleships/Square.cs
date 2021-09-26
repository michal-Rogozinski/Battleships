using System;
using System.Reflection;
using System.ComponentModel;

namespace Battleships
{
    public class Square
    {
        public Coordinates coordinates { get; set; }
        public TypeEnumeration tileStatus { get; set; }

        public Square(Coordinates coords)
        {
            coordinates = coords;
            tileStatus = TypeEnumeration.Empty;
        }

        public bool IsOccupied
        {
            get
            {
                return tileStatus == TypeEnumeration.Battleship ||
                    tileStatus == TypeEnumeration.Carrier ||
                    tileStatus == TypeEnumeration.Crusier ||
                    tileStatus == TypeEnumeration.Destroyer ||
                    tileStatus == TypeEnumeration.Submarine;

            }
        }

        public string ReturnStatus
        {
            get
            {
                return tileStatus.GetAttribute<DescriptionAttribute>().Description;
            }
        }

        public bool CheckRandomPanel
        {
            get
            {
                return (coordinates.row % 2 == 0 && coordinates.col % 2 == 0) || (coordinates.row % 2 == 1 && coordinates.col % 2 == 1);
            }
        }
    }
}
