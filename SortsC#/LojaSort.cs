using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BatalhaDeAlgoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo à Batalha de Algoritmos de Ordenação!");

            // Escolha do tamanho do vetor
            Console.Write("Digite o tamanho do vetor: ");
            int tamanhoVetor = int.Parse(Console.ReadLine());

            // Escolha dos algoritmos
            Console.WriteLine("\nEscolha dois algoritmos para competir!");
            Console.WriteLine("1 - Bubble Sort");
            Console.WriteLine("2 - Selection Sort");
            Console.WriteLine("3 - Insertion Sort");
            Console.WriteLine("4 - Quick Sort");
            Console.WriteLine("5 - Merge Sort");

            Console.Write("\nEscolha o primeiro algoritmo (1-5): ");
            int escolha1 = int.Parse(Console.ReadLine());
            Console.Write("Escolha o segundo algoritmo (1-5): ");
            int escolha2 = int.Parse(Console.ReadLine());

            // Gera o vetor aleatório
            Random random = new Random();
            int[] vetor = new int[tamanhoVetor];
            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = random.Next(1, 1000); // Gerar números entre 1 e 999
            }

            // Execução do primeiro algoritmo
            Console.WriteLine("\nIniciando a execução do primeiro algoritmo...");
            int[] vetor1 = (int[])vetor.Clone();
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            ExecutarAlgoritmo(escolha1, vetor1);
            stopwatch1.Stop();

            // Execução do segundo algoritmo
            Console.WriteLine("\nIniciando a execução do segundo algoritmo...");
            int[] vetor2 = (int[])vetor.Clone();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            ExecutarAlgoritmo(escolha2, vetor2);
            stopwatch2.Stop();

            // Exibe o tempo de execução de cada algoritmo
            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Tempo do algoritmo 1 (Escolha {escolha1}): {stopwatch1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Tempo do algoritmo 2 (Escolha {escolha2}): {stopwatch2.ElapsedMilliseconds} ms");

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        // Executa o algoritmo escolhido
        static void ExecutarAlgoritmo(int escolha, int[] vetor)
        {
            switch (escolha)
            {
                case 1:
                    BubbleSort(vetor);
                    break;
                case 2:
                    SelectionSort(vetor);
                    break;
                case 3:
                    InsertionSort(vetor);
                    break;
                case 4:
                    QuickSort(vetor, 0, vetor.Length - 1);
                    break;
                case 5:
                    vetor = MergeSort(vetor);
                    break;
                default:
                    Console.WriteLine("Escolha inválida.");
                    break;
            }
        }

        // Função Bubble Sort
        static void BubbleSort(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (vetor[j] > vetor[j + 1])
                    {
                        int temp = vetor[j];
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = temp;
                    }
        }

        // Função Selection Sort
        static void SelectionSort(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (vetor[j] < vetor[minIdx])
                        minIdx = j;
                if (minIdx != i)
                {
                    int temp = vetor[i];
                    vetor[i] = vetor[minIdx];
                    vetor[minIdx] = temp;
                }
            }
        }

        // Função Insertion Sort
        static void InsertionSort(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 1; i < n; i++)
            {
                int key = vetor[i];
                int j = i - 1;
                while (j >= 0 && vetor[j] > key)
                {
                    vetor[j + 1] = vetor[j];
                    j--;
                }
                vetor[j + 1] = key;
            }
        }

        // Função Quick Sort
        static void QuickSort(int[] vetor, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(vetor, low, high);
                QuickSort(vetor, low, pi - 1);
                QuickSort(vetor, pi + 1, high);
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
                    int temp = vetor[i];
                    vetor[i] = vetor[j];
                    vetor[j] = temp;
                }
            }
            int temp2 = vetor[i + 1];
            vetor[i + 1] = vetor[high];
            vetor[high] = temp2;
            return i + 1;
        }

        // Função Merge Sort
        static int[] MergeSort(int[] vetor)
        {
            if (vetor.Length <= 1) return vetor;

            int mid = vetor.Length / 2;
            var left = MergeSort(new ArraySegment<int>(vetor, 0, mid).ToArray());
            var right = MergeSort(new ArraySegment<int>(vetor, mid, vetor.Length - mid).ToArray());
            return Merge(left, right);
        }

        static int[] Merge(int[] left, int[] right)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result.Add(left[i++]);
                else
                    result.Add(right[j++]);
            }

            while (i < left.Length) result.Add(left[i++]);
            while (j < right.Length) result.Add(right[j++]);

            return result.ToArray();
        }
    }
}
