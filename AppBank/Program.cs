
using System.ComponentModel;

namespace AppBank
{
    class Program
    {
        public static void Main(String[] args)
        {

            Console.Write("Entre o numero da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Entre com o titular da conta: ");
            string nomeTitular = Console.ReadLine();

            Conta conta = new(numeroConta, nomeTitular);

            Console.WriteLine();

            Console.Write("Haverá deposito inicial?(s/n)");
            char opcao = char.Parse(Console.ReadLine().Trim().ToLower());

            double deposito;
            if (opcao == 's')
            {
                Console.Write("Entre o valor do deposito inicial: ");
                deposito = double.Parse(Console.ReadLine());

                conta.Depositar(deposito);
            }

            Console.WriteLine();

            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);

            Console.WriteLine();

            Console.Write("Entre um valor para deposito: ");
            deposito = double.Parse(Console.ReadLine());
            conta.Depositar(deposito);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);

            Console.WriteLine();

            Console.Write("Entre um valor para saque: ");
            double saque = double.Parse(Console.ReadLine());
            conta.Sacar(saque);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);

        }

    }
}
