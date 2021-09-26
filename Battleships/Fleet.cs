using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class Fleet
    {
        private Ship[] _ships;
        public Ship[] ships { get { return _ships; } set { _ships = value; } }

        Fleet(Ship[] ships)
        {
            _ships = ships;
        }
    }
}
