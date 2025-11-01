// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

//GetAllBooks();
//AddBooks();
//GetAllBooks();
//GetFirstBookWhere();
//GetBookFind(5);
//GetBookEFFunctionLike();
//GetBookOrderBy();
//GetBookOrderByWithWhere();
//GetBookSkipAndTake();
//SetUpdateAll();

//DeleteBook();


//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books;

//    foreach (var item in books)
//    {
//        Console.WriteLine($"Title: {item.Title} - ISBN: {item.ISBN}");
//    }
//}

//void AddBooks()
//{
//    using var context = new ApplicationDbContext();
//    Book book = new() { Title="This is a Google book", ISBN="DD4568", Price=250.50m, Publisher_Id=2  };

//    context.Books.Add(book);
//    context.SaveChanges();
//}

//void GetFirst()
//{
//    using var context = new ApplicationDbContext();

//    var book = context.Books.FirstOrDefault(u=>u.Publisher_Id==2 && u.Price > 125.00m);

//    Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//}

//void GetFirstBookWhere()
//{
//    using var context = new ApplicationDbContext();

//    var books = context.Books.Where(u => u.Publisher_Id == 2 && u.Price > 125.00m);

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }
//}

//void GetFirstBook()
//{
//    using var context = new ApplicationDbContext();

//    var books = context.Books.Where(u => u.Publisher_Id == 2 && u.Price > 125.00m);

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }
//}

//void GetBookFind(int id)
//{
//    using var context = new ApplicationDbContext();

//    var book = context.Books.Find(id);

//    Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//}

//void GetBookContains()
//{
//    using var context= new ApplicationDbContext();
//    var books = context.Books.Where(u => u.ISBN.Contains("DD"));

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }
//}

//void GetBookEFFunctionLike()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.Where(u => EF.Functions.Like(u.ISBN,"%5"));

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }
//}

//void GetBookOrderBy()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.OrderBy(x => x.Title).ThenByDescending(u=>u.ISBN);

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }
//}

//void GetBookOrderByWithWhere()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.Where(u=>u.Price > 100.00m).OrderBy(u=>u.ISBN).ThenByDescending(u=>u.Title);

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }
//}

//// Pagination

//void GetBookSkipAndTake()
//{
//    using var context = new ApplicationDbContext();

//    var books = context.Books.Skip(0).Take(2);

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }

//    books = context.Books.Skip(4).Take(1);

//    foreach (var book in books)
//    {
//        Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Price = {book.Price}");
//    }

//}

//void SetUpdate()
//{
//    using var context = new ApplicationDbContext();

//    var book = context.Books.Find(3);

//    book.Price = 175.00m;
//    book.ISBN = "EFF121";

//    context.SaveChanges();
//}

//void SetUpdateAll()
//{
//    using var context = new ApplicationDbContext();

//    var books = context.Books;

//    foreach (var book in books)
//    {
//        book.Price = 95.00m;
//    }

//    context.SaveChanges();
//}

//void DeleteBook()
//{
//    using var context = new ApplicationDbContext();
//    var book = context.Books.Find(3);

//    context.Books.Remove(book);
//    context.SaveChanges();
//}

//Console.ReadLine();
    