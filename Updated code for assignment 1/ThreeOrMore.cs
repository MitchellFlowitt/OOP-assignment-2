using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_for_assignment_1;

namespace Updated_code_for_assignment_1
{
    //ThreeOrMore class inherits from the game class
    internal class ThreeOrMore : Game
    {
        private int total = 0;
        public int Total { get { return total; } }

        //playgame method is taken from the game class but the implementation is changed using method overriding
        public override void PlayGame(int a)
        {
            int total2 = 0;
            int turn = 1;
            int[] rolls = new int[5];
            total = 0;
            //ends the game once a player reaches a score of 20
            while (total < 20 && total2 == 20)
            {
                //rolls a die 5 times and stores the results in a list
                for (int i = 0; i < 5; i++)
                {
                    rolls[i] = Die1.Roll();
                }
                Console.WriteLine(string.Join(", ", rolls));
                //groups values in the array together so that sets of 3 or more can be found
                var groups = rolls.GroupBy(v => v);
                foreach (var num in groups) 
                {
                    //increases the score by the correct amount depending on the amount of numbers that are equal in the array
                    if (num.Count() >= 3)
                    {
                        Console.WriteLine($"Value {num.Key} has {num.Count()} items");
                        if (num.Count() == 3)
                        {
                            if (turn % 2 == 0 && a == 1)
                            {
                                total2 += 3;
                            }
                            else
                            {
                                total += 3;
                            }                           
                            Console.WriteLine("you gained 3 points");
                        }
                        else if (num.Count() == 4)
                        {
                            if (turn % 2 == 0 && a == 1)
                            {
                                total2 += 6;
                            }
                            else
                            {
                                total += 6;
                            }
                            Console.WriteLine("you gained 6 points");
                        }
                        else if (num.Count() == 5)
                        {
                            if (turn % 2 == 0 && a == 1)
                            {
                                total2 += 12;
                            }
                            else
                            {
                                total += 12;
                            }
                            Console.WriteLine("you gained 12 points");
                        }
                        //allows player 2 to increase total only if the game is not run in test mode
                        if (turn % 2 == 0 && a == 1)
                        {
                            Console.WriteLine("player 2, your total is now " + total2);
                        }
                        else
                        {
                            Console.WriteLine("player 1, your total is now " + total);
                        }
                    }
                }
                //checks who the winner is if the game is not in test mode
                if (total >= 20 || total2 >= 20)
                {
                    if (a == 1)
                    {
                        if (turn % 2 == 0)
                        {
                            Console.WriteLine("player 2 wins");
                        }
                        else
                        {
                            Console.WriteLine("player 1 wins");
                        }
                    }
                    break;
                }
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
            //changes statistics where appropriate if the game is not run in test mode
            if (a == 1)
            {
                if (turn < Program.stats.ThreeOrMoreHighScore)
                {
                    Program.stats.ThreeOrMoreHighScore = total;
                }
                Program.stats.ThreeOrMoreNoOfPlays++;
                PlayAgain();
            }
        }
    }
}
