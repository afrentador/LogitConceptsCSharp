using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var credits = ConsoleExtension.GetInt("Número de Creditos......: ");
    var creditValue = ConsoleExtension.GetDecimal("Valor Credito...........: ");
    var stratum = ConsoleExtension.GetInt("Estrato del estudiante..: ");

    var registrationValue = CalculateRegistrationValue(credits, creditValue, stratum);
    var sudsidy = CalculateSudsidy(stratum);

    Console.WriteLine($"Costo de la Matricula...: {registrationValue,20:C2}");
    Console.WriteLine($"Valor del Subcidio......:{sudsidy,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");

decimal CalculateSudsidy(int stratum)
{
    if (stratum == 1)
    {
        return 200000m;
    }
    if (stratum == 2)
    {
        return 100000m;
    }
    return 0;
}

decimal CalculateRegistrationValue(int credits, decimal creditValue, int stratum)
{
    decimal value;
    if (credits <= 20)
    {
        value = credits * creditValue;
    }
    else
    {
        value = 20 * creditValue + (credits - 20) * creditValue * 2;
    }

    if (stratum == 1)
    {
        return value * 0.2m;
    }
    if (stratum == 2)
    {
        return value * 0.5m;
    }
    if (stratum == 3)
    {
        return value * 0.7m;
    }

    return value;
}

