using System;
using CodingameProject.Source.ObjectOrientedTraining;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    class AccountTests
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
        public void Constructor_NotVerifiedStateIsCreated()
        {
            Assert.That(sut.AccountState, Is.TypeOf<NotVerified>());
        }

        [Test]
        public void Deposit_StateIsNotVerified()
        {
            sut.Deposit(10);
            Assert.That(sut.AccountState, Is.TypeOf<NotVerified>());
        }

        [Test]
        public void WithDraw_StateIsNotVerified()
        {
            sut.Deposit(10);
            sut.Withdraw(1);
            Assert.That(sut.AccountState, Is.TypeOf<NotVerified>());
        }

        [Test]
        public void Verify_StateIsActive()
        {
            sut.Verify();
            Assert.That(sut.AccountState, Is.TypeOf<Active>());
        }

        [Test]
        public void Close_StateIsClosed()
        {
            sut.Close();
            Assert.That(sut.AccountState, Is.TypeOf<Closed>());
        }

        [Test]
        public void Number1_Test_DepositToClosedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Close();
            sut.Deposit(30);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Number2_Test_Deposit()
        {
            sut.Deposit(10);
            sut.Deposit(1);
            Assert.That(sut.Balance, Is.EqualTo(11));
        }

        [Test]
        public void Number3_Test_WithdrawFromNotVerifiedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Number4_Test_WithdrawFromClosedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Verify();
            sut.Close();
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Number5_Test_Withdraw()
        {
            sut.Deposit(10);
            sut.Verify();
            sut.Withdraw(1);
            Assert.That(sut.Balance, Is.EqualTo(9));
        }

        [Test]
        public void Number8_Test_DepositToNotFrozenAccount_DoesNotTriggerAction()
        {
            sut.Deposit(10);
            sut.Deposit(1);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(false));
        }

        [Test]
        public void Number10_Test_WithdrawFromFreezedAccount_Withdrawn()
        {
            sut.Deposit(30);
            sut.Verify();
            sut.Freeze();
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(10));
        }

        [Test]
        public void Number11_Test_WithdrawFromNotFrozenAccount_DoesNotTriggerAction()
        {
            sut.Deposit(10);
            sut.Verify();
            sut.Withdraw(1);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(false));
        }
    }
}