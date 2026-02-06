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

    public void AdicionarQuantidadeProduto()
    {
        Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
        int quantidadeProduto = int.Parse(Console.ReadLine());
        Quantidade += quantidadeProduto;
        AnimarCarregamento();
        Console.Clear();
        Console.WriteLine($"Dados atualizados: {Nome}, ${Preco}, " +
                         $" {Quantidade} unidades, Total: " + ValorTotalEmEstoque().ToString("F2"));

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

    public void RemoverQuantidadeProduto()
    {
        Console.Write("Digite o número de produtos a ser removido do estoque: ");
        int quantidade = int.Parse(Console.ReadLine());
        Quantidade -= quantidade;
        AnimarCarregamento();
        Console.Clear();
        Console.WriteLine($"Dados atualizados: {Nome}, ${Preco}, " +
                          $"{Quantidade} unidades, Total: " + ValorTotalEmEstoque().ToString("F2"));
    }
}
