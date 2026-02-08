using System.Globalization;
using ProgramaVerificaSeAlunoEstaAprovado;

Aluno a = new();


Console.Write("Digite o nome do aluno: ");
a.Nome = Console.ReadLine();
Console.WriteLine("Digite as três notas do aluno: ");
a.NotaPriTri = double.Parse(Console.ReadLine());
a.NotaSegTri = double.Parse(Console.ReadLine());
a.NotaTerTri = double.Parse(Console.ReadLine());


double notaAluno = a.SomarNotas();

if (notaAluno <= 60)
{
    Console.WriteLine("Nota Final: " + notaAluno);
    Console.WriteLine("REPROVADO");
    double resultado = a.VerificarNota(notaAluno);
    Console.WriteLine("FALTAM " + resultado.ToString("F2") + " Pontos");
}
else
{
    Console.WriteLine("Nota Final: " + notaAluno);
    Console.WriteLine("Aprovado");
}