using Shared;

do
{

    Console.WriteLine("Ingrese '3' números diferentes...");
    var a = ConsoleExtension.GetInt("Ingrese el Primer Número : ");
    var b = ConsoleExtension.GetInt("Ingrese el Segundo Número: ");
    if (a == b)
    {
        Console.WriteLine("Deben ser diferentes, vuelva a empezar...");
        continue;

    }
    var c = ConsoleExtension.GetInt("Ingrese el Tercer Número : ");
    if (b == c || c == a)
    {
        Console.WriteLine("Deben ser diferentes, vuelva a empezar...");
        continue;

    }

    if (a > b && a > c)
    {
        if (b > c)
        {
            Console.WriteLine($"El número mayor es {a}, el del medio es {b} y el menor es {c}.");
        }
        else
        {
            Console.WriteLine($"El número mayor es {a}, el del medio es {c} y el menor es {c}.");

        }
    }
    else if (b > a && b > c)
    {
        if (a > c)
        {
            Console.WriteLine($"El número mayor es {b}, el del medio es {a} y el menor es {c}.");
        }
        else
        {
            Console.WriteLine($"El número mayor es {b}, el del medio es {c} y el menor es {a}.");

        }
    }
    else
    {
        if (a > b)
        {
            Console.WriteLine($"El número mayor es {c}, el del medio es {a} y el menor es {b}.");
        }
        else
        {
            Console.WriteLine($"El número mayor es {c}, el del medio es {b} y el menor es {a}.");

        }
    }

} while (true);

Console.WriteLine("Game Over.");
