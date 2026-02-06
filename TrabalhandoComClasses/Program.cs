using System.Globalization;

namespace TrabalhandoComClasses
{
    class Program
    {
        public static void Main(String[] args)
        {
            Triangulo y = new();
            Triangulo x = new();

            Console.WriteLine("Entre com as medidas para o triangulo Y");
            y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Entre com as medidas para o triangulo X");
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

           double areaX = x.Area();
           double areaY = y.Area();

            Console.WriteLine("Area do triangulo X: " + areaX.ToString("F4", CultureInfo.InvariantCulture));
            Console.WriteLine("Area do triangulo Y: " + areaY.ToString("F4", CultureInfo.InvariantCulture));

            if (areaX > areaY)
            {
                Console.WriteLine("Maior área: X");
            }
            else
            {
                Console.WriteLine("Maior área: Y");
            }
        }
    }
}
