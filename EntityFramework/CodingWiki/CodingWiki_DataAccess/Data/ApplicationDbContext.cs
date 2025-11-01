using Microsoft.EntityFrameworkCore;
using CodingWiki_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingWiki_Model.Models.FluentModels;
using CodingWiki_Model.Models.FluentConfigModels;
using CodingWiki_DataAccess.FluentConfig;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<FluentBookDetail> FluentBookDetails { get; set; }
        public DbSet<FluentBook> FluentBooks { get; set; }
        public DbSet<FluentAuthor> FluentAuthors { get; set; }
        public DbSet<FluentPublisher> FluentPublishers { get; set; }
        public DbSet<FluentAuthorBook> FluentAuthorBooks { get; set; }

        public DbSet<FluentConfigBookDetail> FluentConfigBookDetails { get; set; }
        public DbSet<FluentConfigBook> FluentConfigBooks { get; set; }
        public DbSet<FluentConfigAuthor> FluentConfigAuthors { get; set; }
        public DbSet<FluentConfigPublisher> FluentConfigPublishers { get; set; }
        public DbSet<FluentConfigAuthorBook> FluentConfigAuthorBooks { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server=DESKTOP-SQ17O6U\\SQLEXPRESS;Database=CodingWiki;User ID=sa;Password=Pra@009;TrustServerCertificate=True;Trusted_Connection=True")
        //    //    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

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

            modelBuilder.Entity<FluentBookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<FluentBookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Entity<FluentBookDetail>().HasKey(u=>u.BookDetail_Id);
            modelBuilder.Entity<FluentBookDetail>().Property(u => u.NumberOfChapters).IsRequired();
            modelBuilder.Entity<FluentBookDetail>().HasOne(u => u.Book).WithOne(u => u.BookDetail)
                .HasForeignKey<FluentBookDetail>(u=>u.BookId);           

            modelBuilder.Entity<FluentBook>().ToTable("Fluent_Book");
            modelBuilder.Entity<FluentBook>().HasKey(u => u.BookId);
            modelBuilder.Entity<FluentBook>().Property(u => u.ISBN).IsRequired();
            modelBuilder.Entity<FluentBook>().Property(u => u.ISBN).HasMaxLength(20);
            modelBuilder.Entity<FluentBook>().Ignore(u => u.PriceRange);
            modelBuilder.Entity<FluentBook>().HasOne(u => u.Publisher).WithMany(u => u.Books)
                .HasForeignKey(u => u.Publisher_Id);

            modelBuilder.Entity<FluentAuthor>().ToTable("Fluent_Authors");
            modelBuilder.Entity<FluentAuthor>().HasKey(u => u.Author_Id);
            modelBuilder.Entity<FluentAuthor>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<FluentAuthor>().Property(u => u.FirstName).HasMaxLength(50);
            modelBuilder.Entity<FluentAuthor>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<FluentAuthor>().Ignore(u => u.FullName);

            modelBuilder.Entity<FluentPublisher>().ToTable("Fluent_Publishers");
            modelBuilder.Entity<FluentPublisher>().HasKey(u => u.Publisher_Id);
            modelBuilder.Entity<FluentPublisher>().Property(u => u.Name).IsRequired();

            modelBuilder.Entity<FluentAuthorBook>().HasKey(u => new { u.Author_Id, u.BookId });
            modelBuilder.Entity<FluentAuthorBook>().HasOne(u => u.Author).WithMany(u => u.FluentAuthorBooks)
                .HasForeignKey(u=>u.Author_Id);
            modelBuilder.Entity<FluentAuthorBook>().HasOne(u => u.Book).WithMany(u => u.FluentAuthorBooks)
                .HasForeignKey(u=>u.BookId);

            modelBuilder.ApplyConfiguration(new FluentConfigAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigBookConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigBookDetailsConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigAuthorBookConfig());
        }
    }
}
