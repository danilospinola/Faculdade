using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangulos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o primeiro lado");
            Int32 L1, L2, L3;
            L1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Informe o segundo lado");
            L2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Informe o terceiro lado");
            L3 = Int32.Parse(Console.ReadLine());
            Triangulo(L1,L2,L3);
            Console.ReadKey();
        }

        static void Triangulo(Int32 Lado1, Int32 Lado2, Int32 Lado3)
        {
            if (Lado1 < Lado2 + Lado3 && Lado2 < Lado1 + Lado3 && Lado3 < Lado2 + Lado1)
            {
               if(Lado1 == Lado2 && Lado1 == Lado3 && Lado2 == Lado3 ) {
                    Console.WriteLine("O triângulo informado é equilatero");
                    
                }
               else if (Lado1 != Lado2 && Lado1 != Lado3 && Lado2 != Lado3) {
                    Console.WriteLine("O triângulo informado é escaleno");
                }
                else
                {
                    Console.WriteLine("O triângulo informado é isoceles");
                }
            }   
            else {
                Console.WriteLine("O formato informado não é de triângulo");
            }

        }
    }
}
