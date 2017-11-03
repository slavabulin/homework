using System;
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
            BitInserter bitIns = new BitInserter();
            
            bitIns.InsertBits(195, 127, 2, 6); //should be 255
            bitIns.InsertBits(195, -1, 2, 6); //should be 255
        }

        
    }

    class BitInserter
    {
        /// Two integer signed numbers and two positions of bits i and j (i less than j) are given. 
        /// Implement an algorithm for inserting one number into another so that the second number
        /// occupies the position from bit j to bit i (bits are numbered from right to left).
        public int InsertBits(int firstNumber, int secondNumber, int firstIndex, int lastIndex)
        {
            uint insertTo, insertFrom;
            if (lastIndex < firstIndex
                || lastIndex > 31
                || firstIndex < 0) return 0;

            insertFrom = ((uint)secondNumber >> firstIndex) << firstIndex;

            insertFrom = ((uint)insertFrom << (32 - lastIndex));
            insertFrom = ((uint)insertFrom >> (32 - lastIndex));

            insertTo = (((uint)firstNumber >> lastIndex) << lastIndex) | (((uint)firstNumber) << firstIndex) >> firstIndex;
            int retVal = (int)(insertFrom | insertTo);
            return retVal;

        }
    }
}
