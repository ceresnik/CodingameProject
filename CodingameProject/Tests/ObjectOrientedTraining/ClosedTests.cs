/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using CodingameProject.Source.ObjectOrientedTraining;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    [TestFixture]
    public class ClosedTests
    {
        private Closed sut;

        [SetUp]
        public void SetUp()
        {
            sut = new Closed(Console.WriteLine);
        }

        [Test]
        public void Test_Deposit_ReturnsClosed()
        {
            var result = sut.Deposit();
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Withdraw_ReturnsClosed()
        {
            var result = sut.Withdraw();
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Freeze_ReturnsClosed()
        {
            var result = sut.Freeze();
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Close_ReturnsClosed()
        {
            var result = sut.Close();
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Verify_ReturnsActive()
        {
            var result = sut.Verify();
            Assert.That(result, Is.TypeOf<Active>());
        }
    }
}