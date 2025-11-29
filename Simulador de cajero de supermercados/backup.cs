using System;
using System.Collections.Generic;
using System.Text;

namespace Simulador_de_cajero_de_supermercados
{
    internal class backup
    {
        //private LinkedList<int>? id_cliente;

        //private LinkedList<int>? cantidad;
        //private int cantidad_random;

        //public Clientes(LinkedList<int>? id_cliente, LinkedList<int>? cantidad)
        //{
        //    this.id_cliente = id_cliente;
        //    this.cantidad = cantidad;
        //}

        //public Clientes(LinkedList<int>? id_cliente, LinkedList<int>? cantidad, int cantidad_random)
        //{
        //    this.id_cliente = id_cliente;
        //    this.cantidad = cantidad;
        //    this.cantidad_random = cantidad_random;
        //}

        //public LinkedList<int>? Id_cliente { get => id_cliente; set => id_cliente = value; }
        //public LinkedList<int>? Cantidad { get => cantidad; set => cantidad = value; }
        //public int Cantidad_random { get => cantidad_random; set => cantidad_random = value; }

        //public static int cliente_index { get; private set; } = -1;
        //public static int c_del_cliente { get; private set; } = -1;
        //public void cliente()
        //{
        //    Console.WriteLine("Viendo clientes" + "\nPresione Enter para iniciar generación o Escape para terminar");

        //    var teclaInicial = Console.ReadKey(true);
        //    if (teclaInicial.Key == ConsoleKey.Escape)
        //    {
        //        Console.WriteLine("\nPrograma terminado.");
        //        return;
        //    }

        //    if (teclaInicial.Key == ConsoleKey.Enter)
        //    {
        //        LinkedList<int> id_cliente = new LinkedList<int>();
        //        LinkedList<int> cantidad = new LinkedList<int>();
        //        Random random = new Random();

        //        Console.WriteLine("\nGenerando clientes automáticamente...");
        //        Console.WriteLine("Presione Escape en cualquier momento para detener\n");

        //        for (int i = 1; i <= 100; i++)
        //        {
        //            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
        //            {
        //                Console.WriteLine($"\n\nGeneración detenida. Total de clientes generados: {id_cliente.Count}");
        //                break;
        //            }

        //            id_cliente.AddFirst(i);
        //            int cantidadProductos = random.Next(1, 51);
        //            cantidad.AddFirst(cantidadProductos);

        //            Console.WriteLine($"Cliente #{i} generado - Productos: {cantidadProductos}");

        //            cliente_index = i;
        //            c_del_cliente = cantidadProductos;

        //            Console.WriteLine($"Clientes: {cliente_index} teniendo una cantidad de productos {c_del_cliente}\n");

        //            Thread.Sleep(3000);
        //        }

        //        if (id_cliente.Count == 100)
        //        {
        //            Console.WriteLine($"\n\nLímite alcanzado. Total de clientes generados: {id_cliente.Count}");

        //        }

        //        Console.WriteLine("\nPrograma finalizado.");
        //    }


        //}

        //public void ordenar()
        //{
        //    cliente_index = id_cliente.Count;
        //    Console.WriteLine("Clientes" + cliente_index);
        //}
    }
}
