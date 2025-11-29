using Simulador_de_cajero_de_supermercados;

namespace supermercado
{
    class Program
    {
        public static void Main(String[] args)
        {
            // Si el método hilo_cliente requiere un parámetro, se debe usar ParameterizedThreadStart
            // y pasar el argumento adecuado. Aquí se pasa Clientes.id_cliente como ejemplo.
            int inicio = 0;
            

            Console.WriteLine("Desea iniciar?");
            Console.WriteLine("1. Si");
            Console.WriteLine("2: No");
            inicio= int.Parse(Console.ReadLine());

            if(inicio == 1)
            {
                Thread clientes = new Thread(obj => Clientes.hilo_cliente(Clientes.id_cliente));
                clientes.Start(Clientes.id_cliente);


                Thread cajeros = new Thread(obj => Hilo_cajero.cajeros());
                cajeros.Start();
            }
            else
            {
                Console.WriteLine("Fin");
            }

            
        }
    }
}