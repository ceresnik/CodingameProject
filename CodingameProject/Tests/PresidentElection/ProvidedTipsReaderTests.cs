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

        [Ignore("Not implemented.")]
        [Test]
        public void Read()
        {
            var sut = new ProvidedTipsReader("TestTips.json");
            ProvidedTips providedTips = sut.Read();
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

    public class ProvidedTips
    {
    }
}