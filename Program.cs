using Clases_y_objetos5;
using System;
class Program
{
    static void Main(string[] args)
    {
        double v1, v2 ;
        double resultado = 0;
        int elección = 0;
        Console.WriteLine("1. Suma de valores.");
        Console.WriteLine("2. Resta de valores.");
        Console.WriteLine("3. Multiplicación de valores.");
        Console.WriteLine("4. División de valores.");
        Console.Write("Elija su opción: ");
        elección=int.Parse(Console.ReadLine());
        Console.WriteLine("primer numero");
        v1=double.Parse(Console.ReadLine());
        Console.WriteLine("Segundo numero");
        v2 = double.Parse(Console.ReadLine());
        //completar el código……
        if(elección==1)
        {
            resultado = Operaciones.Suma(v1, v2);
            Console.WriteLine("La respuesta es:\n" + resultado);
        }
        else
        {
            if(elección==2)
            {
                resultado = Operaciones.Resta(v1, v2);
                Console.WriteLine("La respuesta es:\n" + resultado);
            }
            else
            {
                if(elección== 3)
                {
                    resultado = Operaciones.Multiplicación(v1, v2);
                    Console.WriteLine("La respuesta es:\n" + resultado);
                }
                else
                {
                    if(elección==4)
                    {
                        resultado = Operaciones.División(v1, v2);
                        Console.WriteLine("La respuesta es:\n" + resultado);
                    }
                }
            }
        }
        Console.ReadKey();
    }
}