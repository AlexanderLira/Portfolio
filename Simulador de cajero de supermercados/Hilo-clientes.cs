using System;
using System.Collections.Generic;
using System.Text;

namespace Simulador_de_cajero_de_supermercados
{
    internal class Clientes
    {
        static bool ejecucion = false;
        
        // Cola compartida thread-safe para los clientes
        public static Queue<Cliente> colaClientes = new Queue<Cliente>();
        public static object lockCola = new object(); // Para sincronización
        
        private static int contadorClientesId = 0;
        private static Random rand_cantidad = new Random();
        private static Random rand_sleep = new Random();

        public static Thread h_clientes = new Thread(() => hilo_cliente());
        
        public static void hilo_cliente()
        {
            Console.WriteLine(" Iniciando generador de clientes ");
            Console.WriteLine("Presione Enter para iniciar generación y Escape para finalizar");

            while (true)
            {
                var tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.Enter && !ejecucion)
                {
                    ejecucion = true;
                    Console.WriteLine("\n=== Creando clientes continuamente \n");

                    while (ejecucion)
                    {
                        if (Console.KeyAvailable)
                        {
                            var teclaGeneracion = Console.ReadKey(true).Key;
                            if (teclaGeneracion == ConsoleKey.Escape)
                            {
                                ejecucion = false;
                                Console.WriteLine("\n\n Generación de clientes detenida ");
                                break;
                            }
                        }

                        // Generar un cliente
                        contadorClientesId++;
                        int cantidadProductos = rand_cantidad.Next(5, 21); // Entre 5 y 20 productos
                        
                        Cliente nuevoCliente = new Cliente(contadorClientesId, cantidadProductos);
                        
                        // Agregar a la cola de forma thread-safe
                        lock (lockCola)
                        {
                            colaClientes.Enqueue(nuevoCliente);
                            Console.WriteLine($"[Cliente {nuevoCliente.Id}] entra en la cola con {nuevoCliente.CantidadProductos} productos. Esperando.");
                        }

                        // Esperar entre 3 y 7 segundos antes de generar el siguiente cliente
                        int tiempoEspera = rand_sleep.Next(3000, 7001);
                        Thread.Sleep(tiempoEspera);
                    }
                }
                else if (tecla == ConsoleKey.Escape)
                {
                    ejecucion = false;
                    Console.WriteLine("\nPrograma finalizado ");
                    break;
                }
            }
        }
        
        public static int ObtenerClientesEnCola()
        {
            lock (lockCola)
            {
                return colaClientes.Count;
            }
        }
    }
}
