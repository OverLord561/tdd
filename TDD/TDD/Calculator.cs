using System;
using System.Linq;

namespace TDD
{
    public static class Calculator
    {
        public static int Task1(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var result = numbers.Split(',').Select(Int32.Parse).Sum();

            return result;
        }
    }
}
