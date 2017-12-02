using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    /// <summary>
    /// Create a calculator which evaluates expressions in Reverse Polish notation. For example, expression 5 1 2 + 4 * + 3 - 
    /// (which is equivalent to 5 + ((1 + 2) * 4) - 3 in normal notation) should evaluate to 14. Note, that for simplicity you may assume that 
    /// there are always spaces between numbers and operations, e.g. 1 3 + expression is valid, but 1 3+ isn't. Empty expression should evaluate to 0.
    /// Valid operations are +, -, *, /.
    /// </summary>
    class Task8
    {
        static void Main(string[] args)
        {
        }
    }

    public class ReversePolishNotation
    {
        public int Calculte(string inputString)
        {
            if (inputString == String.Empty) return 0;
            if (inputString == null)
                throw new ArgumentNullException(nameof(inputString), "argument should not be null or empty or white space");

            var inputList = inputString.Split().ToList();
            var stack = new Stack<int>();
            foreach(string elem in inputList)
            {
                int a;
                if(Int32.TryParse(elem, out a))
                {
                    stack.Push(a);
                }
                else
                {
                    if (stack.Count > 1)
                    {
                        int tmpVar;
                        switch (elem)
                        {
                            case "+":
                                tmpVar = stack.Pop();
                                stack.Push(stack.Pop() + tmpVar);
                                break;
                            case "-":
                                tmpVar = stack.Pop();
                                stack.Push(stack.Pop() - tmpVar);
                                break;
                            case "/":
                                tmpVar = stack.Pop();
                                stack.Push(stack.Pop() / tmpVar);
                                break;
                            case "*":
                                tmpVar = stack.Pop();
                                stack.Push(stack.Pop() * tmpVar);
                                break;
                            default:
                                throw new ArgumentException("arguments are inconsistent", nameof(inputString));
                        }
                    }
                    else
                        throw new ArgumentException("arguments are inconsistent", nameof(inputString));
                }
            }
            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new ArgumentException("arguments are inconsistent", nameof(inputString));
            }
            
        }
    }
}
