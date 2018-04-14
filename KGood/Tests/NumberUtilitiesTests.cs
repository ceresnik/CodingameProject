﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    public class NumberUtilitiesTests
    {
        [Test]
        public void Test_SortNumbers()
        {
            int[] inputs = { -38, 190, 180, 170, 160, 150, 140, 130, 120, 110 };
            int[] output = NumberUtilities.SortArray(inputs);
            var result = string.Join(" ", output);
            Console.Write(result);
            Assert.That(result, Is.EqualTo("-38 110 120 130 140 150 160 170 180 190"));
        }

        [Test]
        public void Test_SortNumbers1()
        {
            int[] inputs = { -38, 190, 180, 170, 160, 150, 140, 130, 120, 110 };
            int[] output = NumberUtilities.SortArray(inputs);
            string result = string.Join(" ", output);
            Trace.Write("'" + result + "'");
            Assert.That(result, Is.EqualTo("-38 110 120 130 140 150 160 170 180 190"));
        }

        [TestCase(12, 3)]
        [TestCase(19, 1)]
        [TestCase(17, 8)]
        [TestCase(71, 8)]
        [TestCase(4294967292, 9)]
        [TestCase(95018375, 2)]
        [TestCase(1850, 5)]
        [TestCase(7645, 4)]
        [Test]
        public void Test_GetSumOfParticularNumbers(Int64 input, int output)
        {
            var result = NumberUtilities.GetSumOfParticularNumbers(input);

            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase(98, 4, 2, 5, "98 102\r\n106 110\r\n114 118\r\n122 126\r\n130 134\r\n")]
        [Test]
        public void Test_CountAndFormatOutput(int a, int b, int c, int d, string expected)
        {
            var result = NumberUtilities.CountAndFormatOutput(a, b, c, d);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 4)]
        [TestCase(5000, 669)]
        [TestCase(10000, 1229)]
        [TestCase(100000, 9592)]
        [Test]
        public void Test_GetCountOfPrimes(int input, int output)
        {
            int result = NumberUtilities.GetCountOfPrimes(input);
            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase(4, "BUGA")]
        [TestCase(156, "ZOBUMEUGA")]
        [TestCase(1420365, "BUBUBUZOZOMEUGABUGAMEUBU")]
        [Test]
        public void Test_TranslateToBuga(int input, string expected)
        {
            var result = NumberUtilities.TranslateToBuga(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3, 2, "5")]
        [TestCase(4, 2, "7")]
        [TestCase(5, 2, "9")]
        [TestCase(6, 2, "11")]
        [TestCase(7, 2, "13")]
        [TestCase(8, 2, "15")]
        [TestCase(3, 3, "4")]
        [TestCase(4, 3, "5")]
        [TestCase(5, 3, "7")]
        [TestCase(6, 3, "8")]
        [TestCase(7, 3, "10")]
        [TestCase(8, 3, "11")]
        [TestCase(9, 3, "13")]
        [TestCase(4, 4, "5")]
        [TestCase(5, 4, "6")]
        [TestCase(42, 0, "42")]
        [TestCase(1000, 4, "1333")]
        [TestCase(995, 3, "1492")]
        [TestCase(8192, 9999, "8192")]
        [TestCase(9999, 3, "14998")]
        [TestCase(425, 1, "IMPOSSIBLE")]
        [Test]
        public void Test_CountCandlesLife(int numberOfCandles, int candleRenewCount, string expected)
        {
            var result = NumberUtilities.CountCandlesLife(numberOfCandles, candleRenewCount);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(17, 4)]
        [TestCase(1, 0)]
        [TestCase(80, 33)]
        [TestCase(236, 92)]
        [TestCase(3000000, 1828649)]
        [Test]
        public void Test_CountNumberOfClaps(int countOfNumbers, int expected)
        {
            var claps = NumberUtilities.CountNumberOfClaps(countOfNumbers);
            Assert.That(claps, Is.EqualTo(expected));
        }

        [TestCase("D982734978", "017265021")]
        [TestCase("d0123456789", "9876543210")]
        [TestCase("O536472635", "241305142")]
        [TestCase("o01234567", "76543210")]
        [Test]
        public void Test_CountDiminishedRadixComplement(string input, string expected)
        {
            var output = NumberUtilities.CountDiminishedRadixComplement(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [TestCase("0b1010", "0xA")]
        [TestCase("0b100100110", "0x126")]
        [Test]
        public void Test_ConvertBinaryToHexa(string input, string expected)
        {
            string result = NumberUtilities.ConvertBinaryToHexa(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_AddingTimes()
        {
            string input1 = "00:01:00";
            string input2 = "00:10:00";
            var result = NumberUtilities.AddDateTimes(input1, input2);
            string expected = "00:11:00";

            Assert.That(result.TimeOfDay.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void Test_FindClosestPointToZero()
        {
            IList<Point> inputPoints = new List<Point> { new Point(2, 2), new Point(-1, 1), new Point(-3, -3) };
            Point result = inputPoints[0];
            int minDistance = 1000;
            foreach (Point point in inputPoints)
            {
                var currentDistance = (int)Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
                if (currentDistance < minDistance)
                {
                    result = point;
                    minDistance = currentDistance;
                }
            }
            Point expected = new Point(-1, 1);
            Assert.That(expected.X, Is.EqualTo(result.X));
            Assert.That(expected.Y, Is.EqualTo(result.Y));
        }

        [TestCase("heLLo world", "Hello World")]
        [TestCase("HaVe fUN And KEEP cOding", "Have Fun And Keep Coding")]
        [Test]
        public void Test_ConvertToUppercase(string input, string expected)
        {
            IList<string> results = new List<string>();
            string[] strings = input.Split(' ');
            foreach (string t in strings)
            {
                string s = t.ToLower();
                char startingLetter = s[0];
                s = s.Substring(1);
                s = s.Insert(0, ((char)(startingLetter - 32)).ToString());
                results.Add(s);
            }
            string result = string.Join(" ", results);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("boom boom ts", 1, 0)]
        [TestCase("ts ts ding boom boom boom boom boom boom boom boom boom boom bing bing bing bing bing bing bing bing bing boom bing bing bing bing bing bing bing boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom boom", 30, 10)]
        [Test]
        public void Test_DoDanceFloorMovement(string input, int expectedX, int expectedY)
        {
            var position = NumberUtilities.DoDanceFloorMovement(input);
            Assert.That(position, Is.EqualTo(new Point(expectedX, expectedY)));
        }

        [TestCase("1 1 2", 2)]
        [TestCase("1 2 1 2 1 2 2", 1)]
        [TestCase("1 2 3 1 2 3 1 2", 3)]
        [TestCase("1 2 3 4 5 1 2 3 5", 4)]
        [TestCase("1 2 3 5 1 2 3 4 5", 4)]
        [TestCase("1 2 3 4 5 1 3 4 5", 2)]
        [TestCase("2 3 4 5 1 2 3 4 5", 1)]
        [TestCase("1 2 3 4 5 1 2 3 4", 5)]
        [Test]
        public void Test_FindMissingNumber(string input, int expected)
        {
            var result = NumberUtilities.FindMissingNumber(input);
            Assert.That(result, Is.EqualTo(expected));

            var query = input
                .Split(' ')
                .Select(int.Parse)
                .GroupBy(s => s)
                .OrderBy(s => s.Count())
                .Select(x => new
                             {
                                 Number = x.Key,
                                 RepetitionCount = x.Count()
                             });
            foreach (var item in query)
            {
                Console.WriteLine($"Number: {item.Number}, repetitionCount: {item.RepetitionCount}");
            }
        }

        [TestCase(5, "5 16 8 4 2 1")]
        [Test]
        public void Test_SyracuzeSequence(int input, string expected)
        {
            var result = NumberUtilities.CountSyracuzeSequence(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("1", "2", "3", 2)]
        [TestCase("5", "3", "8", 5)]
        [Test]
        public void Test_FindMiddleValue(string x, string y, string z, int expected)
        {
            var result = NumberUtilities.FindMiddleValue(x, y, z);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_DateTime()
        {
            DateTime dateOfProduction = new DateTime(2018, 3, 14);
            TimeSpan duration = new TimeSpan(15, 0, 0, 0);
            DateTime bestBefore = dateOfProduction.Add(duration);

            Assert.That(bestBefore, Is.EqualTo(new DateTime(2018, 3, 29)));
        }

        [TestCase(9, "1, 3, 5, 7, 9")]
        [TestCase(17, "1, 3, 5, 7, 9, 11, 13, 15, 17")]
        [Test]
        public void Test_SelectOddNumbers(int input, string expected)
        {
            IEnumerable<int> result = Enumerable
                .Range(1, input)
                .Where(x => x % 2 == 1)
                .Select(x => x);
            Enumerable
                .Range(1, input)
                .Where(x => x % 2 == 1)
                .ToList()
                .ForEach(Console.WriteLine);
            Assert.That(string.Join(", ", result), Is.EqualTo(expected));
        }

        /// <summary>
        /// Number is happy if sum of its digits squares is 1.
        /// </summary>
        /// <example>86=8*8 + 6*6=100=1*1+0*0+0*0=1 => HAPPY</example>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestCase(86, "HAPPY")]
        [TestCase(404, "HAPPY")]
        [TestCase(12, "UNHAPPY")]
        [TestCase(9999999999, "UNHAPPY")]
        [Test]
        public void Test_HappyNumber(long input, string expected)
        {
            int query;
            do
            {
                query = input.ToString().Select(x => int.Parse(x.ToString())).Sum(x => x*x);
                input = query;
            } while (query > 9);
            string result = query == 1 ? "HAPPY":"UNHAPPY";
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2004)]
        [TestCase(2001)]
        [TestCase(1996)]
        [TestCase(100)]
        [TestCase(1111)]
        [TestCase(2100)]
        [Test]
        public void Test_IsLeapYear(int year)
        {
            var result = NumberUtilities.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(DateTime.IsLeapYear(year)));
        }
    }
}