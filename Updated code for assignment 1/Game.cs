using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_for_assignment_1
{
    internal class Game
    {
        //game fields and properties set to private for encapsulation
        private Die _die1;
        private Die _die2;
        private Die _die3;
        private Die _die4;
        private Die _die5;
        private int _numOfRolls = 0;
        private int _currentRoll = 0;
        private int _highestRoll = 0;
        private int _lowestRoll = int.MaxValue;
        private int _sumOfRolls = 0;
        public static bool stillPlaying = true;

        //constructor that creats the dice objects
        public Game()
        {
            _die1 = new Die();
            _die2 = new Die();
            _die3 = new Die();
            _die4 = new Die();
            _die5 = new Die();
        }

        //getters/setters for public access to encapsulated variables
        public Die Die1 { get { return _die1; } }
        public Die Die2 { get { return _die2; } }
        public Die Die3 { get { return _die3; } }
        public Die Die4 { get { return _die4; } }
        public Die Die5 { get { return _die5; } }
        public int NumOfRolls { get { return _numOfRolls; } }
        public int CurrentRoll { get { return _currentRoll; } }
        public int HighestRoll { get { return _highestRoll; } }
        public int LowestRoll { get { return _lowestRoll; } }
        public int SumOfRolls { get { return _sumOfRolls; } }

        //function that controls the gameplay
        public virtual void PlayGame(int a)
        {

            //continuously rolls until STOP is entered
            Console.WriteLine("enter (STOP) to stop rolling");
            string x = "";
            while (x.ToLower() != "stop")
            {
                //rolls the 3 dice
                _die1.Roll();
                _die2.Roll();
                _die3.Roll();

                //prints out the rolls of each dice
                Console.WriteLine("the first die rolled " + _die1.Value);
                Console.WriteLine("the second die rolled " + _die2.Value);
                Console.WriteLine("the third die rolled " + _die3.Value);
                Console.WriteLine("press enter to roll again");

                //edits the value for current, lowest and highest roll if they have changed after the previous roll
                _currentRoll = _die1.Value + _die2.Value + _die3.Value;
                if (_currentRoll > _highestRoll)
                {
                    _highestRoll = _currentRoll;
                }
                if (_currentRoll < _lowestRoll)
                {
                    _lowestRoll = _currentRoll;
                }
                //increments the number of rolls this game and updates the sum of all rolls for use in post game statistics
                _numOfRolls++;
                _sumOfRolls += _currentRoll;
                x = Console.ReadLine();
            }
            Program.stats.DefaultGameNoOfPlays++;
        }
        public void PlayAgain()
        {
            while (true)
            {
                Console.WriteLine("would you like to play again (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "y")
                {
                    stillPlaying = true;
                    break;
                }
                else if (playAgain.ToLower() == "n")
                {
                    stillPlaying = false;
                    break;
                }
                Console.WriteLine("please enter a valid input");
            }
        }

        //rolls all 3 dice individually then sums them for use by the Testing class
        public int RollDice()
        {
            _die1.Roll();
            _die2.Roll();
            _die3.Roll();
            _sumOfRolls = _die1.Value + _die2.Value + _die3.Value;
            return _sumOfRolls;
        }

        //prints the lowest, highest and average roll
        public void ShowStatistics()
        {
            Console.WriteLine("the highest roll in that game was " + _highestRoll);
            Console.WriteLine("the lowest roll in that game was " + _lowestRoll);
            //calculates the average roll
            float averageRoll = _sumOfRolls / _numOfRolls;
            Console.WriteLine("the average roll that game was " + averageRoll);
        }
    }
}
