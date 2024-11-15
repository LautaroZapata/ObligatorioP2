using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using WebAppObligatorio.Filters;

namespace WebAppObligatorio.Controllers
{
    [Logueado]

    public class ClientesController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index(string mensaje)
        {
            return View(sistema.Clientes);
        }
        [HttpPost]
        public IActionResult Comprar(int id)
        {
            Venta venta = sistema.BuscarVentaPorId(id);
            Cliente cliente = sistema.BuscarClientePorEmail(HttpContext.Session.GetString("email"));
            bool compraAutorizada = cliente.RealizarCompra(venta.PrecioVenta);
            if(compraAutorizada)
            {
               ViewBag.Mensaje = "Compra realizada con éxito."; 
            }
            else
            {
                
               ViewBag.Mensaje = "Saldo Insuficiente"; ;
            }
            return View("Index","Negocio");
        }
        public IActionResult Comprar()
        {

            return View();
        }

    }
}

