namespace GradeConverter
{
    public enum  Subject
    {
        Mathamatics=0,
        Science=1,
        English=2,
        History=3,
        Art= 4
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Student Grading System");
            Console.WriteLine("-----------------------");
            Console.WriteLine("");
           
            bool isValid = true;

            do
            {
                double[] marks = new double[5];
                Console.WriteLine("Enter marks for 5 subjects or type exit to exit:");
                Console.WriteLine("");
                int i = 0;
                do{
                    Console.Write($"Marks (0-100) {((Subject)i).ToString()}: ");
                    string? input = Console.ReadLine();

                    if (input == "exit")
                    {
                        isValid = false;
                        break;
                    }

                    if (double.TryParse(input, out double mark) & mark >= 0 & mark <= 100)
                    {
                        marks[i] = mark;
                    }
                    else
                    {
                        i--;
                        Console.WriteLine("Invalid input. Please enter a valid numeric marks between 0-100");
                        Console.WriteLine("");
                    }                  
                }while(++i < marks.Length);

                double totalMarks = marks.Sum();
                double percentage = (totalMarks / 500) * 100;

                Console.WriteLine($"Total Marks: {totalMarks}");
                Console.WriteLine($"Percentage: {percentage}%");
                Console.WriteLine($"Grade: {ConvertToGrade(percentage)}");
                Console.WriteLine("---------------------------");

            } while (isValid);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static string ConvertToGrade(double percentage)
        {
            if (percentage >= 80)
                return "A";
            else if (percentage >= 70)
                return "B";
            else if (percentage >= 55)
                return "C";
            else if (percentage >= 40)
                return "D";
            else
                return "F";
        }
    }
}