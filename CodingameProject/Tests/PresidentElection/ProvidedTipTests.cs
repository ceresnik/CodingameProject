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

        [Test]
        public void NoTipsProvided_CandidateOnFirstPositionNameIsEmptyString()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs();

            //act
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.CandidateOnFirstPosition, Is.EqualTo(string.Empty),
                "When no tip is provided, candidate name on first position must be empty string.");
        }

        [Test]
        public void JustOneTipProvided_CandidateOnSecondPositionNameIsEmptyString()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs {theFirstPlaceTip};

            //act
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.CandidateOnSecondPosition, Is.EqualTo(string.Empty), 
                "When just one tip is provided, candidate name on second position must be empty string.");
        }

        [Test]
        public void JustTwoTipsProvided_CandidateOnThirdPositionNameIsEmptyString()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs { theFirstPlaceTip, theSecondPlaceTip };

            //act
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.CandidateOnThirdPosition, Is.EqualTo(string.Empty),
                "When just two tips are provided, candidate name on third position must be empty string.");
        }

        [Test]
        public void NoTipProvided_CandidateOnFirstPositionPercentIsZero()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs();

            //act
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.CandidateOnFirstPositionPercent, Is.EqualTo(0),
                "When no tip is provided, candidate on first position percent must be 0.");
        }

        [Test]
        public void JustOneTipProvided_CandidateOnSecondPositionPercentIsZero()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs { theFirstPlaceTip };

            //act
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.CandidateOnSecondPositionPercent, Is.EqualTo(0),
                "When just one tip is provided, candidate on second position percent must be 0.");
        }

        [Test]
        public void JustTwoTipsProvided_CandidateOnThirdPositionPercentIsZero()
        {
            //prepare
            var tips = new CandidateNameElectionGainPairs { theFirstPlaceTip, theSecondPlaceTip };

            //act
            var sut = new ProvidedTip(tipperName, tips);

            //assert
            Assert.That(sut.CandidateOnThirdPositionPercent, Is.EqualTo(0),
                "When just two tips are provided, candidate on third position percent must be 0.");
        }
    }
}