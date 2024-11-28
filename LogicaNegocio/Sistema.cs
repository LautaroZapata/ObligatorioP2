using LogicaNegocio;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio
{
    public class Sistema
    {
        // ATRIBUTOS

        private static Sistema s_instancia;
        private List<Usuario> _listaUsuarios = new List<Usuario>();
        private List<Publicacion> _listaPublicaciones = new List<Publicacion>();
        private List<Administrador> _listaAdministradores = new List<Administrador>();
        private List<Subasta> _listaSubastas = new List<Subasta>();


        private List<Articulo> _catalogo = new List<Articulo>();
        private List<Cliente> _listaClientes = new List<Cliente>();

        // PROPIEDADES

        public List<Cliente> Clientes {get { return _listaClientes; }}
        public List<Usuario> Usuarios {get {return _listaUsuarios; } }
        public List<Publicacion> Publicaciones { get { return _listaPublicaciones; } }
        public List<Administrador> Administradores { get { return _listaAdministradores; } }
        public List<Subasta> Subastas { get { return _listaSubastas; } }

        public List<Articulo> Catalogo { get { return _catalogo; } }


        // CONSTRUCTOR
        private Sistema()
        {
            this.PrecargarDatos();
        }

        // METODOS
        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }

        public void PrecargarDatos()
        {
            // Precarga de administradores con nombres simulados
            this._listaAdministradores.Add(new Administrador("Carlos", "Mendoza", "carlos.mendoza@example.com", "adminPass1"));
            this._listaAdministradores.Add(new Administrador( "Laura", "Gómez", "laura.gomez@example.com", "adminPass2"));
            foreach (Administrador admin in this._listaAdministradores)
            {
                this._listaUsuarios.Add(admin);
            }

            // Precarga de clientes con nombres simulados
            this._listaClientes.Add(new Cliente(4200, "Juan", "Pérez", "juan.perez@example.com", "password1"));
            this._listaClientes.Add(new Cliente(3300, "María" , "López", "maria.lopez@example.com", "password2"));
            this._listaClientes.Add(new Cliente(4450, "Pedro", "García", "pedro.garcia@example.com", "password3"));
            this._listaClientes.Add(new Cliente(2500, "Ana", "Martínez", "ana.martinez@example.com", "password4" ));
            this._listaClientes.Add(new Cliente(7150, "Luis", "Ramírez", "luis.ramirez@example.com", "password5"));
            this._listaClientes.Add(new Cliente(6220, "Marta" , "Fernández", "marta.fernandez@example.com", "password6"));
            this._listaClientes.Add(new Cliente(3480, "José" , "Sánchez", "jose.sanchez@example.com", "password7"));
            this._listaClientes.Add(new Cliente(5200, "Elena" , "Vargas", "elena.vargas@example.com", "password8"));
            this._listaClientes.Add(new Cliente(4310, "David" , "Ortiz", "david.ortiz@example.com", "password9"));
            this._listaClientes.Add(new Cliente(6380, "Carolina" , "Hernández", "carolina.hernandez@example.com", "password10"));
            foreach (Cliente cliente in this._listaClientes)
            {
                this._listaUsuarios.Add(cliente);
            }
            // Precarga de articulos con nombres simulados

            this._catalogo.Add(new Articulo("Laptop Lenovo", "Electronica", 745));
            this._catalogo.Add(new Articulo("Silla de Escritorio", "Hogar", 625));
            this._catalogo.Add(new Articulo("Camiseta Nike", "Ropa", 202));
            this._catalogo.Add(new Articulo("Pelota de Fútbol", "Deportes", 556));
            this._catalogo.Add(new Articulo("Lego Star Wars", "Juguetes", 453));
            this._catalogo.Add(new Articulo("Smartphone Samsung", "Electronica", 890));
            this._catalogo.Add(new Articulo("Almohada Viscoelástica", "Hogar", 421));
            this._catalogo.Add(new Articulo("Zapatillas Adidas", "Ropa", 643));
            this._catalogo.Add(new Articulo("Bicicleta de Montaña", "Deportes", 799));
            this._catalogo.Add(new Articulo("Muñeca Barbie", "Juguetes", 352));
            this._catalogo.Add(new Articulo("Tablet Apple", "Electronica", 510));
            this._catalogo.Add(new Articulo("Juego de Sartenes", "Hogar", 720));
            this._catalogo.Add(new Articulo("Pantalón Levis", "Ropa", 545));
            this._catalogo.Add(new Articulo("Raqueta de Tenis", "Deportes", 482));
            this._catalogo.Add(new Articulo("Rompecabezas 1000 Piezas", "Juguetes", 392));
            this._catalogo.Add(new Articulo("Televisor Samsung 55\"", "Electronica", 835));
            this._catalogo.Add(new Articulo("Sofá de Cuero", "Hogar", 519));
            this._catalogo.Add(new Articulo("Camisa Formal", "Ropa", 316));
            this._catalogo.Add(new Articulo("Pesas de 5kg", "Deportes", 230));
            this._catalogo.Add(new Articulo("Playmobil Aventuras", "Juguetes", 698));
            this._catalogo.Add(new Articulo("Monitor Gaming", "Electronica", 953));
            this._catalogo.Add(new Articulo("Licuadora Oster", "Hogar", 384));
            this._catalogo.Add(new Articulo("Abrigo de Invierno", "Ropa", 755));
            this._catalogo.Add(new Articulo("Balón de Baloncesto", "Deportes", 487));
            this._catalogo.Add(new Articulo("Pista Hot Wheels", "Juguetes", 613));
            this._catalogo.Add(new Articulo("Cámara Canon", "Electronica", 468));
            this._catalogo.Add(new Articulo("Ventilador de Techo", "Hogar", 670));
            this._catalogo.Add(new Articulo("Vestido de Verano", "Ropa", 287));
            this._catalogo.Add(new Articulo("Cinta de Correr", "Deportes", 788));
            this._catalogo.Add(new Articulo("Puzzle 3D Castillo", "Juguetes", 210));
            this._catalogo.Add(new Articulo("Audífonos Bluetooth", "Electronica", 703));
            this._catalogo.Add(new Articulo("Juego de Cuchillos", "Hogar", 455));
            this._catalogo.Add(new Articulo("Chaqueta Deportiva", "Ropa", 632));
            this._catalogo.Add(new Articulo("Patines en Línea", "Deportes", 710));
            this._catalogo.Add(new Articulo("Figura de Acción Marvel", "Juguetes", 586));
            this._catalogo.Add(new Articulo("Impresora HP", "Electronica", 935));
            this._catalogo.Add(new Articulo("Microondas Whirlpool", "Hogar", 519));
            this._catalogo.Add(new Articulo("Pantalones Cortos", "Ropa", 365));
            this._catalogo.Add(new Articulo("Set de Mancuernas", "Deportes", 529));
            this._catalogo.Add(new Articulo("Peluche Gigante", "Juguetes", 399));
            this._catalogo.Add(new Articulo("Consola PlayStation 5", "Electronica", 980));
            this._catalogo.Add(new Articulo("Cortinas Blackout", "Hogar", 620));
            this._catalogo.Add(new Articulo("Traje de Baño", "Ropa", 320));
            this._catalogo.Add(new Articulo("Saco de Boxeo", "Deportes", 455));
            this._catalogo.Add(new Articulo("Carro de Juguete", "Juguetes", 289));
            this._catalogo.Add(new Articulo("Smartwatch Xiaomi", "Electronica", 725));
            this._catalogo.Add(new Articulo("Colchón Matrimonial", "Hogar", 799));
            this._catalogo.Add(new Articulo("Suéter de Lana", "Ropa", 490));
            this._catalogo.Add(new Articulo("Pelota de Yoga", "Deportes", 325));
            this._catalogo.Add(new Articulo("Casa de Muñecas", "Juguetes", 610));

            // Precarga de publicaciones
                // Crear listas de artículos para las publicaciones de ventas, agrupados por categoría (mínimo 3, máximo 5 artículos)

                // Venta 1 - Categoría: Electrónica
                List<Articulo> articulosVenta1 = new List<Articulo> { _catalogo[0], _catalogo[5], _catalogo[11] };  // Laptop Lenovo, Smartphone Samsung, Tablet Apple

                // Venta 2 - Categoría: Hogar
                List<Articulo> articulosVenta2 = new List<Articulo> { _catalogo[1], _catalogo[6], _catalogo[12], _catalogo[19] };  // Silla de Escritorio, Almohada Viscoelástica, Juego de Sartenes, Microondas Whirlpool

                // Venta 3 - Categoría: Ropa
                List<Articulo> articulosVenta3 = new List<Articulo> { _catalogo[2], _catalogo[7], _catalogo[13], _catalogo[16] };  // Camiseta Nike, Zapatillas Adidas, Pantalón Levis, Camisa Formal

                // Venta 4 - Categoría: Deportes
                List<Articulo> articulosVenta4 = new List<Articulo> { _catalogo[3], _catalogo[8], _catalogo[14] };  // Pelota de Fútbol, Bicicleta de Montaña, Raqueta de Tenis

                // Venta 5 - Categoría: Juguetes
                List<Articulo> articulosVenta5 = new List<Articulo> { _catalogo[4], _catalogo[9], _catalogo[15], _catalogo[17] };  // Lego Star Wars, Muñeca Barbie, Rompecabezas 1000 Piezas, Figura de Acción Marvel

                // Crear las publicaciones de ventas
                this._listaPublicaciones.Add(new Venta(Estado.Abierta, DateTime.Now, articulosVenta1, null, null, null, "Conectando con el futuro", false));
                this._listaPublicaciones.Add(new Venta(Estado.Abierta, DateTime.Now, articulosVenta2, null, null, null, "Comodidad y funcionalidad para tu hogar", true));
                this._listaPublicaciones.Add(new Venta(Estado.Abierta, DateTime.Now, articulosVenta3, null, null, null, "Estilo para cada ocasión", false));
                this._listaPublicaciones.Add(new Venta(Estado.Abierta, DateTime.Now, articulosVenta4, null, null, null, "Preparados para la acción", true));
                this._listaPublicaciones.Add(new Venta(Estado.Abierta, DateTime.Now, articulosVenta5, null, null, null, "Diversión para todos los niños", false));

                // Crear listas de artículos para las publicaciones de subastas, agrupados por categoría (mínimo 3, máximo 5 artículos)

                // Subasta 1 - Categoría: Electrónica
                List<Articulo> articulosSubasta1 = new List<Articulo> { _catalogo[0], _catalogo[5], _catalogo[10], _catalogo[19] };  // Laptop Lenovo, Smartphone Samsung, Tablet Apple, Microondas Whirlpool

                // Subasta 2 - Categoría: Deportes
                List<Articulo> articulosSubasta2 = new List<Articulo> { _catalogo[3], _catalogo[8], _catalogo[13], _catalogo[18] };  // Pelota de Fútbol, Bicicleta de Montaña, Raqueta de Tenis, Balón de Baloncesto

                // Subasta 3 - Categoría: Juguetes
                List<Articulo> articulosSubasta3 = new List<Articulo> { _catalogo[4], _catalogo[9], _catalogo[14], _catalogo[17], _catalogo[19] };  // Lego Star Wars, Muñeca Barbie, Rompecabezas 1000 Piezas, Figura de Acción Marvel, Pista Hot Wheels

                // Subasta 4 - Categoría: Hogar
                List<Articulo> articulosSubasta4 = new List<Articulo> { _catalogo[1], _catalogo[6], _catalogo[12], _catalogo[16] };  // Silla de Escritorio, Almohada Viscoelástica, Juego de Sartenes, Sofá de Cuero

                // Subasta 5 - Categoría: Ropa
                List<Articulo> articulosSubasta5 = new List<Articulo> { _catalogo[2], _catalogo[7], _catalogo[13], _catalogo[15], _catalogo[16] };  // Camiseta Nike, Zapatillas Adidas, Pantalón Levis, Camisa Formal, Abrigo de Invierno

                List<Puja> listaPujas1 = new List<Puja>();
                List<Puja> listaPujas2 = new List<Puja>();

                // Añadir pujas a la lista 1 (Subasta 1 - Electrónica)
                listaPujas1.Add(new Puja(0, _listaClientes[0], 1000, DateTime.Now.AddDays(-1)));
                listaPujas1.Add(new Puja(1, _listaClientes[1], 1500, DateTime.Now.AddHours(-3)));
                listaPujas1.Add(new Puja(2, _listaClientes[2], 2000, DateTime.Now.AddMinutes(-30)));
                

                // Añadir pujas a la lista 2 (Subasta 2 - Deportes)
                listaPujas2.Add(new Puja(3, _listaClientes[3], 500, DateTime.Now.AddDays(-2)));
                listaPujas2.Add(new Puja(4, _listaClientes[0], 800, DateTime.Now.AddHours(-5)));
                listaPujas2.Add(new Puja(5, _listaClientes[1], 1100, DateTime.Now.AddMinutes(-45)));
                listaPujas2.Add(new Puja(6, _listaClientes[4], 1300, DateTime.Now.AddMinutes(-15)));

            // Crear las publicaciones de subastas
            this._listaSubastas.Add(new Subasta(listaPujas1, Estado.Abierta, DateTime.Now, articulosSubasta1, null,null,null, "Ofertas tecnológicas que no puedes perder"));
                this._listaSubastas.Add(new Subasta(listaPujas2, Estado.Abierta, DateTime.Now.AddDays(3), articulosSubasta2, null,null, null, "Todo lo que necesitas para tu aventura al aire libre"));
                this._listaSubastas.Add(new Subasta(null,Estado.Abierta, DateTime.Now.AddDays(4), articulosSubasta3, null, null, null, "Imagina, construye y diviértete"));
                this._listaSubastas.Add(new Subasta(null,Estado.Abierta, DateTime.Now.AddDays(5), articulosSubasta4, null, null, null, "Renueva tu espacio con estilo"));
                this._listaSubastas.Add(new Subasta(null,Estado.Abierta, DateTime.Now.AddDays(6), articulosSubasta5, null, null, null, "Confort y moda para tu día a día"));

            foreach(Subasta subasta in this._listaSubastas)
            {
                this._listaPublicaciones.Add(subasta);
            }
            
        }

        public string ListaClientes()
        {
            string lista = "";
            foreach(Cliente c in _listaClientes)
            {
                if (_listaClientes.Count == 0)
                {
                    lista = "NO EXISTEN CLIENTES";
                }else
                {
                    lista += c.ToString() + "\n" + "\n";
                }
            }
            return lista;
        }

        public string ListaArticulosMismaCat(string categoria)
        {
            string listaFiltrada = "";
            foreach (Articulo unArticulo in this._catalogo)
            {
                if (unArticulo.Categoria == categoria)
                {
                    listaFiltrada += "\n" + unArticulo.ToString() + "\n" + "\n";
                }
            }
            if (listaFiltrada == "")
            {
                throw new Exception();
            }
            return listaFiltrada;
        }

        public string ListaPublicacionesPorFechas (DateTime fecha1, DateTime fecha2)
        {
            string listaPublicaciones = "";
            DateTime fechaMayor;
            DateTime fechaMenor;

            if (fecha1 > fecha2)
            {
                fechaMayor = fecha1;
                fechaMenor = fecha2;
                foreach (Publicacion unaPublicacion in this._listaPublicaciones)
                {
                    if (unaPublicacion.FechaPublicacion >= fechaMenor && unaPublicacion.FechaPublicacion <= fechaMayor)
                    {
                        listaPublicaciones += unaPublicacion.ToString() + "\n";
                        
                    }
                    else
                    {
                        listaPublicaciones = "No existen publicaciones entre esas fechas";
                    }
                }
                return listaPublicaciones;
            }
            else
            {
                fechaMayor = fecha2;
                fechaMenor = fecha1;
                foreach (Publicacion unaPublicacion in this._listaPublicaciones)
                {
                    if (unaPublicacion.FechaPublicacion >= fechaMenor && unaPublicacion.FechaPublicacion <= fechaMayor)
                    {
                      listaPublicaciones += unaPublicacion.ToString() + "\n";
                        
                    }
                    else
                    {
                        listaPublicaciones = "No existen publicaciones entre esas fechas";

                    }
                }
                return listaPublicaciones;
            }
        }
        public bool AltaArticulo (string nombre)
        {
            bool retorno = false;
            foreach (Articulo articulo in this._catalogo)
            {
                if (nombre.Equals(articulo.Nombre))
                {
                    throw new Exception();
                }
                else
                {
                    
                    retorno = true;
                }
            }

            return retorno;
        }
        public Cliente BuscarClientePorNombre (string nombre)
        {
            foreach (Cliente cliente in _listaClientes)
            {
                if(cliente.Nombre == nombre)
                {
                    return cliente;
                }
            }
            throw new Exception("No existe cliente con ese nombre");
        }
        public string MostrarTodasLasPujas()
        {
            string cant = "";
            if (this._listaSubastas == null || this._listaSubastas.Count == 0)
            {
                return cant = "No hay subastas disponibles.";
            }else
            {
                // Recorremos todas las subastas en la lista
                foreach (Subasta subasta in this._listaSubastas)
                {
                    // Para cada subasta, recorremos su lista de pujas
                    foreach (Puja puja in subasta.Pujas)
                    {
                        cant += puja.ToString() + "\n";  // Incluye salto de línea entre pujas, si quieres separarlas
                    }
                }
                
            }

            return cant;
        }
        public Publicacion BuscarPublicacionPorId(int id)
        {
            foreach(Publicacion unaPublicacion in _listaPublicaciones)
            {
                if(unaPublicacion.Id == id)
                {
                    return unaPublicacion;
                }
            }
            throw new Exception("No existe una publicacion con ese ID");
        }
        public Usuario AutenticarUser (string email, string password)
        {
            foreach (Usuario user in _listaUsuarios)
            {
                if (user.Email == email)
                {
                    if (user.Password != password)
                    {
                        throw new Exception("Password incorrecta");
                    }
                    else
                    {
                        return user;
                    }
                }
            }
            throw new Exception("El email es incorrecto");
        }
        public Venta BuscarVentaPorId(int id)
        {
            foreach (Publicacion unaPublicacion in _listaPublicaciones)
            {
                if (unaPublicacion is Venta unaVenta && unaVenta.Id == id)
                {
                    return unaVenta;
                }
            }
            throw new Exception("No existe una venta con ese ID");
        }
  
        public Usuario UserLogueado(string email)
        {
            foreach(Usuario user in this.Usuarios)
            {
                if(user.Email == email)
                {
                    return user;
                }
            }
            throw new Exception("No esta logueado ningun usuario");
        }
        public Subasta BuscarSubastaPorId(int id)
        {
            foreach (Publicacion unaPublicacion in _listaPublicaciones)
            {
                if (unaPublicacion is Subasta unaSubasta && unaSubasta.Id == id)
                {
                    return unaSubasta;
                }
            }
            throw new Exception("No existe una venta con ese ID");
        }
        public void RecargarSaldoCliente(int saldo, Usuario usuario)
        {
            if (saldo <= 0)
            {
                throw new Exception("El saldo a recargar debe ser mayor a 0");
            }

            if (usuario is Cliente cliente)
            {
                cliente.SaldoDisponible += saldo;
            }
            else
            {
                throw new Exception("El usuario no es un cliente válido.");
            }
        }
        public void OrdenarPujasPorMonto()
        {
            foreach(Subasta subasta in this._listaSubastas)
            {
                subasta.Pujas.Sort();
            }
        }
        public void VerificarPass(string pass)
        {
            if(pass.Length < 8 || ) { }
        }
        public void RegistrarCliente(string email, string pass)
        {

        }
        
    }
}

