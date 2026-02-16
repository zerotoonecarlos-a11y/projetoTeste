using System.Globalization;
using System.Threading;

namespace ProgramaEstoque;

public class Produto
{
    string Nome;
    double Preco;
    int Quantidade;

    public Produto(string nome, double preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = 0;
    }
    public double ValorTotalEmEstoque()
    {
        return Preco * Quantidade;
    }
    public void AdicionarQuantidadeProduto(int quantidade)
    {
        Quantidade += quantidade;
    }

    private static void AnimarCarregamento()
    {
        Console.Write("Processando... ");
        string animacao = "|/-\\";
        for (int i = 0; i < 20; i++)
        {
            Console.Write(animacao[i % 4]);
            Thread.Sleep(100);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    public void RemoverQuantidadeProduto(int quantidade)
    {
        Quantidade -= quantidade;
    }

    public override string ToString()
    {
        return Nome + ", "
              + "$ "
              + Preco + ", "
              + Quantidade + " unidades, "
              + "Total: $ " + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
    }
}
