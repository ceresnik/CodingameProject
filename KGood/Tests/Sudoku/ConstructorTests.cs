using System;
using KGood.Source.Sudoku;
using NUnit.Framework;

namespace KGood.Tests.Sudoku
{
    public class ConstructorTests
    {
        [Test]
        public void Constructor_LineIsNullOrEmpty_ExceptionIsThrown()
        {   
            Assert.Throws<ArgumentException>(() => new OneLineSudoku(null));
        }

        [Test]
        public void Constructor_LineLengthDoesNotEqualNine_ExceptionIsThrown()
        {
            string inputLine = "1234";
            Assert.Throws<ArgumentException>(() => new OneLineSudoku(inputLine));
        }

        [Test]
        public void Constructor_LineDoesNotContainQuestionMark_ExceptionIsThrown()
        {
            string inputLine = "123456789";
            Assert.Throws<ArgumentException>(() => new OneLineSudoku(inputLine));
        }

        [Test]
        public void Constructor_LineDoesNotContainEightNumbers_ExceptionIsThrown()
        {
            string inputLine = "1?34?6789";
            Assert.Throws<ArgumentException>(() => new OneLineSudoku(inputLine));
        }
    }
}