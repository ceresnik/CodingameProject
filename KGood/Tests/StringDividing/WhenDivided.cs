using System;
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
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("a", 1).Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test2()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aa", 1).Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test3()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1).Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test4()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("ab", 1).Count, Is.EqualTo(2));
        }

        [Test]
        public void CountOfItems_Test5()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabc", 1).Count, Is.EqualTo(3));
        }

        [Test]
        public void CountOfItems_Test6()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabc", 2).Count, Is.EqualTo(2));
        }

        [Test]
        public void CountOfItems_Test7()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("abc", 3).Count, Is.EqualTo(1));
        }

        [Test]
        public void CountOfItems_Test8()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("abcdef", 2).Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test9()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabcdef", 2).Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test10()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabbcdef", 2).Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test11()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabbccdef", 2).Count, Is.EqualTo(5));
        }

        [Test]
        public void CountOfItems_Test12()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabbccdef", 5).Count, Is.EqualTo(2));
        }

        [Test]
        public void CountOfItems_Test13()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabbaccd", 2).Count, Is.EqualTo(4));
        }

        [Test]
        public void CountOfItems_Test14()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabbaccd", 3).Count, Is.EqualTo(3));
        }

        [Test]
        public void CountOfItems_Test15()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabbaaaaa", 2).Count, Is.EqualTo(2));
        }

        [Test]
        public void CountOfItems_Test16()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aabbababaabbbab", 2).Count, Is.EqualTo(9));
        }

        [Test]
        public void ContentOfItems_1()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("a", 1)[0], Is.EqualTo(new MaybeString("a")));
        }

        [Test]
        public void ContentOfItems_2()
        {
            StringDivider sut = new StringDivider();
            Assert.That(sut.Divide("aa", 1)[0], Is.EqualTo(new MaybeString("aa")));
        }

        [Test]
        public void ContentOfItems_3()
        {
            StringDivider sut = new StringDivider();
            var result = sut.Divide("aab", 1);
            Assert.That(result[0], Is.EqualTo(new MaybeString("aa")));
            Assert.That(result[1], Is.EqualTo(new MaybeString("b")));
        }

        [Test]
        public void ContentOfItems_4()
        {
            var sut = new StringDivider();
            var result = sut.Divide("aabbccdef", 2);
            Assert.That(result[0], Is.EqualTo(new MaybeString("aabb")));
            Assert.That(result[1], Is.EqualTo(new MaybeString("bbcc")));
            Assert.That(result[2], Is.EqualTo(new MaybeString("ccd")));
            Assert.That(result[3], Is.EqualTo(new MaybeString("de")));
            Assert.That(result[4], Is.EqualTo(new MaybeString("ef")));
        }

        [Test]
        public void ContentOfItems_5()
        {
            StringDivider sut = new StringDivider();
            var result = sut.Divide("aabbccdef", 5);
            Assert.That(result[0], Is.EqualTo(new MaybeString("aabbccde")));
            Assert.That(result[1], Is.EqualTo(new MaybeString("bbccdef")));
        }

        [Test]
        public void StringToDivideIsNull_NoException()
        {
            var sut = new StringDivider();
            var result = sut.Divide(null, 0);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void AndCardinalityIsGreaterThanCountOfDistinctLetters_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new StringDivider();
                sut.Divide("aaaaabb", 3);
            });
        }
    }
}