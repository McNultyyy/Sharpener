using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Sharpener.Core
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> collection, int amount)
        {
            return collection.Reverse().Skip(amount).Reverse();
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> firstSelector, Func<TSource, TKey> secondSelector, params Func<TSource, TKey>[] otherSelectors)
        {
            var result = source.OrderBy(firstSelector).ThenBy(secondSelector);
            foreach (var selector in otherSelectors)
                result = result.OrderBy(selector);
            return result;
        }

        public static string JoinWith(this IEnumerable<string> strings, string separator)
        {
            return String.Join(separator, strings);
        }
        
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            var dt = new DataTable(typeof(T).Name);
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var colName = property.Name;
                dt.Columns.Add(colName, property.PropertyType);
            }

            foreach (var item in source)
            {
                var values = properties.Select(x => x.GetValue(item));
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}
