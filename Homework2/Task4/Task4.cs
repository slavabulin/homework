﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Task4
    {
        /// Two strings include only characters from 'a' to 'z', return a concatenated alphabetized string, excluding duplicate characters.
        static void Main(string[] args)
        {
            StringConcatenator sc = new StringConcatenator();
            string resultString = sc.Concatenate("adzf", "pofgaz");
        }
    }

    class StringConcatenator
    {
        public string Concatenate(string firstString, string secondString)
        {
            StringBuilder sb = new StringBuilder();
            String concatString = String.Concat(firstString, secondString);
            char[] charArr = concatString.ToCharArray();
            Array.Sort(charArr);
            for (int i = 0; i < concatString.Length; i++)
            {
                if (sb.ToString().Contains(charArr[i]))
                {
                    continue;
                }
                else
                {
                    sb.Append(charArr[i].ToString());
                }
            }
            return sb.ToString();
        }
    }

}
