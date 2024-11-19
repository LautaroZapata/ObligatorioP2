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
            if(venta.Estado ==  Estado.Abierta)
            {
                bool compraAutorizada = cliente.RealizarCompra(venta.PrecioVenta);
                if (compraAutorizada)
                {
                    ViewBag.Mensaje = "Compra realizada con éxito.";
                    venta.CerrarPublicacion();
                }
                else
                {

                    ViewBag.Mensaje = "Saldo Insuficiente";
                }
            }
            else
            {
                ViewBag.Mensaje = "La publicacion se encuentra cerrada";

            }
            return RedirectToAction("Index", "Negocio", new { mensaje = ViewBag.Mensaje });
        }
        public IActionResult Comprar()
        {

            return View();
        }
        public IActionResult Subastar(int id, int puja)
        {
            try
            {
                Subasta subasta = sistema.BuscarSubastaPorId(id);
                Cliente cliente = sistema.BuscarClientePorEmail(HttpContext.Session.GetString("email"));
                if (subasta.Estado == Estado.Abierta)
                {
                    if (puja > subasta.MayorPuja() && cliente.SaldoDisponible >= puja)
                    {
                        subasta.AgregrarPuja(puja, cliente);
                        ViewBag.Mensaje = "Puja realizada.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "La puja es menor a la mayor puja realizada.";

                    }
                }
                else
                {
                    ViewBag.Mensaje = "La subasta esta cerrada.";

                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            
            return RedirectToAction("Index", "Negocio", new { mensaje = ViewBag.Mensaje });
        }


    }
}

