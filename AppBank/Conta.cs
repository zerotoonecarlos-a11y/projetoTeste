using System.Runtime.CompilerServices;

namespace AppBank;

public class Conta
{
    public int NumeroConta { get; private set; }
    public string NomeTitular { get; set; }
    public double Saldo { get; set; }

    public void Depositar(double valorDeposito)
    {
        Saldo = valorDeposito;
    }

    public void Saque(double valorSaque)
    {
        if (Saldo >= valorSaque)
        {
            Saldo = Saldo - valorSaque;
        }
        else
        {
            Console.WriteLine("Saldo insuficiente!");
        }
    }
}
