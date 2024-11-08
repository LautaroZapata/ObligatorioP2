using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;

namespace WebAppObligatorio.Controllers
{
    public class NegocioController : Controller
    {
        public IActionResult Index()
        {
            Sistema sistema = Sistema.Instancia;
            sistema.PrecargarDatos();
            Cliente clienteElena = sistema.BuscarClientePorNombre("Elena");
            ViewBag.Cliente = clienteElena;
            return View(sistema.Clientes);
        }
    }
}
