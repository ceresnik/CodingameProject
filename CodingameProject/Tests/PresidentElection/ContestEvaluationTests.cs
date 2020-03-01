using System;
using System.Linq;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ContestEvaluationTests
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
        public void ContestEvaluationObject_InitializedCorrectly()
        {
            //act
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //verify
            Assert.That(sut.ElectionResultsFileName, Is.EqualTo(electionResultsFile));
            Assert.That(sut.ProvidedTipsFileName, Is.EqualTo(providedTipsFile));
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

        [Test]
        public void CountScore_ResultContainsNameOfTipper()
        {
            //prepare
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore();

            //verify
            string expectedTipperNameOne = "Lubo";
            Assert.IsTrue(result.Any(x => x.TipperName.Equals(expectedTipperNameOne)), 
                $"Evaluated tips must contain a tip with TipperName {expectedTipperNameOne}.");
            string expectedTipperNameTwo = "Miso";
            Assert.IsTrue(result.Any(x => x.TipperName.Equals(expectedTipperNameTwo)), 
                $"Evaluated tips must contain a tip with TipperName {expectedTipperNameTwo}.");
        }

        [Test]
        public void CountScore_ResultDoesNotContainNotExistingTipperName()
        {
            //prepare
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore();

            //verify
            string notExistingTipperName = "NoSuchTipper";
            Assert.IsFalse(result.Any(x => x.TipperName.Equals(notExistingTipperName)),
                $"Evaluated tips must NOT contain a tip with TipperName {notExistingTipperName}.");
        }

        [Test]
        public void CountScore_ScoreIsCountedCorrectly()
        {
            //prepare
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore();

            //verify
            Assert.That(result[0].Score, Is.EqualTo(15), 
                $"Score for tipper '{result[0].TipperName}' not counted correctly.");
            Assert.That(result[1].Score, Is.EqualTo(-10),
                $"Score for tipper '{result[1].TipperName}' not counted correctly.");
        }

        [Test]
        public void CountScore_ResultsAreOrderedFromBestScore()
        {
            //prepare
            var sut = new ContestEvaluation(electionResultsFile, providedTipsFile);

            //act
            var result = sut.CountScore().OrderBy(x => x.Score).ToList();

            //verify
            Assert.That(result[0].Score, Is.EqualTo(-10),
                $"On first position must be tipper with best score.");
            Assert.That(result[1].Score, Is.EqualTo(15),
                $"On second position must be tipper with second best score.");
        }

        [Test]
        public void Count_RealResults_ForPresidentElection()
        {
            //prepare
            var realElectionResultsFile = FilePathProvider.ProvideFullPathToFile("ElectionResults.json", @"Source\PresidentElection");
            var realTipsFile = FilePathProvider.ProvideFullPathToFile("ElectionTips.json", @"Source\PresidentElection");
            var sut = new ContestEvaluation(realElectionResultsFile, realTipsFile);

            //act
            var result = sut.CountScore().OrderBy(x => x.Score).ToList();
            int i = 0;
            Console.WriteLine("{0} {1,5} {2,6}", "Place", "Name", "Score");
            Console.WriteLine("-------------------");
            foreach (var evaluatedTip in result)
            {
                Console.WriteLine($"{++i,3}. {evaluatedTip.TipperName,6} {evaluatedTip.Score, 6}");
            }
        }

        [Test]
        public void Count_RealResults_ForParliamentElections2020()
        {
            //prepare
            var realElectionResultsFile = FilePathProvider.ProvideFullPathToFile("ParliamentElections2020Results.json", @"Source\PresidentElection");
            var realTipsFile = FilePathProvider.ProvideFullPathToFile("ParliamentElections2020Tips.json", @"Source\PresidentElection");
            var sut = new ContestEvaluation(realElectionResultsFile, realTipsFile);

            //act
            var result = sut.CountScore().OrderBy(x => x.Score).ToList();
            int i = 0;
            Console.WriteLine("{0} {1,6} {2,7}", "Place", "Name", "Score");
            Console.WriteLine("--------------------");
            foreach (var evaluatedTip in result)
            {
                Console.WriteLine($"{++i,3}. {evaluatedTip.TipperName,7} {evaluatedTip.Score,7}");
            }
        }
    }
}