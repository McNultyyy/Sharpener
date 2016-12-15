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

        public static string Left(this string input, int amount)
        {
            return input.Skip(amount) as string;
        }

        public static string Right(this string input, int amount)
        {
            return input.Reverse().Take(amount).Reverse() as string;
        }
    }
}
