using NUnit.Framework;
using TDD;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        public void Task1(string input, int expectedResult)
        {
            int actualResult = Calculator.Task1(input);

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}