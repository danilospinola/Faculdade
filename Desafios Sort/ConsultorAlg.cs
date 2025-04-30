using System;

class Program
{
    // Função para ordenar com Insertion Sort
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int chave = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > chave)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = chave;
        }
    }

    // Função para ordenar com Quick Sort
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

    // Função para ordenar com Merge Sort
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

    // Função para ordenar com Counting Sort (ideal para muitos elementos repetidos)
    static void CountingSort(int[] arr)
    {
        int max = arr[0];
        foreach (int num in arr)
        {
            if (num > max)
                max = num;
        }

        int[] count = new int[max + 1];
        foreach (int num in arr)
        {
            count[num]++;
        }

        int index = 0;
        for (int i = 0; i <= max; i++)
        {
            while (count[i] > 0)
            {
                arr[index] = i;
                index++;
                count[i]--;
            }
        }
    }

    // Função para gerar um vetor aleatório
    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(1, 100); // Valores aleatórios entre 1 e 99
        }
        return arr;
    }

    // Função para mostrar as opções de escolha
    static void ShowOptions()
    {
        Console.WriteLine("Escolha o tipo de dados para o vetor:");
        Console.WriteLine("1. Já ordenado");
        Console.WriteLine("2. Totalmente desordenado");
        Console.WriteLine("3. Com muitos elementos repetidos");
        Console.Write("Digite sua escolha (1/2/3): ");
    }

    static void Main()
    {
        Console.Write("Digite o tamanho do vetor: ");
        int tamanho = int.Parse(Console.ReadLine());

        ShowOptions();
        int escolha = int.Parse(Console.ReadLine());

        int[] vetor = GenerateRandomArray(tamanho);

        string algoritmoSugerido = string.Empty;
        Action<int[]> algoritmo = null;
        string justificativa = string.Empty;

        // Escolha do algoritmo com base nas características do vetor
        switch (escolha)
        {
            case 1: // Já ordenado
                algoritmoSugerido = "Insertion Sort";
                algoritmo = InsertionSort;
                justificativa = "Insertion Sort é eficiente para vetores quase ordenados, com complexidade O(n^2) no pior caso, mas muito rápido para dados quase ordenados.";
                break;
            case 2: // Totalmente desordenado
                algoritmoSugerido = "Quick Sort";
                algoritmo = (arr) => QuickSort(arr, 0, arr.Length - 1);
                justificativa = "Quick Sort é eficiente para vetores grandes e desordenados, com complexidade média de O(n log n).";
                break;
            case 3: // Muitos elementos repetidos
                algoritmoSugerido = "Counting Sort";
                algoritmo = CountingSort;
                justificativa = "Counting Sort é ideal para vetores com muitos elementos repetidos, com complexidade O(n + k), onde k é o valor máximo.";
                break;
            default:
                Console.WriteLine("Opção inválida.");
                return;
        }

        Console.WriteLine($"\nAlgoritmo sugerido: {algoritmoSugerido}");
        Console.WriteLine($"Justificativa: {justificativa}");

        Console.Write("\nDeseja usar o algoritmo sugerido? (S/N): ");
        string resposta = Console.ReadLine().ToUpper();

        if (resposta == "S")
        {
            algoritmo(vetor);
            Console.WriteLine("\nVetor ordenado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nEscolha um algoritmo manualmente:");
            Console.WriteLine("1. Insertion Sort");
            Console.WriteLine("2. Quick Sort");
            Console.WriteLine("3. Counting Sort");
            Console.Write("Digite sua escolha (1/2/3): ");
            int escolhaManual = int.Parse(Console.ReadLine());

            switch (escolhaManual)
            {
                case 1: InsertionSort(vetor); break;
                case 2: QuickSort(vetor, 0, vetor.Length - 1); break;
                case 3: CountingSort(vetor); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
            Console.WriteLine("\nVetor ordenado com sucesso!");
        }

        // Imprimir vetor ordenado (opcional)
        Console.WriteLine("\nVetor ordenado:");
        foreach (var item in vetor)
        {
            Console.Write(item + " ");
        }
    }
}
