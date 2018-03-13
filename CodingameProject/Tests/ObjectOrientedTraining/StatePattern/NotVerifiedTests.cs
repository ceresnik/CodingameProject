using System;
using CodingameProject.Source.ObjectOrientedTraining.StatePattern;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.StatePattern
{
    [TestFixture]
    public class NotVerifiedTests
    {
        private NotVerified sut;
        private bool addedToBalance;
        private bool removedFromBalance;

        [SetUp]
        public void SetUp()
        {
            sut = new NotVerified(Console.WriteLine);
        }

        [TearDown]
        public void TearDown()
        {
            addedToBalance = false;
        }

        [Test]
        public void Test_Deposit_ReturnsNotVerified()
        {
            var result = sut.Deposit(AddToBalance);
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Deposit_AddToBalanceWasCalled()
        {
            sut.Deposit(AddToBalance);
            Assert.That(addedToBalance, Is.True);
        }

        [Test]
        public void Test_Withdraw_ReturnsNotVerified()
        {
            var result = sut.Withdraw(RemoveFromBalance);
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Withdraw_NotRemovedFromBalance()
        {
            sut.Withdraw(RemoveFromBalance);
            Assert.That(removedFromBalance, Is.False);
        }

        [Test]
        public void Test_Freeze_ReturnsNotVerified()
        {
            var result = sut.Freeze();
            Assert.That(result, Is.EqualTo(sut));
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