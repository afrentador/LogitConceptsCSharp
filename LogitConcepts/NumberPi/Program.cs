using Shared;

internal class Program
{
    private static void Main(string[] args)
    {
        var answer = string.Empty;
        var options = new List<string> { "s", "n" };

        do
        {
            Console.WriteLine("***** CÁLCULO DEL NÚMERO 'Pi' *****");
            var n = ConsoleExtension.GetInt("Cuantos Términos de Precisión Quieres: ");
            var pi = CalculatePi(n);
            Console.WriteLine($"El Valor de 'Pi' con: {n} términos de precisión es: {pi}");

            do
            {
                answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o? : ", options);
                Console.WriteLine();
            } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

        } while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

        double CalculatePi(int n)
        {
            double sum = 0;
            double den = 1;
            int sig = 1;
            for (int i = 0; i < n; i++)
            {
                double ter = 1 / den * sig;
                sum += ter;
                den += 2;
                sig *= -1;
            }
            return sum * 4;
        }
    }
}