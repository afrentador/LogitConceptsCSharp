using Shared;

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

} while (true);

Console.WriteLine("Game Over.");
