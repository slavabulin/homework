using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Task5
    {
        static void Main(string[] args)
        {
        }
    }
    /// <summary>
    /// Complete the solution so that it reverses all of the words within the string passed in. 
    /// Example: ReverseWords("The greatest victory is that which requires no battle") => "battle no requires which that is victory greatest The"
    /// </summary>
    public class WordOrderChanger
    {
        public string Change(string inputString)
        {
            if (String.IsNullOrWhiteSpace(inputString)) throw new ArgumentException(nameof(inputString), "argument is null or empty or white spaces");
            string[] strArr = inputString.Split(' ');
            var sb = new StringBuilder();
            for(int i = strArr.Length - 1; i >= 0; i--)
            {
                sb.Append(strArr[i]);
                if (i != 0) sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
