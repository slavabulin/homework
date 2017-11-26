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
    /// UPDATE: Add to the class Task 2 Module 3 new methods with custom delegete, allowing to sorting both in ascending and descending, depending on comparison
    /// criterion of the matrix rows. Develop unit-tests using various comparison criterion of the matrix rows.
    /// </summary>
    class Task2
    {
        static void Main(string[] args)
        {
            int[,] arrayToSort = new int[,] { { 0, 1, 2, 3 }, { -10, 3, 75, -15 }, { 1, 4, 3, 2 } };
            //GlobalSorter gSorter = new GlobalSorter(new SumOfElementSorter(arrayToSort));
            GlobalSorter gSorter = new GlobalSorter(new MaximumOfElementSorter(arrayToSort));
            //GlobalSorter gSorter = new GlobalSorter(new MinimumOfElementSorter(arrayToSort));
            gSorter.SortDecrease();
            //gSorter.SortIncrease();


            GlobalSorterOverDelegate gSorterOD = new GlobalSorterOverDelegate(new MaximumOfElementSorter(arrayToSort).GetKeyToSort, arrayToSort);
            gSorterOD.SortDecrease();
        }
    }

    class SumOfElementSorter:IStrategy
    {
        public int[,] arrayToSort{ get; set; }
        public SumOfElementSorter(int[,]inputArray)
        {
            arrayToSort = inputArray;
        }
        public int[]GetKeyToSort()
        {
            int tmpVar = 0;
            int[] key = new int[arrayToSort.GetUpperBound(0) + 1];

            int colLastIndex = arrayToSort.GetUpperBound(1);
            int rowLastIndex = arrayToSort.GetUpperBound(0);

            for (int i = 0; i < rowLastIndex + 1; i++)
            {
                for (int j = colLastIndex; j > 0; j--)
                {
                    tmpVar += arrayToSort[i, j];
                }
                key[i] = tmpVar;
                tmpVar = 0;
            }
            return key;
        }
    }

    class MaximumOfElementSorter : IStrategy
    {
        public int[,] arrayToSort{ get; set; }
        public MaximumOfElementSorter(int[,] inputArray)
        {
            arrayToSort = inputArray;
        }
        public int[] GetKeyToSort()
        {
            return Sorter.GetKey(arrayToSort, Order.increase);
        }
    }

    class MinimumOfElementSorter : IStrategy
    {
        public int[,] arrayToSort{ get; set; }
        public MinimumOfElementSorter(int[,] inputArray)
        {
            arrayToSort = inputArray;
        }
        public int[] GetKeyToSort()
        {
            return Sorter.GetKey(arrayToSort, Order.decrease);
        }
    }

    class GlobalSorter
    {
        public IStrategy GSorter { get; set; }
        public int[,] sortedArray;
        int[] key;
        public GlobalSorter(IStrategy sorter)
        {
            GSorter = sorter;
            sortedArray = sorter.arrayToSort;
            key = GSorter.GetKeyToSort();
        }        
        public void SortIncrease()
        {
            Sorter.SortRowsByKey(ref sortedArray, key, Order.increase);
        }
        public void SortDecrease()
        {
            Sorter.SortRowsByKey(ref sortedArray, key, Order.decrease);
        }
        
    }
    class GlobalSorterOverDelegate
    {
        public int[,] sortedArray;
        Func<int[]> _getKey;
        public GlobalSorterOverDelegate(Func<int[]>getKey, int[,] inputArray)
        {
            _getKey = getKey;
            if (inputArray == null) throw new ArgumentNullException(nameof(inputArray));
            sortedArray = inputArray;
        }
        public void SortIncrease()
        {
            Sorter.SortRowsByKey(ref sortedArray, _getKey.Invoke(), Order.increase);
        }
        public void SortDecrease()
        {
            Sorter.SortRowsByKey(ref sortedArray, _getKey.Invoke(), Order.decrease);
        }
    }
    
}
