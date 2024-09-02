using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNH_VIOTTI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tipo = "";
            Console.WriteLine("Bem vindo ao programa para retirar a CNH!!!");
            Console.WriteLine("Primeiramente digite sua idade:");
            int idade = Convert.ToInt32(Console.ReadLine());
            bool elegivel = false;
            conferirIdade(idade);
            if (elegivel == true)
            {
                Console.Clear();
                Console.WriteLine("Agora digite seu nome: ");
                string nome = Convert.ToString(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"Muito bem {nome} Continuaremos a retirada de sua carta.");
                int escolha = 0;
                while (escolha != 3)
                {
                    Console.WriteLine("Digite 1 para selecionar o tipo de carta");
                    Console.WriteLine("Em manutenção");
                    Console.WriteLine("Digite 3 Para Finalizar");
                    escolha = Convert.ToInt32(Console.ReadLine());
                    switch (escolha)
                    {
                        case 1:
                            Console.Clear();                          
                            Console.WriteLine("Digite 1 para Carro");
                            Console.WriteLine("Digite 2 Para Moto");
                            Console.WriteLine("Digite 3 Para Caminhão");
                            int carta = Convert.ToInt32(Console.ReadLine());
                            switch (carta)
                            {
                                case 1:
                                    tipo = "Carro";
                                    break;
                                case 2:
                                    tipo = "Moto";
                                    break;
                                case 3:
                                    tipo = "Caminhão";
                                    break;
                            }
                            Console.WriteLine("Muito bem, aperte qualquer tecla para continuar...");
                            Console.ReadKey();                       
                            Console.Clear();
                            break;



                        case 2:
                            Console.Clear();
                            break;



                        case 3:

                        default:
                            Console.Clear();
                            Console.WriteLine($"Ok {nome}, iremos preparar as aulas para sua retirada da carta de {tipo}");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }

            void conferirIdade(int valor)
            {
                if (valor >= 18)
                {
                    Console.WriteLine("Você está elegivel para tirar a CNH!!!, Aperte qualquer tecla para continuar:");
                    elegivel = true;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Você não está elegivel para retirar a CNH. Aguarde mais { (18 - idade)} Anos");
                    Console.WriteLine("Aperte qualquer tecla para Finalizar:");
                    Console.ReadKey();
                }
            }
        }
    }
}
