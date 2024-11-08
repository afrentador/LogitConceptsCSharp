var numberString = string.Empty;

do
{
    Console.Write("Ingrese un número entero, o la palabra 'S' para salir: ");
    numberString = Console.ReadLine();

    if (numberString!.ToLower() == "s")
    {
        continue;
    }

    var numberInt = 0;
    if (int.TryParse(numberString, out numberInt))
    {
        if (numberInt % 2 == 0)
        {
            Console.WriteLine($"El número {numberInt}, es par.");
        }
        else
        {
            Console.WriteLine($"El número {numberInt}, es impar.");
        }
    }
    else
    {
        Console.WriteLine($"Lo que ingresaste: {numberString}, no es un número entero.");
    }
} while (numberString!.ToLower() != "s");
Console.WriteLine("Game Over.");
