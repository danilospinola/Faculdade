using System;

namespace SortUsuarioConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] listaUsuario = new int[10];

            // 1) Leitura dos 10 elementos
            for (int i = 0; i < listaUsuario.Length; i++)
            {
                Console.Write($"Digite o número {i + 1}: ");
                listaUsuario[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nVetor original:");
            ExibirVetor(listaUsuario);
            Console.WriteLine();

            // 2) Chama o Merge Sort recursivo
            MergeSortRecursivo(listaUsuario, 0, listaUsuario.Length - 1);

            Console.WriteLine("\nVetor final ordenado:");
            ExibirVetor(listaUsuario);

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        // Função recursiva de Merge Sort
        static void MergeSortRecursivo(int[] vetor, int inicio, int fim)
        {
            // Caso base: subvetor com 1 elemento já está “ordenado”
            if (inicio >= fim) return;

            int meio = (inicio + fim) / 2;

            // 3) Mostra a divisão atual
            Console.WriteLine($"Dividindo vetor[{inicio}..{fim}] em [{inicio}..{meio}] e [{meio + 1}..{fim}]");

            // Recursão nas duas metades
            MergeSortRecursivo(vetor, inicio, meio);
            MergeSortRecursivo(vetor, meio + 1, fim);

            // Faz o merge das duas metades
            Merge(vetor, inicio, meio, fim);

            // 4) Exibe o subvetor mesclado
            Console.WriteLine($"Após mesclar vetor[{inicio}..{fim}]:");
            ExibirSubvetor(vetor, inicio, fim);
        }

        // Merge in-place usando arrays auxiliares
        static void Merge(int[] vetor, int inicio, int meio, int fim)
        {
            int n1 = meio - inicio + 1;
            int n2 = fim - meio;

            int[] esquerda = new int[n1];
            int[] direita = new int[n2];

            for (int i = 0; i < n1; i++)
                esquerda[i] = vetor[inicio + i];
            for (int j = 0; j < n2; j++)
                direita[j] = vetor[meio + 1 + j];

            int idxE = 0, idxD = 0, k = inicio;
            while (idxE < n1 && idxD < n2)
            {
                if (esquerda[idxE] <= direita[idxD])
                    vetor[k++] = esquerda[idxE++];
                else
                    vetor[k++] = direita[idxD++];
            }
            // copia restos, se houver
            while (idxE < n1) vetor[k++] = esquerda[idxE++];
            while (idxD < n2) vetor[k++] = direita[idxD++];
        }

        // Imprime o vetor inteiro
        static void ExibirVetor(int[] v)
        {
            foreach (int num in v)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        // Imprime apenas o subvetor [inicio..fim]
        static void ExibirSubvetor(int[] v, int inicio, int fim)
        {
            for (int i = inicio; i <= fim; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }
    }
}
