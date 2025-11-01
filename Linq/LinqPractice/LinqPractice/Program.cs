
using LinqPractice;

string sentence = "I love cats";
string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
int[] numbers = {5,6,3,2,1,5,6,7,8,4,234,54,14,653,3,4,5,6,7};


IEnumerable<int> nums = from i in numbers where i<5 select i;

foreach (var item in nums)
{
    //Console.WriteLine(item);
}

var catsWithA = from str in catNames where str.Contains("a") && str.Length < 5 select str;

foreach (var item in catsWithA)
{
    //Console.WriteLine(item);
}

var numsBetFiveAndTen = from num in numbers 
                        where num >5
                        where num <10
                        orderby num descending
                        select num;

foreach (var item in numsBetFiveAndTen)
{
    //Console.WriteLine(item);
}



List<Person> people = new List<Person>
{
    new Person("Alvin", 180, 75, Gender.Male),
    new Person("Randini", 165, 60, Gender.Female),
    new Person("Sarath", 170, 70, Gender.Male),
    new Person("Ranmini", 160, 55, Gender.Female)
};

var AllMales = from p in people
               where p.Gender == Gender.Male
               select p;

foreach (var item in AllMales)
{
    //Console.WriteLine(item.Name);
}

var peopleWithFourCaracterNames = from p in people
                                  where p.Name.Length == 4
                                  orderby p.Weight descending
                                  select p;

foreach (var item in peopleWithFourCaracterNames)
{
    //Console.WriteLine($"Name {item.Name} and Weight {item.Weight}");
}

var extractOnlyNames = from p in people
                       orderby p.Name, p.Height descending
                       select p.Name;

foreach (var item in extractOnlyNames)
{
    //Console.WriteLine(item);
}

var orderPeople = from p in people
                  orderby p.Name, p.Height descending
                  select p;

foreach (var item in orderPeople)
{
    Console.WriteLine($"Name {item.Name} and Weight {item.Weight}");
}

Console.ReadLine();