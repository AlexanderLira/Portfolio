using Simulador_de_cajero_de_supermercados;

namespace supermercado
{
    class program
    {
        public static void Main(String[] args)
        {
            int inicio = 0;

            Console.WriteLine("=== SIMULADOR DE CAJEROS DE SUPERMERCADO ===");
            Console.WriteLine("\n¿Desea iniciar la simulación?");
            Console.WriteLine("1. Si");
            Console.WriteLine("2. No");
            Console.Write("\nOpción: ");
            
            try
            {
                inicio = int.Parse(Console.ReadLine());
            }
            catch
            {
                inicio = 2;
            }

            if (inicio == 1)
            {
                Console.WriteLine("\n=== Iniciando simulación ===\n");
                
                // Iniciar hilo de generación de clientes
                Thread clientes = new Thread(() => Clientes.hilo_cliente());
                clientes.Start();

                // Dar un momento para que se inicialice el generador de clientes
                Thread.Sleep(1000);

                // Iniciar hilo de cajeros
                Thread cajeros = new Thread(() => Hilo_cajero.cajeros());
                cajeros.Start();

                // Esperar a que terminen los hilos
                clientes.Join();
                cajeros.Join();
            }
            else
            {
                Console.WriteLine("\n=== Simulación cancelada ===");
            }
        }
    }
}