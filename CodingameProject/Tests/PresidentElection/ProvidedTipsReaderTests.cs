using System;
using System.IO;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ProvidedTipsReaderTests
    {
        private string inputDataDirectoryName = @"Tests\PresidentElection\InputData";

        [Test]
        public void ProvidedTipsReaderObject_InitializedCorrectly()
        {
            //prepare
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", inputDataDirectoryName);

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
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", inputDataDirectoryName);
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips, Is.InstanceOf<ProvidedTips>());
        }

        [Test]
        public void Read_ReturnedTwoProvidedTips()
        {
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", inputDataDirectoryName);
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips.Count, Is.EqualTo(2));
        }

        [Test]
        public void Read_ReadoutValuesFitWithValuesInFile_Tip1()
        {
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", inputDataDirectoryName);
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips[0].TipperName, Is.EqualTo("Lubo"));
            Assert.That(providedTips[0].Tips[0].CandidateName, Is.EqualTo("TestCandidate1"));
            Assert.That(providedTips[0].Tips[0].ElectionGainInPercent, Is.EqualTo(25));
            Assert.That(providedTips[0].Tips[1].CandidateName, Is.EqualTo("TestCandidate2"));
            Assert.That(providedTips[0].Tips[1].ElectionGainInPercent, Is.EqualTo(20));
            Assert.That(providedTips[0].Tips[2].CandidateName, Is.EqualTo("TestCandidate3"));
            Assert.That(providedTips[0].Tips[2].ElectionGainInPercent, Is.EqualTo(15));
        }

        [Test]
        public void Read_ReadoutValuesFitWithValuesInFile_Tip2()
        {
            string inputFileName = FilePathProvider.ProvideFullPathToFile("TestTips.json", inputDataDirectoryName);
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips[1].TipperName, Is.EqualTo("Miso"));
            Assert.That(providedTips[1].Tips[0].CandidateName, Is.EqualTo("TestCandidate1"));
            Assert.That(providedTips[1].Tips[0].ElectionGainInPercent, Is.EqualTo(40));
            Assert.That(providedTips[1].Tips[1].CandidateName, Is.EqualTo("TestCandidate2"));
            Assert.That(providedTips[1].Tips[1].ElectionGainInPercent, Is.EqualTo(25));
            Assert.That(providedTips[1].Tips[2].CandidateName, Is.EqualTo("TestCandidate3"));
            Assert.That(providedTips[1].Tips[2].ElectionGainInPercent, Is.EqualTo(20));
        }
    }
}