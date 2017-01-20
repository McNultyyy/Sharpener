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
        
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int times = 2)
        {
            var counter = 0;
            while (counter < times)
            {
                foreach (var item in source)
                    yield return item;
                counter++;
            }
        }

        public static IEnumerable<T> RepeatIndefinitely<T>(this IEnumerable<T> source)
        {
            while (true)
                foreach (var item in source)
                    yield return item;
        }
        
        public static int Product(this IEnumerable<int> source)
        {
            return DynamicProduct(source, 1);
        }

        public static int? Product(this IEnumerable<int?> source)
        {
            return DynamicProduct(source, 1);
        }
        private static T DynamicProduct<T>(this IEnumerable<T> source, T one)
        {
            dynamic product = one;
            foreach (var item in source)
                product *= item;

            return product;
        }
        
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            var result = Append(source, new[] { item });
            return result;
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            foreach (var item in source)
                yield return item;
            foreach (var item in items)
                yield return item;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            var result = Append(items, source);
            return result;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
        {
            var result = Append(new[] { item }, source);
            return result;
        }
        
        public static bool ContainsAll<T>(this IEnumerable<T> input, IEnumerable<T> values)
        {
            var enumerable = input as IList<T> ?? input.ToList();
            foreach (var value in values)
                if (!enumerable.Contains(value))
                    return false;
            return true;
        }

        public static bool ContainsAny<T>(this IEnumerable<T> input, IEnumerable<T> values)
        {
            var enumerable = input as IList<T> ?? input.ToList();
            foreach (var value in values)
                if (enumerable.Contains(value))
                    return true;
            return false;
        }
    }
}
