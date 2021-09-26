
namespace Battleships
{
    public abstract class Ship
    {
        public int ShipSize { get; set; }
        public string ShipName { get; set; }
        public TypeEnumeration ShipType { get; set; }

        public int HitsCount { get; set; }

        public bool IsSunk
        {
            get
            {
                return HitsCount >= ShipSize;
            }
        }
    }
}
