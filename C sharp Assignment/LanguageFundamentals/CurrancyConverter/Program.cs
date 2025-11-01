namespace CurrancyConverter
{   using System.Globalization;
    class Program
    {
        static void Main(string[] args)
        {
           const decimal inrToUsdRate = 0.012m;
           const decimal inrToEurRate = 0.010m;
           const decimal inrTojpyRate = 1.62m;

           Console.WriteLine("Welcome to the Currency Converter!");
           Console.Write("Enter amount in INR: ");
           Console.WriteLine("=================================");

            string? input;

            while (true)
            {
                Console.Write("INR ");
                input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal amount))
                {
                    decimal usdAmount = amount * inrToUsdRate;
                    decimal eurAmount = amount * inrToEurRate;
                    decimal jpyAmount = amount * inrTojpyRate;

                    Console.OutputEncoding = System.Text.Encoding.UTF8;

                    Console.WriteLine($"USD: {usdAmount.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
                    Console.WriteLine($"EUR: {eurAmount.ToString("C", CultureInfo.GetCultureInfo("fr-FR"))}");
                    Console.WriteLine($"JPY: {jpyAmount.ToString("C", CultureInfo.GetCultureInfo("ja-JP"))}");

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric amount");
                }
               
            }

            Console.WriteLine("Thank you for using the Currency Converter!");
            Console.WriteLine("=================================");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }   
    }
}