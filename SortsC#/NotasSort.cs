using System;
using System.Collections.Generic;

namespace SistemaPontuacaoJogadores
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(string nome, int pontuacao)> jogadores = new List<(string nome, int pontuacao)>();

            // Recebe os dados dos jogadores
            for (int i = 0; i < 5; i++) // Modifique para o número de jogadores desejado
            {
                Console.WriteLine($"Digite o nome do jogador {i + 1}:");
                string nome = Console.ReadLine();

                Console.WriteLine($"Digite a pontuação do jogador {nome}:");
                int pontuacao = int.Parse(Console.ReadLine());

                jogadores.Add((nome, pontuacao));
            }

            // Ordena os jogadores pela pontuação usando Quick Sort
            QuickSort(jogadores, 0, jogadores.Count - 1);

            // Exibe os jogadores ordenados por pontuação
            Console.WriteLine("\nJogadores ordenados por pontuação (do maior para o menor):");
            foreach (var jogador in jogadores)
            {
                Console.WriteLine($"Nome: {jogador.nome}, Pontuação: {jogador.pontuacao}");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        // Função recursiva Quick Sort
        static void QuickSort(List<(string nome, int pontuacao)> lista, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(lista, low, high);

                // Recursão nas duas metades
                QuickSort(lista, low, pi - 1);
                QuickSort(lista, pi + 1, high);
            }
        }

        // Função de particionamento do Quick Sort
        static int Partition(List<(string nome, int pontuacao)> lista, int low, int high)
        {
            int pivot = lista[high].pontuacao; // Pivô é a pontuação do último jogador
            int i = low - 1; // Índice do menor elemento

            for (int j = low; j < high; j++)
            {
                if (lista[j].pontuacao >= pivot) // Ordem decrescente
                {
                    i++;
                    Swap(lista, i, j);
                }
            }

            // Troca o pivô com o elemento após o maior valor
            Swap(lista, i + 1, high);
            return i + 1;
        }

        // Função para trocar dois elementos na lista
        static void Swap(List<(string nome, int pontuacao)> lista, int i, int j)
        {
            var temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }
    }
}
