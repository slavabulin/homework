using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Implement a method for the counting of the Fibonacci's numbers of the Fibonacci using the iterator block yield. Develop unit-tests.
    /// </summary>
    class Task3
    {
        static void Main(string[] args)
        {
        }
    }
    public class Fibonacci
    {
        public IEnumerable<int> Count(int number)
        {
            if (number == 0) yield return 0;

            bool numberIsNegative = false;
            if (number < 0) numberIsNegative = true;
            int result, prevNumber = 1, curNumber = 0;
            number = Math.Abs(number);

            while (number > 0)
            {
                if (numberIsNegative)
                {
                    result = prevNumber - curNumber;
                }
                else
                {
                    result = curNumber + prevNumber;
                }
                
                prevNumber = curNumber;
                curNumber = result;
                number--;
                yield return result;
            }
        }
    }
}
