using System;
using KGood.Source.Sudoku;
using NUnit.Framework;

namespace KGood.Tests.Sudoku
{
    public class AcceptanceTests
    {
        [Test]
        public void AcceptanceTest1()
        {
            string line = "8372?9514";
            OneLineSudoku sut = new OneLineSudoku(line);
            Assert.That(sut.GetSolution(), Is.EqualTo(6));
        }

        [Test]
        public void AcceptanceTest2()
        {
            string line = "981453?67";
            OneLineSudoku sut = new OneLineSudoku(line);
            Assert.That(sut.GetSolution(), Is.EqualTo(2));
        }

        [Test]
        public void AcceptanceTest3()
        {
            string line = "318?92657";
            OneLineSudoku sut = new OneLineSudoku(line);
            Assert.That(sut.GetSolution(), Is.EqualTo(4));
        }

        [Test]
        public void AcceptanceTest4()
        {
            string line = "1234?6789";
            OneLineSudoku sut = new OneLineSudoku(line);
            Assert.That(sut.GetSolution(), Is.EqualTo(5));
        }
    }
}