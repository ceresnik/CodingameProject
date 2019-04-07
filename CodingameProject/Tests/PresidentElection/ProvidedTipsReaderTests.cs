﻿using System;
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
            string inputFileName = ProvideFullPathToFile("TestTips.json");

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
            string inputFileName = ProvideFullPathToFile("TestTips.json");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips, Is.InstanceOf<ProvidedTips>());
        }

        [Test]
        public void Read_ReturnedTwoProvidedTips()
        {
            string inputFileName = ProvideFullPathToFile("TestTips.json");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips.Count, Is.EqualTo(2));
        }

        [Test]
        public void Read_ReadoutValuesFitWithValuesInFile_Tip1()
        {
            string inputFileName = ProvideFullPathToFile("TestTips.json");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips[0].TipperName, Is.EqualTo("Lubo"));
            Assert.That(providedTips[0].CandidateOnFirstPosition, Is.EqualTo("LubosCandidate1"));
            Assert.That(providedTips[0].CandidateOnFirstPositionPercent, Is.EqualTo(31.33));
            Assert.That(providedTips[0].CandidateOnSecondPosition, Is.EqualTo("LubosCandidate2"));
            Assert.That(providedTips[0].CandidateOnSecondPositionPercent, Is.EqualTo(32.33));
            Assert.That(providedTips[0].CandidateOnThirdPosition, Is.EqualTo("LubosCandidate3"));
            Assert.That(providedTips[0].CandidateOnThirdPositionPercent, Is.EqualTo(33.33));
        }

        [Test]
        public void Read_ReadoutValuesFitWithValuesInFile_Tip2()
        {
            string inputFileName = ProvideFullPathToFile("TestTips.json");
            var sut = new ProvidedTipsReader(inputFileName);
            ProvidedTips providedTips = sut.Read();

            Assert.That(providedTips[1].TipperName, Is.EqualTo("Miso"));
            Assert.That(providedTips[1].CandidateOnFirstPosition, Is.EqualTo("MisosCandidate1"));
            Assert.That(providedTips[1].CandidateOnFirstPositionPercent, Is.EqualTo(41.44));
            Assert.That(providedTips[1].CandidateOnSecondPosition, Is.EqualTo("MisosCandidate2"));
            Assert.That(providedTips[1].CandidateOnSecondPositionPercent, Is.EqualTo(42.44));
            Assert.That(providedTips[1].CandidateOnThirdPosition, Is.EqualTo("MisosCandidate3"));
            Assert.That(providedTips[1].CandidateOnThirdPositionPercent, Is.EqualTo(43.44));
        }

        //TODO: extract to separate utility/helper
        private static string ProvideFullPathToFile(string fileName)
        {
            string baseDirectory = AppContext.BaseDirectory;
            string twoLevelsUp = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\"));
            string destinationDirectory = Path.Combine(twoLevelsUp, @"Tests\PresidentElection");
            return Path.GetFullPath(Path.Combine(destinationDirectory, fileName));
        }
    }
}