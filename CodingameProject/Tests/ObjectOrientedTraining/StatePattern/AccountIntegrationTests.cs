using System;
using CodingameProject.Source.ObjectOrientedTraining.StatePattern;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.StatePattern
{
    [TestFixture]
    public class AccountIntegrationTests
    {
        private Account sut;
        private bool unfreezingWasTriggered;

        private void DoUnfreezeAction(string message)
        {
            unfreezingWasTriggered = true;
            Console.WriteLine(message);
        }

        [SetUp]
        public void SetUp()
        {
            sut = new Account(DoUnfreezeAction);
        }

        [TearDown]
        public void TearDown()
        {
            unfreezingWasTriggered = false;
            sut = null;
        }

        [Test]
        public void Id1_DepositToClosedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Close();
            sut.Deposit(30);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }
        [Test]
        public void Id2_Deposit()
        {
            sut.Deposit(10);
            sut.Deposit(1);
            Assert.That(sut.Balance, Is.EqualTo(11));
        }

        [Test]
        public void Id3_WithdrawFromNotVerifiedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Id4_WithdrawFromClosedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Verify();
            sut.Close();
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Id5_Withdraw()
        {
            sut.Deposit(10);
            sut.Verify();
            sut.Withdraw(1);
            Assert.That(sut.Balance, Is.EqualTo(9));
        }

        [Test]
        public void Id8_DepositToNotFrozenAccount_DoesNotTriggerAction()
        {
            sut.Deposit(10);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(false));
        }

        [Test]
        public void Id10_WithdrawFromFreezedAccount_Withdrawn()
        {
            sut.Deposit(30);
            sut.Verify();
            sut.Freeze();
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(10));
        }

        [Test]
        public void Id11_WithdrawFromNotFrozenAccount_DoesNotTriggerAction()
        {
            sut.Deposit(10);
            sut.Verify();
            sut.Withdraw(1);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(false));
        }

        [Test]
        public void Test_DepositToFrozenAccount_TriggersAction()
        {
            sut.Verify();
            sut.Freeze();
            sut.Deposit(10);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(true));
        }
    }
}