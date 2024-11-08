// See https://aka.ms/new-console-template for more information
using LogicaNegocio;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

// Precarga de datos en sistema
Sistema sistema = Sistema.Instancia;
sistema.PrecargarDatos();


// MENU

string opcionMenu = "";
while (opcionMenu != "0")
{
    Console.WriteLine("Seleccione una opcion:\n 0 - Salir \n 1 - Ver lista de clientes \n 2 - Ver articulos de una categoría \n 3 - Dar alta a un articulo \n 4 - Listar publicaciones entre dos fechas \n 5");
    opcionMenu = Console.ReadLine();
    switch (opcionMenu)
    {
        case "0":
            Console.WriteLine("Hasta luego!");
            
            break;
        case "1":
            Console.WriteLine("-- LISTA DE CLIENTES -- \n");
            Console.WriteLine(sistema.ListaClientes());
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            break;
        case "2":
            Console.WriteLine("Ingrese un nombre de categoría");
            string categoria = Console.ReadLine();
            try
            {
               Console.WriteLine(sistema.ListaArticulosMismaCat(categoria));
            }
            catch (Exception)
            {
              Console.WriteLine("No existe esa categoria, intenta con otra");
            }
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            break;
        case "3":
            try
            {
                Console.WriteLine("Ingrese los siguientes datos para agregar su articulo:");
                Console.WriteLine("-- Nombre del Articulo  -- \n");
                string nombreArticulo = Console.ReadLine();
                Console.WriteLine("-- Categoria del Articulo -- \n");
                string categoriaArticulo = Console.ReadLine();
                Console.WriteLine("-- Precio del Articulo -- \n");
                int precioArticulo = int.Parse(Console.ReadLine());
                if (sistema.AltaArticulo(nombreArticulo))
                {
                    sistema.Catalogo.Add(new Articulo(nombreArticulo, categoriaArticulo, precioArticulo));
                }
            }
            catch (Exception) 
            {
                Console.WriteLine("Error en el ingreso del articulo");

            }
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            break;
        case "4":
            try
            {
                Console.WriteLine("Ingrese una fecha");
                DateTime fecha1 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la segunda fecha");
                DateTime fecha2 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(sistema.ListaPublicacionesPorFechas(fecha1, fecha2));
            }
            catch (Exception)
            {
                Console.WriteLine("Fecha inválida. Ingrese en el siguiente formato:(DD-MM-AAAA)");
            }
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            break;
        case "5":
            Console.WriteLine(sistema.MostrarTodasLasPujas());
            break;
    }
}
