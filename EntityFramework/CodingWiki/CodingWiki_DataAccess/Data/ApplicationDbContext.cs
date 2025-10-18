using Microsoft.EntityFrameworkCore;
using CodingWiki_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }

        DbSet<Publisher> Publishers { get; set; }

        DbSet<Author> Authors { get; set; }

        DbSet<SubCategory> SubCategories { get; set; }

        DbSet<BookDetail> BookDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SQ17O6U\\SQLEXPRESS;Database=CodingWiki;User ID=sa;Password=Pra@009;TrustServerCertificate=True;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10,5);
            modelBuilder.Entity<AuthorBook>().HasKey(u => new { u.Author_Id, u.BookId });

            modelBuilder.Entity<Book>().HasData(
                new Book() { BookId=1, ISBN="ASD123444", Price=50.50m, Title="Generics", Publisher_Id=1  },
                new Book() { BookId=2, ISBN="BGG9005", Price=100.00m, Title="Advance C sharp", Publisher_Id=2}
            );

            List<Book> books = new List<Book>() {
                new Book() { BookId=3, ISBN="GOOGLE", Price=150.50m, Title="Google", Publisher_Id=3  },
                new Book() { BookId=4, ISBN="FFF4590", Price=50.00m, Title="Basic C sharp" , Publisher_Id = 2},
                new Book() { BookId=5, ISBN="AAA5555", Price=75.00m, Title="Intermediate C sharp", Publisher_Id = 1}
            };

            modelBuilder.Entity<Book>().HasData(books);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher() { Publisher_Id=1, Name="ORellay", Location="Newyork" },
                new Publisher() { Publisher_Id=2, Name="Simons", Location="London" },
                new Publisher() { Publisher_Id=3, Name="Gunasena", Location="Colombo"}
                );
        }
    }
}
