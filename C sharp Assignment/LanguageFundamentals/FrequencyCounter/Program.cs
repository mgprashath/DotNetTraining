namespace FrequancyCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("======== Count Frequency ========");
            Console.WriteLine("");

            Random random = new Random();

            int[] numbers = new int[50];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0,10);
            }

            bool[] visited = new bool[numbers.Length];
            int[] freq = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (visited[i]) continue;
                int count = 1;

                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        visited[j] = true;
                        count++;
                    }
                }
                freq[numbers[i]] = count;
            }

            for (int i = 0; i < freq.Length; i++)
            {
                Console.WriteLine($"Value {i} count:{freq[i]}");
            }

            Console.WriteLine("");
            Console.WriteLine(String.Join(',', numbers));
            Console.ReadLine();

        }
      
    }
}