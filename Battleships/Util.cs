using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public static class Util
    {
        public static List<Square> FetchPanelRange(this List<Square> squaresList, int startRow, int startCol, int stopRow, int stopCol)
        {
            return squaresList.Where(e => e.coordinates.row >= startRow && e.coordinates.col >= startCol && e.coordinates.row <= stopRow & e.coordinates.col <= stopCol).ToList();
        }
        public static Square At (this List<Square> squareList,int row,int col)
        {
            return (Square)squareList.Where(e => e.coordinates.row == row && e.coordinates.col == col).First();
        }
        public static bool getBool()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            if(rng.Next() % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static T GetAttribute<T>(this Enum value) where T : System.Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attrib = memberInfo[0].GetCustomAttributes(typeof(T), false);
            if(attrib.Length > 0)
            {
                return (T)attrib[0];
            }
            else
            {
                return null;
            }
        }
    }
}
