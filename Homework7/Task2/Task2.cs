using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// A string is considered to be in title case if each word in the string is either (a) capitalised (that is, only the first letter of the word is in
    /// upper case) or (b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised. Write
    /// a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words will be given 
    /// as a string with each word separated by a space. Your function should ignore the case of the minor words string -- it should behave in the same way
    /// even if the case of the minor word string is changed. 
    /// Arguments:
    /// First argument(required): the original string to be converted.
    /// Second argument (optional): space-delimited list of minor words that must always be lowercase except for the first word in the string.
    /// Example:
    /// TitleCase("a an the of", "a clash of KINGS") => "A Clash of Kings"
    /// TitleCase("The In", "THE WIND IN THE WILLOWS") => "The Wind in the Willows"
    /// TitleCase("the quick brown fox") => "The Quick Brown Fox"    
    /// 
    /// /// </summary>
    class Task2
    {
        static void Main(string[] args)
        {
        }
    }
    public class StringChanger
    {
        /// <summary>
        /// Converts incoming string's words into capitalized except word from second stringLowCase (they will be leaved in low case)
        /// </summary>
        /// <param name="originStr">incoming string to convert</param>
        /// <param name="stringLowCase">string that contains words tht should be left in low case</param>
        /// <returns>The string with capitalized first letters in every word</returns>
        public string Convert(string originStr, string stringLowCase = null)
        {
            if (String.IsNullOrWhiteSpace(originStr)) throw new ArgumentException("argument is null or empty or whitespace", nameof(originStr));
            
            List<string> stringLowCaseList;
            if (stringLowCase != null)
            {
                stringLowCaseList = stringLowCase.Split().ToList();
            }
            else
            {
                stringLowCaseList = new List<string>();
            }
            
            List<string> originStrList = originStr.Split().ToList<string>();
            var sb = new StringBuilder();
            bool flagWordAdded = false;

            foreach(string word in originStrList)
            {
                foreach (string exptn in stringLowCaseList)
                {
                    if(String.Compare(word, exptn, StringComparison.InvariantCultureIgnoreCase)==0)
                    {
                        sb.Append(word.ToLower());
                        sb.Append(" ");
                        flagWordAdded = true;
                        break;
                    }
                }
                if (!flagWordAdded)
                {
                    sb.Append(word.First().ToString().ToUpper());
                    sb.Append(word.Substring(1).ToLower());
                    sb.Append(" ");
                }
                flagWordAdded = false;
            }
            return sb.ToString().TrimEnd();
        }
    }


}
