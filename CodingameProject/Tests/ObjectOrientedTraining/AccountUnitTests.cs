using System;
using CodingameProject.Source.ObjectOrientedTraining;
using Moq;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    class AccountUnitTests
    {
        private Account sut;
        private Mock<IAccountState> mState;

        private void DoUnfreezeAction(string message)
        {
            Console.WriteLine(message);
        }

        [SetUp]
        public void SetUp()
        {
            mState = new Mock<IAccountState>();
            sut = new Account(DoUnfreezeAction, mState.Object);
        }

        [TearDown]
        public void TearDown()
        {
            sut = null;
        }

        [Test]
        public void Test_Deposit_DepositOnStateIsCalled()
        {
            sut.Deposit(10);
            mState.Verify(x => x.Deposit(It.IsAny<Action>()), Times.Once);
        }

        [Test]
        public void Test_Withdraw_WithdrawOnStateIsCalled()
        {
            sut.Withdraw(10);
            mState.Verify(x => x.Withdraw(It.IsAny<Action>()), Times.Once);
        }

        [Test]
        public void Test_Freeze_FreezeOnStateIsCalled()
        {
            sut.Freeze();
            mState.Verify(x => x.Freeze(), Times.Once);
        }

        [Test]
        public void Test_Close_CloseOnStateIsCalled()
        {
            sut.Close();
            mState.Verify(x => x.Close(), Times.Once);
        }

        [Test]
        public void Test_Verify_VerifyOnStateIsCalled()
        {
            sut.Verify();
            mState.Verify(x => x.Verify(), Times.Once);
        }
    }
}