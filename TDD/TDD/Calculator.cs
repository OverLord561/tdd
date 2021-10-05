using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD
{
    public static class Calculator
    {

        public delegate void CalculatorHandler(string message);
        public static event Action<string, int> AddOccured;

        ////;\n1;2
        public static int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var baseSeparatingStrings = new List<string>() { ",", "\n" };
            var starter = "//";


            if (numbers.StartsWith("//"))
            {
                var delimitersPattern = string.Join("", numbers.Skip(starter.Length).Take(numbers.IndexOf("\n") - 2));

                if (delimitersPattern.StartsWith("["))
                {

                    string[] delimeters = delimitersPattern.Replace("[", "").Split(']');
                    baseSeparatingStrings.AddRange(delimeters);
                }
                else
                {
                    baseSeparatingStrings.Add($"{delimitersPattern}");

                }

                numbers = string.Join("", numbers.Skip(starter.Length + delimitersPattern.Length));

            }


            var integers = numbers.Split(baseSeparatingStrings.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse)
                .Where(x => x <= 1000);

            var negative = integers.Where(x => x < 0);
            if (negative.Any())
            {
                throw new Exception($"negatives not allowed = {string.Join(";", negative.ToArray())}");
            }

            var result = integers.Sum();

            AddOccured?.Invoke(numbers, result);

            return result;
        }

        public static int GetCalledCount()
        {
            var list = AddOccured.GetInvocationList();
            return AddOccured.GetInvocationList().Count();
        }
    }
}
