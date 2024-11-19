using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using WebAppObligatorio.Filters;

namespace WebAppObligatorio.Controllers
{
    [Logueado]
    [ClienteFilter]

    public class PublicacionesController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View(sistema.Publicaciones);
        }
        public IActionResult DetallePublicacion(int id)
        {
            try
            {
                return View(sistema.BuscarPublicacionPorId(id));
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Index", new {mensaje = ex.Message});
            }
        }

        


    }
}
