using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Updated_code_for_assignment_1
{
    internal class Statistics
    {
        //encapsulated variables to store information about each of the 3 games
        private int _defaultGameNoOfPlays = 0;
        private int _sevensOutNoOfPlays = 0;
        private int _sevensOutHighScore = 0;
        private int _threeOrMoreNoOfPlays = 0;
        private int _threeOrMoreHighScore = int.MaxValue;

        public int DefaultGameNoOfPlays { get { return _defaultGameNoOfPlays; } set { _defaultGameNoOfPlays = value; } } 
        public int SevensOutNoOfPlays { get {  return _sevensOutNoOfPlays; } set { _sevensOutNoOfPlays = value; } }
        public int SevensOutHighScore {  get { return _sevensOutHighScore; } set { _sevensOutHighScore = value; } }
        public int ThreeOrMoreNoOfPlays { get { return _threeOrMoreNoOfPlays; } set { _threeOrMoreNoOfPlays = value; } }
        public int ThreeOrMoreHighScore { get { return _threeOrMoreHighScore; } set { _threeOrMoreHighScore = value; } }

        public void DisplayStatistics()
        {
            //prints information about the 3 games to the user when called
            Console.WriteLine("you have played the default game " + _defaultGameNoOfPlays + " times");
            Console.WriteLine("you have played sevens out " + _sevensOutNoOfPlays + " times with a high score of " + _sevensOutHighScore);
            Console.WriteLine("you have played three or more " + _threeOrMoreNoOfPlays + " times with a high score of winning in " + _threeOrMoreHighScore + " turns");
        }
    }
}
