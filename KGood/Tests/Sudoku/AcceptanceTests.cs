using KGood.Source.Sudoku;
using NUnit.Framework;

namespace KGood.Tests.Sudoku
{
    public class AcceptanceTests
    {
        [Test]
        public void AcceptanceTest1()
        {
            string inputLine = "8372?9514";
            var sut = new OneLineSudoku();
            var result = sut.GetSolutionFor(inputLine);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void AcceptanceTest2()
        {
            string inputLine = "981453?67";
            var sut = new OneLineSudoku();
            var result = sut.GetSolutionFor(inputLine);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void AcceptanceTest3()
        {
            string inputLine = "318?92657";
            var sut = new OneLineSudoku();
            var result = sut.GetSolutionFor(inputLine);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void AcceptanceTest4()
        {
            string inputLine = "1234?6789";
            var sut = new OneLineSudoku();
            var result = sut.GetSolutionFor(inputLine);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void AcceptanceTest5()
        {
            string inputLine1 = "1234?6789";
            string inputLine2 = "318?92657";
            var sut = new OneLineSudoku();
            var result = sut.GetSolutionFor(inputLine1);
            Assert.That(result, Is.EqualTo(5));
            result = sut.GetSolutionFor(inputLine2);
            Assert.That(result, Is.EqualTo(4));
        }
    }
}