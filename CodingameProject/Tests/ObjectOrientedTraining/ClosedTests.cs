/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using CodingameProject.Source.ObjectOrientedTraining;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    [TestFixture]
    public class ClosedTests
    {
        private Closed sut;
        private bool addedToBalance;
        private bool removedFromBalance;

        [SetUp]
        public void SetUp()
        {
            sut = new Closed();
        }

        [TearDown]
        public void TearDown()
        {
            addedToBalance = false;
        }

        [Test]
        public void Test_Deposit_ReturnsClosed()
        {
            var result = sut.Deposit(AddToBalance);
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Deposit_AddToBalanceWasNotCalled()
        {
            sut.Deposit(AddToBalance);
            Assert.That(addedToBalance, Is.False);
        }

        [Test]
        public void Test_Withdraw_ReturnsClosed()
        {
            var result = sut.Withdraw(RemoveFromBalance);
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
            Assert.That(result, Is.EqualTo(sut));
        }

        private void AddToBalance()
        {
            addedToBalance = true;
        }

        private void RemoveFromBalance()
        {
            removedFromBalance = true;
        }

    }
}