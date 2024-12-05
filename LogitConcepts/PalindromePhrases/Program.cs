using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data Input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("***** FRASES PALÍNDROMAS *****");
    var phrase = ConsoleExtension.GetString("Ingresa Palabra o Frase?: ");
   
    // Do Process
    var isPalindrome = IsPalindrome(phrase);

    // Show Results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($" La Palabra o Frase '{phrase}' {(isPalindrome ? "Si" : "No")} es Palíndromo.");
   
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

bool IsPalindrome(string? phrase)
{
    phrase = PreparePharase(phrase);
    var n = phrase.Length;
    for (var i = 0; i < phrase!.Length / 2; i++)
    {
        if (phrase[i] != phrase[n - i - 1])
        {
            return false;
        }
    }
    return true;
}

string? PreparePharase(string? phrase)
{
    phrase = phrase!.ToLower();
    var newPhrase = string.Empty;
    var expetion = new List<char> { ' ',',','.',':','-','?','¿','¡','!',';','´'};
    
    foreach (var character in phrase)
    {
        if (!expetion.Contains(character))
        {
            if (character == 'á') newPhrase += 'a';
            else if (character == 'é') newPhrase += 'e';
            else if (character == 'í') newPhrase += 'i';
            else if (character == 'ó') newPhrase += 'o';
            else if (character == 'ú') newPhrase += 'u';
            else newPhrase += character;
        }
    }
    return newPhrase;
}