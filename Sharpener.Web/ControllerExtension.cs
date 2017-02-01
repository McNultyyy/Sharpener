using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sharpener.Core;

namespace Sharpener.Web
{
    public static class ControllerExtension
    {
        public static string GetControllerName<TController>(this TController controller) where TController : IController
        {
            var result = typeof(TController).Name.Replace("Controller", "");
            return result;
        }
    }
}