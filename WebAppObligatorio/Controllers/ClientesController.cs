using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using WebAppObligatorio.Filters;

namespace WebAppObligatorio.Controllers
{
    [Logueado]
    [ClienteFilter]

    public class ClientesController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        //public IActionResult Index(string mensaje)
        //{
        //    Usuario clienteLogueado = sistema.UserLogueado(HttpContext.Session.GetString("email"));

        //    return View(clienteLogueado);
        //}

        [HttpPost]
        public IActionResult Comprar(int id)
        {
            Venta venta = sistema.BuscarVentaPorId(id);
            Usuario clienteLogueado = sistema.UserLogueado(HttpContext.Session.GetString("email"));
            if (clienteLogueado is Cliente cliente)
            {
                if (venta.Estado == Estado.Abierta)
                {
                    bool compraAutorizada = cliente.RealizarCompra(venta.PrecioVenta);
                    if (compraAutorizada)
                    {
                        ViewBag.Mensaje = "Compra realizada con éxito.";
                        venta.CerrarPublicacion(cliente, venta);
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
                Usuario cliente = sistema.UserLogueado(HttpContext.Session.GetString("email"));
                if(cliente is Cliente clienteSubastador)
                if (subasta.Estado == Estado.Abierta)
                {
                    if (puja > 0)
                    {
                        subasta.AgregrarPuja(puja, clienteSubastador);
                        ViewBag.Mensaje = "Puja realizada.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "La puja debe ser mayor a 0.";

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
        public IActionResult RecargarSaldo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecargarSaldo(int saldo)
        {
            try
            {
                Usuario userLogueado = sistema.UserLogueado(HttpContext.Session.GetString("email"));
                sistema.RecargarSaldoCliente(saldo, userLogueado);
                ViewBag.Mensaje = "Recarga exitosa";
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en la recarga";
                ViewBag.Error = ex.Message;
                return View();

            }

        }
        
    }
}

