using System;
namespace Exercicio.Banco.DIO
{
    public class Conta
    {
        
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }

		public Conta(TipoConta tipoConta, string nome, double saldo, double credito) // Método construtor
		{
			this.TipoConta = tipoConta;
            this.Nome = nome;
			this.Saldo = saldo;
			this.Credito = credito;	
		}

        public void listarContas(int conta)
        {   
			double resto = this.Credito + this.Saldo;
            Console.WriteLine($"#{conta} | {this.TipoConta}\t Nome: {this.Nome}\t Saldo: {this.Saldo:C}\t Credito: {this.Credito:C}\t Disponivel {resto:C}");
        }
		
		public bool Sacar(double valorSaque)
		{
            if (valorSaque > (this.Saldo + this.Credito))
			{
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
			else
			{	this.Saldo = this.Saldo - valorSaque;
			    double resto = this.Credito + this.Saldo;

            	Console.WriteLine($"Saldo atual da conta de {this.Nome} é de {this.Saldo:C}, Crédito de {this.Credito:C} e Disponível {resto:C}");
				Console.WriteLine();
            	return true;
			}
		}	
		public void Depositar(double valorDeposito)
        {   
			this.Saldo = this.Saldo + valorDeposito;
			double resto = this.Credito + this.Saldo;
			Console.WriteLine();
			Console.WriteLine($"Saldo atual da conta de {this.Nome} é de {this.Saldo:C}, Crédito de {this.Credito:C} e Disponível {resto:C}");
		}	

		public void Transferir()
        {   
			// Executado na Classe "Program" no método "Transferir"
		}

		
    }
}