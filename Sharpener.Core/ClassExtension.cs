using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        public static bool IsIn<T>(this T needle, T first, T second, params T[] remainder)
        {
            return new[] { first, second }.Contains(needle) || remainder.Contains(needle);
        }

        public static void ThrowIfNull<T>(this T obj, [CallerMemberName]string callingObjectName = null)
        {
            if (obj == null) throw new NullReferenceException(callingObjectName ?? "obj");
        }

        public static string ToString<T>(this T instance, string format)
        {
            var pattern = new Regex(@"\{(\w+)(\:.*?)?\}");

            var dict = new Dictionary<string, int>();
            var counter = 0;
            var objs = new List<object>();
            foreach (Match match in pattern.Matches(format))
            {
                var name = match.Groups[1].Value;
                var nameFormatting = match.Groups[2].Value;
                var stringToFind = String.Format("{{{0}{1}}}", name, nameFormatting);
                var value = typeof(T).GetProperty(name).GetValue(instance);

                int formatIndex;
                if (!dict.TryGetValue(name, out formatIndex))
                {
                    dict.Add(name, counter);
                    formatIndex = counter;
                    counter++;
                    var replacementString = String.Format("{{{0}{1}}}", formatIndex, nameFormatting);
                    format = format.Replace(stringToFind, replacementString);
                    objs.Add(value);
                }

            }
            var result = String.Format(format, objs.Distinct().ToArray());
            return result;
        }
    }
}
