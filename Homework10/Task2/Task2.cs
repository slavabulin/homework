using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    /// <summary>
    /// The test file contains some information. Implement an algorithm that allows to determine the frequency of occurrences of words in the text. 
    /// Develop unit-tests.
    /// </summary>
    class Task2
    {
        static void Main(string[] args)
        {
        }
    }

    public class WordCounter
    {
        public Dictionary<string, int> Count(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath), "argument should not be null or empty oe white space");

            var outDict = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            using(var st = new StreamReader(filePath))
            {
                var wordsArr = st.ReadToEnd().Split(new char[] { ' ', ',', '.' });
             
                foreach (string word in wordsArr)
                {
                    if (outDict.TryGetValue(word, out int val))
                    {
                        outDict[word] = ++val;
                    }
                    else
                    {
                        outDict.Add(word, 1);
                    }

                }
            }
            return outDict;

        }
    }
}
