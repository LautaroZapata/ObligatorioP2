using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Puja : IComparable<Puja>
    {
        // ATRIBUTOS
        public static int s_proxId = 0;
        private int _idPuja;
        private Cliente _usuarioPuja;
        private int _montoOfertado;
        private DateTime _fechaPuja;

        // PROPIEDADES
        public int IdPuja
        {
            get { return _idPuja; }
        }

        public Cliente UsuarioPuja
        {
            get { return _usuarioPuja; }
            set { _usuarioPuja = value; }
        }

        public int MontoOfertado
        {
            get { return _montoOfertado; }
            set { _montoOfertado = value; }
        }

        public DateTime FechaPuja
        {
            get { return _fechaPuja; }
            set { _fechaPuja = value; }
        }

        // CONSTRUCTORES

        public Puja ()
        {
            this._idPuja = Puja.s_proxId++;
        }
        public Puja(int IdPuja, Cliente UsuarioPuja, int MontoOfertado, DateTime FechaPuja)
        {
            this._idPuja = Puja.s_proxId++;
            this._usuarioPuja = UsuarioPuja;
            this._montoOfertado= MontoOfertado;
            this._fechaPuja=FechaPuja;
        }

        public override string ToString()
        {
            string username;

            if (this.UsuarioPuja != null)
            {
                username = this.UsuarioPuja.Nombre.ToString();
            }
            else
            {
                username = "Sin usuario";
            }

            return
                "Mayor monto ofertado: " + this.MontoOfertado;
        }

        public int CompareTo(Puja? other)
        {
            return this.MontoOfertado.CompareTo(other.MontoOfertado) * -1;
        }

    }
}
