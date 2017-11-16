using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            MaximumFinder mf = new MaximumFinder();
            int a = mf.Find(new[] {1,2,5,0,3,-1255,-1});
        }
    }

    public class MaximumFinder
    { 
        int FindMax(int[] inputArrary, int index = 0, int tmpMaxVal = Int32.MinValue)
        {
            if(inputArrary[index] > tmpMaxVal)
            {
                tmpMaxVal = inputArrary[index];
            }
            if(index < inputArrary.Length - 1)
            {
                index += 1;
                return FindMax(inputArrary, index, tmpMaxVal);
            }

            return tmpMaxVal;
        }

        public int Find(int[]inputArray)
        {
            return FindMax(inputArray);
        }
    }
}
