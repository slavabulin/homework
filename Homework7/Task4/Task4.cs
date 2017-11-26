using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Task4
    {
        static void Main(string[] args)
        {
        }
    }
    /// <summary>
    /// Implement the function UniqueInOrder which takes as argument a sequence and returns a list of items without any elements with the same value 
    /// next to each other and preserving the original order of elements. For example (Note that you can return any data structure you want, as long it inherits
    /// the IEnumerable interface.)
    /// UniqueInOrder("AAAABBBCCDAABBB") => "ABCDAB"
    /// UniqueInOrder("ABBCcAD") => "ABCcAD"
    /// UniqueInOrder("12233") => "123"
    /// UniqueInOrder(new List {1.1, 2.2, 2.2, 3.3}) => new List {1.1, 2.2, 3.3}
    /// /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Order<T>
    {   
        public List<T> UniqueInOrder(IEnumerable<T> inData)
        {
            if (inData == null) throw new ArgumentNullException(nameof(inData));
            
            IEnumerator<T> enumInData;
            List<T> outData = new List<T>();
            enumInData = inData.GetEnumerator();

            while (enumInData.MoveNext())
            {
                if (outData.Count == 0) outData.Add(enumInData.Current);
                if (enumInData.Current.Equals(outData.Last()))
                {
                    continue;
                }
                else
                {
                    outData.Add(enumInData.Current);
                }
            }
            if (outData.Count == 0) throw new ArgumentException("incomming data length is zero", nameof(inData));
            return outData;
        }
    }
}
