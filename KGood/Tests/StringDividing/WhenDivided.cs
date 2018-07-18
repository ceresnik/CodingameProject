/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2017. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    internal class WhenDivided
    {
        [Test]
        public void CountOfItems_Test1()
        {
            StringDivider sut = new StringDivider("a", 1);
            Assert.That(sut.Divide().Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test2()
        {
            StringDivider sut = new StringDivider("aa", 1);
            Assert.That(sut.Divide().Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test3()
        {
            StringDivider sut = new StringDivider("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1);
            Assert.That(sut.Divide().Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test4()
        {
            StringDivider sut = new StringDivider("ab", 1);
            Assert.That(sut.Divide().Count, Is.EqualTo(2));
        }

        [Test]
        public void CountOfItems_Test5()
        {
            StringDivider sut = new StringDivider("aabc", 1);
            Assert.That(sut.Divide().Count, Is.EqualTo(3));
        }

        [Test]
        public void CountOfItems_Test6()
        {
            StringDivider sut = new StringDivider("aabc", 2);
            Assert.That(sut.Divide().Count, Is.EqualTo(2));
        }

        [Test]
        public void CountOfItems_Test7()
        {
            StringDivider sut = new StringDivider("abc", 3);
            Assert.That(sut.Divide().Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test8()
        {
            StringDivider sut = new StringDivider("abcdef", 2);
            Assert.That(sut.Divide().Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test9()
        {
            StringDivider sut = new StringDivider("aabcdef", 2);
            Assert.That(sut.Divide().Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test10()
        {
            StringDivider sut = new StringDivider("aabbcdef", 2);
            Assert.That(sut.Divide().Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test11()
        {
            StringDivider sut = new StringDivider("aabbccdef", 2);
            Assert.That(sut.Divide().Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test12()
        {
            StringDivider sut = new StringDivider("aabbccdef", 5);
            Assert.That(sut.Divide().Count, Is.EqualTo(2));
        }

        [Test]
        public void CountOfItems_Test13()
        {
            StringDivider sut = new StringDivider("aabbaccd", 2);
            Assert.That(sut.Divide().Count, Is.EqualTo(4));
        }

        [Test]
        public void CountOfItems_Test14()
        {
            StringDivider sut = new StringDivider("aabbaccd", 3);
            Assert.That(sut.Divide().Count, Is.EqualTo(3));
        }

        [Test]
        public void CountOfItems_Test15()
        {
            StringDivider sut = new StringDivider("aabbababaabbbab", 2);
            Assert.That(sut.Divide().Count, Is.EqualTo(1));
        }

        [Test]
        public void ContentOfItems_1()
        {
            StringDivider sut = new StringDivider("a", 1);
            Assert.That(sut.Divide()[0], Is.EqualTo(new MaybeString("a")));
        }

        [Test]
        public void ContentOfItems_2()
        {
            StringDivider sut = new StringDivider("aa", 1);
            Assert.That(sut.Divide()[0], Is.EqualTo(new MaybeString("aa")));
        }

        [Test]
        public void ContentOfItems_3()
        {
            StringDivider sut = new StringDivider("aab", 1);
            var result = sut.Divide();
            Assert.That(result[0], Is.EqualTo(new MaybeString("aa")));
            Assert.That(result[1], Is.EqualTo(new MaybeString("b")));
        }

        [Test]
        public void ContentOfItems_4()
        {
            var sut = new StringDivider("aabbccdef", 2);
            var result = sut.Divide();
            Assert.That(result[0], Is.EqualTo(new MaybeString("aabb")));
            Assert.That(result[1], Is.EqualTo(new MaybeString("bbcc")));
            Assert.That(result[2], Is.EqualTo(new MaybeString("ccd")));
            Assert.That(result[3], Is.EqualTo(new MaybeString("de")));
            Assert.That(result[4], Is.EqualTo(new MaybeString("ef")));
        }

        [Test]
        public void ContentOfItems_5()
        {
            StringDivider sut = new StringDivider("aabbccdef", 5);
            var result = sut.Divide();
            Assert.That(result[0], Is.EqualTo(new MaybeString("aabbccde")));
            Assert.That(result[1], Is.EqualTo(new MaybeString("bbccdef")));
        }
    }
}