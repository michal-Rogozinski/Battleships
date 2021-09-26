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
        //String zwracający wartość opisu stworzonego za pomocą klasy ComponentModel zawartego przy wybranym polu enumeratora
        public string ReturnStatus
        {
            get
            {
                return TileStatus.GetAttribute<DescriptionAttribute>().Description;
            }
        }
    }
}
