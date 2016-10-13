using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpener.Core
{
    public static class IntExtension
    {
        public static IEnumerable<int> To(this int start, int end)
        {
            var posDiff = Math.Abs(end - start + 1);
            var negDiff = Math.Abs(start - end + 1);
            if (end > start)
                return Enumerable.Range(start, posDiff);
            return Enumerable.Range(end, negDiff).Reverse();
        }

        public static IEnumerable<T> Of<T>(this int amount, T instance)
        {
            return 1.To(amount).Select(x => instance);
        }
    }
}