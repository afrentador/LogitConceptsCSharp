﻿using Shared;
using System.Runtime.Intrinsics.Arm;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("**** DATOS DE ENTRADA ****");
    // CC = "Costo de Compra"
    // TP = "Tipo de Producto"
    // TC = "Tipo de Conservacion"
    // PC = "Periodo de Conservacion"
    // PA = "Periodo de Almacenamiento"
    // VOL = "Volumen litros"
    // MA = "Medio de Almacenamiento"

    var CC = ConsoleExtension.GetDecimal("Costo de Comprea ($)..................................................: ");

    var tpOptions = new List<string> { "p", "n" };
    var TP = string.Empty;
    do
    {
        TP = ConsoleExtension.GetValidOptions("Tipo de Producto [P]erecedero, [N]o perecedero........................:", tpOptions);
    }while(!tpOptions.Any(x => x.Equals(TP, StringComparison.CurrentCultureIgnoreCase)));

    var tcOptions = new List<string> { "f", "a" };
    var TC = string.Empty;
    do
    {
        TC = ConsoleExtension.GetValidOptions("Tipo de Conservacion [F]rio, [A]mbient................................:", tcOptions);
    } while (!tcOptions.Any(x => x.Equals(TC, StringComparison.CurrentCultureIgnoreCase)));

    var PC = ConsoleExtension.GetInt("Periodo de Conservacion (disa)........................................: ");
    var PA = ConsoleExtension.GetInt("Periodo de Almacenamiento (disa)......................................: ");
    var VOL = ConsoleExtension.GetInt("Volumen (litros)......................................................: ");

    var maOptions = new List<string> { "n", "c", "e", "g" };
    var MA = string.Empty;
    do
    {
        MA = ConsoleExtension.GetValidOptions("Medio de Almacenamiento [N]evera, [C]ongelador, [E]staneria, [G]uacal.:", maOptions);
    } while (!maOptions.Any(x => x.Equals(MA, StringComparison.CurrentCultureIgnoreCase)));


    Console.WriteLine("**** CALCULOS ****");
    // CA = Costo de Almacenamiento
    //// VR_V = Valor de Venta
    // VR_V = ValorVenta
    // CE = Costo de Exhibición
    // VR_P = Valor de Producto

    var CA = GetCostoDeAlmacenamiento(TP, CC, TC, PC, VOL);
    var PDP = GetPorcentajeDeDepreciacionDelProducto(PA);
    var CE = GetCostodeExhibición(TP, TC, CA, MA);
    var VR_P = GetValorProducto(CC, CA, CE, PDP);
    var VR_V = GetValorVenta(TP, VR_P);

    // Show Results
    Console.WriteLine($"Costo de Almacenamiento.........: {CA,20:C2}");
    Console.WriteLine($"Porcentaje de Depreciciación....:  {PDP,20:P2}");
    Console.WriteLine($"Costo de Exhibición.............: {CE,20:C2}");
    Console.WriteLine($"Valor de Producto...............: {VR_P,20:C2}");
    Console.WriteLine($"Valor de Venta..................: {VR_V,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? ..: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over.");

decimal GetValorVenta(string? TP, decimal VR_P)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        return VR_P * 1.4m;
    }

    return VR_P * 1.2m;

}

decimal GetValorProducto(decimal CC, decimal CA, decimal CE, float PDP)
{
    return (CC + CA + CE) * (decimal)PDP;
}

decimal GetCostodeExhibición(string? TP, string? TC, decimal CA, string? MA)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (TP!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if (MA!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
            {
                return CA * 2;
            }
            
            return CA;
        }
    }

    if (MA!.Equals("e", StringComparison.CurrentCultureIgnoreCase))
    {
        return CA * 0.05m;
    }

    return CA * 0.07m;
}

float GetPorcentajeDeDepreciacionDelProducto(int PA)
{
    if (PA < 30)
    {
        return 0.95f;
    }
    return 0.85f;

}

decimal GetCostoDeAlmacenamiento(string? TP, decimal CC, string? TC, int PC, int VOL)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (TC!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if (PC < 10)
            {
                return CC * 0.05m;
            }

            return CC * 0.1m;
        }

        if (PC < 20)
        {
            return CC * 0.03m;
        }

        if (PC > 20)
        {
            return CC * 0.1m;
        }

        return CC * 0.05m;
    }

    if (VOL >= 50)
    {
        return CC * 0.1m;
    }

    return CC * 0.2m;

}
