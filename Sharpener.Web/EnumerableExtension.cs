using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Sharpener.Web
{
    public static class EnumerableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> source,
            Expression<Func<T, string>> textExpr, Expression<Func<T, string>> valueExpr)
        {
            return source.Select(x => new SelectListItem()
            {
                Text = textExpr.Compile().Invoke(x),
                Value = valueExpr.Compile().Invoke(x)
            });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<string> source)
        {
            {
                return ToSelectListItems(source, x => x, x => x);
            }
        }
    }
}