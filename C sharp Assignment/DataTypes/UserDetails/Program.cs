namespace UserDetails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User user = new User(30, 5.9, 160.5m, MaritalStatus.Married);

            Console.WriteLine("-------------------");
            Console.WriteLine("User Information:");
            Console.WriteLine("-------------------");

            Console.WriteLine($"Age:            {user.age}");
            Console.WriteLine($"Height:         {user.height}");
            Console.WriteLine($"Weight:         {user.weight}");
            Console.WriteLine($"Marital Status: {user.MaritalStatus}");

            Console.WriteLine("-------------------");
            Console.ReadLine();

        }
    }

}


