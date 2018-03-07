using System;
using CodingameProject.Source.ObjectOrientedTraining;
using Moq;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    class AccountTests
    {
        private Account sut;
        private bool unfreezingWasTriggered;
        private IAccountState mState;

        private void DoUnfreezeAction(string message)
        {
            unfreezingWasTriggered = true;
            Console.WriteLine(message);
        }

        [SetUp]
        public void SetUp()
        {
            //mState = new Mock<IAccountState>().Object;
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
            Assert.That(sut.State, Is.TypeOf<NotVerified>());
        }

        [Test]
        public void Deposit_StateIsNotVerified()
        {
            sut.Deposit(10);
            Assert.That(sut.State, Is.TypeOf<NotVerified>());
        }

        [Test]
        public void DepositToVerified_StateIsActive()
        {
            sut.Verify();
            sut.Deposit(10);
            Assert.That(sut.State, Is.TypeOf<Active>());
        }

        [Test]
        public void DepositToClosed_StateIsClosed()
        {
            sut.Close();
            sut.Deposit(10);
            Assert.That(sut.State, Is.TypeOf<Closed>());
        }

        [Test]
        public void DepositToVerifiedAndFrozen_StateIsActive()
        {
            sut.Verify();
            sut.Freeze();
            sut.Deposit(10);
            Assert.That(sut.State, Is.TypeOf<Active>());
        }

        [Test]
        public void Withdraw_StateIsNotVerified()
        {
            sut.Withdraw(1);
            Assert.That(sut.State, Is.TypeOf<NotVerified>());
        }

        [Test]
        public void WithDrawFromVerified_StateIsActive()
        {
            sut.Verify();
            sut.Withdraw(1);
            Assert.That(sut.State, Is.TypeOf<Active>());
        }

        [Test]
        public void Verify_StateIsActive()
        {
            sut.Verify();
            Assert.That(sut.State, Is.TypeOf<Active>());
        }

        [Test]
        public void Close_StateIsClosed()
        {
            sut.Close();
            Assert.That(sut.State, Is.TypeOf<Closed>());
        }

        [Test]
        public void Id1_Test_DepositToClosedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Close();
            sut.Deposit(30);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Id2_Test_Deposit()
        {
            sut.Deposit(10);
            sut.Deposit(1);
            Assert.That(sut.Balance, Is.EqualTo(11));
        }

        [Test]
        public void Id3_Test_WithdrawFromNotVerifiedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Id4_Test_WithdrawFromClosedAccount_NoChange()
        {
            sut.Deposit(20);
            sut.Verify();
            sut.Close();
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(20));
        }

        [Test]
        public void Id5_Test_Withdraw()
        {
            sut.Deposit(10);
            sut.Verify();
            sut.Withdraw(1);
            Assert.That(sut.Balance, Is.EqualTo(9));
        }

        [Test]
        public void Id8_Test_DepositToNotFrozenAccount_DoesNotTriggerAction()
        {
            sut.Deposit(10);
            Assert.That(unfreezingWasTriggered, Is.EqualTo(false));
        }

        [Test]
        public void Id10_Test_WithdrawFromFreezedAccount_Withdrawn()
        {
            sut.Deposit(30);
            sut.Verify();
            sut.Freeze();
            sut.Withdraw(20);
            Assert.That(sut.Balance, Is.EqualTo(10));
        }

        [Test]
        public void Id11_Test_WithdrawFromNotFrozenAccount_DoesNotTriggerAction()
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

        [Test]
        public void Test_Deposit_DepositOnStateIsCalled()
        {
            sut.Deposit(10);
            //mState.Verify(x => x.Deposit(It.IsAny<Action>()), Times.Once);
        }
    }
}