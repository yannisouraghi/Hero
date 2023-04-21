

using Microsoft.EntityFrameworkCore;

namespace Hero.Models
{
    public class HeroContext : DbContext
    {
        public HeroContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER=localhost;DATABASE=Hero;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
