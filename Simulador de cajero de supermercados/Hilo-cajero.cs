using Simulador_de_cajero_de_supermercados;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace Simulador_de_cajero_de_supermercados
{
    internal class Hilo_cajero
    {

        static bool ejecucion = true;
        static Thread cajero_hilos = new Thread(cajeros);
        static Random rand_envio = new Random();

        public static List<int> id_cajeros = [1, 2];
        public static void cajeros()
        {
            Console.WriteLine("Cuantos clientes hay?");
            Console.WriteLine(Clientes.id_cliente.Count());



            while (true)
            {
                var tecla2 = Console.ReadKey(true).Key;


                if (tecla2 == ConsoleKey.Enter && !ejecucion)
                {

                    ejecucion = true;
                    Console.WriteLine("Trabajando");
                    Console.WriteLine("Cuantos clientes hay?");
                    Console.WriteLine(Clientes.id_cliente.Count());
                    Thread.Sleep(1000);

                    if (Console.KeyAvailable)
                    {
                        var tecla_trabajo = Console.ReadKey(true).Key;

                        if(tecla_trabajo== ConsoleKey.Escape)
                        {
                            Console.WriteLine("trabajo pausado");
                        }

                        //Logica para el trabajo 
                        



                    }




                }
                else if( tecla2 == ConsoleKey.Escape)
                {
                    ejecucion = false;
                }
            }



        }


    }
}
