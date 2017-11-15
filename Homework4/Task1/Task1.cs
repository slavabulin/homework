using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    /// <summary>
    /// Implement a binary representation of a real double-precision number in IEEE 754 format as the extension method.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Double d = -1.0D;
            string ext = d.ToIEEE754();
            Console.WriteLine(ext);
            Console.ReadLine();
        }
    }

    public static class MyExtensions
    {
        public static string ToIEEE754(this Double num)
        {
            byte[] byteArr = BitConverter.GetBytes(num);
            StringBuilder sb = new StringBuilder();
            for (int b = byteArr.Length - 1; b >= 0; b-- )
            {
                sb.AppendFormat("{0}", Convert.ToString(byteArr[b], 2).PadLeft(8,'0'));
            }
            return sb.ToString().PadLeft(64, '0');
        }
    } 
}
