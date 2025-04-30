using System;

namespace SortUsuarioConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] listaUsuario = new int[10];

            // Leitura dos 10 elementos
            for (int i = 0; i < listaUsuario.Length; i++)
            {
                Console.Write($"Digite o número {i + 1}: ");
                listaUsuario[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nVetor original:");
            ExibirVetor(listaUsuario);

            // Chama o Selection Sort recursivo com debug
            SelectionSortRecursivo(listaUsuario, 0);

            Console.WriteLine("\nVetor final ordenado:");
            ExibirVetor(listaUsuario);

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void SelectionSortRecursivo(int[] vetor, int i)
        {
            int n = vetor.Length;

            // Caso base
            if (i >= n - 1) return;

            Console.WriteLine($"\n=== Seleção {i + 1}: procurando o menor elemento para a posição {i} ===");

            int indiceMin = i;

            // Encontra o índice do menor elemento no subvetor [i..n-1]
            for (int j = i + 1; j < n; j++)
            {
                Console.WriteLine($"Comparando vetor[{j}] = {vetor[j]} com vetor[{indiceMin}] = {vetor[indiceMin]}");
                if (vetor[j] < vetor[indiceMin])
                {
                    indiceMin = j;
                    Console.WriteLine($"  → Novo mínimo agora é vetor[{indiceMin}] = {vetor[indiceMin]}");
                }
            }

            // Se encontrou um mínimo diferente, troca
            if (indiceMin != i)
            {
                Console.WriteLine($"Trocando vetor[{i}] = {vetor[i]} com vetor[{indiceMin}] = {vetor[indiceMin]}");
                int temp = vetor[i];
                vetor[i] = vetor[indiceMin];
                vetor[indiceMin] = temp;
            }
            else
            {
                Console.WriteLine($"Nenhuma troca necessária para a posição {i}");
            }

            // Exibe o vetor após esta etapa
            Console.WriteLine("Estado atual do vetor:");
            ExibirVetor(vetor);

            // Próxima seleção
            SelectionSortRecursivo(vetor, i + 1);
        }

        static void ExibirVetor(int[] v)
        {
            foreach (int num in v)
                Console.Write(num + " ");
            Console.WriteLine();
        }
    }
}
