using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1
    {
        static void Main(string[] args)
        {
        }
    }
    ///Implement a BinarySearch generic method(do not use the type constraints). Develop unit-tests.
    
     
    public class BinarySearch<T> where T: IComparable
    {
        public int? Search(T[] inputData, T value)
        {
            if (inputData == null
                ||inputData.Length == 0
                || value.CompareTo(inputData[0]) < 0
                || value.CompareTo(inputData[inputData.Length-1]) > 0
                ) return null;

            int firstIndex, lastIndex, midIndex;
            firstIndex = 0;
            lastIndex = inputData.Length;

            while(firstIndex < lastIndex)
            {
                midIndex = firstIndex + (lastIndex - firstIndex) / 2;
                if (value.CompareTo(inputData[midIndex]) == 0) return midIndex;
                if (value.CompareTo(inputData[midIndex]) < 0) lastIndex = midIndex;
                else firstIndex = midIndex + 1;
            }
            return (inputData[lastIndex].CompareTo(value) == 0) ? (int?)lastIndex : null;
        }
    }
}
