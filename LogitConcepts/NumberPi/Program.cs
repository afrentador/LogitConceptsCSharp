using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data Input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("***** CÁLCULO DEL NÚMERO 'Pi' *****");
    var n = ConsoleExtension.GetInt("Cuantos Términos de Precisión Quieres: ");

    // Do Process
    var pi = CalculatePi(n);

    // Show Results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($"El Valor de 'Pi' con: {n} términos de precisión es: {pi}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculatePi(int n)
{
    double sum = 0;
    double den = 1;
    int sig = 1;
    for (int i = 0; i < n; i++)
    {
        double ter = 1 / den * sig;
        sum += ter;
        den += 2;
        sig *= -1;
    }
    return sum * 4;
}
  