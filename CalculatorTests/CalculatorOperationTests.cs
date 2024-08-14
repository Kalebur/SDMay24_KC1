using KnowledgeCheck1_Calculator.Logic;
using System.Numerics;

namespace CalculatorTests
{
    public class CalculatorOperationTests
    {
        private static readonly Random _random = new();
        private static readonly int _minInteger = -10_000;
        private static readonly int _maxInteger = 10_000;

        [TestCase(null)]
        public static void Add_ThrowsNullException_IfCollectionIsNull(IEnumerable<int> input)
        {
            Assert.Throws<ArgumentNullException>(() => Calculator.Add(input));
        }

        [TestCaseSource(nameof(GetEmptyCollections))]
        public static void Add_ThrowsArgumentException_IfCollectionIsEmpty(IEnumerable<int> input)
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add(input));
        }

        [TestCaseSource(nameof(GetSingleValueCollection))]
        [TestCaseSource(nameof(GetSingleValueCollection))]
        [TestCaseSource(nameof(GetSingleValueCollection))]
        [TestCaseSource(nameof(GetSingleValueCollection))]
        [TestCaseSource(nameof(GetSingleValueCollection))]
        public static void Add_ReturnsOnlyValue_IfCollectionOnlyHasOneElement(IEnumerable<int> input)
        {
            BigInteger firstItem = input.First();
            var result = Calculator.Add(input);

            Assert.That(result, Is.EqualTo(firstItem));
        }

        [TestCaseSource(nameof(GetCollectionOfIntegers))]
        [TestCaseSource(nameof(GetCollectionOfIntegers))]
        [TestCaseSource(nameof(GetCollectionOfIntegers))]
        [TestCaseSource(nameof(GetCollectionOfIntegers))]
        [TestCaseSource(nameof(GetCollectionOfIntegers))]
        public static void Add_ReturnsSumOfAllNumbers_WhenGivenCollectionOfIntegers(IEnumerable<int> input)
        {
            BigInteger sum = 0;
            foreach (var number in input)
            {
                sum += number;
            }

            var result = Calculator.Add(input);

            Assert.That(result, Is.EqualTo(sum));
        }

        private static object[] GetEmptyCollections()
        {
            return
            [
                new List<int>(),
                Array.Empty<int>(),
            ];
        }

        private static IEnumerable<int>[] GetSingleValueCollection()
        {
            var randomNumber = _random.Next(_minInteger, _maxInteger);

            return new[] { new List<int> { randomNumber } };
        }

        private static IEnumerable<int>[] GetCollectionOfIntegers()
        {
            List<int> numbers = [];
            var countOfNumbersToAdd = _random.Next(2, 100);

            for (int i = 0; i < countOfNumbersToAdd; i++)
            {
                numbers.Add(GetRandomInteger(_minInteger, _maxInteger));
            }

            return [
                numbers,
                ];
        }

        private static int GetRandomInteger(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
