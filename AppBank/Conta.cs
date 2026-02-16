using System.Runtime.CompilerServices;

namespace AppBank;

public class ContaBancaria
{
    private decimal TaxaSaque = 5m;
    public int Conta { get; private set; }
    public string Titular { get; set; }
    public decimal Saldo { get; private set; }

    public ContaBancaria(int conta, string titular)
    {
        Conta = conta;
        Titular = titular;
    }

    public ContaBancaria(int conta, string titular, decimal saldo) : this(conta, titular)
    {
        Saldo = saldo;
    }

    public void Depositar(decimal valorDeposito)
    {
        Saldo += valorDeposito;
    }

    public bool Sacar(decimal valorSaque)
    {
        decimal totalDebito = valorSaque + TaxaSaque;

        if (Saldo >= totalDebito)
        {
            Saldo -= totalDebito;
            return true;
        }

        VerificaCoesSistema.VerificacaoDeEntrada();
        Console.WriteLine("Saldo insuficiente!");
        Console.WriteLine();
        return false;
    }

    public override string ToString()
    {
        return $"Numero da conta: {Conta}, Titular da conta: {Titular}, Saldo: {Saldo}";
    }
}
