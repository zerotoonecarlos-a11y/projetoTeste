using System.Security.Cryptography.X509Certificates;

namespace AppBank;

public static class Start
{
    public static ContaBancaria contaBanco;
    public static bool MenuInicial()
    {


        Console.WriteLine("Seja Bem Vindo!");

        while (true)
        {
            Console.WriteLine("1 - para entrar na conta ");
            Console.WriteLine("2 - para criar uma conta ");
            Console.WriteLine("0 - para sair");


            if (int.TryParse(Console.ReadLine(), out int opc))
            {

                switch (opc)
                {
                    case 1:
                        //Ainda não foi totalmente implementado
                        Console.WriteLine("Esta parte do projeto ainda não esta pronta.");
                        break;

                    case 2:
                        int conta = LerInteiro("Entre o numero da conta: ");
                        string titular = LerString("Entre o titular da conta: ");

                        char resp = LerChar("Haverá deposito inicial?(s/n) ");

                        if (resp == 's')
                        {
                            decimal depositoInicial = LerDecimal("Entre o valor deposito inicial: ");
                            contaBanco = new(conta, titular, depositoInicial);
                        }
                        else
                        {
                            contaBanco = new(conta, titular);
                        }

                        Console.WriteLine("Dados da conta:");
                        Console.WriteLine(contaBanco);
                        Thread.Sleep(3000);

                        MenuDepositoSaque();
                        break;
                }
            }
            return false;
        }
    }

    public static void MenuDepositoSaque()
    {
        Console.WriteLine("1 - para fazer um deposito");
        Console.WriteLine("2 - para fazer um saque");
        Console.WriteLine("0 - para sair");

        if (int.TryParse(Console.ReadLine(), out int opc))
        {
            switch (opc)
            {
                case 1:
                    decimal deposito = LerDecimal("Entre um valor para deposito: ");
                    contaBanco.Depositar(deposito);
                    Thread.Sleep(3000);

                    Console.WriteLine("Dados da conta atualizados: ");
                    Console.WriteLine(contaBanco);
                    Thread.Sleep(3000);
                    break;

                case 2:
                    decimal saque = Start.LerDecimal("Entre um valor para saque: ");
                    Start.contaBanco.Sacar(saque);
                    Thread.Sleep(3000);

                    Console.WriteLine("Dados da conta atualizados: ");
                    Console.WriteLine(Start.contaBanco);
                    break;
                case 0: 
                    System.Environment.Exit(0);
                    break;
            }

        }

    }
    public static int LerInteiro(string prompt)
    {
        while (true)
        {
            Console.Clear();
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0) return valor;

            Console.WriteLine("O valor precisa ser maior que 0!");
            Thread.Sleep(1500);
        }
    }

    public static decimal LerDecimal(string prompt)
    {
        while (true)
        {
            Console.Clear();
            Console.Write(prompt);

            if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
                return valor;

            Console.WriteLine("O valor precisa ser maior que 0.");
            Thread.Sleep(1500);
        }
    }

    private static string LerString(string prompt)
    {
        while (true)
        {
            Console.Clear();
            Console.Write(prompt);
            string? entrada = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entrada))
                return entrada.Trim().ToLower();

            Console.WriteLine("Entrada invalida.");
            Thread.Sleep(1500);
        }

    }

    private static char LerChar(string prompt)
    {
        while (true)
        {
            Console.Clear();
            Console.Write(prompt);
            string? entrada = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entrada))
            {
                char c = char.ToLower(entrada.Trim()[0]);
                if (c == 's' || c == 'n')
                    return c;

                Console.WriteLine("Digite 's' para sim e 'n' para não");
                Thread.Sleep(1500);
            }
        }
    }

}

