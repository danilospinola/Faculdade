using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificarIntervalo
{
    internal class Program
    {
        static void Main(string[] args)
        {   //Sem operador logico como pedido pelo professor
            Console.WriteLine("Verificador do intervalo de 10 - 20, digite seu numero");
            int numero = Convert.ToInt32(Console.ReadLine());
            VerificarIntervalo(numero);
        }

        static void VerificarIntervalo(int Num)
        {
            if(Num >= 10) {
                if(Num <= 20)
                {
                    Console.WriteLine($"{Num} Está dentro do intervalo 10-20");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine($"O numero {Num} é maior que 20");
                    Console.Read();
                }
            }
            Console.WriteLine($"{Num} é menor que 10");
            Console.Read();
        }
    }
}
