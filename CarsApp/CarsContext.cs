using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarsApp
{
    public class CarsContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Cars;Trusted_Connection=True;");
                        
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=Cars;User Id=SA;Password=P@ssw0rd123;TrustServerCertificate=True");
        }
    }
}
