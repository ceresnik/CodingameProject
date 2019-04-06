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
        [Test]
        public void GetEnumerator_DoesNotThrowException()
        {
            //prepare
            var sut = new ElectionResults();

            //assert
            Assert.IsFalse(sut.Any());
        }

        [Test]
        public void Read_ReturnsInstanceOfIList()
        {
            //prepare
            var sut = new ElectionResults();

            //assert
            Assert.That(sut, Is.InstanceOf(typeof(IList)));
            Assert.That(sut, Is.InstanceOf<IList>());
            Assert.IsInstanceOf<IList>(sut);
        }

        [Test]
        public void Read_ReturnsInstanceOfListOfElectionResult()
        {
            //prepare
            var sut = new ElectionResults();

            //assert
            Assert.That(sut, Is.InstanceOf(typeof(List<ElectionResult>)));
            Assert.That(sut, Is.InstanceOf<List<ElectionResult>>());
            Assert.IsInstanceOf<List<ElectionResult>>(sut);
        }
    }
}