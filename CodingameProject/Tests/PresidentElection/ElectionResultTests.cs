using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    internal class ElectionResultTests
    {
        [Test]
        public void ElectionResultObject_InitializedCorrectly()
        {
            string candidateName = "TestCandidateName";
            double resultInPercent = 10.5;
            var sut = new ElectionResult(candidateName, resultInPercent);
            Assert.That(sut.CandidateName, Is.EqualTo(candidateName), 
                "Candidate name is not as expected.");
            Assert.That(sut.ResultInPercent, Is.EqualTo(resultInPercent), 
                "Candidate result in percent is not as expected.");
        }
    }
}