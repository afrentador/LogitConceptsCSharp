using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var routeOptions = new List<string> { "1", "2", "3", "4" };
    var route = string.Empty;
    do
    {
        route = ConsoleExtension.GetValidOptions("Ruta [1][2][3][4]...............................:", routeOptions);
    } while (!routeOptions.Any(x => x == route));

    var trips = ConsoleExtension.GetInt("Número de viajes................................: ");
    var passangers = ConsoleExtension.GetInt("Número de pasajeros total.......................: ");
    var packages10 = ConsoleExtension.GetInt("Número de encomiendas de menos de 10Kg..........: ");
    var packages10_20 = ConsoleExtension.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg: ");
    var packages20 = ConsoleExtension.GetInt("Número de encomiendas de más de 20Kg............: ");

    //Callculations
    var inconePassager = GetInconePassager(route, passangers, trips);
    var inconePackages = GetInconePacKages(route, packages10, packages10_20, packages20);
    var incones = inconePassager + inconePackages;
    var valueHelper = GetValueHelper(incones);
    var valueAssurrce = GetValueAssurrace(incones);
    var fuelValue = GetFuelValue(route, trips, passangers, packages10, packages10_20, packages20);
    var deductions = valueHelper + valueAssurrce + fuelValue;
    var totalToPay = incones - deductions;

    Console.WriteLine("*** CLACULOS ***");
    Console.WriteLine($"Ingresos por Pasajeros.........................: {inconePassager,20:c2}");
    Console.WriteLine($"Ingresos por Encomiendas.......................: {inconePackages,20:c2}");
    Console.WriteLine($"                                                 ---------------------");
    Console.WriteLine($"TOTAL INGRESOS.................................: {incones,20:c2}");
    Console.WriteLine($"Pago Ayudante..................................: {valueHelper,20:c2}");
    Console.WriteLine($"Pago Seguro....................................: {valueAssurrce,20:c2}");
    Console.WriteLine($"Pago Combustible...............................: {fuelValue,20:c2}");
    Console.WriteLine($"                                                 ---------------------");
    Console.WriteLine($"TOTAL DEDUCCIONES..............................: {deductions,20:c2}");
    Console.WriteLine($"                                                 =====================");
    Console.WriteLine($"TOTAL A LIQUIDAR...............................: {totalToPay,20:c2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over.");

decimal GetFuelValue(string? route, int trips, int passangers, int packages10, int packages10_20, int packages20)
{
    float kms;
    switch (route)
    {
        case "1":
            kms = 150 * trips;
            break;
        case "2":
            kms = 167 * trips;
            break;
        case "3":
            kms = 184 * trips;
            break;
        default:
            kms = 203 * trips;
            break;
    }

    var gallon = kms / 39;
    var value = (decimal)gallon * 8860m;
    var weigth = passangers * 60 + packages10 * 10 + packages10_20 * 15 + packages20 * 20;
    if (weigth < 5000) return value;
    if (weigth <= 10000) return value * 1.1m;
    return value * 1.25m;
}

decimal GetValueAssurrace(decimal incones)
{
    if (incones < 1000000) return incones * 0.03m;
    if (incones < 2000000) return incones * 0.04m;
    if (incones < 4000000) return incones * 0.06m;
    return incones * 0.09m;
}

decimal GetValueHelper(decimal incones)
{
    if (incones < 1000000) return incones * 0.05m;
    if (incones < 2000000) return incones * 0.08m;
    if (incones < 4000000) return incones * 0.1m;
    return incones * 0.13m;
}

decimal GetInconePacKages(string? route, int packages10, int packages10_20, int packages20)
{
    decimal value = 0; 
    switch (route)
    {
        case "1":
        case "2":
            if (packages10 < 50) value += packages10 * 100;
            else if (packages10 <= 100) value += packages10 * 120;
            else if (packages10 <= 130) value += packages10 * 150;
            else value += packages10 * 160;

            var packagesGreather10 = packages10_20 + packages20;
            if (packagesGreather10 < 50) value += packagesGreather10 * 120;
            else if (packagesGreather10 <= 100) value += packagesGreather10 * 140;
            else if (packagesGreather10 <= 130) value += packagesGreather10 * 160;
            else value += packagesGreather10 * 180;

            return value;

        default:
            if (packages10 < 50) value += packages10 * 130;
            else if (packages10 <= 100) value += packages10 * 160;
            else if (packages10 <= 130) value += packages10 * 175;
            else value += packages10 * 200;

            if (packages10_20 < 50) value += packages10_20 * 140;
            else if (packages10_20 <= 100) value += packages10_20 * 180;
            else if (packages10_20 <= 130) value += packages10_20 * 200;
            else value += packages10_20 * 250;

            if (packages20 < 50) value += packages20 * 170;
            else if (packages20 <= 100) value += packages20 * 210;
            else if (packages20 <= 130) value += packages20 * 250;
            else value += packages20 * 300;

            return value;
    }
}

decimal GetInconePassager(string? route, int passangers, int trips)
{
    decimal value;
    switch (route)
    {
        case "1":
            value = 500000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value *1.05m;
            if (passangers <= 150) return value *1.06m;
            if (passangers <= 200) return value * 1.07m;
            return value * 1.07m + (passangers - 200) * 50m;
        case "2":
            value = 600000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value * 1.07m;
            if (passangers <= 150) return value * 1.08m;
            if (passangers <= 200) return value * 1.09m;
            return value * 1.09m + (passangers - 200) * 60m;
        case "3":
            value = 800000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value * 1.1m;
            if (passangers <= 150) return value * 1.13m;
            if (passangers <= 200) return value * 1.15m;
            return value * 1.15m + (passangers - 200) * 100m; ;
        default:
            value = 1000000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value * 1.125m;
            if (passangers <= 150) return value * 1.15m;
            if (passangers <= 200) return value * 1.17m;
            return value * 1.17m + (passangers - 200) * 150m;
    }
}

