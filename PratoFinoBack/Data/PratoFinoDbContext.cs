using Microsoft.EntityFrameworkCore;
using PratoFinoBack.Models;

namespace PratoFinoBack.Data
{
    public class PratoFinoDbContext : DbContext
    {
        public PratoFinoDbContext(DbContextOptions<PratoFinoDbContext> options)
        :base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }

    }
}