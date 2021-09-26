using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public static class Util
    {
        //Funkcja zwracająca pola w wybranym zakresie
        public static List<Square> FetchPanelRange(this List<Square> squaresList, int startRow, int startCol, int stopRow, int stopCol)
        {
            return squaresList.Where(e => e.Coordinates.row >= startRow && e.Coordinates.col >= startCol && e.Coordinates.row <= stopRow & e.Coordinates.col <= stopCol).ToList();
        }
        //Funkcja zwracająca pojedyńcze pole znajdujące się na określonych koordynatach
        public static Square At(this List<Square> squareList, int row, int col)
        {
            return squareList.First(e => e.Coordinates.row == row && e.Coordinates.col == col);
        }
        //Generator losowych wartości logicznych
        public static bool GetBool()
        {
            Random rng = new(Guid.NewGuid().GetHashCode());
            if (rng.Next() % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Funkcja zwracająca wartość attrybutu przy dowolnym obiekcie
        public static T GetAttribute<T>(this Enum value) where T : System.Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attrib = memberInfo[0].GetCustomAttributes(typeof(T), false);
            if (attrib.Length > 0)
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
