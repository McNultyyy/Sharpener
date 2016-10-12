using System.Collections.Generic;
using System.Web.Routing;

namespace Sharpener.Web
{
    public static class DictionaryExtension
    {
        public static RouteValueDictionary ToRouteValueDictionary<T>(this IDictionary<string, T> dict)
        {
            return new RouteValueDictionary(dict);
        }
    }
}