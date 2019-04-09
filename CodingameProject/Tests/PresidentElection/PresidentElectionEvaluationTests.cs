using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class PresidentElectionEvaluationTests
    {
        [Test]
        public void PresidentElectionEvaluationObject_InitializedCorrectly()
        {
            //prepare
            string electionResultsFile = FilePathProvider.ProvideFullPathToFile("TestResults.json", @"Tests\PresidentElection");
            string providedTipsFile = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");

            //act
            var sut = new PresidentElectionEvaluation(electionResultsFile, providedTipsFile);

            //verify
            Assert.That(sut.ElectionResultsFile, Is.EqualTo(electionResultsFile));
            Assert.That(sut.ProvidedTipsFile, Is.EqualTo(providedTipsFile));
        }

        [Test]
        public void CountScore_ReturnsTypeOfEvaluatedTips()
        {
            //prepare
            string electionResultsFile = FilePathProvider.ProvideFullPathToFile("TestResults.json", @"Tests\PresidentElection");
            string providedTipsFile = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");
            var sut = new PresidentElectionEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore();

            //verify
            Assert.That(result, Is.TypeOf<EvaluatedTips>());
        }

        [Test]
        public void CountScore_CountOfEvaluatedTips()
        {
            //prepare
            string electionResultsFile = FilePathProvider.ProvideFullPathToFile("TestResults.json", @"Tests\PresidentElection");
            string providedTipsFile = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");
            var sut = new PresidentElectionEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore();

            //verify
            Assert.That(result.Count, Is.EqualTo(2), "Count of evaluated tips must fit the count of provided tips.");
        }
    }
}