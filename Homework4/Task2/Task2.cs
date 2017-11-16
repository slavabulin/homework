﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task2
{
    /// <summary>
    /// Develop a class that allows performing Greatest Common Divisor (GCD) computations using Euclid's algorithm for two,
    /// three, etc. of integers. The methods of class should be able to determine the GCD calculation time (consider three 
    /// possible oportunities for returning more than one value from the method). Add to the class methods that implement the 
    /// Stein algorithm (Euclid's binary algorithm) to calculate GCD of two, three, etc. of integers. These methods should be
    /// able to determine the GCD calculation time too.
    /// </summary>
    class Task2
    {
        static void Main(string[] args)
        {
            EuclidAlgorithm euAlgo = new EuclidAlgorithm();
            Tuple<uint, System.TimeSpan> a = euAlgo.CalculateGCD(Algorithm.Stein, 175, 568, 257, 3695);
            Console.WriteLine("Algorithm.Stein: result {0}, execution time - {1}", a.Item1, a.Item2);
            Tuple<uint, System.TimeSpan> b = euAlgo.CalculateGCD(Algorithm.Euclid, 175, 568, 257, 3695);
            Console.WriteLine("Algorithm.Euclid: result {0}, execution time - {1}", b.Item1, b.Item2);

            Console.ReadLine();
        }
    }
    
    public class EuclidAlgorithm
    {
        public delegate uint CalculateDelegate(uint firstNumber, uint secondNumber);
        public Tuple<uint, TimeSpan> CalculateGCD(Algorithm alg, params uint[] numbers) 
        {
            if (numbers == null) throw new ArgumentNullException();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            CalculateDelegate Calc;
            if(alg==Algorithm.Euclid)
            {
                Calc = CalculateNormalWay;
            }             
            else
            {
                Calc = CalculateBinaryWay;
            }             

            for (int a = 0; a < numbers.Length - 1; a++ )
            {
                numbers[a + 1] = Calc(numbers[a], numbers[a + 1]);
            }

            sw.Stop();
            return Tuple.Create(numbers[numbers.GetUpperBound(0)], sw.Elapsed);
        }

        uint CalculateNormalWay(uint firstNumber, uint secondNumber)
        {
            if (secondNumber != 0)
            {
                return CalculateNormalWay(secondNumber, firstNumber % secondNumber);
            }
            else
                return firstNumber;
        }

        uint CalculateBinaryWay(uint firstNumber, uint secondNumber)
        {
            if (secondNumber == firstNumber) return firstNumber;
            if (firstNumber == 0) return secondNumber;
            if (secondNumber == 0) return firstNumber;

            if (firstNumber%2==0)
            {
                if (secondNumber%2==1)
                    return CalculateBinaryWay(firstNumber >> 1, secondNumber);
                else
                    return CalculateBinaryWay(firstNumber >> 1, secondNumber >> 1) << 1;
            }
            if (secondNumber%2==0)
                return CalculateBinaryWay(firstNumber, secondNumber >> 1);
            if (firstNumber > secondNumber)
                return CalculateBinaryWay((firstNumber - secondNumber) >> 1, secondNumber);
            return CalculateBinaryWay((secondNumber - firstNumber) >> 1, firstNumber);
        }
    }
    public enum Algorithm
    {
        Euclid,
        Stein
    }
}
