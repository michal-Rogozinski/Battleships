namespace Battleships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            ShipSize = 4;
            ShipName = "Battleship";
            ShipType = TypeEnumeration.Battleship;
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser()
        {
            ShipSize = 3;
            ShipName = "Cruiser";
            ShipType = TypeEnumeration.Crusier;
        }
    }

    public class Carrier : Ship
    {
        public Carrier()
        {
            ShipSize = 5;
            ShipName = "Carrier";
            ShipType = TypeEnumeration.Carrier;
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            ShipSize = 2;
            ShipName = "Destroyer";
            ShipType = TypeEnumeration.Destroyer;
        }
    }
    public class Submarine : Ship
    {
        public Submarine()
        {
            ShipSize = 3;
            ShipName = "Submarine";
            ShipType = TypeEnumeration.Submarine;
        }
    }
}
