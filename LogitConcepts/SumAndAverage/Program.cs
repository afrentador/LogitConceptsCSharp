using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Cuantos Números desea: ");
    int sum = 0;
    int i = 1;
    while (i <= n)
    {
        Console.Write($"{i}\t");
        sum += i;
        i++;
    }

    //Ciclo FOR
    /*
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{i}\t");
        sum += i;
    }
    */
    var average = sum / n;
    Console.WriteLine();
    Console.WriteLine($"La Suma es....: {sum,20:N0}");
    Console.WriteLine($"El Promedio es: {average,20:N0}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");
