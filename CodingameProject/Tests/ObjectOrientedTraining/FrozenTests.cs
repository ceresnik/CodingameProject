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

        private void DoUnfreezeAction(string message)
        {
            unfreezingWasTriggered = true;
            Console.WriteLine(message);
        }

        [SetUp]
        public void SetUp()
        {
            this.sut = new Frozen(DoUnfreezeAction);
        }

        [TearDown]
        public void TearDown()
        {
            unfreezingWasTriggered = false;
        }

        [Test]
        public void Test_Deposit_ReturnsActive()
        {
            var result = sut.Deposit();
            Assert.That(result, Is.TypeOf<Active>());
        }

        [Test]
        public void Test_Withdraw_ReturnsActive()
        {
            var result = sut.Withdraw();
            Assert.That(result, Is.TypeOf<Active>());
        }

        [Test]
        public void Test_Freeze_ReturnsFrozen()
        {
            var result = sut.Freeze();
            Assert.That(result, Is.TypeOf<Frozen>());
        }

        [Test]
        public void Test_Verify_ReturnsActive()
        {
            var result = sut.Verify();
            Assert.That(result, Is.TypeOf<Active>());
        }

        [Test]
        public void Number6_Test_DepositToFreezedAccountTriggersAction()
        {
            sut.Deposit();
            Assert.That(unfreezingWasTriggered, Is.EqualTo(true));
        }

        [Test]
        public void Number9_Test_WithdrawFromFreezedAccountTriggersAction()
        {
            sut.Deposit();
            sut.Withdraw();
            Assert.That(unfreezingWasTriggered, Is.EqualTo(true));
        }

        [Test]
        public void Test_WithdrawTwoTimesFromFreezedAccount_TriggersOnlyOneAction()
        {
            sut.Deposit();
            sut = sut.Withdraw();
            unfreezingWasTriggered = false;
            sut.Withdraw();
            Assert.That(unfreezingWasTriggered, Is.EqualTo(false));
        }
    }
}