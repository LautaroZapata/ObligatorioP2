using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente : Usuario
    {
        // ATRIBUTOS
        private int _saldoDisponible;

        // PROPIEDADES
        public int SaldoDisponible
        {
            get { return _saldoDisponible; }
            set { _saldoDisponible = value; }
        }

        // CONSTRUCTOR

        public Cliente(int saldoDisponible, string nombre, string apellido, string email, string password) : base(nombre,apellido,email,password)
        {
            this._saldoDisponible = saldoDisponible;
        }
        // METODOS
        public override string ToString()
        {
            return 
                "ID Usuario: " + this.Id +
                "\n Saldo disponible : " + this.SaldoDisponible +
                "\n Nombre : " + this.Nombre +
                "\n Apellido : " + this.Apellido +
                "\n Email : " + this.Email +
                "\n Password :  " + this.Password;
        }
        public bool RealizarCompra(int montoTotal)
        {
            if(SaldoDisponible >= montoTotal)
            {
                SaldoDisponible -= montoTotal;
                return true;
            }
            return false;
        }
    }
}
