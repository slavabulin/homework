using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface ISort
    {
        int[,] arrayToSort { get; set; }
        void SortIncrease();
        void SortDecrease();
    }
}
