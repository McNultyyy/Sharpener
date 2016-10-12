using JetBrains.Annotations;

namespace Sharpener.Core
{
    public static class StringExtension
    {
        [StringFormatMethod("format")]
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}