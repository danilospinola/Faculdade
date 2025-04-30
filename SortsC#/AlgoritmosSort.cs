using System;
using System.Collections.Generic;
using System.Linq;

namespace OrdenaAlunos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(string nome, double media)> alunos = new List<(string nome, double media)>();

            // Recebe os dados dos alunos
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Digite o nome do aluno {i + 1}:");
                string nome = Console.ReadLine();

                Console.WriteLine($"Digite a média final do aluno {nome}:");
                double media = double.Parse(Console.ReadLine());

                alunos.Add((nome, media));
            }

            // Ordena a lista pela média em ordem decrescente
            var alunosOrdenados = alunos.OrderByDescending(a => a.media).ToList();

            // Exibe os alunos ordenados
            Console.WriteLine("\nAlunos ordenados por média (do maior para o menor):");
            foreach (var aluno in alunosOrdenados)
            {
                Console.WriteLine($"Nome: {aluno.nome}, Média: {aluno.media:F2}");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
