using System.Globalization;
using System.Runtime.CompilerServices;

namespace AppBank;

public class ContaBancaria
{
    public int Conta { get; private set; }
    public string Titular { get; set; }
    public decimal Saldo { get; private set; }

    public ContaBancaria(int conta, string titular)
    {
        Conta = conta;
        Titular = titular;
    }

    public ContaBancaria(int conta, string titular, decimal depositoInicial) : this(conta, titular)
    {
        Depositar(depositoInicial);
    }

    public void Depositar(decimal valorDeposito)
    {
        Saldo += valorDeposito;
    }

    public void Sacar(decimal valorSaque)
    {
        decimal taxaSaque = 5m;

        if (Saldo < valorSaque + taxaSaque)
        {
            throw new InvalidOperationException("Saldo insuficiente!");
        }

        Saldo -= valorSaque + taxaSaque;
    }

    public override string ToString()
    {
        return $"Numero da conta: {Conta}, Titular da conta: {Titular}, " 
             + $"Saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}
