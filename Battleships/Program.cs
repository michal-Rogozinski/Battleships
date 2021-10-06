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

            PrintBoards();

            while (!p1.LosingCondition && !p2.LosingCondition)
            {
                RoundCycle();
            }

            if (p1.LosingCondition)
            {
                Console.WriteLine("{0} has won the game. \r\n", p2.PlayerName);
            }
            else if (p2.LosingCondition)
            {
                Console.WriteLine("{0} has won the game. \r\n", p1.PlayerName);
            }

            PrintBoards();

        }

        public static void RoundCycle()
        {
            var coords = p1.PlaceShot();
            p2.RegisterStrike(coords);
            p1.PrintResult(coords);

            //System.Threading.Thread.Sleep(250);

            if (!p2.LosingCondition)
            {
                coords = p2.PlaceShot();
                p1.RegisterStrike(coords);
                p2.PrintResult(coords);
            }
        }
        public static void PrintBoards()
        {
            Console.WriteLine("Player 1 \r\n");
            p1.PrintBoard();
            Console.WriteLine("Player 2 \r\n");
            p2.PrintBoard();
        }
    }
}
