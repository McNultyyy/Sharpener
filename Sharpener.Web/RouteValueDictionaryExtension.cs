using System.Web.Routing;

namespace Sharpener.Web
{
    public static class RouteValueDictionaryExtension
    {
        public static string GetController(this RouteValueDictionary dictionary)
        {
            var result = dictionary["controller"] as string;
            return result;
        }

        public static string GetAction(this RouteValueDictionary dictionary)
        {
            var result = dictionary["action"] as string;
            return result;
        }
    }
}