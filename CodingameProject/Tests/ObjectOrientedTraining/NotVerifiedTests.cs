using System;
using CodingameProject.Source.ObjectOrientedTraining;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining
{
    [TestFixture]
    public class NotVerifiedTests
    {
        private NotVerified sut;

        [SetUp]
        public void SetUp()
        {
            sut = new NotVerified(Console.WriteLine);
        }

        [Test]
        public void Test_Deposit_ReturnsNotVerified()
        {
            var result = sut.Deposit();
            Assert.That(result, Is.EqualTo(sut));
        }

        [Test]
        public void Test_Withdraw_ReturnsNotVerified()
        {
            var result = sut.Withdraw();
            Assert.That(result, Is.EqualTo(sut));
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
    }
}