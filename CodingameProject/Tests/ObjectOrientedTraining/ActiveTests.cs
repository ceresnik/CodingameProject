using System;
using CodingameProject.Source.ObjectOrientedTraining;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    [TestFixture]
    public class ActiveTests
    {
        private IAccountState sut;
        private bool addedToBalance;
        private bool removedFromBalance;

        [SetUp]
        public void SetUp()
        {
            this.sut = new Active(Console.WriteLine);
        }

        [TearDown]
        public void TearDown()
        {
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
        public void Test_Close_ReturnsClosed()
        {
            var result = sut.Close();
            Assert.That(result, Is.TypeOf<Closed>());
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