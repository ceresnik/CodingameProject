using System;
using KGood.Source;
using NUnit.Framework;
using Test.Library;
using Test.Library.TestSteps;

namespace KGood.Tests
{
    public class ConvertTimeToMinutesTests : GWT
    {
        [Test]
        public void ThenResultIs785Minutes()
        {
            string result = null;
            Given(new SimpleTestStep("desc of given", () => Console.WriteLine("This is Given.")));
            When(new SimpleTestStep("desc of when", () => result = NumberUtilities.ConvertTimeToMinutes("13:05")));
            Then(new SimpleTestStep("", () => Assert.That(result, Is.EqualTo("785"))));
        }

        [TestCase("13:05", "785")]
        [Test]
        public void Test_ConvertTimeToMinutes(string input, string expected)
        {
            var result = NumberUtilities.ConvertTimeToMinutes(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}