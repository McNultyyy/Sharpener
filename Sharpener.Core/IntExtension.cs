using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpener.Core
{
    public static class IntExtension
    {
        public static IEnumerable<int> To(this int start, int end)
        {
            var diff = Math.Abs(end - start +1);
            if (end > start)
                return Enumerable.Range(start, diff);
            return Enumerable.Range(end, diff).Reverse();
        }
    }
}