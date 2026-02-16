using System.Globalization;
using System.IO.Pipes;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;

namespace ExemploMembrosStaticos
{
    class Program
    {
        static double Pi = Math.PI;
        public static void Main(string[] args)
        {
            Console.WriteLine("Entre com o valor do raio: ");
            double raio = double.Parse(Console.ReadLine());

            double circ = Circunferencia(raio);
            double volu = Volume(raio);

            Console.WriteLine("Circuferência: " 
                              + circ.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine("Volume: " 
                              + volu.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine("Valor de PI: " + Pi);
 
        }

        static double Circunferencia(double r)
        {
            return 2 * Pi * r;
        }

        static double Volume(double r)
        {
            return 4.0 / 3.0 * Pi * r * r * r;
        }
    }
}