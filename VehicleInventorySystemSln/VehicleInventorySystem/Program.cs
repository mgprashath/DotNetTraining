using VehicleInventorySystem;

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Toyota", "Corolla", 2020, 4),
                new Truck("Suzuki", "Wagon R", 2018, 20.5),
                new MotorBike("Honda", "CRV", 2022, false)
            };

        string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        string fileFolder = Path.Combine(projectRoot, "Files");
        Directory.CreateDirectory(fileFolder);
        string filePath = Path.Combine(fileFolder, "vehicles.txt");

        // Write and read
        WriteVehicles(vehicles, filePath);
        ReadVehicles(filePath);

        Console.WriteLine($"Data saved in: {filePath}");
    }

    static void WriteVehicles(List<Vehicle> vehicles, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath, false))
        {
            sw.WriteLine("=== Vehicle Inventory ===");
            foreach (var v in vehicles)
            {
                sw.WriteLine(v.DisplayInfo());
            }
        }
        Console.WriteLine("Vehicles written to file.");
    }

    static void ReadVehicles(string filePath)
    {
        Console.WriteLine("Reading Vehicles from File");
        foreach (var line in File.ReadAllLines(filePath))
        {
            Console.WriteLine(line);
        }
    }
}
