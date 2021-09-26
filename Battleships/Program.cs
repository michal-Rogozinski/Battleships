using System;

namespace Battleships
{
    public class Program
    {
        static Player p1;
        static Player p2;
        static void Main(string[] args)
        {
            p1 = new Player("Player 1");
            p2 = new Player("Player 2");

            p1.PlaceShips();
            p2.PlaceShips();

            p1.PrintBoard();
            p2.PrintBoard();

            while(!p1.LoosingCondition && !p2.LoosingCondition)
            {
                RoundCycle();
            }

            if (p1.LoosingCondition)
            {
                Console.WriteLine("{0} has won the game.", p2.playerName);
            }
            else if (p2.LoosingCondition)
            {
                Console.WriteLine("{0} has won the game.", p1.playerName);
            }
        }

        public static void RoundCycle()
        {
            var coords = p1.PlaceShot();
            var output = p2.RegisterStrike(coords);
            p1.UpdateBoardTiles(coords, output);

            //System.Threading.Thread.Sleep(500);

            if (!p2.LoosingCondition)
            {
                coords = p2.PlaceShot();
                output = p1.RegisterStrike(coords);
                p2.UpdateBoardTiles(coords, output);
            }
        }
    }
}
