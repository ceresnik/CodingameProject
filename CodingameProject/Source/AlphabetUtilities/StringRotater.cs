using System.Text;

namespace CodingameProject.Source.AlphabetUtilities
{
    public static class StringRotater
    {
        public static bool IsRightRotated(string input, string expected)
        {
            bool result = false;
            string stringToRotate = input;
            for (int i = 0; i < input.Length; i++)
            {
                stringToRotate = DoRightRotation(stringToRotate);
                if (expected == stringToRotate)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static string DoRightRotation(string input)
        {
            var sb = new StringBuilder();
            sb.Append(input[input.Length - 1]);
            sb.Append(input.Substring(0, input.Length - 1));
            return sb.ToString();
        }

        public static string DoLeftRotation(string input)
        {
            var sb = new StringBuilder();
            sb.Append(input.Substring(1, input.Length - 1));
            sb.Append(input[0]);
            return sb.ToString();
        }

    }
}