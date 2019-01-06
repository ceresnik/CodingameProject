using CodingameProject.Source.AlphabetUtilities;
using NUnit.Framework;

namespace CodingameProject.Tests.AlphabetUtilities
{
    public class StringFormatterTests
    {
        [Test]
        public void Test()
        {
            var sut = new StringFormatter("Xx xxxx xx Xxxxxx!");
            var result = sut.Format("mynaMeismICHAL");
            Assert.That(result, Is.EqualTo("My name is Michal!"));
        }
    }
}