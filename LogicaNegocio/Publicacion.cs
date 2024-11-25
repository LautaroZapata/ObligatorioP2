using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public abstract class Publicacion
    {
        // ATRIBUTOS
        public static int s_proxId = 0;
        private int _idPublicacion;
        private Estado _estado;
        private List<Articulo> _articulos;
        private Usuario? _clienteComprador;
        private Usuario? _userCierraVenta;
        private DateTime _fechaPublicacion;
        private DateTime? _fechaFinalizado;
        private string _nombre;

        // PROPIEDADES
        public int Id
        {
            get { return _idPublicacion; }
        }

        public Estado Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public List<Articulo> Articulos
        {
            get { return _articulos; }
            set { _articulos = value; }
        }
        public Usuario ClienteComprador
        {
            get { return _clienteComprador; }
            set { _clienteComprador = value; }
        }
        public Usuario UserCierraVenta
        {
            get { return _userCierraVenta; }
            set { _userCierraVenta = value; }
        }

        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }

        public DateTime? FechaFinalizado
        {
            get { return _fechaFinalizado; }
            set { _fechaFinalizado = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }



        // CONSTRUCTOR
        public Publicacion()
        {
            this._idPublicacion = Publicacion.s_proxId++;
        }

        public Publicacion(Estado estado, List<Articulo> articulos, Usuario? clienteComprador, Usuario? userCierraVenta, DateTime fechaPublicacion, DateTime? fechaFinalizado, string nombre)
        {
            this._idPublicacion = Publicacion.s_proxId++;
            this.Estado = estado;
            this.Articulos = articulos;
            this.ClienteComprador = clienteComprador;
            this.UserCierraVenta = userCierraVenta;
            this.FechaPublicacion = fechaPublicacion;
            this.FechaFinalizado = fechaFinalizado;
            this.Nombre = nombre;
        }

        // METODOS

        public string ListaArticulos()
        {
            string listaArticulos = "";
            foreach (Articulo unArticulo in this.Articulos)
            {
                listaArticulos += unArticulo + " - ";
            }
            return listaArticulos;
        }
        public abstract void CerrarPublicacion(Usuario user, Publicacion publicacion);
    }
}
