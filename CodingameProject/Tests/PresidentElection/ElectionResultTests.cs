using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    internal class ElectionResultTests
    {
        [Test]
        public void ElectionResultObject_InitializedCorrectly()
        {
            //prepare
            string candidateName = "TestCandidateName";
            double resultInPercent = 10.5;

            //act
            var sut = new ElectionResult(candidateName, resultInPercent);

            //assert
            Assert.That(sut.CandidateName, Is.EqualTo(candidateName), 
                "Candidate name is not as expected.");
            Assert.That(sut.ResultInPercent, Is.EqualTo(resultInPercent), 
                "Candidate result in percent is not as expected.");
        }
    }
}