using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Calculadora.MVC.Filters
{
    public class SessionAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString("usuario");
            if (string.IsNullOrEmpty(session))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }
    }
}
