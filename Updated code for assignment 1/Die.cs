using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_for_assignment_1
{
    internal class Die 
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Properties
        private int _value;
        //creates a static random variable accross all objects to avoid generating the same random sequence when random variable are generated within a short time frame
        private static Random _R = new Random();

        //getters/setters for encapsulated values
        public int Value { get { return _value; } set { value = value + 1; } }

        //Method
        public int Roll()
        {
            //generates a random number between 1 and 6 inclusive
            int y = _R.Next(1, 7);

            //stores the value of the die so that it can be accessed by other classes
            _value = y;
            return _value;
        }

    }
}
