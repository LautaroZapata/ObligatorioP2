using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;


namespace WebAppObligatorio.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol) || rol != "Administrador")
            {
                context.Result = new RedirectToActionResult("Index", "Negocio", new { mensaje = "Acceso Restringido" });
            }
            base.OnActionExecuted(context);
        }
    }
}
