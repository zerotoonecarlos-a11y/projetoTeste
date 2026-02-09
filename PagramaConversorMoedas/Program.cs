using System.Diagnostics.Contracts;
using PagramaConversorMoedas;



Console.Write("Qual é a cotação do dólar: ");
double cotacao = double.Parse(Console.ReadLine());

Console.Write("Quantos dólares você vai comprar: ");
double quantia = double.Parse(Console.ReadLine());

Console.WriteLine("Valor a se pago em reias: " + ConversoMoeda.ValorDaCompra(cotacao, quantia).ToString("F2"));


