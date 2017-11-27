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

            var outDict = new Dictionary<string, int>();
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                int numBytesToRead = (int)fs.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fs.Read(bytes, numBytesRead, numBytesToRead);
                    if (n == 0) break;
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                
                var wordsArr = Encoding.Unicode.GetString(bytes).ToLower().Split(new char[] { ' ', ',', '.' });
                foreach(string word in wordsArr)
                {
                    
                    if(outDict.ContainsKey(word))
                    {
                        int val;
                        outDict.TryGetValue(word, out val);
                        outDict.Remove(word);
                        outDict.Add(word, ++val);
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
