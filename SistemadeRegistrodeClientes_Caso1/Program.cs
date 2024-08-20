using System;
using System.Collections.Generic;

namespace SistemaRegistroClientes
{
    
    class Cliente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }

        public Cliente(string nombre, int edad, string correo)
        {
            Nombre = nombre;
            Edad = edad;
            Correo = correo;
        }

        
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Correo: {Correo}");
        }
    }

    
    class ClienteCorporativo : Cliente
    {
        public string NombreEmpresa { get; set; }

        public ClienteCorporativo(string nombre, int edad, string correo, string nombreEmpresa)
            : base(nombre, edad, correo)
        {
            NombreEmpresa = nombreEmpresa;
        }

       
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Nombre de la Empresa: {NombreEmpresa}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Agregar nuevo cliente");
                Console.WriteLine("2. Mostrar lista de clientes");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarCliente(clientes);
                        break;
                    case "2":
                        MostrarClientes(clientes);
                        break;
                    case "3":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void AgregarCliente(List<Cliente> clientes)
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();

            int edad;
            while (true)
            {
                Console.Write("Ingrese la edad del cliente: ");
                if (int.TryParse(Console.ReadLine(), out edad) && edad > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Edad no válida. Intente de nuevo.");
                }
            }

            Console.Write("Ingrese el correo del cliente: ");
            string correo = Console.ReadLine();

            Console.Write("¿Es un cliente corporativo? (S/N): ");
            string esCorporativo = Console.ReadLine().ToUpper();

            if (esCorporativo == "S")
            {
                Console.Write("Ingrese el nombre de la empresa: ");
                string nombreEmpresa = Console.ReadLine();
                clientes.Add(new ClienteCorporativo(nombre, edad, correo, nombreEmpresa));
            }
            else if (esCorporativo == "N")
            {
                clientes.Add(new Cliente(nombre, edad, correo));
            }
            else
            {
                Console.WriteLine("Entrada no válida. Cliente no agregado.");
            }
        }

        static void MostrarClientes(List<Cliente> clientes)
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            Console.WriteLine("\nLista de Clientes:");
            foreach (var cliente in clientes)
            {
                cliente.MostrarInformacion();
                Console.WriteLine(); 
            }
        }
    }
}