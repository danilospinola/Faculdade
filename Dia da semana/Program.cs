using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dia_da_semana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um numero de 1-7 para descobrir o dia da semana:");
            int Dia = Convert.ToInt32(Console.ReadLine());
            DiadaSemana(Dia);


        }

        static void DiadaSemana(int diaSemana){
            Console.WriteLine("Seu dia é: ");
            switch (diaSemana){
                case 1: Console.WriteLine("Segunda-feira");
                    Console.ReadKey();
                    break;
                case 2: Console.WriteLine("Terça-feira");
                    Console.ReadKey();
                    break;
                case 3: Console.WriteLine("Quarta-feira");
                    Console.ReadKey();
                    break; 
                case 4: Console.WriteLine("Quinta-feira");
                    Console.ReadKey();
                    break;
                case 5: Console.WriteLine("Sexta-feira");
                    Console.ReadKey();
                    break;
                case 6: Console.WriteLine("Sabado");
                    Console.ReadKey();
                    break;
                case 7: Console.WriteLine("Domingo");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
