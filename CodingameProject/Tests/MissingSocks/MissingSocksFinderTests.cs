using System;
using System.Collections.Generic;

using CodingameProject.Source.MissingSocks;

using NUnit.Framework;


namespace CodingameProject.Tests.MissingSocks
{
    /*
     Acceptance tests:
     1)7
            sock 43 blue-striped-red
            sweater 4 orange
            sock 43 purple
            pants 10 blue
            t-shirt 5 white
            sock 43 purple
            bra 95 yellow
            1
            43 blue-striped-red
    2) 9
            sock 42 brown
            sock 31 green
            sock 12 brown
            sock 41 blue
            sock 32 blue
            sock 42 yellow
            sock 47 white
            sock 36 purple
            sock 40 purple
            9
            12 brown
            31 green
            32 blue
            36 purple
            40 purple
            41 blue
            42 brown
            42 yellow
            47 white
    3) 5
        sweat 8 red
        t-shirt 6 ugly-purple
        underpants 5 white
        cap 0 light-blue
        underpants 5 white
        0
    4) 6
        sock 38 blue
        sock 43 green-and-blue-stripped-yellow
        short 7 orange
        sock 43 green-and-blue-stripped-yellow
        pants 40 pink
        sock 38 blue
        0
    5) 0 0
    6) 4
        sock 42 red
        sock 43 blue
        sock 42 red
        sock 42 red
        2
        42 red
        43 blue
    7) 5
        sock 15 blue
        sock 9 purple
        sock 15 blue
        pants 40 green
        t-shirt 15 orange
        1
        9 purple
     */

    class MissingSocksFinderTests
    {
        [Test, TestCaseSource(nameof(GetTest1Input))]
        public void Test1(string expected, IEnumerable<(string, int, string)> inputClothes)
        {
            var socksWithoutPair = MissingSocksFinder.FindSocksWithoutPair(inputClothes);
            Console.WriteLine(socksWithoutPair.Count);
            foreach (var sockWithoutPair in socksWithoutPair)
            {
                string output = string.Join(" ", sockWithoutPair.Item2, sockWithoutPair.Item3);
                Console.WriteLine(output);
                Assert.That(output, Is.EqualTo(expected));
            }
        }
            
        [Test, TestCaseSource(nameof(GetTest3Input))]
        public void Test3(string expected, IEnumerable<(string, int, string)> inputClothes)
        {
            var socksWithoutPair = MissingSocksFinder.FindSocksWithoutPair(inputClothes);
            Console.WriteLine(socksWithoutPair.Count);
            foreach (var sockWithoutPair in socksWithoutPair)
            {
                string output = string.Join(" ", sockWithoutPair.Item2, sockWithoutPair.Item3);
                Console.WriteLine(output);
                Assert.That(output, Is.EqualTo(expected));
            }
        }

        [Test, TestCaseSource(nameof(GetTest4Input))]
        public void Test4(string expected, IEnumerable<(string, int, string)> inputClothes)
        {
            var socksWithoutPair = MissingSocksFinder.FindSocksWithoutPair(inputClothes);
            Console.WriteLine(socksWithoutPair.Count);
            foreach (var sockWithoutPair in socksWithoutPair)
            {
                string output = string.Join(" ", sockWithoutPair.Item2, sockWithoutPair.Item3);
                Console.WriteLine(output);
                Assert.That(output, Is.EqualTo(expected));
            }
        }

        [Test, TestCaseSource(nameof(GetTest6Input))]
        public void Test6(IEnumerable<string> expected, IEnumerable<(string, int, string)> inputClothes)
        {
            var socksWithoutPair = MissingSocksFinder.FindSocksWithoutPair(inputClothes);
            Console.WriteLine(socksWithoutPair.Count);
            var foundSocksWithoutPair = new List<string>();
            foreach (var sockWithoutPair in socksWithoutPair)
            {
                string output = string.Join(" ", sockWithoutPair.Item2, sockWithoutPair.Item3);
                Console.WriteLine(output);
                foundSocksWithoutPair.Add(output);
            }
            CollectionAssert.AreEqual(expected , string.Join(", ", foundSocksWithoutPair));
        }

        [Test, TestCaseSource(nameof(GetTest7Input))]
        public void Test7(string expected, IEnumerable<(string, int, string)> inputClothes)
        {
            var socksWithoutPair = MissingSocksFinder.FindSocksWithoutPair(inputClothes);
            Console.WriteLine(socksWithoutPair.Count);
            foreach (var sockWithoutPair in socksWithoutPair)
            {
                string output = string.Join(" ", sockWithoutPair.Item2, sockWithoutPair.Item3);
                Console.WriteLine(output);
                Assert.That(output, Is.EqualTo(expected));
            }
        }

        private static IEnumerable<TestCaseData> GetTest1Input()
        {
            return new[]
            {
                new TestCaseData(
                    "43 blue-striped-red",
                    new[]
                    {
                        ("sock", 43, "blue-striped-red"),
                        ("sweater", 4, "orange"),
                        ("sock", 43, "purple"),
                        ("pants", 10, "blue"),
                        ("t-shirt", 5, "white"),
                        ("sock", 43, "purple"),
                        ("bra", 95, "yellow"),
                    })
            };
        }

        private static IEnumerable<TestCaseData> GetTest3Input()
        {
            return new[]
            {
                new TestCaseData(
                    "",
                    new[]
                    {
                        ("sweat", 8, "red"),
                        ("t-shirt", 5, "ugly-purple"),
                        ("underpants", 5, "white"),
                        ("cap", 0, "blue"),
                        ("underpants", 5, "white")
                    })
            };
        }

        private static IEnumerable<TestCaseData> GetTest4Input()
        {
            return new[]
            {
                new TestCaseData(
                    "",
                    new[]
                    {
                        ("sock", 38, "blue"),
                        ("sock", 43, "green-and-blue-stripped-yellow"),
                        ("short", 7, "orange"),
                        ("sock", 43, "green-and-blue-stripped-yellow"),
                        ("pants", 40, "pink"),
                        ("sock", 38, "blue")
                    })
            };
        }

        private static IEnumerable<TestCaseData> GetTest6Input()
        {
            return new[]
            {
                new TestCaseData(
                    new[]
                    {
                        "42 red",
                        "43 blue"
                    },
                    new[]
                    {
                        ("sock", 42, "red"),
                        ("sock", 43, "blue"),
                        ("sock", 42, "red"),
                        ("sock", 42, "red")
                    })
            };
        }

        private static IEnumerable<TestCaseData> GetTest7Input()
        {
            return new[]
            {
                new TestCaseData(
                    "9 purple",
                    new[]
                    {
                        ("sock", 15, "blue"),
                        ("sock", 9, "purple"),
                        ("sock", 15, "blue"),
                        ("pants", 40, "green"),
                        ("t-shirt", 15, "orange")
                    })
            };
        }
    }
}
