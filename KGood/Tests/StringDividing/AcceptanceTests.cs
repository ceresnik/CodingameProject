/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2017. All rights reserved
   ------------------------------------------------------------------------------------------------- */

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
            StringDivider sut = new StringDivider("abcdef", 3);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(3));
        }

        [Test]
        public void Test_2()
        {
            StringDivider sut = new StringDivider("aaaaaaaabc", 3);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(10));
        }

        [Test]
        public void Test_3()
        {
            StringDivider sut = new StringDivider("phcaiodkhycinmbakdsjfplekgwaxkgqbhbhmvtlvwrmrvkqxeepjhvfdmjjewhthnhilkrxanxrelqajavubjfiaxebsjmjgsbfmxganqffrmlcydcsvxpnawskrhmutgpnkpwopudobptikjrfogdeairwyglcrqepnybcpinrybrjudcjalxumwedvngnkvoportnqeshafaodwxwjxvonaumvdtmtkotppuisubxhwcmunbdxcatppdswnsmjnygnrikvienvpysfuxrlikbkndeyxxj", 23);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(102));
        }

        [Test]
        public void Test_4()
        {
            StringDivider sut = new StringDivider("tfxaiakmlmdslooqykfmemxouisgkcxctbbvwypytslqotpfkqapjoqsyjauxolwsigsbkwyekchquoyocfkywvwwcofutasegmwodmmripixjjeltiugqarrmhgywviwgbixxhsbulhgpaylctsjcssqvidcbvwmdciuiknmsnbadlayretgprnsjwwfbrccucogpxmxeutcrkhibmudbinkilrkwdjqsdrpnghaoxilnghdokpallikfxdripqkkymrhdcttticwhkiowsypqoamxxbyiqaepwtf", 18);
            Assert.That(sut.GetLengthOfLongestSubstring(), Is.EqualTo(46));
        }
    }
}