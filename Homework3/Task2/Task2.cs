using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Implement the "Bubble Sort" algorithm of integer array (do not usу methods of class System.Array) so that there was an opportunity to order matrix rows: 
    /// in order of increasing (decreasing) sums of elements of rows of the matrix;
    /// in order of increasing (decreasing) the maximum elements of rows of the matrix;
    /// in order of increasing (decreasing) the minimum elements of rows of the matrix;
    /// etc.
    /// </summary>
    class Task2
    {
        static void Main(string[] args)
        {
            //GlobalSorter gSorter = new GlobalSorter(new MaximumOfElementSorter());
            //GlobalSorter gSorter = new GlobalSorter(new MinimumOfElementSorter());
            GlobalSorter gSorter = new GlobalSorter(new SumOfElementSorter());
            //int[,] resVal = gSorter.IncreaseSort(new int[,] { { 0, 1, 2, 3 }, { -10, 3, 75, -15 }, { 1, 4, 3, 2 } });
            int[,] resVal = gSorter.DecreaseSort(new int[,] { { 0, 1, 2, 3 }, { -10, 3, 75, -15 }, { 1, 4, 3, 2 } });
        }
    }

    class SumOfElementSorter:ISort
    {
        public int[,] SortIncrease(int[,] inputArray)
        {
            int colLastIndex = inputArray.GetUpperBound(1);
            int rowLastIndex = inputArray.GetUpperBound(0);
            int[] arrOfSums = SumOfRow(inputArray);
            int[,] retVal=null;
            int tmpVar;

            BubbleSorter bs = new BubbleSorter();
            for (int i = 0; i < rowLastIndex + 1; i++)
            {
                for (int j = 0; j < rowLastIndex - i; j++)
                {
                    if(arrOfSums[j] > arrOfSums[j+1])
                    {
                        retVal = bs.SwapRow(inputArray, j, j + 1);
                        tmpVar = arrOfSums[j];
                        arrOfSums[j] = arrOfSums[j + 1];
                        arrOfSums[j + 1] = tmpVar;
                    }
                }
            }
            return retVal;
        }
        public int[,] SortDecrease(int[,] inputArray)
        {
            int colLastIndex = inputArray.GetUpperBound(1);
            int rowLastIndex = inputArray.GetUpperBound(0);
            int tmpVar;
            int[] arrOfSums = SumOfRow(inputArray);
            int[,] retVal = null;

            BubbleSorter bs = new BubbleSorter();
            for (int i = 0; i < rowLastIndex + 1; i++)
            {
                for (int j = 0; j < rowLastIndex - i; j++)
                {
                    if (arrOfSums[j] < arrOfSums[j + 1])
                    {
                        retVal = bs.SwapRow(inputArray, j, j + 1);
                        tmpVar = arrOfSums[j];
                        arrOfSums[j] = arrOfSums[j + 1];
                        arrOfSums[j + 1] = tmpVar;
                    }
                }
            }
            return retVal;
        }

        int[]SumOfRow(int[,]inputArray)
        {
            if (inputArray == null) return null;

            int tmpVar = 0;
            int colLastIndex = inputArray.GetUpperBound(1);
            int rowLastIndex = inputArray.GetUpperBound(0);

            int[] retVal = new int[rowLastIndex + 1];            

            for (int i = 0; i <= rowLastIndex; i++)
            {
                for (int j = 0; j <= colLastIndex; j++)
                {
                    tmpVar += inputArray[i, j];
                }
                retVal[i] = tmpVar;
                tmpVar = 0;
            }
            return retVal;
        }
    }

    class MaximumOfElementSorter : ISort
    {
        public int[,] SortIncrease(int[,] inputArray)
        {
            if (inputArray == null) return null;

            int rowLastIndex = inputArray.GetUpperBound(0);
            int colLastIndex = inputArray.GetUpperBound(1);
            BubbleSorter bs = new BubbleSorter();
            int[,] tmpArr = bs.SortElementsInRow(inputArray);

            for (int y = 0; y < rowLastIndex; y++)
            {
                for (int x = 0; x < rowLastIndex - y; x++)
                {
                    if (tmpArr[y, colLastIndex] > tmpArr[y + 1, colLastIndex])
                    {
                        tmpArr = bs.SwapRow(tmpArr, y, y + 1);
                    }
                        
                }
            }
            return tmpArr;
        }
        public int[,] SortDecrease(int[,] inputArray)
        {
            if (inputArray == null) return null;

            int rowLastIndex = inputArray.GetUpperBound(0);
            int colLastIndex = inputArray.GetUpperBound(1);
            BubbleSorter bs = new BubbleSorter();
            int[,] tmpArr = bs.SortElementsInRow(inputArray);

            for (int y = 0; y < rowLastIndex; y++)
            {
                for (int x = 0; x < rowLastIndex - y; x++)
                {
                    if (tmpArr[y, colLastIndex] < tmpArr[y + 1, colLastIndex])
                    {
                        tmpArr = bs.SwapRow(tmpArr, y, y + 1);
                    }

                }
            }
            return tmpArr;
        }

        
    }

    class MinimumOfElementSorter : ISort
    {
        public int[,] SortIncrease(int[,] inputArray)
        {
            if (inputArray == null) return null;

            int rowLastIndex = inputArray.GetUpperBound(0);
            BubbleSorter bs = new BubbleSorter();
            int[,] tmpArr = bs.SortElementsInRow(inputArray);

            for (int y = 0; y < rowLastIndex; y++)
            {
                for (int x = 0; x < rowLastIndex - y; x++)
                {
                    if (tmpArr[y, 0] > tmpArr[y + 1, 0])
                    {
                        tmpArr = bs.SwapRow(tmpArr, y, y + 1);
                    }

                }
            }
            return tmpArr;
        }
        public int[,] SortDecrease(int[,] inputArray)
        {
            if (inputArray == null) return null;

            int rowLastIndex = inputArray.GetUpperBound(0);
            int colLastIndex = inputArray.GetUpperBound(1);
            BubbleSorter bs = new BubbleSorter();
            int[,] tmpArr = bs.SortElementsInRow(inputArray);

            for (int y = 0; y < rowLastIndex; y++)
            {
                for (int x = 0; x < rowLastIndex - y; x++)
                {
                    if (tmpArr[y, 0] < tmpArr[y + 1, 0])
                    {
                        tmpArr = bs.SwapRow(tmpArr, y, y + 1);
                    }

                }
            }
            return tmpArr;
        }
    }

    class GlobalSorter
    {
        public ISort Sorter { get; set; }
        public GlobalSorter(ISort sorter)
        {
            Sorter = sorter;
        }

        public int[,] IncreaseSort(int[,] inputArray)
        {
            return Sorter.SortIncrease(inputArray);
        }
        public int[,] DecreaseSort(int[,] inputArray)
        {
            return Sorter.SortDecrease(inputArray);
        }
    }
}
