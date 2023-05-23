using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L_LeControleur_LesFiltres
{
    public class MesFiltres : IActionFilter, IResultFilter, IExceptionFilter, IAuthorizationFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
           
        }

        public void OnException(ExceptionContext filterContext)
        {
           
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
        }
    }
}