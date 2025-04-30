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

            Console.WriteLine("\nVetor antes da ordenação:");
            ExibirVetor(listaUsuario);

            QuickSortRecursivo(listaUsuario, 0, listaUsuario.Length - 1);

            Console.WriteLine("\nVetor após a ordenação:");
            ExibirVetor(listaUsuario);

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void QuickSortRecursivo(int[] vetor, int low, int high)
        {
            if (low < high)
            {
                // Faz a partição e obtém o índice final do pivô
                int pi = Partition(vetor, low, high);

                // Indica no console a posição do pivô desta chamada
                Console.WriteLine($"\nPivô na posição {pi} com valor {vetor[pi]}");
                Console.Write("Estado atual do vetor: ");
                ExibirVetor(vetor);

                // Recursão nas duas metades
                QuickSortRecursivo(vetor, low, pi - 1);
                QuickSortRecursivo(vetor, pi + 1, high);
            }
        }

        static int Partition(int[] vetor, int low, int high)
        {
            int pivot = vetor[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (vetor[j] <= pivot)
                {
                    i++;
                    Swap(vetor, i, j);
                }
            }

            // Coloca o pivô na sua posição correta
            Swap(vetor, i + 1, high);
            return i + 1;
        }

        static void Swap(int[] vetor, int a, int b)
        {
            int temp = vetor[a];
            vetor[a] = vetor[b];
            vetor[b] = temp;
        }

        static void ExibirVetor(int[] v)
        {
            foreach (int num in v)
                Console.Write(num + " ");
            Console.WriteLine();
        }
    }
}
