using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{

    Console.WriteLine("Ingrese '3' números diferentes.");
    var a = ConsoleExtension.GetInt("Ingrese el Primer Número: ");
    var b = ConsoleExtension.GetInt("Ingrese el Segundo Número: ");
    var c = ConsoleExtension.GetInt("Ingrese el Tercer Número: ");

    if (a > b && a > c)
    {
        Console.WriteLine($"El número mayor es {a}.");
    }
    else if (b > a && b > c)
    {
        Console.WriteLine($"El número mayor es {b}.");
    }
    else
    {
        Console.WriteLine($"El número mayor es {c}.");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");
