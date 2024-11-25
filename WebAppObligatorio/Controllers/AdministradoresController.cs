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
        public IActionResult SubastasAdmin() 
        {
            try
            {
                return View(sistema.Subastas);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "No se encuentran subastas";
                return RedirectToAction("Index", "Negocio");
            }
        }
        [HttpPost]
        public IActionResult CerrarSubasta(int id)
        {
            try
            {
                sistema.OrdenarPujasPorMonto();
                Subasta subasta = sistema.BuscarSubastaPorId(id);
                Usuario adminCierraSubasta = sistema.UserLogueado(HttpContext.Session.GetString("email"));
                subasta.CerrarPublicacion(adminCierraSubasta, subasta);
                ViewBag.Mensaje = "Subasta cerrada con exito";

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en cerrar la subasta";

            }
            return RedirectToAction("Index", "Negocio", new { mensaje = ViewBag.Mensaje });
        }
        public IActionResult CerrarSubasta()
        {
            return View();

        }

    }

}
