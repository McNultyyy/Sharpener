using System;
using System.Linq;
using System.Web.Mvc;

namespace Sharpener.Web.Attributes
{
    public class ServiceFilterAttribute : ActionFilterAttribute
    {
        private readonly Type _typeToInject;
        private ActionFilterAttribute _typeInstance;

        public ServiceFilterAttribute(Type typeToInject)
        {
            _typeToInject = typeToInject;
            CreateInstance();
        }

        private void CreateInstance()
        {
            var firstCtor = _typeToInject.GetConstructors().FirstOrDefault();
            var ctorParamTypes = firstCtor.GetParameters().Select(x => x.ParameterType);
            var injectedCtorParamValues = ctorParamTypes.Select(x => DependencyResolver.Current.GetService(x)).ToArray();
            _typeInstance = Activator.CreateInstance(_typeToInject, injectedCtorParamValues) as ActionFilterAttribute;
        }

        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _typeInstance.OnActionExecuting(filterContext);
        }


        public virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _typeInstance.OnActionExecuted(filterContext);
        }

        public virtual void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _typeInstance.OnResultExecuting(filterContext);
        }

        public virtual void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _typeInstance.OnResultExecuted(filterContext);
        }
    }
}
