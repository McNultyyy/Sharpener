using System.Net;
using System.Web.Mvc;

namespace Sharpener.Web.Attributes
{
    public class ThrowHttpStatusCodeAttribute : ActionFilterAttribute
    {
        private readonly HttpStatusCode _statusCode;

        public ThrowHttpStatusCodeAttribute(int statusCode)
        {
            _statusCode = (HttpStatusCode)statusCode;
        }
        public ThrowHttpStatusCodeAttribute(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Result = new HttpStatusCodeResult(_statusCode);
        }
    }
}
