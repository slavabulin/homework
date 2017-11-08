using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class BubbleSorter
    {
        /// <summary>
        /// Sorts every row of 2-dimention array increasing
        /// </summary>
        /// <param name="inputArray">
        /// 2-dimention array of int
        /// </param>
        /// <returns>2-dimention array with every row sorted increasing</returns>
        public int[,] SortElementsInRow(int[,] inputArray)
        {
            if (inputArray == null) return null;

            int tmpVar;
            int colLastIndex = inputArray.GetUpperBound(1);
            int rowLastIndex = inputArray.GetUpperBound(0);

            for (int i = 0; i < rowLastIndex + 1; i++)//row
            {
                for (int a = 0; a < colLastIndex; a++)//column
                {
                    for (int b = 0; b < colLastIndex - a; b++)//column
                    {
                        if (inputArray[i,b] > inputArray[i,b + 1])
                        {
                            tmpVar = inputArray[i,b + 1];
                            inputArray[i,b + 1] = inputArray[i,b];
                            inputArray[i,b] = tmpVar;
                        }
                    }
                }
            }
                
            return inputArray;
        }
        /// <summary>
        /// swaps rows in array
        /// </summary>
        /// <param name="inputArray">array where to swap</param>
        /// <param name="y">index of first row to swap</param>
        /// <param name="y1">index of second row to swap</param>
        /// <returns>array with swaped rows</returns>
        public int[,] SwapRow(int[,] inputArray, int y, int y1)
        {
            int tmpVar;
            int colLastIndex = inputArray.GetUpperBound(1);
            for (int i = 0; i <= colLastIndex; i++)
            {
                tmpVar = inputArray[y1, i];
                inputArray[y1, i] = inputArray[y, i];
                inputArray[y, i] = tmpVar;
            }
            return inputArray;
        }
    }
}
