using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            shipSize = 4;
            name = "Battleship";
            shipType = TypeEnumeration.Battleship;
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser()
        {
            shipSize = 3;
            name = "Cruiser";
            shipType = TypeEnumeration.Crusier;
        }
    }

    public class Carrier : Ship
    {
        public Carrier()
        {
            shipSize = 5;
            name = "Carrier";
            shipType = TypeEnumeration.Carrier;
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            shipSize = 2;
            name = "Destroyer";
            shipType = TypeEnumeration.Destroyer;
        }
    }
    public class Submarine : Ship
    {
        public Submarine()
        {
            shipSize = 3;
            name = "Submarine";
            shipType = TypeEnumeration.Submarine;
        }
    }
}
