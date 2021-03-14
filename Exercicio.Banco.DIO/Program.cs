using System.Collections.Generic;
using System;

namespace Exercicio.Banco.DIO
{
    class Program
    {
        static List<Conta> listBDContas = new List<Conta>();
        static void Main()
        {
            Console.WriteLine("Bem vindo aos nossos serviços bancários");
            Apresentacao();
        }
        static void Apresentacao()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:\n"+
			                "1- Listar contas\n"+
			                "2- Inserir nova conta\n"+
			                "3- Transferir\n"+
			                "4- Sacar\n"+
			                "5- Depositar\n"+
                            "L- Limpar Tela\n"+
			                "Ou opção diferente para sair");
            string opcTransacao = Console.ReadLine().ToUpper();                            
			
            switch (opcTransacao)
			{
				case "1":
                    Console.WriteLine();
					ListarContas();
					break;
				case "2":
                    Console.WriteLine();
					InserirConta();
					break;
				case "3":
                    Console.WriteLine();
					Transferir();
					break;
				case "4":
                    Console.WriteLine();
					Sacar();
					break;
				case "5":
                    Console.WriteLine();
					Depositar();
					break;
                case "L":
                    Console.Clear();
					break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Obrigado por uitlizar nossos serviços. Até logo!\n");
                    Environment.Exit(0);
                    break;
            }
            Apresentacao() ;      			
        }
        static void ListarContas()
        {
			Console.WriteLine("Listar contas............................");

			if (ValidarConta(0))
			{
                int numConta = 0;
                foreach (Conta conta in listBDContas)
			    {
				    conta.listarContas(numConta);
                    numConta ++;
                }
				
			}
          
        }
        static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta..........\n");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int opcTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string nomeCliente = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double valorSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double valorCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta((TipoConta)opcTipoConta, nomeCliente,  valorSaldo,valorCredito);

			listBDContas.Add(novaConta);
            
        }
        static void Transferir()
        {
            Console.Write("Digite o número da conta a ser debitado: ");
            int numContaDeb = int.Parse(Console.ReadLine());

            if (ValidarConta(numContaDeb))
            {
                Console.Write("Digite o valor a ser debitado/creditado: ");
                double valorDebCred = double.Parse(Console.ReadLine());

                Console.Write("Digite o número da conta a ser creditado: ");              
                int numContaCred = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (ValidarConta(numContaCred))
                {
                    if (listBDContas[numContaDeb].Sacar(valorDebCred))
                    {
                        listBDContas[numContaCred].Depositar(valorDebCred);
                    }
                }       
            }
        }
        static void Sacar()
        {
            
			Console.Write("Digite o número da conta: ");
			int numConta = int.Parse(Console.ReadLine());

            if (ValidarConta(numConta))
            {
                Console.WriteLine();
			    Console.Write("Digite o valor a ser debitado: ");
			    double valorSaque = double.Parse(Console.ReadLine());

                listBDContas[numConta].Sacar(valorSaque); 
            }                   
        }
        static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            if (ValidarConta(numConta))
            {
                Console.Write("Digite o valor a ser creditado: ");
                double valorDeposito = double.Parse(Console.ReadLine());

                listBDContas[numConta].Depositar(valorDeposito);
            }
        }
        static bool ValidarConta(int numValConta) //Verifica se existe conta criada
        {
            if (numValConta <= listBDContas.Count - 1)
            {
                return true;
            }
            Console.WriteLine();
            Console.WriteLine("Transação não concluída");
            Console.WriteLine("Conta inexistente");
            return false;
            //Console.WriteLine($"{ValConta} contas existentes");
        }
    }
}
