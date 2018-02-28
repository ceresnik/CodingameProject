using System;

namespace CodingameProject
{
    class Program
    {
        private static int Sum(int[] input, bool oddNumbersOnly)
        {
            int result = 0;
            foreach (int number in input)
            {
                if (oddNumbersOnly == false || number % 2 != 0)
                {
                    result += number;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            int result = Sum(new[] { 1, 2, 3, 4, 5 }, true);
            Console.WriteLine($"Sum of odd numbers: {result}");
            result = Sum(new[] { 1, 2, 3, 4, 5 }, false);
            Console.WriteLine($"Sum of all numbers: {result}");
            Console.ReadLine();
        }
    }
}
