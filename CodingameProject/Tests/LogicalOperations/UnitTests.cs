/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using CodingameProject.Source.LogicalOperations;
using NUnit.Framework;

namespace CodingameProject.Tests.LogicalOperations
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase("0001010", "0101010", "0101010")]
        [TestCase("1101010", "0101010", "1101010")]
        [TestCase("1101010", "0000000", "1101010")]
        [TestCase("1111111", "0000000", "1111111")]
        [TestCase("1101010", "1111111", "1111111")]
        [Test]
        public void Test_DoLogicalOr_ObjectOriented(string input1, string input2, string expected)
        {
            string result = new LogicalOperation(input1).Or(input2).Result;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Or_InputIsNull_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => { new LogicalOperation(null); });
        }

        [Test]
        public void Or_OperandIsNull_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => { new LogicalOperation("Test").Or(null); });
        }

        [Test]
        public void Or_OperandsWithDifferentLength_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => { new LogicalOperation("Test").Or("Invalid"); });
        }

        [TestCase("0001010", "0101010", "0001010")]
        [TestCase("1101010", "0101010", "0101010")]
        [TestCase("0001010", "1111111", "0001010")]
        [TestCase("0001010", "0000000", "0000000")]
        [Test]
        public void Test_DoLogicalAnd_ObjectOriented(string input1, string input2, string expected)
        {
            string result = new LogicalOperation(input1).And(input2).Result;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void And_OperandIsNull_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => { new LogicalOperation("Test").And(null); });
        }

        [Test]
        public void And_OperandsWithDifferentLength_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => { new LogicalOperation("Test").And("Invalid"); });
        }

        [Test]
        public void Or_ThreeOperands()
        {
            string result = new LogicalOperation("110").Or("010").Or("101").Result;
            Assert.That(result, Is.EqualTo("111"));
        }

        [Test]
        public void And_ThreeOperands()
        {
            string result = new LogicalOperation("110").And("010").And("101").Result;
            Assert.That(result, Is.EqualTo("000"));
        }

        [Test]
        public void OrAnd_ThreeOperands()
        {
            string result = new LogicalOperation("110").Or("010").And("101").Result;
            Assert.That(result, Is.EqualTo("100"));
        }

        [Test]
        public void AndOr_ThreeOperands()
        {
            string result = new LogicalOperation("110").And("010").Or("101").Result;
            Assert.That(result, Is.EqualTo("111"));
        }

        [Test]
        public void FiveOperands()
        {
            string result = new LogicalOperation("110").Or("010").And("101").Or("101").And("001").Result;
            Assert.That(result, Is.EqualTo("001"));
        }
    }
}