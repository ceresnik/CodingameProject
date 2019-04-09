using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    internal class CandidateNameElectionGainPairTests
    {
        [Test]
        public void CandidateNameElectionGainPairObject_InitializedCorrectly()
        {
            //prepare
            string candidateName = "TestCandidateName";
            double electionGainInPercent = 10.5;

            //act
            var sut = new CandidateNameElectionGainPair(candidateName, electionGainInPercent);

            //assert
            Assert.That(sut.CandidateName, Is.EqualTo(candidateName), 
                "Candidate name is not as expected.");
            Assert.That(sut.ElectionGainInPercent, Is.EqualTo(electionGainInPercent), 
                "Candidate result in percent is not as expected.");
        }
    }
}