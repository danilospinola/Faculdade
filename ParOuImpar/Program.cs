using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParOuImpar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escreva um numero");
            int numero  = Convert.ToInt32(Console.ReadLine());
            ParOuImpar(numero);
        }

        static void ParOuImpar(int Num)
        {
            if (Num % 2 == 0 && Num != 0) {
                Console.WriteLine($"{Num} é Par");
                Console.ReadKey(); 
            } else if (Num % 2 != 0)
            {
                Console.WriteLine($"{Num} é Impar");
                Console.ReadKey();
            }
            else if (Num == 0) 
            {
                Console.WriteLine($"{Num} é Nem par nem impar!");
                Console.ReadKey();
            }
            else { 
                Console.WriteLine("Erro");
                Console.ReadKey();
            }
        }
    }
}
