namespace DataAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<double> salesFigures = new List<double>();

            string? input;

            Console.WriteLine("=== Simple Data Analyzer ===");
            Console.WriteLine("");
            Console.WriteLine("Enter sales figures (type 'done' to finish):");

            while (true)
            {
                input = Console.ReadLine();
                if (input?.ToLower() == "done")
                {
                    if (salesFigures.Any())
                    {
                        double average = salesFigures.Average();
                        double max = salesFigures.Max();
                        double min = salesFigures.Min();

                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("======= Sales Summary: =======");
                        Console.WriteLine("");
                        Console.WriteLine($"\nAverage Sales: {average}");
                        Console.WriteLine($"Maximum Sales: {max}");
                        Console.WriteLine($"Minimum Sales: {min}");
                        Console.WriteLine("");
                        Console.WriteLine("-------------------------------");
                    }
                    break;
                }
                if (double.TryParse(input, out double figure))
                {
                    salesFigures.Add(figure);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value or 'done' to finish.");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}