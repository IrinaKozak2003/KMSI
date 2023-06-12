// See https://aka.ms/new-console-template for more information

using lab3;


Console.WriteLine("Hello, World!");
Console.WriteLine("НОД(499,531): "+Operations.EuclideanAlgorithm(499,531));
Console.WriteLine("НОД(56,200): "+Operations.EuclideanAlgorithm(56,200));
Console.WriteLine("НОД(21,43, 342): "+Operations.EuclideanAlgorithm(24,48, 64));

Console.WriteLine("Все простые числа от 499 до 539: ");
foreach (int i in Operations.SieveOfEratosthenes(499, 531))
{
    Console.WriteLine(i+'\n');
}
Console.WriteLine("Все простые числа от 2 до 499: ");
foreach (int i in Operations.SieveOfEratosthenes(2, 499))
{
    Console.WriteLine(i+'\n');
}

