using Microsoft.EntityFrameworkCore;

namespace ChildhoodHeroAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }
        public DbSet<ChildhoodHero> ChildhoodHeroes { get; set; }
    }
}
