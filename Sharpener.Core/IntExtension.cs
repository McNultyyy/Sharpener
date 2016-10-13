using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpener.Core
{
    public static class IntExtension
    {
        public static IEnumerable<int> To(this int start, int end)
        {
            var posDiff = Math.Abs(end - start + 1);
            var negDiff = Math.Abs(start - end + 1);
            if (end > start)
                return Enumerable.Range(start, posDiff);
            return Enumerable.Range(end, negDiff).Reverse();
        }

        public static IEnumerable<T> Of<T>(this int amount, T instance)
        {
            return 1.To(amount).Select(x => instance);
        }

        public static bool IsEven(this int input)
        {
            return input % 2 == 0;
        }

        public static bool IsOdd(this int input)
        {
            return !IsEven(input);
        }

        public static int RoundToNearest(this int input, int nearest, MidpointRounding roundingMode = MidpointRounding.AwayFromZero)
        {
            var dResult = Convert.ToDouble(input) / Convert.ToDouble(nearest);
            var dResultRounded = Convert.ToInt32(Math.Round(dResult, roundingMode));
            var result = dResultRounded * nearest;
            return result;
        }

        public static bool IsPrime(this int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= boundary; ++i)
                if (number%i == 0) return false;

            return true;
        }
    }
}