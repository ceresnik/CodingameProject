using System;
using System.IO;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ProvidedTipsReaderTests
    {
        [Test]
        public void ProvidedTipsReaderObject_InitializedCorrectly()
        {
            //prepare
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");

            //act
            var sut = new ProvidedTipsReader(inputFileName);
            Console.Error.WriteLine($"Full file name: {sut.InputFileName}");

            //verify
            Assert.That(sut.InputFileName, Is.EqualTo(inputFileName));
        }

        [Test]
        public void InputFileDoesNotExist_ExceptionIsThrown()
        {
            var notExistingFile = "NotExistingFile.json";
            Assert.Throws<FileNotFoundException>(() => { new ProvidedTipsReader(notExistingFile); });
        }

        [Test]
        public void Read_ReturnsProvidedTipsObject()
        {
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips, Is.InstanceOf<ProvidedTips>());
        }

        [Test]
        public void Read_ReturnedTwoProvidedTips()
        {
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips.Count, Is.EqualTo(2));
        }

        [Test]
        public void Read_ReadoutValuesFitWithValuesInFile_Tip1()
        {
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips[0].TipperName, Is.EqualTo("Lubo"));
            Assert.That(providedTips[0].CandidateOnFirstPosition, Is.EqualTo("TestCandidate1"));
            Assert.That(providedTips[0].CandidateOnFirstPositionPercent, Is.EqualTo(25));
            Assert.That(providedTips[0].CandidateOnSecondPosition, Is.EqualTo("TestCandidate2"));
            Assert.That(providedTips[0].CandidateOnSecondPositionPercent, Is.EqualTo(20));
            Assert.That(providedTips[0].CandidateOnThirdPosition, Is.EqualTo("TestCandidate3"));
            Assert.That(providedTips[0].CandidateOnThirdPositionPercent, Is.EqualTo(15));
        }

        [Test]
        public void Read_ReadoutValuesFitWithValuesInFile_Tip2()
        {
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", @"Tests\PresidentElection");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips[1].TipperName, Is.EqualTo("Miso"));
            Assert.That(providedTips[1].CandidateOnFirstPosition, Is.EqualTo("TestCandidate1"));
            Assert.That(providedTips[1].CandidateOnFirstPositionPercent, Is.EqualTo(40));
            Assert.That(providedTips[1].CandidateOnSecondPosition, Is.EqualTo("TestCandidate2"));
            Assert.That(providedTips[1].CandidateOnSecondPositionPercent, Is.EqualTo(25));
            Assert.That(providedTips[1].CandidateOnThirdPosition, Is.EqualTo("TestCandidate3"));
            Assert.That(providedTips[1].CandidateOnThirdPositionPercent, Is.EqualTo(20));
        }
    }
}