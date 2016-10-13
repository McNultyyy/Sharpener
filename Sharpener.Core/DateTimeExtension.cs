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
        
        public static bool IsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }
        
        public static bool IsWeekday(this DateTime value)
        {
            return !IsWeekend(value);
        }
    }
}
