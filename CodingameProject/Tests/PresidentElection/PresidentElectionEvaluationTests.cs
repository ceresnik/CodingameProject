using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class PresidentElectionEvaluationTests
    {
        private string electionResultsFile;
        private string providedTipsFile;

        [SetUp]
        public void SetUp()
        {
            electionResultsFile = FilePathProvider.ProvideFullPathToFile("TestResults.json", @"Tests\PresidentElection");
            providedTipsFile = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");
        }

        [TearDown]
        public void TearDown()
        {
            electionResultsFile = null;
            providedTipsFile = null;
        }

        [Test]
        public void PresidentElectionEvaluationObject_InitializedCorrectly()
        {
            //act
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //verify
            Assert.That(sut.ElectionResultsFile, Is.EqualTo(electionResultsFile));
            Assert.That(sut.ProvidedTipsFile, Is.EqualTo(providedTipsFile));
        }

        [Test]
        public void CountScore_ReturnsTypeOfEvaluatedTips()
        {
            //prepare
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore();

            //verify
            Assert.That(result, Is.TypeOf<EvaluatedTips>());
        }

        [Test]
        public void CountScore_CountOfEvaluatedTips()
        {
            //prepare
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore();

            //verify
            Assert.That(result.Count, Is.EqualTo(2), "Count of evaluated tips must fit the count of provided tips.");
        }
    }
}