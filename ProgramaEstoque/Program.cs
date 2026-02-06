namespace ProgramaEstoque
{
    class Program
    {
        public static void Main(String[] args)
        {   Produto prod = new();

            Console.WriteLine("Entre com os dados do produto: ");
            Console.Write("Nome: ");
            prod.Nome = Console.ReadLine();

            Console.Write("Preço: ");
            prod.Preco = double.Parse(Console.ReadLine());

            Console.Write("Quantidade em estoque: ");
            prod.Quantidade = int.Parse(Console.ReadLine());

            double total = prod.ValorTotalEmEstoque();
            Console.WriteLine($"Dados do prdouto: {prod.Nome}, ${prod.Preco}, {prod.Quantidade} unidades, Total: {total.ToString("F2")} ");
     
            prod.AdicionarQuantidadeProduto();

            prod.RemoverQuantidadeProduto();

        }
    }
}