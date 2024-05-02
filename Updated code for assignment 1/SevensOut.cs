using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using test_for_assignment_1;

namespace Updated_code_for_assignment_1
{
    //SevensOut class inherits from the game class
    internal class SevensOut : Game
    {
        //playgame method is taken from the game class but the implementation is changed using method overriding
        public override void PlayGame(int a)
        {
            int turn = 1;
            int total = 0;
            int total2 = 0;
            while (true)
            {
                //Die1 and Die2 are properties inherited from the game class
                Die1.Roll();
                Die2.Roll();
                Console.WriteLine("the first die rolled " + Die1.Value);
                Console.WriteLine("the second die rolled " + Die2.Value);
                if (Die1.Value + Die2.Value == 7)
                {
                    Console.WriteLine("you rolled a 7, the game will now end");
                    break;
                }
                if (Die1.Value == Die2.Value) 
                {
                    Console.WriteLine("you rolled a double, " + 2 * (Die1.Value + Die2.Value) + " will be added to your score");
                    if (turn % 2 == 0 && a == 1) 
                    {
                        total2 += 2 * (Die1.Value + Die2.Value);
                    }
                    else
                    {
                        total += 2 * (Die1.Value + Die2.Value);
                    }                    
                }
                else
                {
                    Console.WriteLine(Die1.Value + Die2.Value + " will be added to your score");
                    if ((turn % 2) == 0 && a == 1) 
                    {
                        total2 += Die1.Value + Die2.Value;
                    }
                    else
                    {
                        total += Die1.Value + Die2.Value;
                    }
                }
                //allows player 2 to increase total only if the game is not run in test mode
                if (a == 1)
                {
                    if (turn % 2 == 0)
                    {
                        Console.WriteLine("player 1, press enter to roll");
                    }
                    else 
                    {
                        Console.WriteLine("player 2, press enter to roll");
                    }
                    turn++;
                    Console.ReadLine();
                }
            }
            //determines the winner of the game
            if (a == 1)
            {
                Console.WriteLine("player 1, your score that game was " + total);
                Console.WriteLine("player 2, your score that game was " + total2);
                if (total > total2)
                {
                    Console.WriteLine("player 1 wins");
                }
                else
                {
                    Console.WriteLine("player 2 wins");
                }
                //changes statistics where appropriate if the game is not run in test mode
                if (total > Program.stats.SevensOutHighScore) 
                {
                    Program.stats.SevensOutHighScore = total;
                }
                if (total2 > Program.stats.SevensOutHighScore)
                {
                    Program.stats.SevensOutHighScore = total2;
                }
                Program.stats.SevensOutNoOfPlays++;
                PlayAgain();
            }
            else
            {
                Console.WriteLine("your score was "+ total);
            }
        }
        
    }
}
