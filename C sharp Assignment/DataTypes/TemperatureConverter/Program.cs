namespace TemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temperature Converter Celsius to Fahrenheit and Kelvin");

            string? input;

            do
            {
                Console.WriteLine("Enter temperature in Celsius or press q to quit:");
                input = Console.ReadLine();

                if (input != null && input.ToLower() == "q")
                {
                    Console.WriteLine("Application shut down, Good bye!");
                    break;
                }

                if (double.TryParse(input, out double celsius))
                {
                    double fahrenheit = TemperatureConverter.CelsiusToFahrenheit(celsius);
                    double kelvins = TemperatureConverter.CelsiusToKelvins(celsius);
                    Console.WriteLine($"{celsius}°C is {fahrenheit}°F");
                    Console.WriteLine($"{celsius}°C is {kelvins}K");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            }while (true);
           
        }
       
    }

    // Creating a static class since the temperature conversion class does not need to maintain any state
    // or instance-specific data.
    public static class TemperatureConverter
    {
        // 1. Implicit Conversion: No data loss, safe conversion, 32 in implicitly converts to 32.0
        // when performing arithmetic between double (Celsius) and int (9 or 5) the integer is implicitly
        // converted to double.
        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        // 2. (double) cast is used to explicitly convert the lower-precision float constant to double
        public static double CelsiusToKelvins(double celsius)
        {
            const float ABSOLUTE_ZERO_DIFFERENCE = 273.15f;
            return celsius + (double)ABSOLUTE_ZERO_DIFFERENCE;
        }
    }
}