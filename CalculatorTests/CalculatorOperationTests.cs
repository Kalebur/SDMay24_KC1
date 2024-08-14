using KnowledgeCheck1_Calculator.Logic;
using System.Numerics;

namespace CalculatorTests
{
    public class CalculatorOperationTests
    {
        private static readonly Random _random = new();

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
            var randomNumber = _random.Next(-10_000, 10_000);

            return new[] { new List<int> { randomNumber } };
        }
    }
}
