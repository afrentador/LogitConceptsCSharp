using Shared;

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

} while (true);

Console.WriteLine("Game Over.");
