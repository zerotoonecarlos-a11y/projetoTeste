
using System.ComponentModel;

namespace AppBank
{
    class Program
    {
        public static void Main(String[] args)
        {
           
            Conta conta = new();
            

            Console.Write("Entre o numero da conta: ");
            conta.NumeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o titular da conta: ");
            conta.NomeTitular = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Haverá deposito inicial?(s/n)");
            char opcao = Console.ReadLine().Trim().ToLower();

            if(opcao == "s")
            {   Console.WriteLine("Entre o valor do deposito inicial: ");
                double deposito = double.Parse(Console.ReadLine());
                conta.Depositar(deposito);
            }
            
        }
    }
}
