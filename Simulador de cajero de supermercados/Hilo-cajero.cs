using Simulador_de_cajero_de_supermercados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Simulador_de_cajero_de_supermercados
{
    internal class Hilo_cajero
    {
        static bool ejecucion = false;
        public static List<int> id_cajeros = new List<int> { 1, 2 };
        
        // Estadísticas
        private static Dictionary<int, int> clientesAtendidosPorCajero = new Dictionary<int, int>();
        private static Dictionary<int, int> tiempoTotalPorCajero = new Dictionary<int, int>();

        public static void cajeros()
        {
            // Inicializar estadísticas
            foreach (int cajeroId in id_cajeros)
            {
                clientesAtendidosPorCajero[cajeroId] = 0;
                tiempoTotalPorCajero[cajeroId] = 0;
            }

            Console.WriteLine(" Sistema de cajeros iniciado ");
            Console.WriteLine($"Cajeros disponibles: {id_cajeros.Count}");
            Console.WriteLine("Presione Enter para que los cajeros empiecen a trabajar");
            Console.WriteLine("Presione Escape para pausar/finalizar\n");

            while (true)
            {
                var tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.Enter && !ejecucion)
                {
                    ejecucion = true;
                    Console.WriteLine("\nCajeros trabajando \n");

                    
                    List<Thread> hilosCajeros = new List<Thread>();
                    
                    foreach (int cajeroId in id_cajeros)
                    {
                        Thread hiloCajero = new Thread(() => ProcesarClientesCajero(cajeroId));
                        hiloCajero.Start();
                        hilosCajeros.Add(hiloCajero);
                    }

                    // Esperar a que se presione Escape para detener
                    while (ejecucion)
                    {
                        if (Console.KeyAvailable)
                        {
                            var teclaDetener = Console.ReadKey(true).Key;
                            if (teclaDetener == ConsoleKey.Escape)
                            {
                                ejecucion = false;
                                Console.WriteLine("\n\n Cajeros detenidos ");
                                break;
                            }
                        }
                        Thread.Sleep(100);
                    }

                    // Esperar a que terminen todos los cajeros
                    foreach (Thread hilo in hilosCajeros)
                    {
                        hilo.Join();
                    }

                    MostrarEstadisticas();
                }
                else if (tecla == ConsoleKey.Escape)
                {
                    ejecucion = false;
                    Console.WriteLine("\nSistema finalizado");
                    break;
                }
            }
        }

        private static void ProcesarClientesCajero(int cajeroId)
        {
            while (ejecucion)
            {
                Cliente clienteActual = null;

                // Intentar obtener un cliente de la cola
                lock (Clientes.lockCola)
                {
                    if (Clientes.colaClientes.Count > 0)
                    {
                        clienteActual = Clientes.colaClientes.Dequeue();
                        clienteActual.Estado = "siendo_atendido";
                        clienteActual.CajeroAsignado = cajeroId;
                        clienteActual.HoraInicioAtencion = DateTime.Now;
                    }
                }

                if (clienteActual != null)
                {
                    // Mostrar que empieza a atender
                    int clientesRestantes = Clientes.ObtenerClientesEnCola();
                    Console.WriteLine($"[Cajero {cajeroId}] empieza a atender al Cliente {clienteActual.Id} ({clienteActual.CantidadProductos} productos). El cliente esta siendo atendido.");
                    
                    // Calcular tiempo de atención
                    int tiempoAtencion = clienteActual.CalcularTiempoAtencion();
                    
                    // Simular atención
                    Thread.Sleep(tiempoAtencion);
                    
                    // Finalizar atención
                    clienteActual.Estado = "finalizado";
                    clienteActual.HoraFinalizacion = DateTime.Now;
                    
                    // Actualizar estadísticas
                    clientesAtendidosPorCajero[cajeroId]++;
                    tiempoTotalPorCajero[cajeroId] += tiempoAtencion;
                    
                    clientesRestantes = Clientes.ObtenerClientesEnCola();
                    Console.WriteLine($"[Cajero {cajeroId}] ha terminado con Cliente {clienteActual.Id}. Ha tardado {tiempoAtencion} ms. El cliente ha finalizado. Quedan {clientesRestantes} clientes por atender en la cola.");
                }
                else
                {
                    // No hay clientes, esperar un poco
                    Thread.Sleep(500);
                }
            }
        }

        private static void MostrarEstadisticas()
        {
            Console.WriteLine("\nEstadisticas ");
            
            foreach (int cajeroId in id_cajeros)
            {
                int clientesAtendidos = clientesAtendidosPorCajero[cajeroId];
                int tiempoTotal = tiempoTotalPorCajero[cajeroId];
                
                Console.WriteLine($"\nCajero {cajeroId}:");
                Console.WriteLine($"Clientes atendidos: {clientesAtendidos}");
                Console.WriteLine($"Tiempo total trabajado: {tiempoTotal} ms ({tiempoTotal / 1000.0:F2} segundos)");
                
                if (clientesAtendidos > 0)
                {
                    double tiempoPromedio = tiempoTotal / (double)clientesAtendidos;
                    Console.WriteLine($"Tiempo promedio por cliente: {tiempoPromedio:F2} ms");
                }
            }
            
            // Cajero más rápido (el que más clientes atendió)
            int cajeroMasRapido = clientesAtendidosPorCajero.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine($"\nCajero más rápido (más clientes atendidos): Cajero {cajeroMasRapido} con {clientesAtendidosPorCajero[cajeroMasRapido]} clientes");
            
            Console.WriteLine($"\nClientes restantes en cola: {Clientes.ObtenerClientesEnCola()}");
        }
    }
}
