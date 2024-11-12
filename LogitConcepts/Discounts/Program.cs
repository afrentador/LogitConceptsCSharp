using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var desks = ConsoleExtension.GetInt("Ingrese Número de Escritorios: ");
    float discount;
    if (desks < 5)
    {
        discount = 0.1f;
    }
    else if (desks < 10)
    {
        discount = 0.2f;
    }
    else
    {
        discount = 0.3f;
    }

    var valueToPay = desks * 650000M;
    Console.WriteLine($"El valor a pagar es: {valueToPay:C2}");

    var valueToDiscount = desks * 650000M * (decimal)(1 - discount);
    Console.WriteLine($"El valor total a pagar es: {valueToDiscount:C2}");    

    var totalDiscount = valueToDiscount - (desks * 650000M);
    Console.WriteLine($"Descuento generado: {totalDiscount:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");
