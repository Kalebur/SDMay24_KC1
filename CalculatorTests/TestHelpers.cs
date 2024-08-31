using System;

namespace CalculatorTests
{
    public class TestHelpers
    {
        private readonly Random _random;

        public TestHelpers()
        {
            _random = new Random();
        }

        public object[] GetEmptyCollections()
        {
            return
            [
                new List<int>(),
                Array.Empty<int>(),
            ];
        }

        public IEnumerable<int>[] GetSingleValueCollection(int minInteger, int maxInteger)
        {
            var randomNumber = _random.Next(minInteger, maxInteger);

            return new[] { new List<int> { randomNumber } };
        }

        public IEnumerable<int>[] GetCollectionOfIntegers(int minInteger, int maxInteger)
        {
            List<int> numbers = [];
            var countOfNumbersToAdd = _random.Next(2, 100);

            for (int i = 0; i < countOfNumbersToAdd; i++)
            {
                numbers.Add(GetRandomInteger(minInteger, maxInteger));
            }

            return [
                numbers,
            ];
        }

        public int GetRandomInteger(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
