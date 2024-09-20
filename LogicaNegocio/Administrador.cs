using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Administrador : Usuario
    {
        public Administrador()
        {

        }
        public Administrador (string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password)
        {

        }
        public override string ToString()
        {
            return "ID Admin : " + this.Id+
                " Nombre Admin : " + this.Nombre+
                " Apellido Admin : " + this.Apellido+
                " Email Admin : " + this.Email+
                " Password Admin : " + this.Password;
        }
    }
}
