using System.ComponentModel;

namespace Battleships
{
    public class Square
    {
        public Coordinates Coordinates { get; set; }
        public TypeEnumeration TileStatus { get; set; }

        public Square(Coordinates coords)
        {
            Coordinates = coords;
            TileStatus = TypeEnumeration.Empty;
        }

        public bool IsOccupied
        {
            get
            {
                return TileStatus == TypeEnumeration.Battleship ||
                    TileStatus == TypeEnumeration.Carrier ||
                    TileStatus == TypeEnumeration.Crusier ||
                    TileStatus == TypeEnumeration.Destroyer ||
                    TileStatus == TypeEnumeration.Submarine;

            }
        }

        public string ReturnStatus
        {
            get
            {
                return TileStatus.GetAttribute<DescriptionAttribute>().Description;
            }
        }

        public bool CheckRandomPanel
        {
            get
            {
                return (Coordinates.row % 2 == 0 && Coordinates.col % 2 == 0) || (Coordinates.row % 2 == 1 && Coordinates.col % 2 == 1);
            }
        }
    }
}
