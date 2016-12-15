using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Sharpener.Core
{
    public static class ClassExtension
    {
        public static bool IsIn<T>(this T needle, IEnumerable<T> haystack)
        {
            return haystack.Contains(needle);
        }

        public static bool IsIn<T>(this T needle, T first, T second, params T[] remainder)
        {
            return new[] { first, second }.Contains(needle) || remainder.Contains(needle);
        }

        public static void ThrowIfNull<T>(this T obj, [CallerMemberName]string callingObjectName = null)
        {
            if (obj == null) throw new NullReferenceException(callingObjectName ?? "obj");
        }
        
        public static T As<T>(this object instance) where T : class
        {
            return instance as T;
        }

        public static void SetPropertyValue<TSource, TProperty>(this TSource target,
            Expression<Func<TSource, TProperty>> memberLamda, TProperty value)
        {
            var propertyName = memberLamda.GetMemberName();
            var property = typeof(TSource).GetProperty(propertyName);

            property.SetValue(target, value);
        }
    }
}
