// See https://aka.ms/new-console-template for more information
using LogicaNegocio;

Sistema sistema = Sistema.Instancia;

int saldoDisponible = int.Parse(Console.ReadLine());
string nombre = Console.ReadLine();
string apellido = Console.ReadLine(); 
string email = Console.ReadLine();
string password = Console.ReadLine();

Usuario cliente1 = new Cliente(saldoDisponible,nombre, apellido,email,password);

string nombreAdmin = Console.ReadLine();
string apellidoAdmin = Console.ReadLine();
string emailAdmin = Console.ReadLine();
string passwordAdmin = Console.ReadLine();

Usuario admin = new Administrador(nombreAdmin, apellidoAdmin, emailAdmin, passwordAdmin);


Console.WriteLine(cliente1.ToString() + " " + admin.ToString());
    

