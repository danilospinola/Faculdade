using System;
using System.IO;
using System.Diagnostics;

class Program
{
    // Função Merge Sort
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    // Função Quick Sort
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(ref arr[i], ref arr[j]);
            }
        }
        Swap(ref arr[i + 1], ref arr[high]);
        return i + 1;
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Função para gerar números aleatórios e salvar em um arquivo
    static void GenerateRandomNumbers(string fileName, int size)
    {
        Random rand = new Random();
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < size; i++)
            {
                writer.WriteLine(rand.Next(1, 10001)); // Números entre 1 e 10.000
            }
        }
    }

    // Função para ler os números de um arquivo
    static int[] ReadNumbersFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int[] numbers = new int[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            numbers[i] = int.Parse(lines[i]);
        }
        return numbers;
    }

    // Função para salvar os números ordenados em um arquivo
    static void SaveNumbersToFile(string fileName, int[] arr)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var number in arr)
            {
                writer.WriteLine(number);
            }
        }
    }

    static void Main()
    {
        // Gerar vetor de 1.000 números aleatórios e salvar em "entrada.txt"
        int size = 1000;
        string inputFile = "entrada.txt";
        GenerateRandomNumbers(inputFile, size);
        Console.WriteLine("Arquivo entrada.txt gerado com 1.000 números aleatórios.");

        // Medir tempo de execução do Merge Sort
        int[] numbersForMerge = ReadNumbersFromFile(inputFile);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        MergeSort(numbersForMerge, 0, numbersForMerge.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Merge Sort - Tempo de execução: {stopwatch.ElapsedMilliseconds}ms");

        // Salvar resultado do Merge Sort em "saida_merge.txt"
        SaveNumbersToFile("saida_merge.txt", numbersForMerge);

        // Medir tempo de execução do Quick Sort
        int[] numbersForQuick = ReadNumbersFromFile(inputFile);
        stopwatch.Restart();
        QuickSort(numbersForQuick, 0, numbersForQuick.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Quick Sort - Tempo de execução: {stopwatch.ElapsedMilliseconds}ms");

        // Salvar resultado do Quick Sort em "saida_quick.txt"
        SaveNumbersToFile("saida_quick.txt", numbersForQuick);

        // Comparação dos tempos
        Console.WriteLine("\nComparação dos Tempos:");
        Console.WriteLine($"Merge Sort: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"Quick Sort: {stopwatch.ElapsedMilliseconds}ms");

        if (stopwatch.ElapsedMilliseconds < stopwatch.ElapsedMilliseconds)
        {
            Console.WriteLine("O Quick Sort foi mais rápido.");
        }
        else
        {
            Console.WriteLine("O Merge Sort foi mais rápido.");
        }
    }
}
