using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sharpener.Core
{
    public static class ClassExtension
    {
        public static bool IsIn<T>(this T needle, IEnumerable<T> haystack)
        {
            return haystack.Contains(needle);
        }

        public static void ThrowIfNull<T>(this T obj, [CallerMemberName]string callingObjectName = null)
        {
            if (obj == null) throw new NullReferenceException(callingObjectName ?? "obj");
        }
    }
}