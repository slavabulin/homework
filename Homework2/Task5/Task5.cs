using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Task5
    {
        /// Write a method FilterLucky that accepts a list of integers and filters the list to only include the elements 
        /// that contain the digit 7. For example, FilterLucky(1,2,3,4,5,6,7,68,69,70,15,17) --> { 7, 70, 17 }.

        static void Main(string[] args)
        {
            FilterLucky fl = new FilterLucky();
            int[] result = fl.Filter(new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 });
        }
    }

    class FilterLucky
    {
        public int[] Filter(int[] inputArray)
        {
            List<int> outputArray = new List<int>();
            for (int y = 0; y < inputArray.Length; y++)
            {
                if(inputArray[y].ToString().ToCharArray().Contains('7'))
                {
                    outputArray.Add(inputArray[y]);
                }
            }
            return outputArray.ToArray<int>();
        }
    }

}
