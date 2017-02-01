using System.Web.Mvc;

namespace Sharpener.Web.Attributes
{
    public class LayoutInjectorAttribute : ActionFilterAttribute
    {
        private readonly string _layoutName;

        public LayoutInjectorAttribute(string layoutName)
        {
            _layoutName = layoutName;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.MasterName = _layoutName;
            }
        }
    }
}
