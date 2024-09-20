using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente : Usuario
    {
        private int _saldoDisponible;

        public int SaldoDisponible
        {
            get { return _saldoDisponible; }
            set { _saldoDisponible = value; }
        }

        public Cliente(int saldoDisponible, string nombre, string apellido, string email, string password) : base(nombre,apellido,email,password)
        {
            this._saldoDisponible = saldoDisponible;
        }

        public override string ToString()
        {
            return 
                "ID Usuario: " + this.Id +
                " \n Saldo disponible : " + this.SaldoDisponible +
                " \n Nombre : " + this.Nombre +
                " \n Apellido : " + this.Apellido +
                " \n Email : " + this.Email +
                " \n Password :  " + this.Password;
        }
    }
}
