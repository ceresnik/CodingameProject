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
    }
}