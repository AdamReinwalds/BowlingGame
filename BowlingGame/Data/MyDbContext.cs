using Microsoft.EntityFrameworkCore;


namespace BowlingGame.data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BowlingGame3;Integrated Security=SSPI;TrustServerCertificate=True;");
        }
    }
}
