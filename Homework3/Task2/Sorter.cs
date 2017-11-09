using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Sorter
    {
        public static void SetMinFirstInRow(ref int[,] inputArray)
        {
            MoveInRow(ref inputArray, Value.min);
        }
        public static void SetMaxFirstInRow(ref int[,] inputArray)
        {
            MoveInRow(ref inputArray, Value.max);
        }
        static void MoveInRow(ref int[,] inputArray, Value value)
        {
            int tmpVar;
            int colLastIndex = inputArray.GetUpperBound(1);
            int rowLastIndex = inputArray.GetUpperBound(0);
            bool condition;

            for (int i = 0; i < rowLastIndex + 1; i++)
            {
                for (int a = colLastIndex; a > 0; a--)
                {
                    if (value == Value.max)
                    {
                        condition = (inputArray[i, a] > inputArray[i, a - 1]);
                    }
                    else
                    {
                        condition = (inputArray[i, a] < inputArray[i, a - 1]);
                    }

                    if (condition)
                    {
                        tmpVar = inputArray[i, a - 1];
                        inputArray[i, a - 1] = inputArray[i, a];
                        inputArray[i, a] = tmpVar;
                    }
                }
            }
        }
        static void SortRows(ref int[,] inputArray, Order order = Order.increase)
        {
            int rowLastIndex = inputArray.GetUpperBound(0);
            int colLastIndex = inputArray.GetUpperBound(1);
            bool orderCondition;

            for (int y = 0; y < rowLastIndex; y++)
            {
                for (int x = 0; x < rowLastIndex - y; x++)
                {
                    if(order == Order.increase)
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
        public static void SetSumFirstInRow(ref int[,] inputArray)
        {
            int tmpVar = 0;
            int colLastIndex = inputArray.GetUpperBound(1);
            int rowLastIndex = inputArray.GetUpperBound(0);

            for (int i = 0; i < rowLastIndex + 1; i++)
            {
                for (int j = colLastIndex; j > 0; j--)
                {
                    tmpVar += inputArray[i, j];
                }
                inputArray[i, 0] = tmpVar;
                tmpVar = 0;
            }

        }
        public static void SwapRows(ref int[,] inputArray, int firstRow, int secondRow)
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
    }
    enum Value
    {
        min,
        max
    }
    enum Order
    {
        increase,
        decrease
    }
}
