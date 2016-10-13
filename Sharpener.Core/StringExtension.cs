using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sharpener.Core
{
    public static class StringExtension
    {
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
        
        public static string FormatWith(this string input, params Expression<Func<object, object>>[] expr)
        {
            var indexValueDict = expr.Select((item, index) => 
                new Tuple<string, object, int>(
                    item.GetMemberName(), //name
                    item.Compile().Invoke(null), //value
                    index //index
                )).ToList();

            foreach (var pair in indexValueDict)
                input = input.Replace("{" + pair.Item1 + "}", "{" + pair.Item3 + "}");

            var args = indexValueDict.Select(x => x.Item2).ToArray();
            var resultFormat = String.Format(input, args);

            return resultFormat;
        }
    }
}
