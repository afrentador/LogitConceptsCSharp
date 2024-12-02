using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("***** CÁLCULO DEL NÚMERO");
    var n = ConsoleExtension.GetInt("Cuantos Términos de Precisión Quieres: ");
    var e = CalculateE(n);  
    Console.WriteLine($"El Valor de e con {n} términos de precisión es: {e}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculateE(int n)
{
    double sum = 0;
    for (var i = 0; i < n; i++)
    {
        sum += 1 / MyMath.Factorial(i);
    }
    return sum;
}
