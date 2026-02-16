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
        decimal taxaSaque = 5m;

        if (Saldo < valorSaque)
        {
            Console.Clear();
            Console.WriteLine("Saldo insuficiente!");
            return false;
        }

        Saldo -= valorSaque + taxaSaque;
        return true;
    }

    public override string ToString()
    {
        return $"Numero da conta: {Conta}, Titular da conta: {Titular}, " 
             + $"Saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}
