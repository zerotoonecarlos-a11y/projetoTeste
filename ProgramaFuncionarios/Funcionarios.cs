using System.Globalization;

namespace ProgramaFuncionarios;

public class Funcionarios
{
    public string Nome;
    public double SalarioBruto, Imposto;

    public double SalarioLiquido()
    {
        return SalarioBruto - Imposto;
    }

    public double AlmentarSalario(double porcentagem)
    {
        SalarioBruto += SalarioBruto * (porcentagem / 100.00);
        return SalarioLiquido();

    }

    public override string ToString()
    {
        return Nome + ", "
              + "$ " 
              + SalarioLiquido().ToString("F2", CultureInfo.InstalledUICulture);
    }
}
