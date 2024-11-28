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
            try
            {
                string email = HttpContext.Session.GetString("email");
                Usuario cliente = sistema.UserLogueado(email);
                return View(cliente);

            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(mensaje))
                {
                    ViewBag.Error = ex.Message;
                }
                return RedirectToAction("Login", new { mensaje = ex.Message });
            }


            
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
        public IActionResult Registrarse(string mensaje)
        {
            ViewBag.Error = mensaje;
            return View();
        }
        [HttpPost]
        public IActionResult Registrarse(string nombre, string apellido, string email, string pass, int saldoDisponible)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass) && saldoDisponible != null)
                {
                    sistema.RegistrarCliente(email,pass,nombre,apellido, saldoDisponible);
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return View();

        }

    }
}
