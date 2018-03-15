using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KGood.Source
{
    public class NumberUtilities
    {
        public static int[] SortArray(int[] inputs)
        {
            Array.Sort(inputs);
            return inputs;
        }

        public static int GetSumOfParticularNumbers(long input)
        {
            string strInput = input.ToString();
            int result;
            do
            {
                result = 0;
                foreach (char c in strInput)
                {
                    result += Convert.ToInt16(c.ToString());
                }
                strInput = result.ToString();
            } while (result > 9);
            return result;
        }

        /// <summary>
        /// Reverse engineering assignment
        /// </summary>
        /// <param name="a">Starting number</param>
        /// <param name="b">Increment</param>
        /// <param name="c">Count of columns</param>
        /// <param name="d">Count of rows</param>
        /// <returns></returns>
        public static String CountAndFormatOutput(int a, int b, int c, int d)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < d; i++)
            {
                IList<int> oneLine = new List<int>();
                for (int j = 0; j < c; j++)
                {
                    oneLine.Add(a);
                    a += b;
                }
                result.AppendLine(String.Join(" ", oneLine));
            }
            return result.ToString();
        }

        /// <summary>
        /// Gets count of prime numbers smaller than given input number.
        /// </summary>
        /// <param name="input"></param>
        /// <remarks>Input must be greater or equal 3.</remarks>
        /// <returns>Count of prime numbers.</returns>
        public static int GetCountOfPrimes(int input)
        {
            DateTime beginningTime = DateTime.Now;
            var primeNumbers = new List<int> { 2 };
            for (int i = 3; i < input; i++)
            {
                bool isPrime = true;
                foreach (int primeNumber in primeNumbers)
                {
                    if (i % primeNumber == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
                if (i % 1000 == 0)
                {
                    Console.WriteLine($"Counted {i} numbers.");
                }
            }
            Console.WriteLine(String.Join(", ", primeNumbers));
            Console.WriteLine($"Calculation took {(DateTime.Now - beginningTime).TotalMilliseconds} ms.");
            return primeNumbers.Count;
        }

        public static string TranslateToBuga(int input)
        {
            IDictionary<int, string> bugaDictionary = new Dictionary<int, string> { { 0, "GA" }, { 1, "BU" }, { 2, "ZO" }, { 3, "MEU" } };
            IList<int> fourValues = new List<int>();
            do
            {
                var fourValue = input % 4;
                fourValues.Add(fourValue);
                input = input / 4;
            } while (input != 0);
            StringBuilder result = new StringBuilder();
            for (int i = fourValues.Count - 1; i >= 0; i--)
            {
                result.Append(bugaDictionary[fourValues[i]]);
            }
            return result.ToString();
        }

        public static string CountCandlesLife(int numberOfCandles, int candleRenewCount)
        {
            string result;
            if (candleRenewCount > 1)
            {
                int resultCandlesCount = numberOfCandles;
                int newCandleCount = numberOfCandles;
                int candleEndsCount = 0;
                while (newCandleCount > 0)
                {
                    candleEndsCount += newCandleCount % candleRenewCount;
                    newCandleCount = newCandleCount / candleRenewCount;
                    resultCandlesCount += newCandleCount;
                    if (candleEndsCount >= candleRenewCount)
                    {
                        resultCandlesCount++;
                        newCandleCount++;
                        candleEndsCount = candleEndsCount % candleRenewCount;
                    }
                }
                result = resultCandlesCount.ToString();
            }
            else
            {
                result = candleRenewCount == 1 ? "IMPOSSIBLE" : numberOfCandles.ToString();
            }
            return result;
        }

        /// <summary>
        /// Starting from 1, to count of numbers.
        /// If number is divisible by 7, clap.
        /// If number contains digit 7, clap.
        /// If sum of number's digits is divisible by 7, clap.
        /// </summary>
        /// <param name="countOfNumbers"></param>
        /// <returns>Number of claps.</returns>
        public static int CountNumberOfClaps(int countOfNumbers)
        {
            int claps = 0;
            for (int i = 1; i <= countOfNumbers; i++)
            {
                if (i % 7 == 0)
                {
                    claps++;
                }
                else
                {
                    string strNum = Convert.ToString(i);
                    if (strNum.Contains("7"))
                    {
                        claps++;
                    }
                    else
                    {
                        int sum = 0;
                        foreach (char c in strNum)
                        {
                            sum += Convert.ToInt32(c.ToString());
                        }
                        if (sum % 7 == 0)
                        {
                            claps++;
                        }
                    }
                }
            }
            return claps;
        }

        /// <summary>
        /// Given is number in decimal (starting with D) or octagonal (starting with O) system.
        /// Method must output diminished complement for each digit of the number.
        /// </summary>
        /// <example>D389 => 610</example>
        /// <example>O370 => 407</example>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CountDiminishedRadixComplement(string input)
        {
            var baseToSubtract = Char.ToLower(input[0]).Equals('d') ? 9 : 7;
            string result = "";
            for (var i = 1; i < input.Length; i++)
            {
                result += baseToSubtract - Convert.ToInt16(input[i].ToString());
            }
            return result;
        }

        /// <summary>
        /// Converts binary number to hexa number.
        /// </summary>
        /// <param name="input">Binary number string in format 0b... (e.g. 0b110)</param>
        /// <returns>Hexa number string in format 0x... (e.g. 0xA)</returns>
        public static string ConvertBinaryToHexa(string input)
        {
            return $"0x{Convert.ToInt32(input.Substring(2), 2):X}";
        }

        /// <summary>
        /// Adds two date times.
        /// </summary>
        /// <param name="strTime1">time 1 in string representation</param>
        /// <param name="strTime2">time 2 in string representation</param>
        /// <returns></returns>
        public static DateTime AddDateTimes(string strTime1, string strTime2)
        {
            DateTime time1 = Convert.ToDateTime(strTime1);
            DateTime time2 = Convert.ToDateTime(strTime2);
            DateTime result = time1.Add(time2.TimeOfDay);
            return result;
        }

        public static Point DoDanceFloorMovement(string input)
        {
            IDictionary<string, Point> dict = new Dictionary<string, Point>
                                              {
                                                  { "ts", new Point(-1, 0) },
                                                  { "boom", new Point(1, 0) },
                                                  { "ding", new Point(0, -1) },
                                                  { "bing", new Point(0, 1) }
                                              };
            Point position = new Point(0, 0);
            string[] instructions = input.Split(' ');
            foreach (string instruction in instructions)
            {
                int newXPosition = position.X + dict[instruction].X;
                if (newXPosition >= 0 && newXPosition <= 30)
                {
                    position.X = newXPosition;
                }
                int newYPosition = position.Y + dict[instruction].Y;
                if (newYPosition >= 0 && newYPosition <= 10)
                {
                    position.Y = newYPosition;
                }
            }
            return position;
        }

        public static string ConvertTimeToMinutes(string input)
        {
            string[] inputs = input.Split(':');
            int hours = Convert.ToInt16(inputs[0]);
            int minutes = Convert.ToInt16(inputs[1]);
            return (hours * 60 + minutes).ToString();
        }

        /// <summary>
        /// Converts given numbers separated by spaces as string to integers, puts it into list,
        /// groups this list by how many times particular number is present in the list, puts it
        /// into dictionary, orders it by value and picks the first's key.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The number which has lowest count of occurences.</returns>
        public static int FindMissingNumber(string input)
        {
            int result = input
                .Split(' ')
                .Select(Int32.Parse)
                .GroupBy(s => s)
                .OrderBy(s => s.Count())
                .First()
                .Key;
            return result;
        }

        public static string CountSyracuzeSequence(int input)
        {
            int intermediateNumber = input;
            var results = new List<int> { input };
            do
            {
                if (intermediateNumber % 2 == 0)
                {
                    intermediateNumber = intermediateNumber / 2;
                }
                else
                {
                    intermediateNumber = intermediateNumber * 3 + 1;
                }
                results.Add(intermediateNumber);
            } while (intermediateNumber != 1);
            return String.Join(" ", results);
        }


        public static int FindMiddleValue(string x, string y, string z)
        {
            var input = new List<string> { x, y, z };
            return input.Select(Int32.Parse).OrderBy(n => n).ElementAt(input.Count / 2);
        }
    }
}