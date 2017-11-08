using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    /// <summary>
    /// Implement an Newton algorithm for calculate the root of n-degree (n is natural) from the number a (a is real) with a given accuracy.
    /// Check the work of the method (compare the result with the value calculated using the .NET Framework class Math.Pow method).
    /// </summary>
    class Task1
    {
        static void Main(string[] args)
        {
            uint number = 27;
            double degree = 3;
            double accuracy = 0.0001;


            NewtonAlgorithm ng = new NewtonAlgorithm();
            double retVal = ng.CalculateRoot(number, degree, accuracy);

            if(Math.Abs(Math.Pow(retVal,degree)-number)< accuracy)
            {
                Console.WriteLine("it works!");
            }
            else
            {
                Console.WriteLine("oops, it failed...");
            }
            Console.ReadLine();
        }
    }

   
    class NewtonAlgorithm
    {
        public double CalculateRoot(uint number, double degree, double accuracy, double prevRoot = 1)
        {
            double prevRootPow = CalculatePower(prevRoot, (degree - 1));
            double curRoot = 1 / degree * ((degree - 1) * prevRoot + number / prevRootPow);
            if(Math.Abs(curRoot-prevRoot)>accuracy)
            {
                return CalculateRoot(number, degree, accuracy, curRoot);
            }
            return curRoot;
        }

        double CalculatePower(double firstNumber, double degree)
        {
            double retVal = firstNumber;
            if (firstNumber == 0) return 0;
            if (degree == 0) return 1;
            if (degree < 0) return 0;
            for (int i = 1; i < degree; i++)
            {
                retVal *= retVal;
            }
            return retVal;
        }
    }
}
