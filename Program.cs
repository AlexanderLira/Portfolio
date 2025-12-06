namespace ejercicio2
{
    class program
    {
        public static void Main(string[]args)
        {
            byte Op;

           
            Console.WriteLine("Digite La CLave De Su Ciudad");
            Console.WriteLine("Leon _ 1");
            Console.WriteLine("Chinandega _ 2");
            Console.WriteLine("Managua _ 5");
            Console.WriteLine("Estelí _ 8");
            Console.WriteLine("Matagalpa _9");
            Console.WriteLine("Jinotega _ 13");
            Console.WriteLine("Rivas _ 15");
            Op = Convert.ToByte(Console.ReadLine());

            switch (Op)
            {
                case 1:
                    CalculoLlamada(2);
                    break;

                case 2:
                    CalculoLlamada(6);
                    break;

                case 5:
                    CalculoLlamada(2.2);
                    break;

                case 8:
                    CalculoLlamada(4.5);
                    break;

                case 9:
                    CalculoLlamada(3.5);
                    break;

                case 13:
                    CalculoLlamada(6);
                    break;

                case 15:
                    CalculoLlamada(5);
                    break;

                default:
                    Console.WriteLine("Clave Erronea");
                    break;
            }
            Console.ReadKey();
        }
        static void CalculoLlamada(double costo)
        {
            double Duracion, Tiempo_Extra = 0, costo_inicial = 0.25, calculo = 0, costo_final;
            Console.Write("Digite La duracion De llamada: ");
            Duracion = Convert.ToDouble(Console.ReadLine());
            if (Duracion > 8)
            {
                
                costo = (Duracion - 8)  ;
                costo_final = costo + costo_inicial;
                
                


                
            }
            else
            {
                costo_final = Duracion + 0.25;
            }

            Console.Write("El Costo Total De Llamada Es: {0} C$", costo_final);
        }
    }
}
                
                    
            

        
    
