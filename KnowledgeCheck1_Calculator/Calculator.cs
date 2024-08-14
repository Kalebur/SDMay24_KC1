using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace KnowledgeCheck1_Calculator
{
    public class Calculator
    {
        public static int Add(int first, int second)
        {
            return first + second;
        }

        public static BigInteger Add(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        public static int Subtract(int first, int second)
        {
            return first - second;
        }

        public static BigInteger Subtract(List<int> numbers)
        {
            BigInteger difference = numbers.First();

            for (int i = 1; i < numbers.Count; i++)
            {
                difference -= numbers[i];
            }

            return difference;
        }

        public static int Multiply(int first, int second)
        {
            return first * second;
        }

        public static BigInteger Multiply(IEnumerable<int> numbers)
        {
            BigInteger product = 1;

            foreach (var number in numbers)
            {
                product *= number;
            }

            return product;
        }

        public static double Divide(double first, double second)
        {
            return first / second;
        }

        public static double Divide(List<int> numbers)
        {
            double quotient = numbers.First();

            for (int i = 1; i < numbers.Count; i++)
            {
                quotient /= numbers[i];
            }

            return quotient;
        }
    }
}
