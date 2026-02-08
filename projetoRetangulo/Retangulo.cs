namespace projetoRetangulo;

public class Retangulo
{
   public  double Largura, Altura;

    public double Area()
    {
        return Largura * Altura;
    }

    public double Perimetro()
    {
        return 2 * (Altura + Largura);
    }

    public double Diagonal()
    {
        return Math.Sqrt(Math.Pow(Altura, 2) + Math.Pow(Largura, 2));
    }

}
