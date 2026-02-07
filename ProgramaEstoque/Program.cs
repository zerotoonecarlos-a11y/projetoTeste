namespace ProgramaEstoque
{
    class Program
    {
        public static void Main(String[] args)
        {
            Produto prod = new();

            Console.WriteLine("Entre com os dados do produto: ");
            Console.Write("Nome: ");
            prod.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            prod.Preco = double.Parse(Console.ReadLine());
            Console.Write("Quantidade em estoque: ");
            prod.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine($"Dados do prdouto: {prod}");

            Console.WriteLine();
            Console.Write("Digite o numero de produtos a ser adicionado: ");
            int qte = int.Parse(Console.ReadLine());
            prod.AdicionarQuantidadeProduto(qte);

            Console.WriteLine($"Dados do prdouto: {prod}");

            Console.WriteLine();
            Console.Write("Digite o numero de produtos a ser removido: ");
            qte = int.Parse(Console.ReadLine());
            prod.RemoverQuantidadeProduto(qte);

            Console.WriteLine($"Dados do prdouto: {prod}");
        }
    }
}