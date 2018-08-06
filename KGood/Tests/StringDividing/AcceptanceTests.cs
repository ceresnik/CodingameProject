using System;
using System.Collections.Generic;
using System.Linq;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void Test_1()
        {
            var sut = new LongestPartFinder();
            Assert.That(sut.GetLengthOfLongestSubstring("abcdef", 3), Is.EqualTo(3));
        }

        [Test]
        public void Test_2()
        {
            var sut = new LongestPartFinder();
            Assert.That(sut.GetLengthOfLongestSubstring("aaaaaaaabc", 3), Is.EqualTo(10));
        }

        [Test]
        public void Test_3()
        {
            var sut = new LongestPartFinder();
            Assert.That(sut.GetLengthOfLongestSubstring("phcaiodkhycinmbakdsjfplekgwaxkgqbhbhmvtlvwrmrvkqxeepjhvfdmjjewhthnhilkrxanxrelqajavubjfiaxebsjmjgsbfmxganqffrmlcydcsvxpnawskrhmutgpnkpwopudobptikjrfogdeairwyglcrqepnybcpinrybrjudcjalxumwedvngnkvoportnqeshafaodwxwjxvonaumvdtmtkotppuisubxhwcmunbdxcatppdswnsmjnygnrikvienvpysfuxrlikbkndeyxxj", 23), Is.EqualTo(102));
        }

        [Test]
        public void Test_4()
        {
            var sut = new LongestPartFinder();
            Assert.That(sut.GetLengthOfLongestSubstring("tfxaiakmlmdslooqykfmemxouisgkcxctbbvwypytslqotpfkqapjoqsyjauxolwsigsbkwyekchquoyocfkywvwwcofutasegmwodmmripixjjeltiugqarrmhgywviwgbixxhsbulhgpaylctsjcssqvidcbvwmdciuiknmsnbadlayretgprnsjwwfbrccucogpxmxeutcrkhibmudbinkilrkwdjqsdrpnghaoxilnghdokpallikfxdripqkkymrhdcttticwhkiowsypqoamxxbyiqaepwtf", 18), Is.EqualTo(46));
        }

        [Test]
        public void Test()
        {
            string code = "067111100105110103097109101";
            var asciis = SplitToAsciiCodesViaDoCycle(code);
            string result = "";
            result = asciis.Aggregate(result, (current, n) => current + (char)n);
            Assert.That(result, Is.EqualTo("Codingame"));
        }

        private IEnumerable<int> SplitToAsciiCodesViaDoCycle(string input)
        {
            int index = 0;
            var asciiCodes = new List<int>();
            string code = "";
            do
            {
                index++;
                code += input[index].ToString();
                if (HaveEnoughNumbersForCode(index, input))
                {
                    asciiCodes.Add(int.Parse(code));
                    code = "";
                }
            } while (index < input.Length - 1);
            return asciiCodes;
        }

        private static bool HaveEnoughNumbersForCode(int i, string input)
        {
            IEnumerable<int> Series(int k = 2, int n = 3, int c = 1)
            {
                while (true)
                {
                    yield return k;
                    k = (c * k) + n;
                }
            }
            var ZeroTo1000 = Series().Take(1001);
            return ZeroTo1000.Contains(i) || i == input.Length - 1;
        }


        private static List<int> SplitToAsciiCodesViaForCycle(string code)
        {
            var asciis = new List<int>();
            string number = "";
            for (int i = 0; i < code.Length; i++)
            {
                if (i > 0 && i % 3 == 0)
                {
                    asciis.Add(int.Parse(number));
                    number = code[i].ToString();
                }
                else
                {
                    number += code[i];
                }
            }
            return asciis;
        }
    }
}