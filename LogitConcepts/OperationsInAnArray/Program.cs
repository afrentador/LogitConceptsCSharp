using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data Input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("***** OPERACIONES EN UN ARREGLO *****");
    var n = ConsoleExtension.GetInt("Cuantas Posiciones Quieres En Un Arreglo?: ");
    var numbers = new int[n];

    // Do Process
    FillArray(numbers);

    // Show Results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    ShowArray(numbers);
    Console.WriteLine($"La Sumatoria es: {numbers.Sum(),20:N2}");
    Console.WriteLine($"El Promedio es: {numbers.Average(),20:N2}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

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