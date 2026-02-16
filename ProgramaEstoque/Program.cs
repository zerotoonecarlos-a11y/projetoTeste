namespace ProgramaEstoque
{
    class Program
    {
        public static void Main(String[] args)
        {
            

            Console.WriteLine("Entre com os dados do produto: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());


            Produto prod = new(nome, preco, quantidade);


            Console.WriteLine($"Dados do prdouto: {prod}");

            Console.WriteLine();
            Console.Write("Digite o numero de produtos a ser adicionado no estoque: ");
            int qte = int.Parse(Console.ReadLine());
            prod.AdicionarQuantidadeProduto(qte);

            Console.WriteLine($"Dados do prdouto: {prod}");

            Console.WriteLine();
            Console.Write("Digite o numero de produtos a ser removido do estoque: ");
            qte = int.Parse(Console.ReadLine());
            prod.RemoverQuantidadeProduto(qte);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados do prdouto: {prod}");
        }
    }
}