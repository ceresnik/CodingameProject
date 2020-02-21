using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;


namespace CodingameProject.Tests.ClashOfCodeExamples
{
    [TestFixture]
    class ClashOfCodeTests
    {

        [Test]
        public void SortItemsInListAccordingToLength()
        {
            var inputs = new List<string> { "abc", "xs", "longWord", "z" };
            var sorted = inputs.OrderBy(x => x.Length).ToList();
            sorted.ForEach(Console.WriteLine);
        }
    }
}
