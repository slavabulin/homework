using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Task2.Tests
{
    [TestClass]
    public class WordCounterTests
    {
        WordCounter wc;
        public WordCounterTests()
        {
            wc = new WordCounter();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WordCounterInNullShouldThrowExcptn()
        {
            //arrange
            //act
            wc.Count(null);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void WordCounterInNonExistingPathShouldThrowExcptn()
        {
            //arrange
            //act
            wc.Count("local.file");
            //assert
        }
        [TestMethod]
        public void WordCounterInValidFileShouldPass()
        {
            //arange
            string fileContent = "qwe qwe nhj jkjkuj.iku";
            string fileName = Guid.NewGuid().ToString();
            try
            {
                using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    var bytesArr = Encoding.Unicode.GetBytes(fileContent);
                    fs.Write(bytesArr, 0, bytesArr.Length);
                }
                Dictionary<string, int> retDict, expectedDict;
                expectedDict = new Dictionary<string, int>();
                expectedDict.Add("qwe", 2);
                expectedDict.Add("nhj", 1);
                expectedDict.Add("jkjkuj", 1);
                expectedDict.Add("iku", 1);

                //act
                retDict = wc.Count("local.file");
                //assert
                CollectionAssert.AreEqual(expectedDict, retDict);
            }
            catch (Exception) { }
            finally
            {
                File.Delete(fileName);
            }
        }

    }
}
