using System.ComponentModel.Design;

namespace ejercicio1
{
    class program
    {
        public static void Main(string[] args)
        {
            int salario, salario_final= 0, calculo;
            int categoria1 = 500, categoria2 = 1000, categoria3 = 1500, categoria4 = 2000;
            string nombre_del_trabajador;
            decimal c1 = 0.15M, c2 = 0.10M, c3 = 0.8M, c4 = 0.7M;
            
            Console.WriteLine("Nombre del trabajador");
            nombre_del_trabajador= Console.ReadLine();
            Console.WriteLine("Sueldo");
            salario = int.Parse(Console.ReadLine());
            if (salario >= categoria1 && salario < categoria2)
            {
                calculo = (int)(salario *0.15);
                    salario_final = calculo + salario;
                    
            }
            else
            {
                if (salario >= categoria2 && salario < categoria3)
                {
                    calculo = (int)(salario * 0.10);
                    salario_final = calculo + salario;

                }
                else
                {
                    if (salario >= categoria3 && salario < categoria4)
                    {
                        calculo = (int)(salario * 0.08);
                        salario_final = calculo + salario;

                    }
                    else
                    {
                        if (salario >= categoria4)
                        {
                            calculo = (int)(salario * 0.07);
                            salario_final = calculo + salario;

                        }
                        
                    }
                }

            }
   





            
            Console.WriteLine("El nuevo sueldo de..." + nombre_del_trabajador + "...es..." +salario_final + "$");
            
              
            
            
               
            
            
  
            
        }  
    }
}

        
       