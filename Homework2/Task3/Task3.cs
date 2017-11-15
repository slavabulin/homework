using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Task3
    {


        ///
        /// Given an array of integers. Find and return an index n for which the sum of the elements 
        /// to the left of it is equal to the sum of the elements on the right. 
        /// If such an index does not return null (or -1).
        ///
        static void Main(string[] args)
        {
            SumChecker sch = new SumChecker();
            int a = sch.Check(new int[] { 1, 2, 3, 2, 1 });
            int b = sch.Check(new int[] { 1, 2, 3, 2, 1, 1 });
        }
    }

    public class SumChecker
    {
        public int Check(int[] inputArray)
        {
            int dataLenght = inputArray.Length;
            DataElement[] dataArray = new DataElement[dataLenght];
            for (int i = 0; i < dataLenght; i++)
            {
                dataArray[i] = new DataElement();
                dataArray[i].arrayItem = inputArray[i];

                if (i >= 1)
                {
                    dataArray[i].sumLeft = dataArray[i - 1].sumLeft + dataArray[i - 1].arrayItem;
                }
            }
            for (int t = dataLenght - 1; t >= 0; t--)
            {
                if (t < dataLenght - 1)
                {
                    dataArray[t].sumRight = dataArray[t + 1].sumRight + dataArray[t + 1].arrayItem;
                }

                if (dataArray[t].sumRight == dataArray[t].sumLeft) return t;
            }
            return -1;
        }
    }
    class DataElement
    {
        public int arrayItem;
        public int sumLeft;
        public int sumRight;
    }
}
