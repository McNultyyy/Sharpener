using System;

namespace Sharpener.Core
{
    public static class DateTimeExtension
    {
        public static bool IsBefore(this DateTime source, DateTime target)
        {
            return source < target;
        }

        public static bool IsAfter(this DateTime source, DateTime target)
        {
            return source > target;
        }
    }
}