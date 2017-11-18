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
            if (coefficents == null) throw new ArgumentNullException();
            this.coefficents = coefficents;
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            return Operatepolynomiales(polynomial1, polynomial2, Operation.sum);
        }
        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            return Operatepolynomiales(polynomial1, polynomial2, Operation.sub);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) throw new ArgumentNullException();
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
            return base.GetHashCode();
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
        static Polynomial GetShorterOrFirstpolynomial(Polynomial polynomial1, Polynomial polynomial2)
        {
            return (polynomial1.coefficents.Length <= polynomial2.coefficents.Length) ? polynomial1 : polynomial2;
        }
        static Polynomial Operatepolynomiales(Polynomial polynomial1, Polynomial polynomial2, Operation operation)
        {
            int shortLength, longLength;
            Polynomial shorterpolynomial = GetShorterOrFirstpolynomial(polynomial1, polynomial2);
            Polynomial longerpolynomial = shorterpolynomial.Equals(polynomial1) ? polynomial2 : polynomial1;

            longLength = longerpolynomial.coefficents.Length;
            shortLength = shorterpolynomial.coefficents.Length;

            Polynomial retVal = new Polynomial(new int[longerpolynomial.coefficents.Length]);
            for (int i = 0; i < longLength; i++)
            {
                if(operation == Operation.sum)
                {
                    retVal.coefficents[i] = longerpolynomial.coefficents[i];
                    if (i < shortLength)
                    {
                        retVal.coefficents[i] += shorterpolynomial.coefficents[i];
                    }
                }
                else
                {
                    if (i < polynomial1.coefficents.Length)
                    {
                        retVal.coefficents[i] += polynomial1.coefficents[i];
                    }
                    retVal.coefficents[i] -= polynomial2.coefficents[i];
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
