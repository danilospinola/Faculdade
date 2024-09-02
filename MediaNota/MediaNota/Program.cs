using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNota
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digiteo nome, a primeira e a segunda nota do aluno");

            CalcularMedia(Console.ReadLine(), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
        }

        static void CalcularMedia (string nome,double N1, double N2){
            Console.WriteLine($"{nome} sua nota é igual a: {N1 * 0.4 + N2 * 0.6}");
            Console.ReadKey();

        }
    }
}
