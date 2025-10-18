using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Employee>  Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SQ17O6U\\SQLEXPRESS;Database=HNB;User ID=sa;Password=Pra@009;TrustServerCertificate=True;Trusted_Connection=True");
        }
    }
}
