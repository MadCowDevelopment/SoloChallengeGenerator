using System;
using System.Collections.Generic;
using System.Linq;

namespace scg.Utils
{
    public static class ListExtensions
    {
        private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = _random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            var randomIndex = _random.Next(0, list.Count);
            return list[randomIndex];
        }
    }
}