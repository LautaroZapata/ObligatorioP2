﻿using System;
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

        public Subasta(List<Puja>? pujas, Estado estado, DateTime fechaPublicacion, List<Articulo> articulos, Cliente? clienteComprador, Usuario? userCierraVenta, DateTime? fechaFinalizado, string nombre)
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

        public string MayorPuja()
        {
            if (this.Pujas == null || this.Pujas.Count == 0)
            {
                return "No hay pujas.";
            }

            // Encuentra la puja con el monto mayor
            Puja pujaMayor = this.Pujas.Min();

            return pujaMayor.ToString();
        }

    }
}
