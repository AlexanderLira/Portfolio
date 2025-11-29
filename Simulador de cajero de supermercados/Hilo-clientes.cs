using System;
using System.Collections.Generic;
using System.Text;

namespace Simulador_de_cajero_de_supermercados
{
    internal class Clientes
    {
        static bool ejecucion = false;
        public static LinkedList<int>? id_cliente = new LinkedList<int>();
        public static LinkedList<int>? cantidad;

        public static int cliente_id { get; private set; } = -1;
        public static int cantidad_id { get; set; } = -1;

        
        public static Thread h_clientes = new Thread(() => hilo_cliente(id_cliente));
        
        public static void hilo_cliente(LinkedList<int>? id_cliente)
        {
            int cliente;
            Console.WriteLine("Iniciando_clientes");
            Console.WriteLine("Presione enter para iniciar y escape para finalziar");

            while (true)
            {
                var tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.Enter && !ejecucion)
                {
                    ejecucion = true;
                    Console.WriteLine("Creando clientes continuamente...\n");

                    while (ejecucion)
                    {
                        if (Console.KeyAvailable)
                        {
                            var teclaGeneracion = Console.ReadKey(true).Key;
                            if (teclaGeneracion == ConsoleKey.Escape)
                            {
                                ejecucion = false;
                                Console.WriteLine("\n\nGeneración de clientes detenida.");
                                break;
                            }
                        }

                        // Aquí va tu lógica de generación de clientes
                        int idcliente = 0;
                        Random rand_cantidad= new Random();
                        Random sleep = new Random();
                        sleep.Next(3000, 5000);
                        
                        int c_productos;

                        for (int i = 0; i < 100; i++)
                        {
                            int sleep_;
                            sleep.Next(3000, 5000);
                            sleep_ = sleep.Next(3000,7000);

                            idcliente++;
                            id_cliente.AddFirst(idcliente);
                            rand_cantidad.Next(1, 50);
                            c_productos = rand_cantidad.Next(1, 50);
                            cantidad.AddFirst(c_productos);

                            Console.WriteLine(id_cliente.Count());
                            Thread.Sleep(sleep_);
                        }

                    }
                }
                else if (tecla == ConsoleKey.Escape)
                {
                    ejecucion = false;
                    Console.WriteLine("Programa finalizado.");
                    break;
                }
            }
        }
    }
}
