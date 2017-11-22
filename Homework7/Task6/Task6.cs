using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Task6
    {
        static void Main(string[] args)
        {
        }
    }

    public class BigNumberOperator
    {
        StringBuilder sb;
        public BigNumberOperator()
        {
            sb = new StringBuilder();
        }
        public string Sum(string firstNum, string secondNum)
        {
            if (String.IsNullOrWhiteSpace(firstNum)) throw new ArgumentNullException(nameof(firstNum));
            if (String.IsNullOrWhiteSpace(secondNum)) throw new ArgumentNullException(nameof(secondNum));

            int optional = 0, retVal ;
            int highLenght = firstNum.Length >= secondNum.Length ? firstNum.Length : secondNum.Length;
            for (int i=0; i<highLenght;i++)
            {
                int firstElem = (firstNum.Length - i > 0) ? Int32.Parse(firstNum[firstNum.Length - i -1].ToString()) : 0;
                int secondElem = (secondNum.Length - i > 0) ? Int32.Parse(secondNum[secondNum.Length - i -1].ToString()) : 0;
                retVal = ElemSummer(firstElem, secondElem, optional);

                if (retVal > 9)
                {
                    optional = 1;
                }
                else
                {
                    optional = 0;
                }

                if(i==highLenght-1)
                {
                    sb.Insert(0, retVal.ToString());
                }
                else
                {
                    sb.Insert(0, ((retVal % 10).ToString()));
                }
                

            }
            return sb.ToString();
        }

        int ElemSummer(int firstElem, int secondElem, int optional = 0) => firstElem + secondElem + optional;
    }
}
