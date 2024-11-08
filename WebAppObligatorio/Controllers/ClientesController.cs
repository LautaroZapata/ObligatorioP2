using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppObligatorio.Controllers
{
    public class ClientesController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View(sistema.Clientes);
        }
        public IActionResult Publicaciones()
        {
            return View(sistema.Publicaciones);
        }
    }
}
