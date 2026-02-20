using System.Globalization;

namespace AppBank
{
    public class BankApp
    {
        private readonly List<ContaBancaria> _contas = new();

        public void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Bem Vindo ao AppBank ---");
                Console.WriteLine("1 - Criar nova conta");
                Console.WriteLine("2 - Acessar conta existente");
                Console.WriteLine("3 - Listar todas as contas");
                Console.WriteLine("4 - Apagar conta");
                Console.WriteLine("0 - Sair da aplicação");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int opc))
                {
                    switch (opc)
                    {
                        case 1:
                            CriarConta();
                            break;
                        case 2:
                            AcessarConta();
                            break;
                        case 3:
                            ListarContas();
                            break;
                        case 4:
                            ApagarConta();
                            break;
                        case 0:
                            Console.WriteLine("Obrigado por usar o AppBank!");
                            return; // Sai do método Executar e encerra o app
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            Thread.Sleep(1500);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                    Thread.Sleep(1500);
                }
            }
        }

        private void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("--- Criação de Nova Conta ---");

            int numeroConta = LerInteiro("Digite o número da nova conta: ");

            // Verifica se a conta já existe
            if (_contas.Any(c => c.Conta == numeroConta))
            {
                Console.WriteLine("Erro: Já existe uma conta com este número.");
                Thread.Sleep(2000);
                return;
            }

            string titular = LerString("Digite o nome do titular: ");
            char resp = LerChar("Haverá depósito inicial? (s/n): ");

            ContaBancaria novaConta;
            if (resp == 's')
            {
                decimal depositoInicial = LerDecimal("Digite o valor do depósito inicial: ");
                novaConta = new ContaBancaria(numeroConta, titular, depositoInicial);
            }
            else
            {
                novaConta = new ContaBancaria(numeroConta, titular);
            }

            _contas.Add(novaConta);

            Console.WriteLine("\nConta criada com sucesso!");
            Console.WriteLine(novaConta);
            Thread.Sleep(3000);
        }

        private void ApagarConta()
        {
            Console.Clear();
            Console.WriteLine("---Apagar Conta---");
            if (_contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi criada ainda.");
                Thread.Sleep(2000);
                return;
            }

            int numeroConta = LerInteiro("Digite o número da conta que deseja apagar: ");

            ContaBancaria? conta = _contas.FirstOrDefault(c => c.Conta == numeroConta);

            if (conta == null) Console.WriteLine("Conta não encontrada");

            _contas.Remove(conta);
            Console.WriteLine("Conta removida com sucesso");
            Thread.Sleep(2000);
        }

        private void AcessarConta()
        {
            Console.Clear();
            Console.WriteLine("--- Acessar Conta ---");
            if (_contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi criada ainda.");
                Thread.Sleep(2000);
                return;
            }

            int numeroConta = LerInteiro("Digite o número da conta que deseja acessar: ");
            ContaBancaria? conta = _contas.FirstOrDefault(c => c.Conta == numeroConta);

            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
                Thread.Sleep(2000);
                return;
            }

            MenuTransacoes(conta);
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("--- Lista de Contas ---");

            if (_contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }
            else
            {
                foreach (var conta in _contas)
                {
                    Console.WriteLine(conta);
                    Console.WriteLine("---------------------");
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void MenuTransacoes(ContaBancaria conta)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--- Operações na Conta: {conta.Conta} | Titular: {conta.Titular} ---");
                Console.WriteLine($"Saldo atual: {conta.Saldo.ToString("C2", CultureInfo.CurrentCulture)}");
                Console.WriteLine("\n1 - Realizar Depósito");
                Console.WriteLine("2 - Realizar Saque");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int opc))
                {
                    switch (opc)
                    {
                        case 1:
                            decimal valorDeposito = LerDecimal("Digite o valor para depósito: ");
                            conta.Depositar(valorDeposito);
                            Console.WriteLine("Depósito realizado com sucesso!");
                            Thread.Sleep(1500);
                            break;
                        case 2:
                            decimal valorSaque = LerDecimal("Digite o valor para saque (taxa de R$ 5,00): ");
                            try
                            {
                                conta.Sacar(valorSaque);
                                Console.WriteLine("Saque realizado com sucesso!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Erro ao sacar: {ex.Message}");
                            }
                            Thread.Sleep(2000);
                            break;
                        case 0:
                            return; // Volta ao menu principal
                        default:
                            Console.WriteLine("Opção inválida.");
                            Thread.Sleep(1500);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                    Thread.Sleep(1500);
                }
            }
        }

        private int LerInteiro(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0) return valor;

                Console.WriteLine("Entrada inválida. O valor precisa ser um número inteiro positivo.");
                Thread.Sleep(1500);
            }
        }

        private decimal LerDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal valor) && valor > 0)
                    return valor;

                Console.WriteLine("Entrada inválida. O valor precisa ser um número positivo.");
                Thread.Sleep(1500);
            }
        }

        private string LerString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada.Trim();

                Console.WriteLine("Entrada inválida. O campo não pode ser vazio.");
                Thread.Sleep(1500);
            }

        }

        private char LerChar(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? entrada = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    char c = char.ToLower(entrada.Trim()[0]);
                    if (c == 's' || c == 'n')
                        return c;

                    Console.WriteLine("Resposta inválida. Digite 's' para sim ou 'n' para não.");
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
