using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using WebAppObligatorio.Filters;

namespace WebAppObligatorio.Controllers
{
    [Logueado]
    [AdminFilter]

    public class AdministradoresController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View(sistema.Administradores);
        }
        public IActionResult SubastasAdmin() 
        {
            return View(sistema.Subastas);
        }
        
    }

}
