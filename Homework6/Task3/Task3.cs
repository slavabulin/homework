using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Create Polynomial class for working with polynomials of degree n > 0 of one real variable 
    /// (as an internal structure for storing coefficients use the sz-array). Override the necessary methods 
    /// of the System.Object Type and also overload base operations for working with polynomials. Develop unit-tests.
    /// </summary>
    class Task3
    {
        static void Main(string[] args)
        {
        }
    }

    public class Polynomial
    {
        int[] coefficents;
        public Polynomial(params int[] coefficents)
        {
            if (coefficents == null) throw new ArgumentNullException("coefficents","null passed as input parameter");
            this.coefficents = coefficents;
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            return OperatePolynomiales(polynomial1, polynomial2, Operation.sum);
        }
        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            return OperatePolynomiales(polynomial1, polynomial2, Operation.sub);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false; 

            Polynomial inputVal = (obj as Polynomial);
            if (inputVal.coefficents.Length != this.coefficents.Length) return false;
            for (int i = 0; i < this.coefficents.Length;i++ )
            {
                if(this.coefficents[i] != inputVal.coefficents[i]) return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            unchecked
            {
                for (int i = 0; i < coefficents.Length; i++)
                {
                    hash = hash * 23 + coefficents[i].GetHashCode();
                }
            }
            return hash;
        }
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// returns shorter polynomial or first polynomial if they are equal
        /// </summary>
        /// <param name="polynomial1">first polynomial to compare</param>
        /// <param name="polynomial2">second polynomial to compare</param>
        /// <returns></returns>
        static Polynomial GetShorterOrFirstPolynomial(Polynomial polynomial1, Polynomial polynomial2)
        {
            return (polynomial1.coefficents.Length <= polynomial2.coefficents.Length) ? polynomial1 : polynomial2;
        }
        static Polynomial OperatePolynomiales(Polynomial polynomial1, Polynomial polynomial2, Operation operation)
        {
            int shortLength, longLength;
            Polynomial shorterPolynomial = GetShorterOrFirstPolynomial(polynomial1, polynomial2);
            Polynomial longerPolynomial = shorterPolynomial.Equals(polynomial1) ? polynomial2 : polynomial1;

            longLength = longerPolynomial.coefficents.Length;
            shortLength = shorterPolynomial.coefficents.Length;

            Polynomial retVal = new Polynomial(new int[longerPolynomial.coefficents.Length]);
            for (int i = 0; i < longLength; i++)
            {
                switch (operation)
                {
                    case Operation.sum:
                        retVal.coefficents[i] = longerPolynomial.coefficents[i];
                        if (i < shortLength)
                        {
                            retVal.coefficents[i] += shorterPolynomial.coefficents[i];
                        }
                        break;

                    case Operation.sub:
                        if (i < polynomial1.coefficents.Length)
                        {
                            retVal.coefficents[i] += polynomial1.coefficents[i];
                        }
                        retVal.coefficents[i] -= polynomial2.coefficents[i];
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Operation", "Unexpected operation type");
                }

            }
            return retVal;
        }

        enum Operation
        {
            sum,
            sub
        }
    }
}
