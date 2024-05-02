using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Updated_code_for_assignment_1;

namespace test_for_assignment_1
{
    internal class Program
    {
        public static Statistics stats = new Statistics();
        public static void RunStart()
        {
            //asks to user to run the game or test until they enter a valid input
            int x = 0;
            while (true)
            {
                Console.WriteLine("would you like to run the regular game (1), play three or more (2), play sevens out (3), test a game (4), view statistics (5) or close the application (6)");
                //error handling in case the user enters a non integer value
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("please enter an integer");
                }
                if (x == 1 || x == 2 || x == 3 || x == 4 || x == 5 || x == 6)
                {
                    break;
                }
                Console.WriteLine("please enter only 1, 2, 3, 4, 5 or 6");
            }
            if (x == 1 || x == 2 || x == 3)
            {
                RunGame(x);
            }
            else if (x == 4) 
            {
                RunTest();
            }
            else if (x == 5)
            {
                stats.DisplayStatistics();
            }
            else
            {
                //changes the static field in the game class so that the game can be closed
                Game.stillPlaying = false;
            }
        }
        public static void RunGame(int x)
        {
            switch (x)
            {
                case 1:
                    Game game1 = new Game();
                    game1.PlayGame(1);
                    break;
                case 2:
                    ThreeOrMore threeOrMore = new ThreeOrMore();
                    threeOrMore.PlayGame(1);
                    break;
                case 3:
                    SevensOut sevensOut = new SevensOut();
                    sevensOut.PlayGame(1);
                    break;
            }
        }

        public static void RunTest()
        {
            //creates a new testing object to check if the die and game classes are working properly
            Testing test = new Testing();
            test.TestDie();
            test.TestGame();
        }

        static void Main(string[] args)
        {
            //runs the game start in a loop until the user closes the application
            while (Game.stillPlaying == true) 
            {
                RunStart();
            }
            //displays the statistics before ending the game
            stats.DisplayStatistics();
            Console.WriteLine("Thank you for playing");
            Console.ReadLine();
        }
    }
}
