using CodingameProject.Source.PresidentElection;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ProvidedTipTests
    {
        [Test]
        public void ProvidedTipObject_InitializedCorrectly()
        {
            //prepare

            //act
            var tipperName = "TipperName1";
            var candidateOnFirstPosition = "CandidateOnFirstPosition";
            var candidateOnFirstPositionPercent = 9.5;
            var sut = new ProvidedTip(tipperName, candidateOnFirstPosition, candidateOnFirstPositionPercent);

            //assert
            Assert.That(sut.TipperName, Is.EqualTo(tipperName), "Tipper name is not as expected.");
            Assert.That(sut.CandidateOnFirstPosition, Is.EqualTo(candidateOnFirstPosition), 
                "Candidate on first position not as expected.");
            Assert.That(sut.CandidateOnFirstPositionPercent, Is.EqualTo(candidateOnFirstPositionPercent),
                "Candidate on first position percent not as expected.");
        }
    }
}