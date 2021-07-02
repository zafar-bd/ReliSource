using System;
using System.Collections.Generic;
using System.Linq;

namespace StringMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "String Merge";
            string inputOne = "AMAZING";
            string inputTwo = "RELISOURCE";
            string mergedString = "REAMALISZOURCING";

            bool isValidMerged = IsValidMerged(inputOne, inputTwo, mergedString);

            Console.WriteLine($"Is Valid Merged: {isValidMerged}");
            Console.WriteLine($"==============");

            ExecuteFibonacci(84);

            Console.ReadLine();
        }

        private static void ExecuteFibonacci(int input)
        {
            for (int i = 1; i < input; i++)
            {
                var fibonacciSeries = GenerateFibonacciSeries(0, i, input);
                if (fibonacciSeries.Any(f => f == input))
                {
                    Console.WriteLine($"Fibonacci Series:");
                    Console.WriteLine($"==============");
                    fibonacciSeries.ForEach(f => { Console.Write($"{f} "); });
                    break;
                }
            }
        }

        public static List<int> GenerateFibonacciSeries(int firstNumber, int secondNumber, int number)
        {
            List<int> numbers = new() { firstNumber, secondNumber };

            int nextNumber = firstNumber + secondNumber;

            for (int i = 0; nextNumber <= number; i++)
            {
                firstNumber = secondNumber;
                secondNumber = nextNumber;
                nextNumber = firstNumber + secondNumber;
                numbers.Add(secondNumber);
            }
            return numbers;
        }

        static bool IsValidMerged(string inputOne, string inputTwo, string mergedString)
        {
            string concatenatedString = $"{inputOne}{inputTwo}";
            if (concatenatedString?.Length != mergedString?.Length)
                return false;

            var inputStringGrouped = concatenatedString
                .GroupBy(g => g)
                .Select(g => new
                {
                    Key = g.Key.ToString().ToLower(),
                    Count = g.Count()
                })
                .OrderBy(o => o.Key)
                .ToList();

            var mergedStringGrouped = mergedString
                .GroupBy(g => g)
                .Select(g => new
                {
                    Key = g.Key.ToString().ToLower(),
                    Count = g.Count()
                })
                .OrderBy(o => o.Key)
                .ToList();

            return inputStringGrouped.All(inputChar => mergedStringGrouped.Any(m => m.Key == inputChar.Key && m.Count == inputChar.Count));
        }
    }
}
