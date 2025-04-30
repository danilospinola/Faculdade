using System;

namespace EstoqueLoja
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vetor com a quantidade de produtos em estoque (exemplo)
            int[] estoque = { 50, 10, 200, 5, 80, 35, 60, 15, 120, 25 };

            Console.WriteLine("Vetor de estoque antes da ordenação:");
            ExibirVetor(estoque);

            // Ordena o vetor usando o algoritmo Bubble Sort
            BubbleSort(estoque);

            Console.WriteLine("\nVetor de estoque após a ordenação:");
            ExibirVetor(estoque);

            // Exibe os 5 produtos com menor quantidade em estoque
            Console.WriteLine("\n5 produtos com menor quantidade em estoque:");
            for (int i = 0; i < 5 && i < estoque.Length; i++)
            {
                Console.WriteLine($"Produto {i + 1}: {estoque[i]} unidades");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        // Função Bubble Sort
        static void BubbleSort(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (vetor[j] > vetor[j + 1]) // Se o item atual for maior que o próximo, troca
                    {
                        int temp = vetor[j];
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = temp;
                    }
                }
            }
        }

        // Função para exibir o vetor
        static void ExibirVetor(int[] v)
        {
            foreach (var item in v)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
