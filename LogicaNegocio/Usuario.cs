using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public abstract class Usuario
    {
        // ATRIBUTOS
        public static int s_proxId = 0;
        private int _idUser;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;
        
        // PROPIEDADES
        public int Id
        {
            get { return _idUser; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        // CONSTRUCTOR
        public Usuario()
        {
            this._idUser = Usuario.s_proxId++;
            
        }

        public Usuario(string nombre, string apellido, string email, string password)
        {
            this._idUser = Usuario.s_proxId++;
            this._nombre = nombre;
            this._apellido = apellido;
            this._email = email;
            this._password = password;

        }

        // METODOS
        public override string ToString()
        {
            return
                "\n Id Usuario : " + this.Id +
                "\n Nombre : " + this.Nombre +
                "\n Apellido : " + this.Apellido +
                "\n Email : " + this.Email +
                "\n Password : " + this.Password;
        }
    }
}
