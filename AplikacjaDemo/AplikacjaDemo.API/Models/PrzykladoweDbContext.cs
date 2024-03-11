using Microsoft.EntityFrameworkCore;

namespace AplikacjaDemo.API.Models
{
    public class PrzykladoweDbContext : DbContext
    {
        public PrzykladoweDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<PrzykladowyModel> Przykladowy { get; set; }

    }
}
