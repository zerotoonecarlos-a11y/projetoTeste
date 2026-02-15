using System.Runtime.CompilerServices;

namespace AppBank;

public class Conta
{
    public int NumeroConta { get; private set; }
    public string NomeTitular { get; set; }
    public double Saldo { get; set; }

    public Conta(int numeroConta, string nomeTitular)
    {
        NumeroConta = numeroConta;
        NomeTitular = nomeTitular;
    }

    public void Depositar(double valorDeposito)
    {
        Saldo += valorDeposito;
    }

    public void Sacar(double valorSaque)
    {
        if (Saldo >= valorSaque)
        {
            Saldo = Saldo - valorSaque;
            Saldo = Saldo - 5;
        }
        else
        {
            Console.WriteLine("Saldo insuficiente!");
        }
    }

    public override string ToString()
    {
        return $"Numero conta: {NumeroConta}, Titular conta: {NomeTitular}, Saldo: {Saldo}";
    }
}
