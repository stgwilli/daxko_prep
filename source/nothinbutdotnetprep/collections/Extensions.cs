using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public static class Extensions
    {
        public static IEnumerable<T> all_where<T>(this IEnumerable<T> items, Predicate<T> matches)
        {
            foreach (var item in items)
            {
                if (matches(item))
                    yield return item;
            }
        }
    }
}