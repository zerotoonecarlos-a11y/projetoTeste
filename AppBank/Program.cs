
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace AppBank
{
    class Program
    {
        public static void Main(String[] args)
        {
            ContaBancaria contaBanco;

            Console.Write("Entre o numero da conta: ");
            int conta = int.Parse(Console.ReadLine());

            while (conta <= 0)
            {
                Console.Clear();
                Console.Write("Digite novamente: ");
                conta = int.Parse(Console.ReadLine());
            }

            Console.Write("Entre com o titular da conta: ");
            string titular = Console.ReadLine();


            while (string.IsNullOrEmpty(titular))
            {
                VerificaCoesSistema.VerificacaoDeEntrada();

                Console.Clear();
                Console.Write("Digite novamente: ");
                titular = Console.ReadLine();

            }

            Console.WriteLine();

            Console.Write("Haverá deposito inicial?(s/n)");
            char resp = char.Parse(Console.ReadLine().Trim().ToLower());


            if (resp == 's')
            {
                Console.Write("Entre o valor do deposito inicial: ");
                decimal saldo = decimal.Parse(Console.ReadLine());

                contaBanco = new ContaBancaria(conta, titular, saldo);
            }
            else
            {
                contaBanco = new ContaBancaria(conta, titular);

            }


            Console.WriteLine();

            Console.WriteLine("Dados da conta:");
            Console.WriteLine(contaBanco);

            Console.WriteLine();

            Console.Write("Entre um valor para deposito: ");
            decimal deposito = decimal.Parse(Console.ReadLine());
            contaBanco.Depositar(deposito);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(contaBanco);

            Console.WriteLine();

            Console.Write("Entre um valor para saque: ");
            decimal saque = decimal.Parse(Console.ReadLine());
            contaBanco.Sacar(saque);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(contaBanco);

        }

    }
}
