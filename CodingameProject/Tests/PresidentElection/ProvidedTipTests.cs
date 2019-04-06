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
            var candidateOnSecondPosition = "name2";
            var candidateOnThirdPosition = "name3";
            var firstPositionPercent = 11;
            var secondPositionPercent = 12;
            var thirdPositionPercent = 13;

            //act
            var tips = new CandidateNameElectionGainPairs();
            var theFirstPlaceTip = new CandidateNameElectionGainPair(candidateOnFirstPosition, firstPositionPercent);
            var theSecondPlaceTip = new CandidateNameElectionGainPair(candidateOnSecondPosition, secondPositionPercent);
            var theThirdPlaceTip = new CandidateNameElectionGainPair(candidateOnThirdPosition, thirdPositionPercent);
            tips.Add(theFirstPlaceTip);
            tips.Add(theSecondPlaceTip);
            tips.Add(theThirdPlaceTip);
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.TipperName, Is.EqualTo(tipperName), "Tipper name is not as expected.");
            Assert.That(sut.CandidateOnFirstPosition, Is.EqualTo(candidateOnFirstPosition), 
                "Candidate on first position not as expected.");
            Assert.That(sut.CandidateOnSecondPosition, Is.EqualTo(candidateOnSecondPosition),
                "Candidate on second position not as expected.");
            Assert.That(sut.CandidateOnThirdPosition, Is.EqualTo(candidateOnThirdPosition),
                "Candidate on third position not as expected.");
            Assert.That(sut.CandidateOnFirstPositionPercent, Is.EqualTo(firstPositionPercent),
                "Candidate on first position percent not as expected.");
            Assert.That(sut.CandidateOnSecondPositionPercent, Is.EqualTo(secondPositionPercent),
                "Candidate on second position percent not as expected.");
            Assert.That(sut.CandidateOnThirdPositionPercent, Is.EqualTo(thirdPositionPercent),
                "Candidate on third position percent not as expected.");
        }
    }
}