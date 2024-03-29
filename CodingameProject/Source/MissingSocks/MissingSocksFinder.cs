﻿using System.Collections.Generic;
using System.Linq;

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

namespace CodingameProject.Source.MissingSocks
{
    class MissingSocksFinder
    {
        public static List<(string, int, string)> FindSocksWithoutPair(IEnumerable<(string, int, string)> input)
        {
            var socks = input.Where(item => item.Item1.Equals("sock")).ToList();
            var socksWithoutPair = new List<(string, int, string)>();
            foreach (var sock in socks)
            {
                if (socks.Count(x => x.Item2 == sock.Item2 && x.Item3 == sock.Item3) % 2 != 0)
                {
                    socksWithoutPair.Add(sock);
                }
            }
            return socksWithoutPair;
        }
    }
}