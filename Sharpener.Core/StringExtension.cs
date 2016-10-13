using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Sharpener.Core
{
    public static class StringExtension
    {
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static string FormatWith(this string input, params Expression<Func<object>>[] expr)
        {
            var pattern = new Regex(@"\{(\w+)(\:.*?)?\}");

            var nameValueDict = expr.ToDictionary(x => x.GetMemberName(), x => x.Compile().Invoke());


            var dict = new Dictionary<string, int>();
            var counter = 0;
            var objs = new List<object>();
            foreach (Match match in pattern.Matches(input))
            {
                var name = match.Groups[1].Value;
                var nameFormatting = match.Groups[2].Value;
                var stringToFind = String.Format("{{{0}{1}}}", name, nameFormatting);
                var value = nameValueDict[name];

                int formatIndex;
                if (!dict.TryGetValue(name, out formatIndex))
                {
                    dict.Add(name, counter);
                    formatIndex = counter;
                    counter++;
                    var replacementString = String.Format("{{{0}{1}}}", formatIndex, nameFormatting);
                    input = input.Replace(stringToFind, replacementString);
                    objs.Add(value);
                }
            }

            var result = String.Format(input, objs.Distinct().ToArray());
            return result;
        }
    }
}
