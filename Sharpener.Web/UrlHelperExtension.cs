using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sharpener.Core;

namespace Sharpener.Web
{
    public static class UrlHelperExtension
    {
        public static string Action<TController, TActionResult>(this UrlHelper url, Expression<Func<TController, TActionResult>> expr)
            where TController : Controller
            where TActionResult : ActionResult
        {
            var controllerName = typeof(TController).Name.Replace("Controller", "");
            var actionName = expr.GetMemberName();
            var actionParams = expr.GetTypedFunctionInputValues().ToRouteValueDictionary();

            return url.Action(actionName, controllerName, actionParams);
        }
    }
}