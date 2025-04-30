using System;

class Program
{
    // Função Bubble Sort otimizada
    static void BubbleSortOtimizacao(int[] arr, out int numTrocas, out int numComparacoes)
    {
        int n = arr.Length;
        numTrocas = 0;
        numComparacoes = 0;
        bool trocou;

        for (int i = 0; i < n - 1; i++)
        {
            trocou = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                numComparacoes++;
                if (arr[j] > arr[j + 1])
                {
                    // Troca os elementos
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    trocou = true;
                    numTrocas++;
                }
            }
            // Se não houve troca, o vetor já está ordenado
            if (!trocou) break;
        }
    }

    // Função para imprimir o vetor
    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Função para gerar um vetor com valores aleatórios
    static int[] GerarVetorAleatorio(int tamanho)
    {
        Random rand = new Random();
        int[] arr = new int[tamanho];
        for (int i = 0; i < tamanho; i++)
        {
            arr[i] = rand.Next(1, 100); // Valores aleatórios entre 1 e 99
        }
        return arr;
    }

    static void Main()
    {
        int tamanho = 10;

        // Caso 1: Vetor já ordenado
        int[] vetorOrdenado = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int numTrocas, numComparacoes;

        Console.WriteLine("Bubble Sort Otimizado - Vetor já ordenado:");
        BubbleSortOtimizacao((int[])vetorOrdenado.Clone(), out numTrocas, out numComparacoes);
        Console.WriteLine("Número de trocas: " + numTrocas);
        Console.WriteLine("Número de comparações: " + numComparacoes);
        Console.WriteLine();

        // Caso 2: Vetor em ordem inversa
        int[] vetorInverso = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        Console.WriteLine("Bubble Sort Otimizado - Vetor em ordem inversa:");
        BubbleSortOtimizacao((int[])vetorInverso.Clone(), out numTrocas, out numComparacoes);
        Console.WriteLine("Número de trocas: " + numTrocas);
        Console.WriteLine("Número de comparações: " + numComparacoes);
        Console.WriteLine();

        // Caso 3: Vetor com valores aleatórios
        int[] vetorAleatorio = GerarVetorAleatorio(tamanho);

        Console.WriteLine("Bubble Sort Otimizado - Vetor com valores aleatórios:");
        BubbleSortOtimizacao((int[])vetorAleatorio.Clone(), out numTrocas, out numComparacoes);
        Console.WriteLine("Número de trocas: " + numTrocas);
        Console.WriteLine("Número de comparações: " + numComparacoes);
    }
}
