using Shared;

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

    if (year % 4 == 0)
    {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
            {
                Console.WriteLine($"El año: {year}, Si {message} biciesto.");
            }
            else
            {
                Console.WriteLine($"El año: {year}, No {message} biciesto.");
            }
        }
        else
        {
            Console.WriteLine($"El año: {year}, Si {message} biciesto.");
        }
    }
    else
    {
        Console.WriteLine($"El año: {year}, No {message} biciesto.");
    }

} while (true);

Console.WriteLine("Game Over.");
