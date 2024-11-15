using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Venta : Publicacion
    {

        private bool _ofertaRelampago;
        private int _precioVentaTotal;

        public bool OfertaRelampago

        {
            get { return _ofertaRelampago; }
            set { _ofertaRelampago = value; }
        }
        public int PrecioVenta
        {
            get { return _precioVentaTotal; }
            set { _precioVentaTotal = value; }
        }

        public Venta () {}
        public Venta(Estado estado, DateTime fechaPublicacion, List<Articulo> articulos, Cliente clienteComprador, Usuario userCierraVenta, DateTime? fechaFinalizado,string nombre, bool OfertaRelampago) : base(estado, articulos, clienteComprador, userCierraVenta, fechaPublicacion, fechaFinalizado, nombre)
        {
            this._ofertaRelampago = OfertaRelampago;
            this.MontoTotalVenta();
            this.UserCierraVenta = this.ClienteComprador;
 
        }
        public override string ToString()
        {
            return
                "\nTitulo : " + this.Nombre +
                "\nEstado : " + this.Estado +
                "\nArticulos : \n\n" + this.ListaArticulos()+
                "\n\nCliente comprador : " + this.ClienteComprador?.Nombre +
                "\nFinaliza la compra : " + this.UserCierraVenta?.Nombre +
                "\nFecha Publicacion :  " +
                this.FechaPublicacion.Day + "/" + this.FechaPublicacion.Month + "/" + this.FechaPublicacion.Year + "/" +
                "\nEn Oferta Relámpago: " + this.EstaEnOferta();
        }
        public void MontoTotalVenta()
        {
            foreach (Articulo unArticulo in this.Articulos)
            {
                this._precioVentaTotal += unArticulo.PrecioVenta;
            }
        }
        public string EstaEnOferta()
        {
            if (this.OfertaRelampago)
            {

                return "SI \n Precio Total: " + Math.Round(this.PrecioVenta * 0.80);
            }else
            {
                return "NO \n Precio Total: " + this.PrecioVenta;
            }
        }
        //public override int CalcularPrecioPublicacion()
        //{
        //    foreach (Articulo unArticulo in this.Articulos)
        //    {
        //        this._precioVentaTotal += unArticulo.PrecioVenta;
        //    }
        //    return this._precioVentaTotal;
        //}

    }
}
