using System.Globalization;
using System.Transactions;

namespace projetoRetangulo
{
    class Program
    {
        public static void Main(String[] args)
        {
            Retangulo r = new();

            Console.WriteLine("Entre com a altura e a largura do retângulo: ");
            r.Altura = double.Parse(Console.ReadLine());
            r.Largura = double.Parse(Console.ReadLine());

            Console.WriteLine("Area = " + r.Area().ToString("F2", CultureInfo.InstalledUICulture));
            Console.WriteLine();
            Console.WriteLine("Perímetro = " + r.Perimetro().ToString("F2", CultureInfo.InstalledUICulture));
            Console.WriteLine();
            Console.WriteLine("Diagonal = " + r.Diagonal().ToString("F2", CultureInfo.InstalledUICulture));


        } 
    }
}