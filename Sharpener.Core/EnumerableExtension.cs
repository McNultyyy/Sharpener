using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpener.Core
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> collection, int amount)
        {
            return collection.Reverse().Skip(amount).Reverse();
        }
    }
}