using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class CandidateNameElectionGainPairsTests
    {
        [Test]
        public void GetEnumerator_DoesNotThrowException()
        {
            //prepare
            var sut = new CandidateNameElectionGainPairs();

            //assert
            Assert.IsFalse(sut.Any());
        }

        [Test]
        public void ReturnsInstanceOfIList()
        {
            //prepare
            var sut = new CandidateNameElectionGainPairs();

            //assert
            Assert.That(sut, Is.InstanceOf(typeof(IList)));
            Assert.That(sut, Is.InstanceOf<IList>());
            Assert.IsInstanceOf<IList>(sut);
        }

        [Test]
        public void ReturnsInstanceOfListOfElectionResult()
        {
            //prepare
            var sut = new CandidateNameElectionGainPairs();

            //assert
            Assert.That(sut, Is.InstanceOf(typeof(List<CandidateNameElectionGainPair>)));
            Assert.That(sut, Is.InstanceOf<List<CandidateNameElectionGainPair>>());
            Assert.IsInstanceOf<List<CandidateNameElectionGainPair>>(sut);
        }
    }
}