using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            int skip = (pageNumber - 1) * pageSize;
            int current = 0;
            int taken = 0;

            foreach (var item in source)
            {
                if (current >= skip && taken < pageSize)
                {
                    yield return item;
                    taken++;
                }
                current++;

                if (taken == pageSize) yield break;
            }
        }

        public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return default;
        }

        public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var dictionary = new Dictionary<int, T>();
            foreach (var item in source)
            {
                dictionary.Add(item.Id, item);
            }
            return dictionary;
        }

    }
}
