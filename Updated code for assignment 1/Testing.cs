using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_for_assignment_1;
using Updated_code_for_assignment_1;

namespace test_for_assignment_1
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Method

        //tests that the dice rolls are within the 1-6 range
        public void TestDie()
        {
            Die die1 = new Die();
            die1.Roll();
            Debug.Assert(die1.Value >= 1 && die1.Value <= 6);
            Console.WriteLine("dice working correctly");
        }

        //test to check that the sum of the 3 dice rolls are as expected
        public void TestGame()
        {
            int x = 0;
            //continuously asks for input until a valid value is provided
            while (true)
            {
                //exception handling to prevent erroneous input
                Console.WriteLine("which game would you like to test, default game (1), sevens out (2) or threee or more (3)");
                while (true) 
                {
                    try
                    {
                        x = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("please enter an integer");
                        continue;
                    }
                    //detects user error that will not be caught by the exception handling to make sure the integer is within the desired range
                    if (x == 1 || x == 2 || x == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("only enter 1, 2 or 3");
                    }
                }
                break;
            }
            //switch statement used to provide a selection of choices so that games can be tested individually
            switch (x)
            {
                //in all cases, a new game object is created and the game is ran in a test mode so no user input is needed
                //debug.assert will end the program if any errors are found
                case 1:
                    Game game1 = new Game();
                    int sumOfRolls = game1.RollDice();
                    Debug.Assert(sumOfRolls >= 3 && sumOfRolls <= 18);
                    Console.WriteLine("game working correctly");
                    break;
                case 2:
                    SevensOut sevensOutTest = new SevensOut();
                    sevensOutTest.PlayGame(0);
                    Debug.Assert(sevensOutTest.Die1.Value + sevensOutTest.Die2.Value == 7);
                    Console.WriteLine("game working correctly");
                    break;
                case 3:
                    ThreeOrMore threeOrMoreTest = new ThreeOrMore();
                    threeOrMoreTest.PlayGame(0);
                    Debug.Assert(threeOrMoreTest.Total >= 20 && threeOrMoreTest.Total <= 30);
                    Console.WriteLine("game working correctly");
                    break;
            }
            
            
        }
    }
}