/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using CodingameProject.Source.ObjectOrientedTraining;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    [TestFixture]
    public class FrozenTests
    {
        private IAccountState sut;
        private bool unfreezingWasTriggered;
        private bool addedToBalance;
        private bool removedFromBalance;

        private void DoUnfreezeAction(string message)
        {
            unfreezingWasTriggered = true;
            Console.WriteLine(message);
        }

        [SetUp]
        public void SetUp()
        {
            sut = new Frozen(DoUnfreezeAction);
            addedToBalance = false;
        }

        [TearDown]
        public void TearDown()
        {
            unfreezingWasTriggered = false;
            addedToBalance = false;
        }

        [Test]
        public void Test_Deposit_ReturnsActive()
        {
            var result = sut.Deposit(AddToBalance);
            Assert.That(result, Is.TypeOf<Active>());
        }

        [Test]
        public void Test_Deposit_AddToBalanceWasCalled()
        {
            sut.Deposit(AddToBalance);
            Assert.That(addedToBalance, Is.True);
        }

        [Test]
        public void Test_Withdraw_ReturnsActive()
        {
            var result = sut.Withdraw(RemoveFromBalance);
            Assert.That(result, Is.TypeOf<Active>());
        }

        [Test]
        public void Test_Withdraw_RemoveFromBalanceWasCalled()
        {
            sut.Withdraw(RemoveFromBalance);
            Assert.That(removedFromBalance, Is.True);
        }

        [Test]
        public void Test_Freeze_ReturnsFrozen()
        {
            var result = sut.Freeze();
            Assert.That(result, Is.TypeOf<Frozen>());
        }

        [Test]
        public void Test_Close_ReturnsClosed()
        {
            var result = sut.Close();
            Assert.That(result, Is.TypeOf<Closed>());
        }

        [Test]
        public void Test_Verify_ReturnsActive()
        {
            var result = sut.Verify();
            Assert.That(result, Is.TypeOf<Active>());
        }

        [Test]
        public void Id6_Test_DepositToFreezedAccountTriggersAction()
        {
            sut.Deposit(AddToBalance);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(true));
        }

        [Test]
        public void Id9_Test_WithdrawFromFreezedAccountTriggersAction()
        {
            sut.Deposit(AddToBalance);
            sut.Withdraw(RemoveFromBalance);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(true));
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