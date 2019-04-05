using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ElectionResultsTests
    {
        [Ignore("Current implementation does not implement IEnumerable.")]
        [Test]
        public void GetEnumerator_DoesNotThrowException()
        {
            //prepare
            var sut = new ElectionResults();

            //assert
            //Assert.That(sut.Any());
        }

        [Ignore("Current implementation does not implement IEnumerable.")]
        [Test]
        public void Read_ReturnsInstanceOfIEnumerable()
        {
            //prepare
            var sut = new ElectionResults();

            //assert
            Assert.That(sut, Is.InstanceOf(typeof(IEnumerable)));
            Assert.That(sut, Is.InstanceOf<IEnumerable>());
            Assert.IsInstanceOf<IEnumerable>(sut);
        }

        [Ignore("Current implementation does not implement IEnumerable.")]
        [Test]
        public void Read_ReturnsInstanceOfIEnumerableOfElectionResult()
        {
            //prepare
            var sut = new ElectionResults();

            //assert
            Assert.That(sut, Is.InstanceOf(typeof(IEnumerable<ElectionResult>)));
            Assert.That(sut, Is.InstanceOf<IEnumerable<ElectionResult>>());
            Assert.IsInstanceOf<IEnumerable<ElectionResult>>(sut);
        }
    }
}