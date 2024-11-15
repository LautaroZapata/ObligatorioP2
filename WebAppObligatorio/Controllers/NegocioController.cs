using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using WebAppObligatorio.Filters;

namespace WebAppObligatorio.Controllers
{
    public class NegocioController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index(string mensaje)
        {
            string email = HttpContext.Session.GetString("email");
            Cliente cliente = sistema.BuscarClientePorEmail(email);
            return View(cliente);
        }
        public IActionResult Login(string mensaje)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Error = mensaje;
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            try
            {
                Usuario logueado = sistema.AutenticarUser(email, password);
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("rol", logueado.GetType().Name);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();

            }
        }
        public IActionResult Logout()
        {
                HttpContext.Session.SetString("email", "");
                return RedirectToAction("Login");
        }
    }
}
