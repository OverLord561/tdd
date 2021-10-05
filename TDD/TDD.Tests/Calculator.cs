using NUnit.Framework;
using System;
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
        [TestCase("1,2,2", 5)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2,,\n3", 6)]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//--\n1--2", 3)]
        [TestCase("//--\n1\n2", 3)]

        public void Task4(string input, int expectedResult)
        {
            int actualResult = Calculator.Add(input);

            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase("//--\n1\n-2", "negatives not allowed = -2")]
        [TestCase("1,2,-3,-5,5,-7\n-8", "negatives not allowed = -3;-5;-7;-8")]
        [TestCase("//;\n1;2;-3;-5;5;-7\n-8", "negatives not allowed = -3;-5;-7;-8")]


        public void Task5(string input, string expectedResult)
        {
            Exception ex = Assert.Throws<Exception>(() => Calculator.Add(input));

            Assert.AreEqual(expectedResult, ex.Message);
        }

     
        //public void Task7(string input, int expectedResult)
        //{
        //    string giveninput = null;

        //    Calculator.AddOccured += delegate (string input,

        //        int result)
        //    {
        //        giveninput = input;
        //        Console.WriteLine(result);
        //    };

        //    Calculator.Add(input);
            

        //    int actualResult = Calculator.GetCalledCount();

        //    Assert.AreEqual(actualResult, expectedResult);
        //}

        [TestCase("1,2,1001", 3)]
        [TestCase("1,2,1000", 1003)]
        [TestCase("1,2,999", 1002)]

        public void Task9(string input, int expectedResult)
        {
           
            int actualResult = Calculator.Add(input);

            Assert.AreEqual(actualResult, expectedResult);
        }


        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[-]\n1-2-3", 6)]

        public void Task10(string input, int expectedResult)
        {

            int actualResult = Calculator.Add(input);

            Assert.AreEqual(actualResult, expectedResult);
        }



        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[%][%]\n1%2%3", 6)]
        [TestCase("//[)][-]\n1-2)3", 6)]
        public void Task11(string input, int expectedResult)
        {

            int actualResult = Calculator.Add(input);

            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase("//[**][%%]\n1**2%%3", 6)]
        public void Task12(string input, int expectedResult)
        {

            int actualResult = Calculator.Add(input);

            Assert.AreEqual(actualResult, expectedResult);
        }

        //”


        ////[***]\n1***2***3

        //GetCalledCount
    }
}