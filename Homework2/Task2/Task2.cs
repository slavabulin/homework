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

    class MaximumFinder
    { 
        public int Find(int[] inputArray)
        {
            int[] secondaryArray;
            for (int a = inputArray.Length - 1; a > 0; a--)
            {
                if (inputArray[a] > inputArray[a - 1])
                {
                    inputArray[a - 1] = inputArray[a];
                    continue;
                }
                else
                {
                    secondaryArray = new int[a];
                    Array.Copy(inputArray, secondaryArray, secondaryArray.Length);
                    return Find(secondaryArray);
                }
            }
            return inputArray[0];
        }
    }
}
