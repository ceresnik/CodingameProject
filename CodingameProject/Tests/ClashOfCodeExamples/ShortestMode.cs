using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodingameProject.Tests.ClashOfCodeExamples
{
    public class ShortestMode
    {
        [TestCase(2, 2016, 29)]
        [TestCase(2, 2017, 28)]
        [TestCase(2, 2018, 28)]
        [TestCase(2, 2019, 28)]
        [TestCase(2, 2020, 29)]
        [TestCase(1, 2019, 31)]
        [TestCase(3, 2019, 31)]
        [TestCase(4, 2019, 30)]
        [TestCase(5, 2019, 31)]
        [TestCase(6, 2019, 30)]
        [TestCase(7, 2019, 31)]
        [TestCase(8, 2019, 31)]
        [Test]
        public void CountOfDaysInMonth(int month, int year, int expected)
        {
            int m = month;
            int y = year;
            int r = DateTime.DaysInMonth(y, m);
            Assert.That(r, Is.EqualTo(expected));
        }

        [Test]
        public void OrderAndFormatNumbers()
        {
            var inputList1 = new List<int> { 1, 9, 5 }.OrderBy(x => x).ToList();
            var inputList2 = new List<int> { 2, 1, 6 }.OrderBy(x => x).ToList();

            var pairs = inputList1.Select((x, y) => "(" + x + ", " + inputList2[y] + ")").ToList();
            var result = string.Join(", ", pairs);
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo("(1, 1), (5, 2), (9, 6)"));
        }
    }
}