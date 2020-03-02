using System;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ProvidedTipTests
    {
        private string tipperName;
        private string candidateOnFirstPosition;
        private string candidateOnSecondPosition;
        private string candidateOnThirdPosition;
        private double firstPositionPercent;
        private double secondPositionPercent;
        private double thirdPositionPercent;
        private CandidateNameElectionGainPair theFirstPlaceTip;
        private CandidateNameElectionGainPair theSecondPlaceTip;
        private CandidateNameElectionGainPair theThirdPlaceTip;
        private CandidateNameElectionGainPair theFourthPlaceTip;
        private CandidateNameElectionGainPair theFifthPlaceTip;
        private CandidateNameElectionGainPair theSixthPlaceTip;

        [SetUp]
        public void SetUp()
        {
            tipperName = "TipperName1";
            candidateOnFirstPosition = "name1";
            candidateOnSecondPosition = "name2";
            candidateOnThirdPosition = "name3";
            firstPositionPercent = 11;
            secondPositionPercent = 12;
            thirdPositionPercent = 13;
            theFirstPlaceTip = new CandidateNameElectionGainPair(candidateOnFirstPosition, firstPositionPercent);
            theSecondPlaceTip = new CandidateNameElectionGainPair(candidateOnSecondPosition, secondPositionPercent);
            theThirdPlaceTip = new CandidateNameElectionGainPair(candidateOnThirdPosition, thirdPositionPercent);
        }

        [Test]
        public void ProvidedTipObject_InitializedCorrectly()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs {theFirstPlaceTip, theSecondPlaceTip, theThirdPlaceTip};

            //act
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.TipperName, Is.EqualTo(tipperName), "Tipper name is not as expected.");
            Assert.That(sut.Tips[0].CandidateName, Is.EqualTo(candidateOnFirstPosition), 
                "Candidate on first position not as expected.");
            Assert.That(sut.Tips[1].CandidateName, Is.EqualTo(candidateOnSecondPosition),
                "Candidate on second position not as expected.");
            Assert.That(sut.Tips[2].CandidateName, Is.EqualTo(candidateOnThirdPosition),
                "Candidate on third position not as expected.");
            Assert.That(sut.Tips[0].ElectionGainInPercent, Is.EqualTo(firstPositionPercent),
                "Candidate on first position percent not as expected.");
            Assert.That(sut.Tips[1].ElectionGainInPercent, Is.EqualTo(secondPositionPercent),
                "Candidate on second position percent not as expected.");
            Assert.That(sut.Tips[2].ElectionGainInPercent, Is.EqualTo(thirdPositionPercent),
                "Candidate on third position percent not as expected.");
        }

        [Test]
        public void MaximumSixTipsAllowed()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs
            {
                theFirstPlaceTip,
                theSecondPlaceTip,
                theThirdPlaceTip,
                theFourthPlaceTip,
                theFifthPlaceTip,
                theSixthPlaceTip,
                new CandidateNameElectionGainPair("FourthCandidate", 10.0)
            };

            //act
            Assert.Throws<ArgumentException>(() => new ProvidedTip(tipperName, tips));
        }
    }
}