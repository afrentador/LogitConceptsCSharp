using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data Input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("***** OPERACIONES EN UN ARREGLO *****");
    var n = ConsoleExtension.GetInt("Cuantas Posiciones Quieres En Un Arreglo?: ");
    var numbers = new int[n];

    // Do Process
    FillArray(numbers);

    // Show Results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine("Arreglo Sin Ordenar =>");
    ShowArray(numbers);
    Console.WriteLine();

    var numbersEven = GetNumbersEven(numbers);
    var numbersOdd = GetNumbersOdd(numbers);
    OrderArray(numbersEven, true);
    OrderArray(numbersOdd);

    Console.WriteLine("Arreglo Ordenado =>");
    ShowArray(numbersEven);
    ShowArray(numbersOdd);
    Console.WriteLine();

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

int[] GetNumbersOdd(int[] numbers)
{
    var contOdd = 0;
    foreach (var number in numbers)
    {
        if (!IsEven(number))
        {
            contOdd++;
        }
    }

    var numbersOdd = new int[contOdd];
    var i = 0;
    foreach (var number in numbers)
    {
        if (!IsEven(number))
        {
            numbersOdd[i] = number;
            i++;
        }
    }

    return numbersOdd;
}

int[] GetNumbersEven(int[] numbers)
{
    var contEevens = 0;
    foreach (var number in numbers)
    {
        if (IsEven(number))
        {
            contEevens++;
        }
    }

    var numbersEeven = new int[contEevens];
    var i = 0;
    foreach (var number in numbers)
    {
        if (IsEven(number))
        {
            numbersEeven[i] = number;
            i++;
        }
    }

    return numbersEeven;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

void OrderArray(int[] numbers, bool isDescending = false)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        for (int j = i+ 1; j < numbers.Length; j++)
        {
            if (isDescending)
            {
                if (numbers[i] < numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }
            else
            {
                if (numbers[i] > numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }
        }
    }
}

void Change(ref int number1, ref int number2)
{
    int aux = number1;
    number1 = number2;
    number2 = aux;
}

void ShowArray(int[] numbers)
{
    foreach (int number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
}

void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(0, 100);
    }
}