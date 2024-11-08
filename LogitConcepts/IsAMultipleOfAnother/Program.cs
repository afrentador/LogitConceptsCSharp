using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetInt("Ingrese el Primer Número: ");
    var b = ConsoleExtension.GetInt("Ingrese el Segundo Número: ");
  

    if (b % a == 0)
    {
        Console.WriteLine($"{a} es múltiplo de {b}.");
    }    
    else
    {
        Console.WriteLine($"{a} no es múltiplo de {b}.");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");

