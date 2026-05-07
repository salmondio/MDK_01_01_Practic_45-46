using Microsoft.EntityFrameworkCore;
using Practic_45.Models;

namespace Practic_45.Contexts
{
    public class DishContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DishContext()
        {
            Database.EnsureCreated();
            Dishes.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.0.201.112;Trusted_Connection=False;Database=base1_ISP_23_2_8;User=ISP_23_2_8;Pwd=egW19je7D1_;Encrypt=false;");
        }
    }
}
