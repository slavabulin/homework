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
            double number = 27;//real - double
            uint degree = 3;//natural - uint
            double accuracy = 0.0001;
            
            NewtonAlgorithm ng = new NewtonAlgorithm(accuracy);
            double retVal = ng.CalculateRoot(number, degree);

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

   
    public class NewtonAlgorithm
    {
        double accuracy;
        public NewtonAlgorithm(double accuracy)
        {
            this.accuracy = accuracy;
        }

        public double CalculateRoot(double number, uint degree, double prevRoot = 1)
        {
            if (number == 1) return 1;
            if(number==0 && degree ==0) return 1;
            if (number == 0 && degree != 0) return 0;
            
            double prevRootPow = CalculatePower(prevRoot, (degree - 1));
            double curRoot =  ((degree - 1) * prevRoot + number / prevRootPow);
            curRoot /= degree;

            if (Math.Abs(curRoot - prevRoot) > accuracy)
            {
                return CalculateRoot(number, degree, curRoot);
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
