using System.Collections.Generic;
using System.Linq;

namespace KGood.Source.HofstadterConwaySequence
{
    internal static class HofstadterConwaySequenceGenerator
    {
        public static IList<int> Generate(int countOfMembers)
        {
            IList<int> results = new List<int>();
            for (int i = countOfMembers; i > 0; i--)
            {
                results.Add(CountMember(i));
            }
            return results.Reverse().ToList();
        }

        /// <summary>
        /// Formula:
        /// a(1) = 1
        /// a(2) = 1
        /// a(n) = a(a(n - 1)) + a(n - a(n - 1))
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        private static int CountMember(int rank)
        {
            if (rank == 1 || rank == 2)
            {
                return 1;
            }
            return CountMember(CountMember(rank - 1)) + CountMember(rank - CountMember(rank - 1));
        }
    }
}