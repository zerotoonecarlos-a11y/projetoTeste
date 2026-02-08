using ProgramaFuncionarios;


Funcionarios f = new();

Console.Write("Nome: ");
f.Nome = Console.ReadLine();

Console.Write("Salario Bruto: ");
f.SalarioBruto = double.Parse(Console.ReadLine());

Console.Write("Imposto: ");
f.Imposto = double.Parse(Console.ReadLine());

Console.WriteLine("Funcionarios: " + f);

Console.Write("Digite a porcentagem para aumentar o salário: ");
double por = double.Parse(Console.ReadLine());
f.AlmentarSalario(por);

Console.WriteLine("Dados atualizados: " + f);