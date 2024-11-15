using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Ingrese Número: ");
    var factorial = MyMath.Factorial(n);

    Console.WriteLine($"{n}! = {factorial:N0}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");
