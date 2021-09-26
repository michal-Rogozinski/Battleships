
namespace Battleships
{
    public abstract class Ship
    {
        public int shipSize { get; set; }
        public string name { get; set; }
        public TypeEnumeration shipType { get; set; }

        public int hitsCount { get; set; }

        public bool IsSunk
        {
            get
            {
                return hitsCount >= shipSize;
            }
        }
    }
}
