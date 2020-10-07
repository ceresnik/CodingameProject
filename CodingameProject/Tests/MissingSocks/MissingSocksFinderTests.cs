using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;


namespace CodingameProject.Tests.MissingSocks
{
    /*
    Often (I hope) you wash your clothes. And sometimes a sock disappears.
    Now you are in front of your washing machine and you empty it. While emptying you want to know if you have any lost socks and which ones they are.
    Input
    Line 1: n the number of clothes and underwear in the washing machine.
    Next n lines: clothes type clothes size clothes color a string, an int, and a string.

    Socks have the sock clothes type.
    Pants have the pants clothes type.
    T-Shirts have the t-shirt clothes type.
    And so on...

    Two socks form a pair if they are if they have the same clothes type, clothes size, and clothes color.

    Any sock coming out of the washing machine that is not part of pair indicates that you have lost that other sock.
    Output
    First line: The number of disappeared socks.
    Then: The sock size and the sock color (separated by a space) of all missing socks separated by a new line. Nothing if all socks are back from the washing.
    Socks must be in the numerical then alphabetical order. That means socks must be sorted by their size and if they have the same size by their colors.
    Constraints
    0 ≤ n < 10
    Example
    Input
    5
    t-shirt 2 blue
    sock 42 red
    sock 42 red
    short 7 white
    sock 37 grey
    Output:  1 37 grey
    */

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

        [Test, TestCaseSource(nameof(GetTest7Input))]
        public void Test7(string exp, IEnumerable<(string, int, string)> inputClothes)
        {
            var socksWithoutPair = FindSocksWithoutPair(inputClothes);
            Console.WriteLine(socksWithoutPair.Count);
            foreach (var sockWithoutPair in socksWithoutPair)
            {
                string output = string.Join(" ", sockWithoutPair.Item2, sockWithoutPair.Item3);
                Console.WriteLine(output);
                Assert.That(output, Is.EqualTo(exp));
            }
        }

        private static List<(string, int, string)> FindSocksWithoutPair(IEnumerable<(string, int, string)> input)
        {
            var socks = input.Where(item => item.Item1.Equals("sock")).ToList();

            var socksWithoutPair = new List<(string, int, string)>();
            foreach (var sock in socks)
            {
                if (socks.Count(x => x.Item2 == sock.Item2 && x.Item3 == sock.Item3) == 1)
                {
                    socksWithoutPair.Add(sock);
                }
            }

            return socksWithoutPair;
        }
    }
}
