using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tournament.DAL.Entities;

namespace Tournament.DAL.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<TournamentOfSpanish> TournamentsOfSpanish { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var _connectionString = connection.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
