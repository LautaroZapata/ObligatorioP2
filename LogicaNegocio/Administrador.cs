using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Administrador : Usuario
    {
        // CONSTRUCTOR
        public Administrador(){}
        public Administrador (string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password)
        {

        }
        // METODOS
        public override string ToString()
        {
            return "ID Admin : " + this.Id+
                "\n Nombre Admin : " + this.Nombre+
                "\n Apellido Admin : " + this.Apellido+
                "\n Email Admin : " + this.Email+
                "\n Password Admin : " + this.Password;
        }
    }
}
