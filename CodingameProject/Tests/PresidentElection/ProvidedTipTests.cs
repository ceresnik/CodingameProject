using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ProvidedTipTests
    {
        [Test]
        public void ProvidedTipObject_InitializedCorrectly()
        {
            //prepare
            var tipperName = "TipperName1";
            var candidateOnFirstPosition = "name1";
            var candidateOnFirstPositionPercent = 11;

            //act
            CandidateNameElectionGainPairs tips = new CandidateNameElectionGainPairs();
            CandidateNameElectionGainPair theFirstPlaceTip = new CandidateNameElectionGainPair(
                candidateOnFirstPosition, candidateOnFirstPositionPercent);
            CandidateNameElectionGainPair theSecondPlaceTip = new CandidateNameElectionGainPair("name2", 12);
            CandidateNameElectionGainPair theThirdPlaceTip = new CandidateNameElectionGainPair("name3", 13);
            tips.Add(theFirstPlaceTip);
            tips.Add(theSecondPlaceTip);
            tips.Add(theThirdPlaceTip);
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.TipperName, Is.EqualTo(tipperName), "Tipper name is not as expected.");
            Assert.That(sut.CandidateOnFirstPosition, Is.EqualTo(candidateOnFirstPosition), 
                "Candidate on first position not as expected.");
            Assert.That(sut.CandidateOnFirstPositionPercent, Is.EqualTo(candidateOnFirstPositionPercent),
                "Candidate on first position percent not as expected.");
        }
    }
}