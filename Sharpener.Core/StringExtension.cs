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
    }
}
