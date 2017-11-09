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
            int[,] arrayToSort = new int[,] { { 0, 1, 2, 3 }, { -10, 3, 75, -15 }, { 1, 4, 3, 2 } };
            //GlobalSorter gSorter = new GlobalSorter(new MaximumOfElementSorter());
            //GlobalSorter gSorter = new GlobalSorter(new MinimumOfElementSorter());
            GlobalSorter gSorter = new GlobalSorter(new SumOfElementSorter(arrayToSort));
            gSorter.IncreaseSort();            
        }
    }

    class SumOfElementSorter:ISort
    {
        public int[,] arrayToSort{ get; set; }
        public SumOfElementSorter(int[,]inputArray)
        {
            Sorter.SetSumFirstInRow(ref inputArray);
            arrayToSort = inputArray;
        }
        public void SortIncrease() { }
        public void SortDecrease() { }
    }

    class MaximumOfElementSorter : ISort
    {
        public int[,] arrayToSort{ get; set; }
        public MaximumOfElementSorter(int[,] inputArray)
        {
            Sorter.SetMaxFirstInRow(ref inputArray);
            arrayToSort = inputArray;
        }
        public void SortIncrease() { }
        public void SortDecrease() { }
    }

    class MinimumOfElementSorter : ISort
    {
        public int[,] arrayToSort{ get; set; }
        public MinimumOfElementSorter(int[,] inputArray)
        {
            Sorter.SetMinFirstInRow(ref inputArray);
            arrayToSort = inputArray;
        }
        public void SortIncrease() { }
        public void SortDecrease() { }
    }

    class GlobalSorter
    {
        public ISort GSorter { get; set; }
        public int[,] sortedArray;
        public GlobalSorter(ISort sorter)
        {
            GSorter = sorter;
            sortedArray = sorter.arrayToSort;
        }
        
        public void IncreaseSort()
        {
            SortRows(ref sortedArray, Order.increase);
        }
        public void DecreaseSort()
        {
            SortRows(ref sortedArray, Order.decrease);
        }
        void SwapRows(ref int[,] inputArray, int firstRow, int secondRow)
        {
            int tmpVar;
            int colLastIndex = inputArray.GetUpperBound(1);
            for (int i = 0; i <= colLastIndex; i++)
            {
                tmpVar = inputArray[secondRow, i];
                inputArray[secondRow, i] = inputArray[firstRow, i];
                inputArray[firstRow, i] = tmpVar;
            }

        }
        void SortRows(ref int[,] inputArray, Order order = Order.increase)
        {
            int rowLastIndex = inputArray.GetUpperBound(0);
            int colLastIndex = inputArray.GetUpperBound(1);
            bool orderCondition;

            for (int y = 0; y < rowLastIndex; y++)
            {
                for (int x = 0; x < rowLastIndex - y; x++)
                {
                    if (order == Order.increase)
                    {
                        orderCondition = (inputArray[y, 0] > inputArray[y + 1, 0]);
                    }
                    else
                    {
                        orderCondition = (inputArray[y, 0] < inputArray[y + 1, 0]);
                    }
                    if (orderCondition)
                    {
                        SwapRows(ref inputArray, y, y + 1);
                    }
                }
            }
        }
    }
}
