using System;
using System.Diagnostics;

class Program
{
    // Algoritmo Selection Sort
    static void SelectionSort(int[] arr, out long comparacoes, out long trocas)
    {
        int n = arr.Length;
        comparacoes = 0;
        trocas = 0;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                comparacoes++;
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
                trocas++;
            }
        }
    }

    // Algoritmo Insertion Sort
    static void InsertionSort(int[] arr, out long comparacoes, out long trocas)
    {
        int n = arr.Length;
        comparacoes = 0;
        trocas = 0;
        for (int i = 1; i < n; i++)
        {
            int chave = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > chave)
            {
                comparacoes++;
                arr[j + 1] = arr[j];
                j--;
                trocas++;
            }
            arr[j + 1] = chave;
        }
    }

    // Algoritmo Bubble Sort
    static void BubbleSort(int[] arr, out long comparacoes, out long trocas)
    {
        int n = arr.Length;
        comparacoes = 0;
        trocas = 0;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                comparacoes++;
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    trocas++;
                }
            }
        }
    }

    // Algoritmo Merge Sort
    static void MergeSort(int[] arr, int left, int right, out long comparacoes, out long trocas)
    {
        comparacoes = 0;
        trocas = 0;
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid, out comparacoes, out trocas);
            MergeSort(arr, mid + 1, right, out comparacoes, out trocas);
            Merge(arr, left, mid, right, out comparacoes, out trocas);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right, out long comparacoes, out long trocas)
    {
        comparacoes = 0;
        trocas = 0;
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
        {
            comparacoes++;
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

    // Algoritmo Quick Sort
    static void QuickSort(int[] arr, int low, int high, out long comparacoes, out long trocas)
    {
        comparacoes = 0;
        trocas = 0;
        if (low < high)
        {
            int pi = Partition(arr, low, high, out comparacoes, out trocas);
            QuickSort(arr, low, pi - 1, out comparacoes, out trocas);
            QuickSort(arr, pi + 1, high, out comparacoes, out trocas);
        }
    }

    static int Partition(int[] arr, int low, int high, out long comparacoes, out long trocas)
    {
        comparacoes = 0;
        trocas = 0;
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            comparacoes++;
            if (arr[j] <= pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                trocas++;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;
        trocas++;
        return i + 1;
    }

    static void Main()
    {
        int[] sizes = { 1000, 5000, 10000 };
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Algoritmos de Ordenação - Comparativo de Desempenho:");

        foreach (int size in sizes)
        {
            Console.WriteLine($"\nTamanho do vetor: {size}");
            int[] arr = GenerateRandomArray(size);

            // Selection Sort
            int[] arrSelection = (int[])arr.Clone();
            stopwatch.Restart();
            SelectionSort(arrSelection, out long comparacoesSelection, out long trocasSelection);
            stopwatch.Stop();
            Console.WriteLine($"Selection Sort: Tempo = {stopwatch.ElapsedMilliseconds}ms, Comparações = {comparacoesSelection}, Trocas = {trocasSelection}");

            // Insertion Sort
            int[] arrInsertion = (int[])arr.Clone();
            stopwatch.Restart();
            InsertionSort(arrInsertion, out long comparacoesInsertion, out long trocasInsertion);
            stopwatch.Stop();
            Console.WriteLine($"Insertion Sort: Tempo = {stopwatch.ElapsedMilliseconds}ms, Comparações = {comparacoesInsertion}, Trocas = {trocasInsertion}");

            // Bubble Sort
            int[] arrBubble = (int[])arr.Clone();
            stopwatch.Restart();
            BubbleSort(arrBubble, out long comparacoesBubble, out long trocasBubble);
            stopwatch.Stop();
            Console.WriteLine($"Bubble Sort: Tempo = {stopwatch.ElapsedMilliseconds}ms, Comparações = {comparacoesBubble}, Trocas = {trocasBubble}");

            // Merge Sort
            int[] arrMerge = (int[])arr.Clone();
            stopwatch.Restart();
            MergeSort(arrMerge, 0, arr.Length - 1, out long comparacoesMerge, out long trocasMerge);
            stopwatch.Stop();
            Console.WriteLine($"Merge Sort: Tempo = {stopwatch.ElapsedMilliseconds}ms, Comparações = {comparacoesMerge}, Trocas = {trocasMerge}");

            // Quick Sort
            int[] arrQuick = (int[])arr.Clone();
            stopwatch.Restart();
            QuickSort(arrQuick, 0, arr.Length - 1, out long comparacoesQuick, out long trocasQuick);
            stopwatch.Stop();
            Console.WriteLine($"Quick Sort: Tempo = {stopwatch.ElapsedMilliseconds}ms, Comparações = {comparacoesQuick}, Trocas = {trocasQuick}");
        }
    }

    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(1, 10000);
        }
        return arr;
    }
}
