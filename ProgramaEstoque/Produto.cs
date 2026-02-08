using System.Globalization;
using System.Threading;

namespace ProgramaEstoque;

public class Produto
{
    public string Nome;
    public double Preco;
    public int Quantidade;
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
