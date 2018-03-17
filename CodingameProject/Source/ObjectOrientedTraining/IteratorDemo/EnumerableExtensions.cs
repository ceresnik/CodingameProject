using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> input, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
            input.Aggregate((T)null, (best, current) =>
                                         best == null || criterion(best).CompareTo(criterion(current)) > 0 ? current : best);
    }
}