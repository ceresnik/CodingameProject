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
            var sut = new LongestPartFinder("abcdef", 3);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(3));
        }

        [Test]
        public void Test_2()
        {
            var sut = new LongestPartFinder("aaaaaaaabc", 3);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(10));
        }

        [Test]
        public void Test_3()
        {
            var sut = new LongestPartFinder("phcaiodkhycinmbakdsjfplekgwaxkgqbhbhmvtlvwrmrvkqxeepjhvfdmjjewhthnhilkrxanxrelqajavubjfiaxebsjmjgsbfmxganqffrmlcydcsvxpnawskrhmutgpnkpwopudobptikjrfogdeairwyglcrqepnybcpinrybrjudcjalxumwedvngnkvoportnqeshafaodwxwjxvonaumvdtmtkotppuisubxhwcmunbdxcatppdswnsmjnygnrikvienvpysfuxrlikbkndeyxxj", 23);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(102));
        }

        [Test]
        public void Test_4()
        {
            var sut = new LongestPartFinder("tfxaiakmlmdslooqykfmemxouisgkcxctbbvwypytslqotpfkqapjoqsyjauxolwsigsbkwyekchquoyocfkywvwwcofutasegmwodmmripixjjeltiugqarrmhgywviwgbixxhsbulhgpaylctsjcssqvidcbvwmdciuiknmsnbadlayretgprnsjwwfbrccucogpxmxeutcrkhibmudbinkilrkwdjqsdrpnghaoxilnghdokpallikfxdripqkkymrhdcttticwhkiowsypqoamxxbyiqaepwtf", 18);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(46));
        }
    }
}