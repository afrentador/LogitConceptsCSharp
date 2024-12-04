﻿using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data Input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("***** PARES E INPARES EN UN ARREGLO *****");
    var n = ConsoleExtension.GetInt("Cuantas Posiciones Quieres En Un Arreglo?: ");
    var numbers = new int[n];

    // Do Process
    FillArray(numbers);
    var sum = GetSumEven(numbers);
    var prod = GetProdEven(numbers);

    // Show Results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    ShowArray(numbers);
    Console.WriteLine($"La Sumatoria es: {sum,20:N0}");
    Console.WriteLine($"La Productoria es: {prod,20:N0}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetProdEven(int[] numbers)
{
    double prod = 1;
    foreach (int number in numbers)
    {
        if (number % 2 != 0)
        {
            prod *= number;
        }
    }
    return prod;
}

int GetSumEven(int[] numbers)
{
    var sum = 0;
    foreach (int number in numbers)
    {
        if (number % 2 == 0)
        {
            sum += number;
        }
    }
    return sum;
}

void ShowArray(int[] numbers)
{
    foreach (int number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}

void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(0, 100);
    }
}