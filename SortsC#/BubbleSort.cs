using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortUsuarioConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] listaUsuario = new int[10];



            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine($"Digite o numero {k+1} da lista");
                listaUsuario[k] = int.Parse(Console.ReadLine());
            }
            RecursaoMatriz(listaUsuario, 0);


        }

        static int[] RecursaoMatriz(int[] listaUsuario, int i)
        {
            if (i == listaUsuario.Length - 1)
            {
                return listaUsuario;
            }
            else
            {
                for (int j = 0; j < listaUsuario.Length - i - 1; j++)
                {
                    if (listaUsuario[j] > listaUsuario[j + 1])
                    {
                        int temp = listaUsuario[j];
                        listaUsuario[j] = listaUsuario[j + 1];
                        listaUsuario[j + 1] = temp;
                    }
                    Console.WriteLine($"\nVetor ordenado com Bubble Sort, Divisao{j}");
                    ExibirVetor(listaUsuario);
                }

                return listaUsuario =  RecursaoMatriz(listaUsuario, ++i);
                

            }
        }

        static void ExibirVetor(int[] v)
        {
            foreach (var num in v)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
