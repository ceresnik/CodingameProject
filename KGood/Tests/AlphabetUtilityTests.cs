using System.Collections.Generic;
using System.Linq;
using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    public class AlphabetUtilityTests
    {
        [TestCase("ABCDFEGH", "E")]
        [TestCase("MNOPQRTSUVWX", "S")]
        [TestCase("CEGIMKO", "K")]
        [TestCase("ACDEGHIJLNQRSUXZY", "Y")]
        [Test]
        public void Test_FindFirstNotCorrectlyPlacedLetter(string input, string output)
        {
            AlphabetUtility sut = new AlphabetUtility(input);
            Assert.That(sut.FindFirstNotCorrectlyPlacedLetter(), Is.EqualTo(output));
        }

        [TestCase("111 108 108 101 72 32 101 114 101 104 116 32 41 58", "Hello there :)")]
        [TestCase("126 125 124 123 122 121 120 119 118 117 116 115 114 113 112 111 110 109 108 107 106 105 104 103 102 101 100 99 98 97 96 95 94 93 92 91 90 89 88 87 86 85 84 83 82 81 80 79 78 77 76 75 74 73 72 71 70 69 68 67 66 65 64 63 62 61 60 59 58 57 56 55 54 53 52 51 50 49 48 47 46 45 44 43 42 41 40 39 38 37 36 35 34 33", "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~")]
        [Test]
        public void Test_DecodeMessage(string encodedMessage, string decodedMessage)
        {
            AlphabetUtility sut = new AlphabetUtility(encodedMessage);
            var result = sut.DecodeMessage();

            Assert.That(result, Is.EqualTo(decodedMessage));
        }

        [TestCase("abbcccdddd", "1a2b3c4d")]
        [TestCase("abcdefghijklmnopqrstuvwxyz", "1a1b1c1d1e1f1g1h1i1j1k1l1m1n1o1p1q1r1s1t1u1v1w1x1y1z")]
        [TestCase("ZzzzzZzZZZzzzzzzzzzzzzzZZZZZZZZ", "1Z4z1Z1z3Z13z8Z")]
        [Test]
        public void Test_RunLengthEncoding(string input, string output)
        {
            AlphabetUtility sut = new AlphabetUtility(input);
            Assert.That(sut.RunLengthEncoding(), Is.EqualTo(output));
        }

        [TestCase("abbcccdddd", "1a2b3c4d")]
        [TestCase("abcdefghijklmnopqrstuvwxyz", "1a1b1c1d1e1f1g1h1i1j1k1l1m1n1o1p1q1r1s1t1u1v1w1x1y1z")]
        [TestCase("ZzzzzZzZZZzzzzzzzzzzzzzZZZZZZZZ", "1Z4z1Z1z3Z13z8Z")]
        [Test]
        public void Test_RunLengthEncoding2(string input, string output)
        {
            AlphabetUtility sut = new AlphabetUtility(input);
            Assert.That(sut.RunLengthEncoding2(), Is.EqualTo(output));
        }

        [TestCase("CiaonmdGe", "CodinGame")]
        [Test]
        public void Test_CaesarBoxCipher(string input, string output)
        {
            AlphabetUtility sut = new AlphabetUtility(input);
            Assert.That(sut.DecodeCaesarBoxCipher(), Is.EqualTo(output));
        }

        [TestCase("XP", "XP\r\nPX\r\nXP")]
        [TestCase("AAAAAAA", "AAAAAAA\r\nAAAAAAA")]
        [TestCase("Codingame", "Codingame\r\neCodingam\r\nmeCodinga\r\nameCoding\r\ngameCodin\r\nngameCodi\r\ningameCod\r\ndingameCo\r\nodingameC\r\nCodingame")]
        [TestCase("TheQuickBrownFoxJumped", "TheQuickBrownFoxJumped\r\ndTheQuickBrownFoxJumpe\r\nedTheQuickBrownFoxJump\r\npedTheQuickBrownFoxJum\r\nmpedTheQuickBrownFoxJu\r\numpedTheQuickBrownFoxJ\r\nJumpedTheQuickBrownFox\r\nxJumpedTheQuickBrownFo\r\noxJumpedTheQuickBrownF\r\nFoxJumpedTheQuickBrown\r\nnFoxJumpedTheQuickBrow\r\nwnFoxJumpedTheQuickBro\r\nownFoxJumpedTheQuickBr\r\nrownFoxJumpedTheQuickB\r\nBrownFoxJumpedTheQuick\r\nkBrownFoxJumpedTheQuic\r\nckBrownFoxJumpedTheQui\r\nickBrownFoxJumpedTheQu\r\nuickBrownFoxJumpedTheQ\r\nQuickBrownFoxJumpedThe\r\neQuickBrownFoxJumpedTh\r\nheQuickBrownFoxJumpedT\r\nTheQuickBrownFoxJumped")]
        [TestCase("Arturia Pendragon", "Arturia Pendragon\r\nnArturia Pendrago\r\nonArturia Pendrag\r\ngonArturia Pendra\r\nagonArturia Pendr\r\nragonArturia Pend\r\ndragonArturia Pen\r\nndragonArturia Pe\r\nendragonArturia P\r\nPendragonArturia \r\n PendragonArturia\r\na PendragonArturi\r\nia PendragonArtur\r\nria PendragonArtu\r\nuria PendragonArt\r\nturia PendragonAr\r\nrturia PendragonA\r\nArturia Pendragon")]
        [Test]
        public void Test_CycleLetters(string input, string expectedResult)
        {
            AlphabetUtility sut = new AlphabetUtility(input);
            var result = sut.CycleLetters();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("Hello!", "Hleol!")]
        [TestCase("Hello", "Hleol")]
        [TestCase("SquizeeIt", "SeqeuIitz")]
        [Test]
        public void Test_EncodeMessage(string input, string expected)
        {
            var output = AlphabetUtility.EncodeMessage(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [TestCase("Hello world.", "Ook ook.")]
        [TestCase("You need more time; and you probably always will.", "Eek ook ook ook; eek eek ook eek ook.")]
        [Test]
        public void Test_Orang_utanEncoding(string input, string expected)
        {
            string result = AlphabetUtility.EncodeOrang_utan(input);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [TestCase(180, 155, 1, 120, "Am I the only one who thinks it is HOT in here? Sorry, small talk was never my thing. Ehm, hi, my name is Ron. Darn, I was not supposed to say that! Anyway, I have come to free you from this capitalistic world. Just kidding, guys, stop looking at me like that. It WAS a good joke though, right? No? Anyone? Fine, here we go. Geronimo!", "SUCCESS")]
        [TestCase(214, 130, 1, 213, "Hi!", "BUSTED")]
        [TestCase(140, 100, 0, 200, "I am not doing this because I want to, alright, you all? Someone gave me money to break into this bank. Wait a second! This does not make sense. It would be more profitable just to keep the money. Wait for another second. I do not even have to do this. I am out of this. What? That is not an option? Excuse you, sir, but I do not live in the matrix, alright! Wait, I do? This is not free will? Whaaat? No, I will prove it to you! Remember how I said I would not steal anything? Well, guess what!", "BUSTED")]
        [Test]
        public void Test_CalculateBankThief(int timeNeededByPolice, int wordsPerMinute, int timeAfterSentence, int timeAfterAllSentences, string inputSentence, string expected)
        {
            var robberyData = new RobberyData(timeNeededByPolice, wordsPerMinute, timeAfterSentence, timeAfterAllSentences, inputSentence);
            var result = AlphabetUtility.CalculateBankThief(robberyData);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_FindMostQuantityLetter()
        {
            string input = "The quick brown fox jumps over the lazy dog";
            var result = AlphabetUtility.FindMostQuantityLetter(input);
            Assert.That(result, Is.EqualTo(4));
        }

        [TestCase("ThisIsValidNumberInput1234", "VALID")]
        [TestCase("123", "INVALID")]
        [TestCase("UnsupportedChar?", "INVALID")]
        [Test]
        public void Test_ValidateUpperCaseLowerCaseAndNumberInput(string input, string expected)
        {
            var result = AlphabetUtility.ValidateUpperCaseLowerCaseAndNumberInput(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("0001010", "0101010", "0101010")]
        [Test]
        public void Test_DoLogicalOr(string input1, string input2, string expected)
        {
            string result = AlphabetUtility.DoLogicalOr(input1, input2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("0001010", "0101010", "0101010")]
        [Test]
        public void Test_DoLogicalOrWithCharSubtraction(string input1, string input2, string expected)
        {
            string result = AlphabetUtility.DoLogicalOrWithCharSubtraction(input1, input2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("100020300001", 4)]
        [TestCase("123456789", 0)]
        [TestCase("23659801452", 1)]
        [TestCase("10000000000000000", 16)]
        [Test]
        public void Test_CountZeros(string input, int expected)
        {
            int actualCount = 0;
            int maxCount = 0;
            foreach (char c in input)
            {
                if (c == '0')
                {
                    actualCount++;
                    maxCount = actualCount;
                }
                else
                {
                    actualCount = 0;
                }
            }
            Assert.That(maxCount, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GetIndexOfLetterInAlphabet()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string input = "DAbE";
            var indexes = AlphabetUtility.GetIndexOfLettersInAlphabet(alphabet, input);
            CollectionAssert.Contains(indexes, 3);
            CollectionAssert.Contains(indexes, 0);
            CollectionAssert.Contains(indexes, 1);
            CollectionAssert.Contains(indexes, 4);
            Assert.That(indexes.Count, Is.EqualTo(4));
        }

        [TestCase("abc", 3)]
        [TestCase("abbc", 3)]
        [TestCase("aBcdEfGH", 8)]
        [TestCase("abBcdEfGH", 8)]
        [Test]
        public void Test_GetCountOfLetters(string input, int expected)
        {
            var result = AlphabetUtility.GetCountOfLetters(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("HELLO WORLD", "URYYB JBEYQ")]
        [TestCase("URYYB JBEYQ", "HELLO WORLD")]
        [Test]
        public void Test_ROT13Cipher(string expected, string input)
        {
            var result = AlphabetUtility.Encode_Rot13Cipher(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0, "0")]
        [TestCase(45, "P/4")]
        [TestCase(90, "P/2")]
        [TestCase(180, "P")]
        [TestCase(225, "5*P/4")]
        [TestCase(270, "3*P/2")]
        [TestCase(360, "2*P")]
        [TestCase(-90, "3*P/2")]
        [TestCase(-135, "5*P/4")]
        [Test]
        public void Test_ConvertAngleInDegreesToRadians(int angleInDegrees, string expected)
        {
            int num1 = 0;
            int num2 = 0;
            if (angleInDegrees < 0)
            {
                angleInDegrees += 360;
            }
            GetBasicValues(angleInDegrees, ref num1, ref num2);
            FindBiggestCommonDivisor(ref num1, ref num2);
            string result = FormatValues(num1, num2);
            Assert.That(result, Is.EqualTo(expected));
        }

        private static void FindBiggestCommonDivisor(ref int num1, ref int num2)
        {
            int smaller = num1 < num2 ? num1 : num2;
            for (int i = smaller; i > 1; i--)
            {
                if (num1 % i == 0 && num2 % i == 0)
                {
                    num1 /= i;
                    num2 /= i;
                }
            }
        }

        private static string FormatValues(int num1, int num2)
        {
            string result = "";
            if (num1 > 1)
            {
                result = num1 + "*";
            }
            if (num1 >= 1 || num2 >= 1)
            {
                result += "P";
            }
            else
            {
                result = "0";
            }
            if (num2 > 1)
            {
                result = result + "/" + num2;
            }
            return result;
        }

        private static void GetBasicValues(int angleInDegrees, ref int num1, ref int num2)
        {
            if (angleInDegrees > 0 && angleInDegrees % 45 == 0)
            {
                num1 = angleInDegrees / 45;
                num2 = 4;
            }
            else
            {
                if (angleInDegrees > 0 && angleInDegrees % 90 == 0)
                {
                    num1 = angleInDegrees / 90;
                    num2 = 2;
                }
            }
        }
    }
}