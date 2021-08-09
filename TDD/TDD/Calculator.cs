using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD
{
    public static class Calculator
    {

        ////;\n1;2
        public static int Task1(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var baseSeparatingStrings = new List<string>() { ",", "\n" };


            if (numbers.StartsWith("//"))
            {
                var delimiter = string.Join("", numbers.Skip(2).Take(numbers.IndexOf("\n") - 2));
                numbers = string.Join("", numbers.Skip(2 + delimiter.Length));

                baseSeparatingStrings.Add($"{delimiter}");
            }

            
            var integers = numbers.Split(baseSeparatingStrings.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse);

            var negative = integers.Where(x => x < 0);
            if (negative.Any()) {
                throw new Exception($"negatives not allowed = {string.Join(";", negative.ToArray())}");
            }

            var result = integers.Sum();

            return result;
        }
    }
}
