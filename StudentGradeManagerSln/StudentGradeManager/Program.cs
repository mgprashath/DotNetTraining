// See https://aka.ms/new-console-template for more information
using StudentGradeManager;
using System.Xml.Linq;


Console.WriteLine("Student Grade Management System");
Console.WriteLine("-------------------------------");
Console.WriteLine();

List<Student> students = new List<Student>() {
    new Student("Prasad","Math",Grade.Fail),
    new Student("Karthik","Physice",Grade.Pass),
    new Student("Mahela","Biology",Grade.Pass),
    new Student("Ramanan","Chemistry",Grade.Pass)
};

WriteToFile(students);

ReadFromFile();

Console.ReadLine();


static void WriteToFile(List<Student> student)
{
    string currentDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
    string path = Path.Combine(currentDir, "Files\\People.txt");

    FileInfo fileInfo = new FileInfo(path);

    if (!File.Exists(path))
    {
        fileInfo.Create().Close();
    }
    else
    {
        using (FileStream fs = fileInfo.Open(FileMode.Truncate))
        {
            Console.WriteLine("====== All data cleared ======");
        }
    }

    using (StreamWriter str = fileInfo.AppendText())
    {
        foreach (var item in student)
        {
            str.WriteLine($"ID: {item.Id}");
            str.WriteLine($"Name: {item.Name}");
            str.WriteLine($"Course: {item.Course}");
            str.WriteLine($"Grade: {item.Grade}");
            str.WriteLine();
            str.WriteLine("++++++++++");
            str.WriteLine();
        }
    }
}

static void ReadFromFile()
{
    string currentDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
    string path = Path.Combine(currentDir, "Files\\People.txt");

    Console.WriteLine();
    Console.WriteLine("====== File contents are ======");
    Console.WriteLine();

    string[] fileContent = File.ReadAllLines(path);

    foreach (var item in fileContent)
    {
        Console.WriteLine(item);
    }
}
public enum Grade
{
    Pass = 1,
    Fail = 2
}
