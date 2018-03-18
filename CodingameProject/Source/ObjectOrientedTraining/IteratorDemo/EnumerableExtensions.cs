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
            input.Select(obj => Tuple.Create(obj, criterion(obj)))
                .Aggregate((Tuple<T, TKey>)null, (best, current) =>
                                                     best == null || best.Item2.CompareTo(current.Item2) > 0 ? current : best)
                .Item1;
    }
}