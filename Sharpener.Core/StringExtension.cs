﻿using System.Linq;
using System.Security;

namespace Sharpener.Core
{
    public static class StringExtension
    {
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static string ReverseString(this string text)
        {
            return new string(text.Reverse().ToArray());
        }

        public static string Left(this string input, int amount)
        {
            return input.Substring(0, amount);
        }

        public static string Right(this string input, int amount)
        {
            return input.Substring(input.Length - amount, amount);
        }

        public static SecureString ToSecureString(this string input)
        {
            var secureString = new SecureString();
            foreach (var character in input)
                secureString.AppendChar(character);
            return secureString;
        }
    }
}
