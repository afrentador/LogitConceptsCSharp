using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var name = ConsoleExtension.GetString("Ingrese Nombre..........................: ");
    var workHours = ConsoleExtension.GetFloat("Ingrese Número de horas trabajadas......: ");
    var hourvalue = ConsoleExtension.GetDecimal("Ingrese Valor hora......................: ");
    var salaryMinimun = ConsoleExtension.GetDecimal("Ingrese Valor del Salario Minimo mensual: ");

    var salary = (decimal) workHours * hourvalue;
    if (salary < salaryMinimun)
    {
        Console.WriteLine($"Nombre..................................: {name}.");
        Console.WriteLine($"Salario.................................:  {salaryMinimun:C2}.");
    }
    else
    {
        Console.WriteLine($"Nombre..................................: {name}.");
        Console.WriteLine($"Salario.................................: {salary:C2}.");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");
