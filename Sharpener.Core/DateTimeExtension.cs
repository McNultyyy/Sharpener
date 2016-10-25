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

        public static bool IsBetween(this DateTime middle, DateTime left, DateTime right)
        {
            return left < middle && middle < right;
        }
        
                public static DateTime NextWorkday(this DateTime date)
        {
            var nextDay = date;
            while (!nextDay.IsWeekday())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        public static DateTime NextWeekday(this DateTime date)
        {
            var nextDay = date;
            while (!nextDay.IsWeekend())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - current.DayOfWeek;
            if (offsetDays <= 0)
                offsetDays += 7;

            DateTime result = current.AddDays(offsetDays);
            return result;
        }
    }
}
