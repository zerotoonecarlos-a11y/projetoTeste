namespace PagramaConversorMoedas;

public class ConversoMoeda
{
    public static double Iof = 6.0 / 100;

    public static double ValorDaCompra(double cotacao, double quantia)
    {
        double total = quantia * cotacao;
        return total + (total * Iof);
    }

}
