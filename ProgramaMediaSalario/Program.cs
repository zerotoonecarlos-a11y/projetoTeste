using ProgramaMediaSalario;
using System.Globalization;

namespace ProgramaMeidaSlario
{
    public class Program
    {
        static void Main(String[] args)
        {
            Funcionario f1, f2;

            f1 = new Funcionario();
            f2 = new Funcionario();

            Console.WriteLine("Dados do primeiro funcionario: ");
            Console.Write("Nome: ");
            f1.Nome = Console.ReadLine();

            Console.Write("Salário: ");
            f1.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Dados do segundo funcionario: ");
            Console.Write("Nome: ");
            f2.Nome = Console.ReadLine();

            Console.Write("Salário: ");
            f2.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double media = (f1.Salario + f2.Salario) / 2;

            Console.WriteLine("Salário médio: " + media.ToString("F2", CultureInfo.InvariantCulture));
         }
    }
}