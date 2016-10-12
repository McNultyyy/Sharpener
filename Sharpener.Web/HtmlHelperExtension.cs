using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sharpener.Core;

namespace Sharpener.Web
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString Action<TController, TActionResult>(this HtmlHelper html, Expression<Func<TController, TActionResult>> expr)
            where TController : Controller
            where TActionResult : ActionResult
        {
            var controllerName = typeof(TController).Name.Replace("Controller", "");
            var actionName = expr.GetMemberName();
            var actionParams = expr.GetTypedFunctionInputValues().ToRouteValueDictionary();

            return html.Action(actionName, controllerName, actionParams);
        }
    }
}
