using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class Subasta : Publicacion
    {
        // ATRIBUTOS
        private List<Puja> _listaPujas = new List<Puja>();

        // PROPIEDADES
        public List<Puja> Pujas { get { return _listaPujas; } }

        // CONSTRUCTORES
        public Subasta() { }

        public Subasta(List<Puja>? pujas, Estado estado, DateTime fechaPublicacion, List<Articulo> articulos, Usuario? clienteComprador, Usuario? userCierraVenta, DateTime? fechaFinalizado, string nombre)
            : base(estado, articulos, clienteComprador, userCierraVenta, fechaPublicacion, fechaFinalizado, nombre)
        {
            if (pujas != null)
            {
                this._listaPujas = pujas;
            }
            else
            {
                this._listaPujas = new List<Puja>();
            }
        }

        // MÉTODOS
        public override string ToString()
        {
            return
                "\nTitulo : " + this.Nombre +
                "\nEstado : " + this.Estado +
                "\nArticulos : \n\n" + this.ListaArticulos() +
                "\n\nCliente Mayor Puja : " + MayorPuja() + 
                "\nFinaliza la compra : " + this.UserCierraVenta?.Nombre +
                "\nFecha Publicacion :  " +
                this.FechaPublicacion.Day + "/" + this.FechaPublicacion.Month + "/" + this.FechaPublicacion.Year;
        }

        public int MayorPuja()
        {
            if (this.Pujas == null || this.Pujas.Count == 0)
            {
                return 0;
            }

            // Encuentra la puja con el monto mayor
            Puja pujaMayor = this.Pujas.Max();

            return pujaMayor.MontoOfertado;
        }

        public void AgregrarPuja(int puja, Cliente cliente)
        {
            foreach (Puja unaPuja in this.Pujas)
            {
                if(unaPuja.UsuarioPuja == cliente)
                {
                    throw new Exception("Ya tienes una puja realizada.");
                }
            }
            Puja nuevaPuja = new Puja
            {
                MontoOfertado = puja,
                UsuarioPuja = cliente,
                FechaPuja = DateTime.Now
            };

            // Agregar la nueva puja a la lista
            this._listaPujas.Add(nuevaPuja);
        }
        public override void CerrarPublicacion(Usuario user){}
    }
}
