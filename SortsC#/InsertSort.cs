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

            // Chama o Insertion Sort recursivo com passo a passo
            InsertionSortRecursivo(listaUsuario, listaUsuario.Length);

            Console.WriteLine("\nVetor final ordenado:");
            ExibirVetor(listaUsuario);

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        // Ordena recursivamente os primeiros n elementos de 'vetor'
        static void InsertionSortRecursivo(int[] vetor, int n)
        {
            // Caso base: 1 elemento já está “ordenado”
            if (n <= 1) return;

            // Primeiro ordena recursivamente os n-1 elementos iniciais
            InsertionSortRecursivo(vetor, n - 1);

            // Agora vamos inserir o elemento na posição n-1
            int chave = vetor[n - 1];
            int j = n - 2;

            Console.WriteLine($"\n=== Inserindo elemento na posição {n - 1} (valor {chave}) ===");

            // Passo a passo: enquanto houver elementos maiores que a chave, desloca-os
            while (j >= 0)
            {
                Console.WriteLine($"Comparando chave {chave} com vetor[{j}] = {vetor[j]}");

                if (vetor[j] > chave)
                {
                    Console.WriteLine($"Deslocando vetor[{j}] ({vetor[j]}) para posição {j + 1}");
                    vetor[j + 1] = vetor[j];
                    ExibirVetor(vetor);
                }
                else
                {
                    Console.WriteLine($"Parar deslocamento: {vetor[j]} <= {chave}");
                    break;
                }

                j--;
            }

            // Insere finalmente a chave em j+1
            Console.WriteLine($"Inserindo chave {chave} na posição {j + 1}");
            vetor[j + 1] = chave;
            ExibirVetor(vetor);
        }

        static void ExibirVetor(int[] v)
        {
            foreach (int num in v)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
