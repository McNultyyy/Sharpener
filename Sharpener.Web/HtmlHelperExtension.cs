using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sharpener.Core;
using Sharpener.Web.Attributes.Labels;

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

        public static MvcHtmlString CustomLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expr)
        {
            var instance = html.ViewData.Model;
            var property = instance.GetType().GetProperty(expr.GetMemberName());
            var labelAttributes = property.GetCustomAttributes().OfType<LabelParameterAttribute>();

            var htmlAttributes = labelAttributes.ToDictionary(
                x => x.GetHtmlName(),
                x => x.GetValue() as object //needs to be obj as it will be used as an anon obj.
            );

            var result = html.LabelFor(expr, htmlAttributes);
            return result;
        }
    }
}
