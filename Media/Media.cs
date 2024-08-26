// See https://aka.ms/new-console-template for more information
using System;





internal class Program
{
    private static void Main(string[] args)
    {
        double num1;
        double num2;
        float media;

        Console.WriteLine("Digite um numero");
        num1 = Convert.ToDouble(Console.ReadLine());


        Console.WriteLine("Digite o segundo numero");
        num2 = Convert.ToDouble(Console.ReadLine());

        media = (float)((num1 + num2) / 2);

        Console.WriteLine("Sua média é " + media);
    }
}

