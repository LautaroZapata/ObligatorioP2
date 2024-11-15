using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebAppObligatorio.Filters
{
    public class Logueado : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string logueado = context.HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(logueado))
            {
                context.Result = new RedirectToActionResult("Login", "Negocio", new {mensaje = "Inicie sesion."});
            }
            base.OnActionExecuted(context);
        }
    }
}
