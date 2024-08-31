using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace KnowledgeCheck1_Calculator.Logic
{
    public class Calculator
    {
        public static int Add(int first, int second)
        {
            return first + second;
        }

        public static BigInteger Add(IEnumerable<int> numbers)
        {
            ValidateCollection(numbers);
            return numbers.Sum();
        }

        public static int Subtract(int first, int second)
        {
            return first - second;
        }

        public static BigInteger Subtract(List<int> numbers)
        {
            ValidateCollection(numbers);
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
            ValidateCollection(numbers);
            if (numbers.Count() == 1)
            {
                return numbers.First();
            }
            BigInteger product = 1;

            foreach (var number in numbers)
            {
                product *= number;
            }

            return product;
        }

        public static double Divide(double first, double second)
        {
            if (second == 0) throw new DivideByZeroException("Attempting to divide by zero.");
            return first / second;
        }

        public static double Divide(List<int> numbers)
        {
            ValidateCollection(numbers);
            if (numbers.Skip(1).Any(number => number == 0)) throw
                    new DivideByZeroException("One or more values will result in a division by zero.");
            if (numbers.Count == 1)
            {
                return numbers.First();
            }

            double quotient = numbers.First();

            for (int i = 1; i < numbers.Count; i++)
            {
                quotient /= numbers[i];
            }

            return quotient;
        }

        private static void ValidateCollection(IEnumerable<int> numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
            else if (!numbers.Any())
            {
                throw new ArgumentException("Received an empty collection.");
            }
        }
    }
}
