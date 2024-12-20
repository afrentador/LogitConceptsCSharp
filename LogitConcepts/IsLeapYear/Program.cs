﻿using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var currenYear = DateTime.Now.Year;
    var message = string.Empty;
    var year = ConsoleExtension.GetInt("Ingrese año: ");

    if (year == currenYear)
    {
        message = "es";
    }
    else if(year > currenYear)
    {
        message = "va a ser";
    }
    else
    {
        message = "fue";
    }

    var isLeapYear = DateUtilities.IsleapYear(year);
    Console.WriteLine($"El año: {year}, {(isLeapYear ? "SI" : "NO")} {message} biciesto.");


    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");
