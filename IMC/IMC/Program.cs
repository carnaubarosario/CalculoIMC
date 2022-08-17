using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    class Program
    {
        static void Main()
        {
            string acao = "";
            string caminho = "imc.txt";
            double peso, altura, imc;
            string nome, resultado = "";
            int idade;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("######################");
            Console.WriteLine("N - Novo cadastro");
            Console.WriteLine("C - Consultar paciente");
            Console.WriteLine("S - Sair da tela");
            Console.WriteLine("######################");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Informa a operação desejada: ");
            Console.ResetColor();

            acao = Console.ReadLine().ToUpper();
            Console.WriteLine();

            while (acao != "S")
            {
                if (acao == "N")
                {
                    Console.WriteLine("Informe o nome do paciente:");
                    nome = Console.ReadLine();

                    Console.WriteLine("Informe a idade do paciente:");
                    int.TryParse(Console.ReadLine(), out idade);

                    Console.WriteLine("Informe o peso do paciente: ");
                    double.TryParse(Console.ReadLine(), out peso);

                    Console.WriteLine("Informe a altura do paciente: ");
                    double.TryParse(Console.ReadLine(), out altura);

                    imc = Math.Round((peso / (altura * altura)));

                    if (imc < 18.5)
                    {
                        resultado = "Paciente esta abaixo do peso";
                    }
                    else if (imc > 18.5 && imc < 25)
                    {
                        resultado = "Paciente esta com peso normal";
                    }
                    else if (imc > 25 && imc < 30)
                    {
                        resultado = "Paciente esta com sobrepeso";
                    }
                    else if (imc > 30 && imc < 35)
                    {
                        resultado = "Paciente esta com obesidade nivel I";
                    }
                    else if (imc > 35 && imc < 40)
                    {
                        resultado = "Paciente esta com obesidade nivel II";
                    }
                    else if (imc > 40)
                    {
                        resultado = "Paciente esta com obesidade nivel III";
                    }

                    if (resultado != "" && imc > 0 && altura > 0 && peso > 0 && nome.Trim().Length > 2 && idade > 0)
                    {
                        StreamWriter sw = new StreamWriter(caminho, true);

                        sw.WriteLine("Nome: " + nome);
                        sw.WriteLine("Idade: " + idade);
                        sw.WriteLine("Peso:  "+ peso);
                        sw.WriteLine("Altura: " + altura);
                        sw.WriteLine("Imc: " + imc);
                        sw.WriteLine("Resultado: " + resultado);
                        sw.WriteLine("--------------------------");

                        sw.Close();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine();
                        Console.WriteLine("---> Dados Inválidos, Operação cancelada!!");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                }
                else if (acao == "C")
                {
                    StreamReader sr = new StreamReader(caminho);

                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                    sr.Close();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; 
                Console.WriteLine("#####################");
                Console.WriteLine("N - Novo ############");
                Console.WriteLine("C - Consultar #######");
                Console.WriteLine("S - Sair#############");
                Console.WriteLine("#####################");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Informe uma operação: ");
                Console.ResetColor();

                acao = Console.ReadLine().ToUpper();
                Console.WriteLine();
            }
                
               
        }

    }
}

