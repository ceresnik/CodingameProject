using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    [TestFixture]
    public class AsciiArtTests
    {
[Test]
        public void TestAsciiArt()
        {
            string[] inputRows = { ".---.", "|---|", ".---." };
            var result = new AsciiArt().InvertASCIIArt(inputRows);

            Assert.That(result, Is.EqualTo(".|.\r\n---\r\n---\r\n---\r\n.|.\r\n"));
        }
    }
}