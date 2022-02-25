using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context database tabloları ile proje classlarına bağlamak için vardır.
    public class UserContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=BurganUser;Username=postgres;Password=lamal159***");
        }
        public DbSet<User> User { get; set; }
    }
}
