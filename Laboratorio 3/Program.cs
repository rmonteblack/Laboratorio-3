using System;
using System.Collections.Generic;

namespace Laboratorio_3
{
    class Program
    {
        static List<Clientes> cliente = new List<Clientes>();
        static List<Vehiculo> carro = new List<Vehiculo>();
        static List<Pedidos> pedidos = new List<Pedidos>();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema de la Tienda Landivar");
                Console.WriteLine("Por favor seleccione una opción para continuar:");
                Console.WriteLine("1. Registrar clientes");
                Console.WriteLine("2. Registrar vehiculo");
                Console.WriteLine("3. Salir");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        RegistrarCliente();
                        break;
                    case "2":
                        RegistrarVehiculo();
                        break;
                    case "3":
                        Console.WriteLine("Gracias por usar nuestros servicios");
                        Console.WriteLine("Feliz Día");
                        Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                
                Menu2();
            }
        }

        static void Menu2()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Opciones disponibles:");
                Console.WriteLine("1. Registrar clientes");
                Console.WriteLine("2. Registrar vehiculo");
                Console.WriteLine("3. Salir");
                Console.WriteLine("4. Registrar pedido");
                Console.WriteLine("5. Mostrar detalles de clientes");
                Console.WriteLine("6. Mostrar detalles de vehículos");
                Console.WriteLine("7. Mostrar detalles de pedidos");
                Console.WriteLine("8. Buscar cliente por nombre");
                Console.WriteLine("9. Buscar vehiculo por matricula");
                Console.WriteLine("10. Buscar pedido por número");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        RegistrarCliente();
                        break;
                    case "2":
                        RegistrarVehiculo();
                        break;
                    case "3":
                        Console.WriteLine("Gracias por usar nuestros servicios");
                        Console.WriteLine("Feliz Día");
                        Environment.Exit(0); 
                        break;
                    case "4":
                        RegistrarPedido();
                        break;
                    case "5":
                        InfoCliente();
                        break;
                    case "6":
                        InfoVehiculo();
                        break;
                    case "7":
                        InfoPedidos();
                        break;
                    case "8":
                        BuscarCliente();
                        break;
                    case "9":
                        BuscarVehiculo();
                        break;
                    case "10":
                        BuscarPedido();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void RegistrarCliente()
        {
            Console.Clear();
            Console.WriteLine("Seleccione el tipo de cliente que desea agregar:");
            Console.WriteLine("1. Cliente Regular");
            Console.WriteLine("2. Cliente VIP");
            Console.WriteLine("3. Cliente Corporativo");
            string tipoCliente = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el correo del cliente:");
            string correo = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección del cliente:");
            string direccion = Console.ReadLine();

            cliente.Add(new Clientes(nombre, correo, direccion));
            Console.WriteLine("Cliente agregado exitosamente.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void RegistrarVehiculo()
        {
            Console.Clear();
            Console.Write("Ingrese la matrícula del vehículo: ");
            int matricula = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el modelo del vehículo: ");
            int modelo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el tipo de combustible del vehículo: ");
            string combustible = Console.ReadLine();

            carro.Add(new Vehiculo(matricula, modelo, combustible));
            Console.WriteLine("Vehículo agregado exitosamente.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void RegistrarPedido()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del cliente para el pedido:");
            string nombreCliente = Console.ReadLine();

            Clientes clienteExistente = cliente.Find(c => c.Nombre.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase));
            if (clienteExistente == null)
            {
                Console.WriteLine("El cliente no se ha encontrado, registre un cliente para continuar con su pedido.");
                Console.WriteLine("¿Desea continuar (s/n)?");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "s")
                {
                    RegistrarCliente();
                    clienteExistente = cliente.Find(c => c.Nombre.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    return; 
                }
            }

            Console.WriteLine("Ingrese la matrícula del vehículo para el pedido:");
            int matriculaVehiculo = int.Parse(Console.ReadLine());

            Vehiculo vehiculoExistente = carro.Find(v => v.Matricula == matriculaVehiculo);
            if (vehiculoExistente == null)
            {
                Console.WriteLine("El vehículo no se ha encontrado, registre un vehículo para continuar con su pedido.");
                Console.WriteLine("¿Desea continuar (s/n)?");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "s")
                {
                    RegistrarVehiculo();
                    vehiculoExistente = carro.Find(v => v.Matricula == matriculaVehiculo);
                }
                else
                {
                    return; 
                }
            }

            Console.WriteLine("Ingrese el número del pedido:");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha para su pedido:");
            int fecha = int.Parse(Console.ReadLine());
            Console.WriteLine("Seleccione de qué lista quiere su pedido (frutas, verduras):");
            string lista = Console.ReadLine();
            pedidos.Add(new Pedidos(numero, fecha, clienteExistente, vehiculoExistente, lista));

            Console.WriteLine("Pedido registrado exitosamente.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void InfoCliente()
        {
            Console.Clear();
            Console.WriteLine("Detalles de los clientes registrados:");
            foreach (var c in cliente)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void InfoVehiculo()
        {
            Console.Clear();
            Console.WriteLine("Detalles de los vehículos registrados:");
            foreach (var v in carro)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void InfoPedidos()
        {
            Console.Clear();
            Console.WriteLine("Detalles de los pedidos registrados:");
            foreach (var p in pedidos)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarCliente()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del cliente para buscarlo:");
            string nombre = Console.ReadLine();
            var clienteEncontrado = cliente.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (clienteEncontrado != null)
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine(clienteEncontrado);
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarVehiculo()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la matrícula del vehículo para buscarlo:");
            int matricula = int.Parse(Console.ReadLine());

            var vehiculoEncontrado = carro.Find(v => v.Matricula == matricula);
            if (vehiculoEncontrado != null)
            {
                Console.WriteLine("Vehículo encontrado:");
                Console.WriteLine(vehiculoEncontrado);
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarPedido()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el número de pedido para buscarlo:");
            int numero = int.Parse(Console.ReadLine());

            var pedidoEncontrado = pedidos.Find(p => p.Numero == numero);
            if (pedidoEncontrado != null)
            {
                Console.WriteLine("Pedido encontrado:");
                Console.WriteLine(pedidoEncontrado);
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
