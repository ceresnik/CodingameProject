using System.Linq;
using Castle.Components.DictionaryAdapter.Xml;
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
        public void CountScore_NameOfTipperFits()
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
            string notExistingTipperName = "NoSuchTipper";
            Assert.IsFalse(result.Any(x => x.TipperName.Equals(notExistingTipperName)), 
                $"Evaluated tips must NOT contain a tip with TipperName {notExistingTipperName}.");
        }
    }
}