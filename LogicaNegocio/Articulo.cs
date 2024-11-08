using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Articulo
    {
        // ATRIBUTOS

        public static int s_proxId = 0;
        private int _idArticulo;
        private string _nombre;
        private string _categoria;
        private int _precioVenta;

        // PROPIEDADES

        public int IdArticulo
        {
            get { return _idArticulo; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public int PrecioVenta
        {
            get { return _precioVenta; }
            set { _precioVenta = value; }
        }

        // CONSTRUCTOR 

        public Articulo()
        {
            this._idArticulo = Articulo.s_proxId++;
        }

        public Articulo (string nombre, string categoria, int precioVenta)
        {
            this._idArticulo = Articulo.s_proxId++;
            this._nombre = nombre;
            this._categoria = categoria;
            this._precioVenta = precioVenta;
        }

        // METODOS

        public override string ToString()
        {
            return
                this.Nombre+
                "\nCategoria : " + this.Categoria +
                "\nPrecio Venta : " + this.PrecioVenta;
        }
        public override bool Equals(Object? obj)
        {
            if (obj == null || !(obj is Articulo)) return false;
            Articulo other = obj as Articulo;
            return this.Nombre == other.Nombre;
        }
    }
}


