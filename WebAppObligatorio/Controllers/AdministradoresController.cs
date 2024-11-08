using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppObligatorio.Controllers
{
    public class AdministradoresController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View(sistema.Administradores);
        }
    }
}
