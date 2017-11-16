using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Sorter
    {
        public static void SwapRows(ref int[,] inputArray, uint firstRow, uint secondRow)
        {
            if (inputArray == null) throw new ArgumentNullException();
            int tmpVar;
            int colLastIndex = inputArray.GetUpperBound(1);
            for (int i = 0; i <= colLastIndex; i++)
            {
                tmpVar = inputArray[secondRow, i];
                inputArray[secondRow, i] = inputArray[firstRow, i];
                inputArray[firstRow, i] = tmpVar;
            }

        }
        public static void SortRowsByKey(ref int[,] inputArray, int[] key, Order order = Order.increase)
        {
            bool orderCondition;
            int tmpVar;

            if (inputArray == null
                || key==null) throw new ArgumentNullException();

            for (uint i = 0; i < key.Length - 1; i++)
            {
                for (uint j = 0; j < key.Length - i - 1; j++)
                {
                    if (order == Order.increase)
                    {
                        orderCondition = (key[j] > key[j + 1]);
                    }
                    else
                    {
                        orderCondition = (key[j] < key[j + 1]);
                    }
                    if (orderCondition)
                    {
                        SwapRows(ref inputArray, j, j + 1);

                        tmpVar = key[j];
                        key[j] = key[j + 1];
                        key[j + 1] = tmpVar;
                    }
                }
            }
        }
        public static int[] GetKey(int[,]inputArray, Order order)
        {
            if (inputArray == null || inputArray.Length == 0) return null;
            int colLastIndex = inputArray.GetUpperBound(1);
            int rowLastIndex = inputArray.GetUpperBound(0);
            int[] key = new int[rowLastIndex + 1];
            bool condition;

            for (int i = 0; i < rowLastIndex + 1; i++)
            {
                key[i] = inputArray[i, 0];

                for (int j = 0; j < colLastIndex + 1; j++)
                {
                    if(order==Order.decrease)
                    {
                        condition = (key[i] > inputArray[i, j]);
                    }
                    else
                    {
                        condition = (key[i] < inputArray[i, j]);
                    }

                    if (condition)
                    {
                        key[i] = inputArray[i, j];
                    }
                }
            }
            return key;
        }
    }
    public enum Order
    {
        increase,
        decrease
    }
   
}
