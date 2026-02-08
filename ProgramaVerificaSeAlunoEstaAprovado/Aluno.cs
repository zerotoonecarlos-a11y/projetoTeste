namespace ProgramaVerificaSeAlunoEstaAprovado;

public class Aluno
{
    public string Nome;
    public double NotaPriTri, NotaSegTri, NotaTerTri;

    public double SomarNotas()
    {
        return NotaPriTri + NotaSegTri + NotaTerTri;
    }

    public  double VerificarNota(double nota)
    {
        return (60 - nota);
    }

}
