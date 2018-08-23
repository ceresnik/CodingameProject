using System;
using KGood.Source.Sudoku;
using NUnit.Framework;

namespace KGood.Tests.Sudoku
{
    public class OneLineSudokuTests
    {
        [Test]
        public void GetSolution_LineIsNullOrEmpty_ExceptionIsThrown()
        {   
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new OneLineSudoku();
                sut.GetSolution(null);
            });
        }

        [Test]
        public void GetSolution_LineLengthDoesNotEqualNine_ExceptionIsThrown()
        {
            string inputLine = "1234";
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new OneLineSudoku();
                sut.GetSolution(inputLine);
            });
        }

        [Test]
        public void GetSolution_LineDoesNotContainQuestionMark_ExceptionIsThrown()
        {
            string inputLine = "123456789";
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new OneLineSudoku();
                sut.GetSolution(inputLine);
            });
        }

        [Test]
        public void GetSolution_LineDoesNotContainEightNumbers_ExceptionIsThrown()
        {
            string inputLine = "1?34?6789";
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new OneLineSudoku();
                sut.GetSolution(inputLine);
            });
        }
    }
}